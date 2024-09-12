using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Emit;
///Algorithms Project
///Intelligent Scissors
///

namespace ImageEncryptCompress
{
    /// <summary>
    /// Holds the pixel color in 3 byte values: red, green and blue
    /// </summary>
    /// 
    [Serializable]
    public struct RGBPixel
    {
        public byte red, green, blue;
    }
    public struct RGBPixelD
    {
        public double red, green, blue;
    }
    
  
    /// <summary>
    /// Library of static functions that deal with images
    /// </summary>
    public class ImageOperations
    {
        /// <summary>
        /// Open an image and load it into 2D array of colors (size: Height x Width)
        /// </summary>
        /// <param name="ImagePath">Image file path</param>
        /// <returns>2D array of colors</returns>
        public static RGBPixel[,] OpenImage(string ImagePath)
        {
            Bitmap original_bm = new Bitmap(ImagePath);
            int Height = original_bm.Height;
            int Width = original_bm.Width;

            RGBPixel[,] Buffer = new RGBPixel[Height, Width];

            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);
                int x, y;
                int nWidth = 0;
                bool Format32 = false;
                bool Format24 = false;
                bool Format8 = false;

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    Format24 = true;
                    nWidth = Width * 3;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    Format32 = true;
                    nWidth = Width * 4;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Format8 = true;
                    nWidth = Width;
                }
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (y = 0; y < Height; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (Format8)
                        {
                            Buffer[y, x].red = Buffer[y, x].green = Buffer[y, x].blue = p[0];
                            p++;
                        }
                        else
                        {
                            Buffer[y, x].red = p[2];
                            Buffer[y, x].green = p[1];
                            Buffer[y, x].blue = p[0];
                            if (Format24) p += 3;
                            else if (Format32) p += 4;
                        }
                    }
                    p += nOffset;
                }
                original_bm.UnlockBits(bmd);
            }

            return Buffer;
        }
        
        /// <summary>
        /// Get the height of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Height</returns>
        public static int GetHeight(RGBPixel[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);
        }

        /// <summary>
        /// Get the width of the image 
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <returns>Image Width</returns>
        public static int GetWidth(RGBPixel[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);
        }

        /// <summary>
        /// Display the given image on the given PictureBox object
        /// </summary>
        /// <param name="ImageMatrix">2D array that contains the image</param>
        /// <param name="PicBox">PictureBox object to display the image on it</param>
        public static void DisplayImage(RGBPixel[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[2] = ImageMatrix[i, j].red;
                        p[1] = ImageMatrix[i, j].green;
                        p[0] = ImageMatrix[i, j].blue;
                        p += 3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }


       /// <summary>
       /// Apply Gaussian smoothing filter to enhance the edge detection 
       /// </summary>
       /// <param name="ImageMatrix">Colored image matrix</param>
       /// <param name="filterSize">Gaussian mask size</param>
       /// <param name="sigma">Gaussian sigma</param>
       /// <returns>smoothed color image</returns>
        public static RGBPixel[,] GaussianFilter1D(RGBPixel[,] ImageMatrix, int filterSize, double sigma)
        {
            int Height = GetHeight(ImageMatrix);
            int Width = GetWidth(ImageMatrix);

            RGBPixelD[,] VerFiltered = new RGBPixelD[Height, Width];
            RGBPixel[,] Filtered = new RGBPixel[Height, Width];

           
            // Create Filter in Spatial Domain:
            //=================================
            //make the filter ODD size
            if (filterSize % 2 == 0) filterSize++;

            double[] Filter = new double[filterSize];

            //Compute Filter in Spatial Domain :
            //==================================
            double Sum1 = 0;
            int HalfSize = filterSize / 2;
            for (int y = -HalfSize; y <= HalfSize; y++)
            {
                //Filter[y+HalfSize] = (1.0 / (Math.Sqrt(2 * 22.0/7.0) * Segma)) * Math.Exp(-(double)(y*y) / (double)(2 * Segma * Segma)) ;
                Filter[y + HalfSize] = Math.Exp(-(double)(y * y) / (double)(2 * sigma * sigma));
                Sum1 += Filter[y + HalfSize];
            }
            for (int y = -HalfSize; y <= HalfSize; y++)
            {
                Filter[y + HalfSize] /= Sum1;
            }

            //Filter Original Image Vertically:
            //=================================
            int ii, jj;
            RGBPixelD Sum;
            RGBPixel Item1;
            RGBPixelD Item2;

            for (int j = 0; j < Width; j++)
                for (int i = 0; i < Height; i++)
                {
                    Sum.red = 0;
                    Sum.green = 0;
                    Sum.blue = 0;
                    for (int y = -HalfSize; y <= HalfSize; y++)
                    {
                        ii = i + y;
                        if (ii >= 0 && ii < Height)
                        {
                            Item1 = ImageMatrix[ii, j];
                            Sum.red += Filter[y + HalfSize] * Item1.red;
                            Sum.green += Filter[y + HalfSize] * Item1.green;
                            Sum.blue += Filter[y + HalfSize] * Item1.blue;
                        }
                    }
                    VerFiltered[i, j] = Sum;
                }

            //Filter Resulting Image Horizontally:
            //===================================
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    Sum.red = 0;
                    Sum.green = 0;
                    Sum.blue = 0;
                    for (int x = -HalfSize; x <= HalfSize; x++)
                    {
                        jj = j + x;
                        if (jj >= 0 && jj < Width)
                        {
                            Item2 = VerFiltered[i, jj];
                            Sum.red += Filter[x + HalfSize] * Item2.red;
                            Sum.green += Filter[x + HalfSize] * Item2.green;
                            Sum.blue += Filter[x + HalfSize] * Item2.blue;
                        }
                    }
                    Filtered[i, j].red = (byte)Sum.red;
                    Filtered[i, j].green = (byte)Sum.green;
                    Filtered[i, j].blue = (byte)Sum.blue;
                }

            return Filtered;
        }
        public static string ConvertToBin(string s)
        {
            string bin = "";
            foreach (char c in s)
            {
                string tmp = Convert.ToString(c, 2);
                bin += tmp;
            }
            return bin;
        }

        public static RGBPixel[,] alphaEncode(RGBPixel[,] ImageMatrix, String InitialSeed, int tap , bool encode)
        {

        
            string tempSeed = InitialSeed;


            InitialSeed = ConvertToBin(InitialSeed);

            int length = InitialSeed.Length;


            List<byte> byteKeys = new List<byte>();

            string output = "";

            //generate keys
            int loop = (int)Math.Pow(2, length) / 8;
            for (int i = 0; i < loop; i++)
            {

                int xorRes = (InitialSeed[0] - '0') ^ (InitialSeed[tap] - '0');
                InitialSeed = InitialSeed.Substring(1) + xorRes.ToString();


                output += InitialSeed[length - 1] - '0';

                if (output.Length == 8)
                {

                    byte temp = Convert.ToByte(output, 2);
                    byteKeys.Add(temp);

                    output = "";
                }
            }

            //endcoding
            int counter = 1;
            for (int i = 0; i < ImageMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ImageMatrix.GetLength(1); j++)
                {
                    ImageMatrix[i, j].red = (byte)(ImageMatrix[i, j].red ^ byteKeys[counter]);
                    counter++;
                    ImageMatrix[i, j].green = (byte)(ImageMatrix[i, j].green ^ byteKeys[counter]);
                    counter++;
                    ImageMatrix[i, j].blue = (byte)(ImageMatrix[i, j].blue ^ byteKeys[counter]);
                    counter++;
                }

            }

            if (encode)
                saveImage(ImageMatrix, tempSeed, tap);
            return ImageMatrix;

        }


        public static RGBPixel[,] binEncoding(RGBPixel[,] ImageMatrix, String InitialSeed, int tap , bool encode)
        {

            String tempSeed = InitialSeed;
            int feed, resutl, temp2, counter = 0;
            String tempKey = "";
            double check = (int)Math.Pow(2, InitialSeed.Length);
            String[] keys;
            
            byte[] byteKeys;
            if (check < 0 || check * 8 < 0)
            {
                keys = new String[6500000];
                byteKeys = new byte[6500000];
                check = 6500000;


            }
            else
            {
                keys = new String[(int)(Math.Pow(2, InitialSeed.Length) / 8)];
                byteKeys = new byte[(int)(Math.Pow(2, InitialSeed.Length) / 8)];
                check = Math.Pow(2, InitialSeed.Length);
            }

            for (int i = 0; i < check; i++)
            {
                feed = InitialSeed[0] - '0';
                temp2 = InitialSeed[InitialSeed.Length - tap - 1] - '0';
                resutl = feed ^ temp2;
                InitialSeed = InitialSeed.Remove(0, 1);
                InitialSeed = InitialSeed + resutl;
                tempKey = tempKey + resutl;
                if (tempKey.Length == 8)
                {
                    keys[counter] = tempKey;
                    Console.WriteLine(keys[counter]);
                    counter++;
                    tempKey = "";
                }
            }


            
            for (int i = 0; i < keys.Length; i++)
            {
                byteKeys[i] = Convert.ToByte(keys[i], 2);
            }

            
            counter = 0;
            for (int i = 0; i < ImageMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ImageMatrix.GetLength(1); j++)
                {
                    ImageMatrix[i, j].red = (byte)(ImageMatrix[i, j].red ^ byteKeys[counter++ % keys.Length]);
                    ImageMatrix[i, j].green = (byte)(ImageMatrix[i, j].green ^ byteKeys[counter++ % keys.Length]);
                    ImageMatrix[i, j].blue = (byte)(ImageMatrix[i, j].blue ^ byteKeys[counter++ % keys.Length]);

                }

            }

            if (encode)
            {
                saveImage(ImageMatrix, tempSeed, tap);
            }
            return ImageMatrix;
        }

        public static int TAP;
        public static String SEED;
        public static int TAP2;
        public static String SEED2;
        public static float compress(RGBPixel[,] ImageMatrix, string seed, int tap)
        {
            Huff ImageHuff  = new Huff(ImageMatrix);
            ImageHuff.replace_values();
            Files myImage = new Files(ImageHuff, seed, tap);


            return myImage.Ratio();
        }
        public static RGBPixel[,] Decompress()
        {
            ExtractFiles file = new ExtractFiles();
            TAP = file.tap;
            SEED = file.seed;


         
            return file.huff.arr;
        }
        public static int Rtap()
        {
            return TAP;
        }
        public static String Rseed()
        {
            return SEED;

        }

    


        public static void saveImage(RGBPixel[,] ImageMatrix ,string seed , int tap)
        {
            BinaryConvertForEncode bc;
            

            bc.seed = seed;
            bc.tap = tap;
            

            Files f = new Files(bc);

            
        }

        public static BinaryConvertForEncode loadImage()
        {
            ExtractFiles extractFiles = new ExtractFiles(true);


            return  extractFiles.myObjectEncode;
        }

    }
}
