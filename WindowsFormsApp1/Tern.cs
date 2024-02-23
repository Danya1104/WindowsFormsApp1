using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Tern : Filters
    {
        private float centerX;
        private float centerY;
        private double angle;

        public Tern() { }

        public void SetParameters(float centerX, float centerY, double angle)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.angle = angle;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double cosAngle = Math.Cos(angle);
            double sinAngle = Math.Sin(angle);

            int newX = (int)((x - centerX) * cosAngle - (y - centerY) * sinAngle + centerX);
            int newY = (int)((x - centerX) * sinAngle + (y - centerY) * cosAngle + centerY);

            if (newX < 0 || newX >= sourceImage.Width || newY < 0 || newY >= sourceImage.Height)
                return Color.Black;
            else
                return sourceImage.GetPixel(newX, newY);
        }
    }

}
