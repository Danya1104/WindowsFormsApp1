using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Sharpness1 : MatrixFilter
    {
        public Sharpness1()
        {
            kernel = new float[3, 3]
            {{ -1, -1, -1 },{ -1,  9, -1 },{ -1, -1, -1 }};
        }

        public void SetKernel()
        {
            kernel = new float[3, 3]
            {{ -1, -1, -1 },{ -1,  9, -1 },{ -1, -1, -1 }};
        }
    }

}
