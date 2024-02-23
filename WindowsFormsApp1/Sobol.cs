using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Sobol : MatrixFilter
    {
        public float[,] Gx = new float[3, 3]
        {{ -1 , -2, -1 },{ 0 , 0 , 0 },{ 1 , 2, 1 }};
        public float[,] Gy = new float[3, 3]
        {{ -1 , 0 , 1 },{ -2 , 0 , 2 },{ -1 , 0 , 1 }};
        public Sobol()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = Gx[i, j];
                    kernel[i, j] = Gy[i, j];
                }
            }
        }
    }
}
