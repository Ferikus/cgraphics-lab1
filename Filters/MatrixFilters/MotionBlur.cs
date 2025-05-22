using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class MotionBlur : MatrixFilter
    {
        public MotionBlur()
        {
            int size = 10;
            kernel = new float[size, size];
            for (int i = 0; i < size; ++i)
            {
                kernel[i, i] = 1.0f / size;
            }
        }
    }
}
