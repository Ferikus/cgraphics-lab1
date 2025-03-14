using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = 30;
            Color sourceColor = sourceImage.GetPixel(x, y);
            int R = Clamp((int)(sourceColor.R + k), 0, 255);
            int G = Clamp((int)(sourceColor.G + k), 0, 255);
            int B = Clamp((int)(sourceColor.B + k), 0, 255);

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
