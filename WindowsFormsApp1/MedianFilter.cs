using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    class MedianFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            List<int> redValues = new List<int>();
            List<int> greenValues = new List<int>();
            List<int> blueValues = new List<int>();

            // Получаем значения цветов в окрестности пикселя
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int newY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(newX, newY);
                    redValues.Add(neighborColor.R);
                    greenValues.Add(neighborColor.G);
                    blueValues.Add(neighborColor.B);
                }
            }

            // Сортируем значения цветов и находим медианные значения
            redValues.Sort();
            greenValues.Sort();
            blueValues.Sort();
            int medianRed = redValues[4];
            int medianGreen = greenValues[4];
            int medianBlue = blueValues[4];

            return Color.FromArgb(medianRed, medianGreen, medianBlue);
        }
    }
}