using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;

namespace OOp_Project
{
    public partial class MainFOrm : Form
    {
        FilterInfoCollection webcams;
        VideoCaptureDevice cam;
        RGB Rgb_obj = new RGB();
        Gray gray_obj = new Gray();
        Bitmap video1,video2,grayScale_Image;
        int minR = 150,maxR = 255,minG = 0,maxG = 75,minB = 0,maxB = 75;  

        
        public MainFOrm()
        {
            InitializeComponent();
        }

        private void MainFOrm_Load(object sender, EventArgs e)
        {
                              

            try
            {
                webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                foreach (FilterInfo webcam in webcams)
                {
                    comboBox1.Items.Add(webcam.Name);
                }

                comboBox1.SelectedIndex = 0;
                cam = new VideoCaptureDevice();
            }
            catch
            {
                Error obj = new Error();
                obj.ShowDialog();
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cam = new VideoCaptureDevice(webcams[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);

            cam.Start();
        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
             video1 = (Bitmap)eventArgs.Frame.Clone();
             video2 = (Bitmap)eventArgs.Frame.Clone();
             bool isChecked = radioButton1.Checked;
             if (isChecked)
             {

                 trackBar3.Enabled = true;
                 trackBar4.Enabled = true;
                 trackBar5.Enabled = true;
                 trackBar6.Enabled = true;
                 trackBar7.Enabled = true;
                 trackBar8.Enabled = true;
                 Rgb_obj.ApplyRGB(video2, minR, maxR, minG, maxG, minB, maxB); // Apply Rgb Filter
             }
             else
             {
                 FACE_DECTECTION.Face_Detection(video2); // Apply Face detection filter
             }
                 
            grayScale_Image = gray_obj.Apply_grayscale(video2); // Apply GrayScale Filter
            Blob_Detection.blob_setter(video1 ,grayScale_Image, 10, 10);

            pictureBox1.Image = video2;
            pictureBox2.Image = video1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning == true)
            {
                cam.Stop();
                pictureBox2.Image = null;
                pictureBox1.Image = null;
            }
        }

        private void MainFOrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cam.IsRunning == true)
            {
                cam.Stop();
                pictureBox2.Image = null;
                pictureBox1.Image = null;
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            bool isChecked = radioButton1.Checked;
            if (!isChecked)
            { trackBar3.Enabled = false; }
            else
            {
                trackBar3.Minimum = 0;
                trackBar3.Maximum = 255;
                minR = trackBar3.Value;
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            bool isChecked = radioButton1.Checked;
            if (!isChecked)
            { trackBar4.Enabled = false; }
            else
            {
                trackBar4.Minimum = 0;
                trackBar4.Maximum = 255;
                maxR = trackBar4.Value;
            }
        }
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            bool isChecked = radioButton1.Checked;
            if (!isChecked)
            { trackBar5.Enabled = false; }
            else
            {
                trackBar5.Minimum = 0;
    
                trackBar5.Maximum = 255;
                minG = trackBar5.Value;
            }
        }
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            bool isChecked = radioButton1.Checked;
            if (!isChecked)
            { trackBar6.Enabled = false; }
            else
            {
                trackBar6.Maximum = 255;
                trackBar6.Minimum = 0;
                
                maxG = trackBar6.Value;

            }
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            bool isChecked = radioButton1.Checked;
            if (!isChecked)
            { trackBar8.Enabled = false; }
            else
            {
                trackBar8.Minimum = 0;
                
                trackBar8.Maximum = 255;
                minB = trackBar8.Value;
            }
        }
        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            bool isChecked = radioButton1.Checked;
            if (!isChecked)
            { trackBar7.Enabled = false; }
            else
            {
                trackBar7.Maximum = 255;
                trackBar7.Minimum = 0;
                
                maxB = trackBar7.Value;
            }
        }

    }
}
