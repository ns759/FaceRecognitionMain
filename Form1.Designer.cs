namespace FaceRecognitionMain
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.pictureBoxDetected = new System.Windows.Forms.PictureBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnSavePerson = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnStartRec = new System.Windows.Forms.Button();
            this.btnStopRec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(629, 520);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            // 
            // pictureBoxDetected
            // 
            this.pictureBoxDetected.Location = new System.Drawing.Point(660, 12);
            this.pictureBoxDetected.Name = "pictureBoxDetected";
            this.pictureBoxDetected.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxDetected.TabIndex = 1;
            this.pictureBoxDetected.TabStop = false;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(866, 12);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(280, 26);
            this.txtPersonName.TabIndex = 2;
            // 
            // btnSavePerson
            // 
            this.btnSavePerson.Location = new System.Drawing.Point(866, 44);
            this.btnSavePerson.Name = "btnSavePerson";
            this.btnSavePerson.Size = new System.Drawing.Size(280, 60);
            this.btnSavePerson.TabIndex = 3;
            this.btnSavePerson.Text = "Save person";
            this.btnSavePerson.UseVisualStyleBackColor = true;
            this.btnSavePerson.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(660, 282);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(916, 282);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 250);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // btnStartRec
            // 
            this.btnStartRec.Location = new System.Drawing.Point(660, 234);
            this.btnStartRec.Name = "btnStartRec";
            this.btnStartRec.Size = new System.Drawing.Size(250, 42);
            this.btnStartRec.TabIndex = 6;
            this.btnStartRec.Text = "Start recognition";
            this.btnStartRec.UseVisualStyleBackColor = true;
            this.btnStartRec.Click += new System.EventHandler(this.btnStartRec_Click);
            // 
            // btnStopRec
            // 
            this.btnStopRec.Location = new System.Drawing.Point(916, 234);
            this.btnStopRec.Name = "btnStopRec";
            this.btnStopRec.Size = new System.Drawing.Size(250, 42);
            this.btnStopRec.TabIndex = 7;
            this.btnStopRec.Text = "Stop recognition";
            this.btnStopRec.UseVisualStyleBackColor = true;
            this.btnStopRec.Click += new System.EventHandler(this.btnStopRec_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 544);
            this.Controls.Add(this.btnStopRec);
            this.Controls.Add(this.btnStartRec);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSavePerson);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.pictureBoxDetected);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnStartRec;
        private System.Windows.Forms.Button btnStopRec;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnSavePerson;

        private System.Windows.Forms.PictureBox pictureBoxDetected;

        private System.Windows.Forms.PictureBox pictureBoxMain;

        #endregion
    }
}