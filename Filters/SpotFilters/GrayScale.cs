using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    class GrayScale : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.36f * sourceColor.R + 0.53f * sourceColor.G + 0.11f * sourceColor.B);
            Color resultColor = Color.FromArgb(intensity, intensity, intensity);
            return resultColor;
        }
    }
}
