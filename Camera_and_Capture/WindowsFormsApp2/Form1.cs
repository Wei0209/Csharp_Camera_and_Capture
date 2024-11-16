using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Text;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private VideoCaptureDevice videoCapture;
        FilterInfoCollection filterInfo;

        private void button1_Click(object sender, EventArgs e)
        {
            startCamera();
        }

        private void startCamera()
        {
            try
            {
                filterInfo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videoCapture = new VideoCaptureDevice(filterInfo[0].MonikerString);
                videoCapture.NewFrame += new NewFrameEventHandler(Camera_on);
                videoCapture.Start();
            }
            catch(Exception e)
            {

            }
        
        }
        private void Camera_on(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            // filename location
            string filename = @"C:\Users\rvl224\source\repos\Camera_and_Capture\image\" + textBox1.Text + ".jpg";
            var bitmap = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.DrawToBitmap(bitmap, pictureBox2.ClientRectangle);

            System.Drawing.Imaging.ImageFormat imageFormat = null;

            imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            // save image

            bitmap.Save(filename);

        }
    }
}
