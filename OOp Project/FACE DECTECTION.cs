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
    public static class FACE_DECTECTION
    {
        

        public static void Face_Detection(Bitmap video)
        {
            ColorFiltering filter = new ColorFiltering();
            // set color ranges to keep
            filter.Red = new IntRange(0, 75);
            filter.Green = new IntRange(0, 75);
            filter.Blue = new IntRange(10, 255);
            filter.ApplyInPlace(video);
        }

    }
}
