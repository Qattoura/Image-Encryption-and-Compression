using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ImageEncryptCompress
{
    public partial class MainForm : Form
    {
        string pf;
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix;

        string seedd;
        int tapp;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                pf =OpenedFilePath;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            double sigma = double.Parse(txtGaussSigma.Text);
            int maskSize = (int)nudMaskSize.Value ;
            ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Tap_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Encode_Button_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            String Seed = Seed_Box.Text;
            int tap = int.Parse(Tap_Box.Text);
            ImageMatrix = ImageOperations.binEncoding(ImageMatrix, Seed, tap,true);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            double ts = Stopwatch.Elapsed.TotalSeconds;
            textBox2.Text = ts.ToString().Substring(0, 3);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }

            Stopwatch.Reset();
        }

        private void Seed_Box_TextChanged(object sender, EventArgs e)
        {
           /* TextBox textBox = (TextBox)sender;

            if (textBox.Text.Length > 4)
            {
                textBox.Text = textBox.Text.Substring(0, 4);
                textBox.Select(4, 0); 
            }*/
        }

        private void txtGaussSigma_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void decode_btn_Click(object sender, EventArgs e)
        {

            BinaryConvertForEncode bc = ImageOperations.loadImage();


            seedd = bc.seed;

            tapp = bc.tap;
            ImageMatrix = ImageOperations.OpenImage(pf);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void decode_image_btn_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            String Seed = seedd;
            int tap = tapp;

            ImageMatrix = ImageOperations.binEncoding(ImageMatrix, seedd, tapp, false);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            double ts = Stopwatch.Elapsed.TotalSeconds;
            textBox2.Text = ts.ToString().Substring(0, 5);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }

            Stopwatch.Reset();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            String Seed = Seed_Box.Text;
            int tap = int.Parse(Tap_Box.Text);
            ImageMatrix = ImageOperations.alphaEncode(ImageMatrix, Seed, tap, true);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            double ts = Stopwatch.Elapsed.TotalSeconds;
            textBox2.Text = ts.ToString().Substring(0, 5);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }

            Stopwatch.Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            String Seed = seedd;
            int tap = tapp;
            ImageMatrix = ImageOperations.alphaEncode(ImageMatrix, Seed, tap, false);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            double ts = Stopwatch.Elapsed.TotalSeconds;
            textBox2.Text = ts.ToString().Substring(0, 5);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }

            Stopwatch.Reset();


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            float ratio = ImageOperations.compress(ImageMatrix, "0", 0);
            if (ratio.ToString().Length < 5)
            {
                textBox1.Text = ratio.ToString().Substring(0, 3) + " %";
            }
            else
            {
                textBox1.Text = ratio.ToString().Substring(0, 5) + " %";
            }
            double ts = Stopwatch.Elapsed.TotalSeconds;
            textBox2.Text = ts.ToString().Substring(0, 5);
            Stopwatch.Reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            ImageMatrix =  ImageOperations.Decompress();
           ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

            double ts = Stopwatch.Elapsed.TotalSeconds;

            textBox2.Text = ts.ToString().Substring(0, 5);
            Stopwatch.Reset();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            String Seed = Seed_Box.Text;
            int tap = int.Parse(Tap_Box.Text);
            ImageMatrix = ImageOperations.binEncoding(ImageMatrix, Seed, tap,true);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            float ratio = ImageOperations.compress(ImageMatrix, Seed ,tap);
            Stopwatch.Stop();
            double ts = Stopwatch.Elapsed.TotalSeconds;
            if (ratio.ToString().Length < 5)
            {
                textBox1.Text = ratio.ToString().Substring(0, 3) + " %";
            }
            else
            {
                textBox1.Text = ratio.ToString().Substring(0, 5) + " %";
            }
            textBox2.Text = ts.ToString().Substring(0, 5);
            // // // // // // 
            
            Stopwatch.Reset();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            ImageMatrix = ImageOperations.Decompress();
            ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

            String Seed = ImageOperations.Rseed();
            int tap = ImageOperations.Rtap();
 
            ImageMatrix = ImageOperations.binEncoding(ImageMatrix, Seed, tap,false);

            Stopwatch.Stop();

            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            double ts = Stopwatch.Elapsed.TotalSeconds;
            textBox2.Text = ts.ToString().Substring(0, 5);


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }



            Stopwatch.Reset();

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            String Seed = Seed_Box.Text;
            int tap = int.Parse(Tap_Box.Text);
            ImageMatrix = ImageOperations.alphaEncode(ImageMatrix, Seed, tap,true);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);
            float ratio = ImageOperations.compress(ImageMatrix, Seed, tap);
            Stopwatch.Stop();
            double ts = Stopwatch.Elapsed.TotalSeconds;
            string text1;
            if (ratio.ToString().Length < 5)
            {
                text1 = ratio.ToString().Substring(0, 3) + " %";
            }
            else
            {
                text1 = ratio.ToString().Substring(0, 5) + " %";
            }
            textBox1.Text = text1;
            string text2= ts.ToString().Substring(0, 5);
            textBox2.Text = text2;
            Stopwatch.Reset();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Stopwatch Stopwatch = new Stopwatch();
            Stopwatch.Start();

            ImageMatrix = ImageOperations.Decompress();
            ImageOperations.DisplayImage(ImageMatrix, pictureBox1);

            String Seed = ImageOperations.Rseed();
            int tap = ImageOperations.Rtap();

            ImageMatrix = ImageOperations.alphaEncode(ImageMatrix, Seed, tap,false);
            Stopwatch.Stop();

            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);

            double ts = Stopwatch.Elapsed.TotalSeconds;
            textBox2.Text = ts.ToString().Substring(0, 5);


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }



            Stopwatch.Reset();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}