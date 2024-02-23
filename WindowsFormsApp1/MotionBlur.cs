using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MotionBlur : Filters
    {
        private int n;

        public MotionBlur() { }

        public void SetKernelSize(int size)
        {
            this.n = size;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = n / 2;
            int kernelSize = n * n;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    resultR += neighborColor.R;
                    resultG += neighborColor.G;
                    resultB += neighborColor.B;
                }
            }

            resultR /= kernelSize;
            resultG /= kernelSize;
            resultB /= kernelSize;

            return Color.FromArgb(Clamp((int)resultR, 0, 255), Clamp((int)resultG, 0, 255),Clamp((int)resultB, 0, 255));}
    }
}
