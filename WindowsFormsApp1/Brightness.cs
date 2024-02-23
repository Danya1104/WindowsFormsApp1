using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Brightness : Filters
    {
        public Brightness() { }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int constanta = 70;

            int newR = Math.Min(255, sourceColor.R + constanta);
            int newG = Math.Min(255, sourceColor.G + constanta);
            int newB = Math.Min(255, sourceColor.B + constanta);

            return Color.FromArgb(
                Clamp((int)newR, 0, 255),
                Clamp((int)newG, 0, 255),
                Clamp((int)newB, 0, 255));
        }
    }
}
