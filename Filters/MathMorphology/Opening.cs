﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters.MathMorphology
{
    internal class Opening : MorphOperation
    {
        public Opening(bool[,] mask, int threshold) : base(mask, threshold) { }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker backgroundWorker)
        {
            sourceImage = new Erosion(kernel, threshold).processImage(sourceImage, backgroundWorker);
            return new Dilation(kernel, threshold).processImage(sourceImage, backgroundWorker);
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
