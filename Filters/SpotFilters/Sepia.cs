using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class Sepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 30;
            Color sourceColor = sourceImage.GetPixel(x, y);
            float intensity = 0.36f * sourceColor.R + 0.53f * sourceColor.G + 0.11f * sourceColor.B;
            int R = Clamp((int)(intensity + 2 * k), 0, 255);
            int G = Clamp((int)(intensity + 0.5f * k), 0, 255);
            int B = Clamp((int)(intensity - 1 * k), 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
