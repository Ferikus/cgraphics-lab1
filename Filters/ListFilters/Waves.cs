using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    internal class WavesX : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int newX = k;
            int newY = Clamp(l + (int)(20 * Math.Sin(Math.PI * k / 30)), 0, sourceImage.Height - 1);

            Color pixelColor = sourceImage.GetPixel(k, l);
            if ((newX >= 0 && newX <= sourceImage.Width) && (newY >= 0 && newY <= sourceImage.Height))
            {
                pixelColor = sourceImage.GetPixel(newX, newY);
            }
            return pixelColor;
        }

    }

    internal class WavesY : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int newX = Clamp(k + (int)(20 * Math.Sin(2 * Math.PI * l / 60)), 0, sourceImage.Width - 1);
            int newY = l;

            Color pixelColor = sourceImage.GetPixel(k, l);
            if ((newX >= 0 && newX <= sourceImage.Width) && (newY >= 0 && newY <= sourceImage.Height))
            {
                pixelColor = sourceImage.GetPixel(newX, newY);
            }
            return pixelColor;
        }

    }
}
