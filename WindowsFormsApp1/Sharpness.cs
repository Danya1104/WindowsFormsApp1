using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Sharpness : MatrixFilter
    {
        public float[,] sharpness = new float[3, 3]
        {{ 0 , -1 , 0 },{ -1 , 5 , -1 },{ 0 , -1 , 0 }};
        public Sharpness()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = sharpness[i, j];
                }
            }
        }
    }
}
