using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;

namespace OOp_Project
{
    class RGB
    {
        ColorFiltering filter = new ColorFiltering();

        public void ApplyRGB(Bitmap video, int minR, int maxR, int minG, int maxG, int minB, int maxB)
        {
            // set color ranges to keep
            filter.Red = new IntRange(minR, maxR);
            filter.Green = new IntRange(minG, maxG);
            filter.Blue = new IntRange(minB, maxB);
            filter.ApplyInPlace(video);
        }
    }
}
