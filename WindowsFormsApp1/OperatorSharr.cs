using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class OperatorSharr : MatrixFilter
    {
        public OperatorSharr()
        {
            // Ядро оператора Щарра по оси Y
            float[,] kernelY = new float[3, 3]
            {
            { 3,  10,  3 },
            { 0,   0,  0 },
            { -3, -10, -3 }
            };

            // Ядро оператора Щарра по оси X
            float[,] kernelX = new float[3, 3]
            {
            { 3,   0, -3 },
            { 10,  0, -10 },
            { 3,   0, -3 }
            };

            // Комбинированное ядро оператора Щарра (для обоих осей)
            kernel = CombineKernels(kernelX, kernelY);
        }

        private float[,] CombineKernels(float[,] kernelX, float[,] kernelY)
        {
            throw new NotImplementedException();
        }
    }
}
