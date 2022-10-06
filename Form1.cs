using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceRecognitionMain
{
    public partial class Form1 : Form
    {
        #region Variables

        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        private bool facesDetectionEnabled = false;

        CascadeClassifier faceCasacdeClassifier =
            new CascadeClassifier(Directory.GetCurrentDirectory() + @"\haarcascade_frontalface_alt.xml");

        Image<Bgr, Byte> faceResult = null;
        Mat frame = new Mat();
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }
    }
}