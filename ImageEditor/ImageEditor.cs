﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class ImageEditor : Form
    {
        private Size originalImageSize;
        private Stack<Bitmap> previousStates;
        private int revertCounter;


        public ImageEditor()
        {
            InitializeComponent();
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            previousStates = new Stack<Bitmap>();
            revertCounter = 0;
        }

        private void AddState(Bitmap state)
        {
            previousStates.Push(state);
            revertCounter++;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Imagini|*.jpg;*.jpeg;*.png;*.bmp|Toate fișierele|*.*" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox.Image = Image.FromFile(openFileDialog.FileName);
                originalImageSize = PictureBox.Image.Size;
                PictureBox.Image = ScaleImage(PictureBox.Image, PictureBox.Size);
                AddState(new Bitmap(PictureBox.Image));
            }
        }

        private Image ScaleImage(Image image, Size pictureBoxSize)
        {
            int width = image.Width;
            int height = image.Height;
            int newWidth, newHeight;

            if ((float)width / pictureBoxSize.Width > (float)height / pictureBoxSize.Height)
            {
                newWidth = pictureBoxSize.Width;
                newHeight = (int)((float)height / width * newWidth);
            }
            else
            {
                newHeight = pictureBoxSize.Height;
                newWidth = (int)((float)width / height * newHeight);
            }

            Bitmap scaledImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(scaledImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return scaledImage;
        }

        private void FlipVerticalButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                PictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                PictureBox.Refresh();
            }
        }

        private void HorizontalFlipButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                PictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                PictureBox.Refresh();
            }
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap bmp = new Bitmap(PictureBox.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                PictureBox.Image = bmp;
            }
        }

        private void InvertButton_Click(object sender, EventArgs e)
        {
            InvertImage(PictureBox.Image);
        }

        private void InvertImage(Image image)
        {
            if (image != null)
            {
                Bitmap bmp = new Bitmap(image);

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixelColor = bmp.GetPixel(x, y);
                        Color invertedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                        bmp.SetPixel(x, y, invertedColor);
                    }
                }

                PictureBox.Image = bmp;
            }
        }

        private Bitmap ApplyBlackAndWhiteFilter(Image image)
        {
            Bitmap filteredImage = new Bitmap(image);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = filteredImage.GetPixel(x, y);
                    int avgColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color newColor = Color.FromArgb(avgColor, avgColor, avgColor);
                    filteredImage.SetPixel(x, y, newColor);
                }
            }

            return filteredImage;
        }

        private void BlackAndWhiteFilterButton_Click(object sender, EventArgs e)
        {
            if (PictureBox != null)
            {
                Bitmap filteredImage = ApplyBlackAndWhiteFilter(PictureBox.Image);
                PictureBox.Image = filteredImage;
            }
        }

        private void SepiaFilterButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap filteredImage = ApplySepiaFilter(PictureBox.Image);
                PictureBox.Image = filteredImage;
            }
        }

        private Bitmap ApplySepiaFilter(Image image)
        {
            Bitmap filteredImage = new Bitmap(image);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = filteredImage.GetPixel(x, y);
                    Color newColor = CalculateSepia(pixelColor);
                    filteredImage.SetPixel(x, y, newColor);
                }
            }

            return filteredImage;
        }

        private Color CalculateSepia(Color color)
        {
            int r = (int)(color.R * 0.393 + color.G * 0.769 + color.B * 0.189);
            int g = (int)(color.R * 0.349 + color.G * 0.686 + color.B * 0.168);
            int b = (int)(color.R * 0.272 + color.G * 0.534 + color.B * 0.131);

            r = Math.Min(255, r);
            g = Math.Min(255, g);
            b = Math.Min(255, b);

            return Color.FromArgb(r, g, b);
        }

        private void GreenFilterButton_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(PictureBox.Image);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    int r = originalColor.R;
                    int g = Math.Min(255, (int)(originalColor.G * 1.5));
                    int b = originalColor.B;

                    Color newColor = Color.FromArgb(r, g, b);
                    image.SetPixel(x, y, newColor);
                }
            }


            PictureBox.Image = image;
        }

        private void BlueFilterButton_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(PictureBox.Image);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    int tr = originalColor.R / 2;
                    int tg = originalColor.G / 2;
                    int tb = originalColor.B;

                    Color newColor = Color.FromArgb(tr, tg, tb);
                    image.SetPixel(x, y, newColor);
                }
            }

            PictureBox.Image = image;
        }

        private void BrightnessHighButton_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(PictureBox.Image);
            int brightness = 5;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    int newR = Math.Max(0, Math.Min(255, originalColor.R + brightness));
                    int newG = Math.Max(0, Math.Min(255, originalColor.G + brightness));
                    int newB = Math.Max(0, Math.Min(255, originalColor.B + brightness));
                    image.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }

            PictureBox.Image = image;
        }

        private void BrightnessLowButton_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(PictureBox.Image);
            int brightness = 5;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    int newR = Math.Max(0, originalColor.R - brightness);
                    int newG = Math.Max(0, originalColor.G - brightness);
                    int newB = Math.Max(0, originalColor.B - brightness);

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    image.SetPixel(x, y, newColor);
                }
            }

            PictureBox.Image = image;
        }

        private void ContrastHighButton_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(PictureBox.Image);

            double averageIntensity = CalculateAverageIntensity(image);
            double factor = 1.1;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    int newR = CalculateNewIntensity(originalColor.R, averageIntensity, factor);
                    int newG = CalculateNewIntensity(originalColor.G, averageIntensity, factor);
                    int newB = CalculateNewIntensity(originalColor.B, averageIntensity, factor);

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    image.SetPixel(x, y, newColor);
                }
            }

            PictureBox.Image = image;
        }

        static double CalculateAverageIntensity(Bitmap image)
        {
            double totalIntensity = 0;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    totalIntensity += (pixelColor.R + pixelColor.G + pixelColor.B) / 3.0; 
                }
            }

            return totalIntensity / (image.Width * image.Height);
        }

        static int CalculateNewIntensity(int originalIntensity, double averageIntensity, double factor)
        {
            int newIntensity = (int)((originalIntensity - averageIntensity) * factor + averageIntensity);
            return Math.Min(255, Math.Max(0, newIntensity));
        }

        private void ContrastLowButton_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(PictureBox.Image);

            double averageIntensity = CalculateAverageIntensity(image);
            double factor = 0.9;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    int newR = CalculateNewIntensity(originalColor.R, averageIntensity, factor);
                    int newG = CalculateNewIntensity(originalColor.G, averageIntensity, factor);
                    int newB = CalculateNewIntensity(originalColor.B, averageIntensity, factor);

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    image.SetPixel(x, y, newColor);
                }
            }

            PictureBox.Image = image;
        }

        private void Revert_Click(object sender, EventArgs e)
        {
            if (previousStates.Count >= revertCounter)
            {
                Bitmap desiredState = null;
                for (int i = 0; i < revertCounter; i++)
                {
                    desiredState = previousStates.Pop();
                }

                PictureBox.Image = desiredState;
                AddState(desiredState);
                revertCounter = previousStates.Count;

                if (revertCounter < 3)
                {
                    ContrastLowButton.Enabled = true;
                }
            }
        }

        private void GrayscaleHighButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap grayImage = ApplyHighGrayscaleFilter(PictureBox.Image);
                PictureBox.Image = grayImage;
            }
        }

        private Bitmap ApplyHighGrayscaleFilter(Image image)
        {
            Bitmap grayImage = new Bitmap(image);
            double factor = 1.1;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = grayImage.GetPixel(x, y);
                    int avgColor = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                    avgColor = Math.Min(255, (int)(avgColor * factor));
                    Color newColor = Color.FromArgb(avgColor, avgColor, avgColor);
                    grayImage.SetPixel(x, y, newColor);
                }
            }

            return grayImage;
        }

        private void GrayscaleLowButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap grayImage = ApplyLowGrayscaleFilter(PictureBox.Image);
                PictureBox.Image = grayImage;
                AddState(new Bitmap(PictureBox.Image));
            }
        }

        private Bitmap ApplyLowGrayscaleFilter(Image image)
        {
            Bitmap grayImage = new Bitmap(image);
            double factor = 0.9;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = grayImage.GetPixel(x, y);
                    int avgColor = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                    avgColor = (int)(avgColor * factor);
                    avgColor = Math.Min(255, avgColor);
                    Color newColor = Color.FromArgb(avgColor, avgColor, avgColor);
                    grayImage.SetPixel(x, y, newColor);
                }
            }

            return grayImage;
        }

        private void ColorCorrectionButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                Bitmap correctedImage = ApplyColorCorrection(PictureBox.Image);
                PictureBox.Image = correctedImage;
                AddState(new Bitmap(PictureBox.Image));
            }
        }

        private Bitmap ApplyColorCorrection(Image image)
        {
            Bitmap correctedImage = new Bitmap(image);

            int redAdjustment = 20;
            int greenAdjustment = 10;
            int blueAdjustment = 5;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = correctedImage.GetPixel(x, y);

                    int correctedR = Clamp(pixelColor.R + redAdjustment, 0, 255);
                    int correctedG = Clamp(pixelColor.G + greenAdjustment, 0, 255);
                    int correctedB = Clamp(pixelColor.B + blueAdjustment, 0, 255);

                    Color newColor = Color.FromArgb(correctedR, correctedG, correctedB);

                    correctedImage.SetPixel(x, y, newColor);
                }
            }

            return correctedImage;
        }

        private int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }

        private void Resize_Click(object sender, EventArgs e)
        {
            int newWidth = 200;
            int newHeight = 200;

            if (PictureBox.Image != null)
            {
                Bitmap resizedImage = new Bitmap(PictureBox.Image, newWidth, newHeight);
                PictureBox.Image = resizedImage;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (PictureBox.Image != null)
            {
                SaveImage();
            }
        }

        private void SaveImage()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    switch (extension)
                    {
                        case ".jpg":
                            PictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            MessageBox.Show("Image successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case ".bmp":
                            PictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            MessageBox.Show("Image successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case ".png":
                            PictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            MessageBox.Show("Image successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            MessageBox.Show("Unsupported format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }

    }
}
