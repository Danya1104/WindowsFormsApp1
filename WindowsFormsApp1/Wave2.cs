using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Wave2 : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = (int)(x + 20 * Math.Sin(2 * Math.PI * x / 30));
            int newY = y;

            newX = Clamp(newX, 0, sourceImage.Width - 1);

            return sourceImage.GetPixel(newX, newY);
        }
    }
}
