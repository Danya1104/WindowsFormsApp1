using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
 

    class GlowingEdges
    {
        public Bitmap Apply(Bitmap sourceImage)
        {
            // Применяем медианный фильтр
            MedianFilter medianFilter = new MedianFilter();
            Bitmap medianImage = medianFilter.processImage(sourceImage, null);

            // Применяем оператор выделения контуров
            OperatorPrewitt OperatorPrewitt = new OperatorPrewitt();
            Bitmap edgesImage = OperatorPrewitt.processImage(medianImage, null);

            // Применяем фильтр максимума
            Bitmap resultImage = MaximumFilter(edgesImage);

            return resultImage;
        }

        private Bitmap MaximumFilter(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color maxColor = Color.Black;

                    // Находим максимальное значение по каждому каналу в окрестности пикселя
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {
                            int x = Clamp(i + k, 0, sourceImage.Width - 1);
                            int y = Clamp(j + l, 0, sourceImage.Height - 1);

                            Color neighborColor = sourceImage.GetPixel(x, y);

                            maxColor = Color.FromArgb(
                                Math.Max(maxColor.R, neighborColor.R),
                                Math.Max(maxColor.G, neighborColor.G),
                                Math.Max(maxColor.B, neighborColor.B)
                            );
                        }
                    }

                    resultImage.SetPixel(i, j, maxColor);
                }
            }

            return resultImage;
        }

        private int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }

}
