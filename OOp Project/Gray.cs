﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
 ing AForge.Video.DirectShow;

namespace OOp_Project
{
    class Gray
    {
        // create grayscale filter (BT709)
        Grayscale gray = new Grayscale(0.2125, 0.7154, 0.0721);

        public Bitmap Apply_grayscale(Bitmap video)
        {
            Bitmap grayImage;
            // apply the filter
            grayImage = gray.Apply(video);
            return grayImage;

        }
    }
}
