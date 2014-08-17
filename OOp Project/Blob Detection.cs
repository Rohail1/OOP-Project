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
    public static class Blob_Detection
    {


 

        public static void  blob_setter(Bitmap video , Bitmap grayImage , int height , int width)
        {
            BlobCounter blobCounter = new BlobCounter();
            // configure it to filter out small objects
            blobCounter.MinWidth = width;
            blobCounter.MinHeight = height;
     //       blobCounter.FilterBlobs = true;
            // set ordering - bigger objects go first
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            // locate blobs
            blobCounter.ProcessImage(grayImage);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();

            foreach (Rectangle recs in rects)
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0];
                    Graphics g = Graphics.FromImage(video);
                    using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 3))
                    {
                        g.DrawRectangle(pen, objectRect);
                    }
                    g.Dispose();
                }
        }
    }
}
