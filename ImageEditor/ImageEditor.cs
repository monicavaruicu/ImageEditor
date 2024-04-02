using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class ImageEditor : Form
    {
        public ImageEditor()
        {
            InitializeComponent();
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {

        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Imagini|*.jpg;*.jpeg;*.png;*.bmp|Toate fișierele|*.*" };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PictureBox.Image = Image.FromFile(openFileDialog.FileName);
                PictureBox.Image = ScaleImage(PictureBox.Image, PictureBox.Size);
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

                    // Crește intensitatea culorii verzi
                    int r = originalColor.R;
                    int g = Math.Min(255, (int)(originalColor.G * 1.5)); // Creștere cu 50%
                    int b = originalColor.B;

                    // Actualizează pixelul din imaginea rezultat
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

                    // Păstrează componenta albastră și scade celelalte componente
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

                    // Reducem intensitatea tuturor componentelor culorilor
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
            int factor = 5;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color originalColor = image.GetPixel(x, y);

                    // Calculează noua intensitate a culorii pentru fiecare componentă
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
                    totalIntensity += (pixelColor.R + pixelColor.G + pixelColor.B) / 3.0; // Media intensității culorilor
                }
            }

            // Calculează media intensității culorilor pe toată imaginea
            return totalIntensity / (image.Width * image.Height);
        }

        // Funcție pentru calculul noii intensități a culorilor
        static int CalculateNewIntensity(int originalIntensity, double averageIntensity, double factor)
        {
            // Formula pentru ajustarea intensității în funcție de factorul de contrast
            return (int)(averageIntensity + factor * (originalIntensity - averageIntensity));
        }
    }
}
