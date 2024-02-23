using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Sepia : Filters
    {
        public Sepia() { }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            double k = 40;
            double R = intensity + 2 * k;
            double G = intensity + 0.5 * k;
            double B = intensity - (1 * k);
            return Color.FromArgb(Clamp((int)R, 0, 255),Clamp((int)G, 0, 255),Clamp((int)B, 0, 255));
        }
    }
}
