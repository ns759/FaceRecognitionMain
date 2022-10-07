using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using static System.Windows.Forms.PictureBoxSizeMode;

namespace FaceRecognitionMain
{
    public partial class Form1 : Form
    {
        #region Variables

        private readonly Capture _videoCapture;
        private Image<Bgr, byte> _currentFrame;
        private bool _enableSaveImage;
        private bool _enableRecognition;
        private bool _isTrained;
        private static readonly string Cascade = Directory.GetCurrentDirectory() + @"\haarcascade_frontalface_alt.xml";
        private readonly string _path = Directory.GetCurrentDirectory() + @"\TrainedImages";
        private readonly CascadeClassifier _faceCascadeClassifier = new CascadeClassifier(Cascade);
        private readonly List<Image<Gray, byte>> _trainedFaces = new List<Image<Gray, byte>>();
        private readonly List<int> _personsLabels = new List<int>();
        private readonly List<string> _personsNames = new List<string>();
        private EigenFaceRecognizer _recognizer;
        private readonly Mat _frame = new Mat();

        #endregion

        public Form1()
        {
            InitializeComponent();
            _videoCapture = new Capture();
            Application.Idle += ProcessFrame;
            TrainImagesFromDir();
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private void ProcessFrame(object sender, EventArgs e)
        {
            if ( /*_videoCapture != null &&*/ _videoCapture.Ptr != IntPtr.Zero)
            {
                _videoCapture.Retrieve(_frame);
                _currentFrame = _frame.ToImage<Bgr, byte>()
                    .Resize(pictureBoxMain.Width, pictureBoxMain.Height, Inter.Cubic);

                var grayImage = new Mat();
                CvInvoke.CvtColor(_currentFrame, grayImage, ColorConversion.Bgr2Gray);
                //Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                var faces = _faceCascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                //If faces detected
                if (faces.Length > 0)
                {
                    foreach (var face in faces)
                    {
                        //Drawing square around each face 
                        CvInvoke.Rectangle(_currentFrame, face, new Bgr(Color.Yellow).MCvScalar, 2);

                        //Assign the face to the pictureBoxDetected
                        var resultImage = _currentFrame.Convert<Bgr, byte>();
                        resultImage.ROI = face;
                        pictureBoxDetected.SizeMode = StretchImage;
                        pictureBoxDetected.Image = resultImage.Bitmap;

                        //Adding new person
                        if (_enableSaveImage)
                        {
                            //Searching for or creating a directory for the trained images
                            if (!Directory.Exists(_path))
                                Directory.CreateDirectory(_path);
                            Task.Factory.StartNew(() =>
                            {
                                //Resizing and saving 10 images to the directory
                                for (var i = 0; i < 10; i++)
                                {
                                    resultImage.Resize(200, 200, Inter.Cubic).Save(_path + @"\" + txtPersonName.Text +
                                        "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                    Thread.Sleep(1000);
                                }
                            });
                            _enableSaveImage = false;
                        }


                        if (btnSave.InvokeRequired)
                        {
                            btnSave.Invoke(new ThreadStart(delegate { btnSave.Enabled = true; }));
                        }


                        if (_isTrained && _enableRecognition)
                        {
                            var grayFaceResult = resultImage.Convert<Gray, byte>().Resize(200, 200, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = _recognizer.Predict(grayFaceResult);
                            pictureBox1.Image = grayFaceResult.Bitmap;
                            pictureBox2.Image = _trainedFaces[result.Label].Bitmap;
                            //Here results found known faces
                            if (result.Label != -1 && result.Distance < 2000)
                            {
                                CvInvoke.PutText(_currentFrame, _personsNames[result.Label],
                                    new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Green).MCvScalar);
                                CvInvoke.Rectangle(_currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                btnSave.Enabled = false;
                            }
                            //here results did not find any know faces
                            else
                            {
                                CvInvoke.PutText(_currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Red).MCvScalar);
                                CvInvoke.Rectangle(_currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                                btnSave.Enabled = true;
                            }
                        }
                    }
                }

                pictureBoxMain.Image = _currentFrame.Bitmap;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _enableSaveImage = true;
        }

        private void TrainImagesFromDir()
        {
            var imagesCount = 0;
            double threshold = 2000;
            _trainedFaces.Clear();
            _personsLabels.Clear();
            _personsNames.Clear();
            try
            {
                //string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                var files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\TrainedImages", "*.jpg",
                    SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    var trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    _trainedFaces.Add(trainedImage);
                    _personsLabels.Add(imagesCount);
                    var name = file.Split('\\').Last().Split('_')[0];
                    _personsNames.Add(name);
                    imagesCount++;
                }

                if (_trainedFaces.Any())
                {
                    _recognizer = new EigenFaceRecognizer(imagesCount, threshold);
                    _recognizer.Train(_trainedFaces.ToArray(), _personsLabels.ToArray());

                    _isTrained = true;
                }
                else
                {
                    _isTrained = false;
                }
            }
            catch (Exception ex)
            {
                _isTrained = false;
                MessageBox.Show(@"Error in Train Images: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _enableRecognition = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _enableRecognition = false;
            txtPersonName.Text = "";
            txtPersonName.Enabled = true;
            btnSave.Enabled = true;
        }
    }
}