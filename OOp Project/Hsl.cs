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
   public static class Hsl
    {
       public static void Hsl_Setter(Bitmap video, int minHue, int maxHue, float minSat, float maxSat, float minLum, float maxLum)
       {

           //Create color filter
           HSLFiltering HslFilter = new HSLFiltering();
           //configre the filter
           HslFilter.Hue = new IntRange(minHue, maxHue);
           HslFilter.Saturation = new Range(minSat, maxSat);
           HslFilter.Luminance = new Range(minLum, maxLum);
           //apply color filter to the image
           HslFilter.ApplyInPlace(video);
       }
    }
}
