﻿using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB
{
    public static class ImageComparer
    {
        // The file extension for the generated Bitmap files
        private const string BitMapExtension = ".bmp";

        /// <summary>
        /// Compares the images.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="targetImage">The target image.</param>
        /// <param name="compareLevel">The compare level.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="similarityThreshold">The similarity threshold.</param>
        /// <returns>Boolean result</returns>
        public static Boolean CompareImages(string image, string targetImage, double compareLevel, string filepath, float similarityThreshold)
        {
            //System.Drawing.Image img;
            //using (var bmpTemp = new Bitmap("image_file_path"))
            //{
            //    img = new Bitmap(bmpTemp);
            //}
            // Load images into bitmaps


            try
            {
                
                System.Drawing.Image imageOne;
                using (var bmpTemp = new Bitmap(image))
                {
                    imageOne = new Bitmap(bmpTemp);
                }



                //var imageTwo = new Bitmap(targetImage);
                System.Drawing.Image imageTwo;
                using (
                    var bmpTemp = new Bitmap(targetImage))
                {
                    imageTwo = new Bitmap(bmpTemp);
                }

                
                if(imageTwo.Size.Height == imageOne.Size.Width)
                {
                    imageTwo.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }


                var newBitmap1 = ChangePixelFormat(new Bitmap(imageOne), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                var newBitmap2 = ChangePixelFormat(new Bitmap(imageTwo), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                newBitmap1 = SaveBitmapToFile(newBitmap1, filepath, image, BitMapExtension);
                newBitmap2 = SaveBitmapToFile(newBitmap2, filepath, targetImage, BitMapExtension);

                // Setup the AForge library
                var tm = new ExhaustiveTemplateMatching(similarityThreshold);
                // Process the images
                var results = tm.ProcessImage(newBitmap1, newBitmap2);

                // Compare the results, 0 indicates no match so return false
                if (results.Length <= 0)
                {
                    return false;
                }

                // Return true if similarity score is equal or greater than the comparison level
                var match = results[0].Similarity >= compareLevel;

                return match;

            }
            catch(Exception ex)
            {
                return false;
            }


            //return true;

        }

        /// <summary>
        /// Saves the bitmap automatic file.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="filepath">The filepath.</param>
        /// <param name="name">The name.</param>
        /// <param name="extension">The extension.</param>
        /// <returns>Bitmap image</returns>
        private static Bitmap SaveBitmapToFile(Bitmap image, string filepath, string name, string extension)
        {
            var savePath = string.Concat(filepath, "\\", Path.GetFileNameWithoutExtension(name), extension);

            image.Save(savePath, System.Drawing.Imaging.ImageFormat.Bmp);

            return image;
        }

        /// <summary>
        /// Change the pixel format of the bitmap image
        /// </summary>
        /// <param name="inputImage">Bitmapped image</param>
        /// <param name="newFormat">Bitmap format - 24bpp</param>
        /// <returns>Bitmap image</returns>
        private static Bitmap ChangePixelFormat(Bitmap inputImage, System.Drawing.Imaging.PixelFormat newFormat)
        {
            return (inputImage.Clone(new Rectangle(0, 0, inputImage.Width, inputImage.Height), newFormat));
        }
    }
}
