using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Embossing : Filters
    {
        public Embossing() { }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

            float[,] embossKernel = new float[3, 3] { { 0, 1, 0 }, { 1, 0, -1 }, { 0, -1, 0 } };

            int radiusX = embossKernel.GetLength(0) / 2;
            int radiusY = embossKernel.GetLength(1) / 2;
            float resultIntensity = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    int neighborIntensity = (int)(0.299 * neighborColor.R + 0.587 * neighborColor.G + 0.114 * neighborColor.B);
                    resultIntensity += neighborIntensity * embossKernel[k + radiusX, l + radiusY];
                }
            }
            resultIntensity += 255;
            resultIntensity /= 2;
            return Color.FromArgb(Clamp((int)resultIntensity, 0, 255),
                                  Clamp((int)resultIntensity, 0, 255),
                                  Clamp((int)resultIntensity, 0, 255));}
    }
}
