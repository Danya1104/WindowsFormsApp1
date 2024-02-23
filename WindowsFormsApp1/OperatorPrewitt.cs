using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class OperatorPrewitt : MatrixFilter
    {
        public OperatorPrewitt()
        {
            // Ядро оператора Прюитта по оси Y
            float[,] kernelY = new float[3, 3]
            {
            { -1, -1, -1 },
            {  0,  0,  0 },
            {  1,  1,  1 }
            };

            // Ядро оператора Прюитта по оси X
            float[,] kernelX = new float[3, 3]
            {
            { -1,  0,  1 },
            { -1,  0,  1 },
            { -1,  0,  1 }
            };

            // Комбинированные ядра оператора Прюитта для обеих осей
            kernel = CombineKernels(kernelX, kernelY);
        }

        private float[,] CombineKernels(float[,] kernelX, float[,] kernelY)
        {
            throw new NotImplementedException();
        }
    }
}
