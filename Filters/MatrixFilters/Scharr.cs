using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class ScharrX : MatrixFilter
    {
        public ScharrX()
        {
            kernel = new float[,] {

                {3.0f, 0.0f, -3.0f},
                {10.0f, 0.0f, -10.0f},
                {3.0f, 0.0f, -3.0f}
            };
        }
    }

    class ScharrY : MatrixFilter
    {
        public ScharrY()
        {
            kernel = new float[,] {

                {3.0f, 10.0f, 3.0f},
                {0.0f, 0.0f, 0.0f},
                {-3.0f, -10.0f, -3.0f}
            };
        }
    }
}
