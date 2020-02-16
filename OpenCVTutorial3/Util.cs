using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVTutorial3
{
    class Util
    {
        public static OpenCvSharp.Point[] getCCWList(OpenCvSharp.Point[] pp)
        {
            OpenCvSharp.Point[] alignedList = new OpenCvSharp.Point[4];
            OpenCvSharp.Point center = new OpenCvSharp.Point();
            for(int i=0; i<pp.Length; i++)
            {
                center.X += pp[i].X;
                center.Y += pp[i].Y;
            }
            center.X = center.X / pp.Length;
            center.Y = center.Y / pp.Length;

            
            for(int i=0; i<pp.Length; i++)
            {
                // left top
                if (pp[i].X < center.X && pp[i].Y < center.Y)
                {
                    alignedList[0] = pp[i];
                }
                // right top
                if(pp[i].X > center.X && pp[i].Y < center.Y)
                {
                    alignedList[1] = pp[i];
                }
                // right  bottom
                if(pp[i].X > center.X && pp[i].Y > center.Y)
                {
                    alignedList[2] = pp[i];
                }
                // left bottom
                if(pp[i].X < center.X && pp[i].Y > center.Y)
                {
                    alignedList[3] = pp[i];
                }
            }
            
            return alignedList;
        }




        public static int rectMinX(OpenCvSharp.Point[] pp)
        {
            int minX = int.MaxValue;
            foreach(OpenCvSharp.Point pt in pp)
            {
                minX = minX < pt.X ? minX : pt.X;
            }

            return minX;
        }

        public static int rectMaxX(OpenCvSharp.Point[] pp)
        {
            int maxX = int.MinValue;
            foreach (OpenCvSharp.Point pt in pp)
            {
                maxX = maxX > pt.X ? maxX : pt.X;
            }

            return maxX;
        }

        public static int rectMinY(OpenCvSharp.Point[] pp)
        {
            int minY = int.MaxValue;
            foreach (OpenCvSharp.Point pt in pp)
            {
                minY = minY < pt.Y ? minY : pt.Y;
            }

            return minY;
        }

        public static int rectMaxY(OpenCvSharp.Point[] pp)
        {
            int maxY = int.MinValue;
            foreach (OpenCvSharp.Point pt in pp)
            {
                maxY = maxY > pt.X ? maxY : pt.Y;
            }

            return maxY;
        }





        public static int rectMinX(List<OpenCvSharp.Point> pp)
        {
            int minX = int.MaxValue;
            foreach (OpenCvSharp.Point pt in pp)
            {
                minX = minX < pt.X ? minX : pt.X;
            }

            return minX;
        }

        public static int rectMaxX(List<OpenCvSharp.Point> pp)
        {
            int maxX = int.MinValue;
            foreach (OpenCvSharp.Point pt in pp)
            {
                maxX = maxX > pt.X ? maxX : pt.X;
            }

            return maxX;
        }

        public static int rectMinY(List<OpenCvSharp.Point> pp)
        {
            int minY = int.MaxValue;
            foreach (OpenCvSharp.Point pt in pp)
            {
                minY = minY < pt.Y ? minY : pt.Y;
            }

            return minY;
        }

        public static int rectMaxY(List<OpenCvSharp.Point> pp)
        {
            int maxY = int.MinValue;
            foreach (OpenCvSharp.Point pt in pp)
            {
                maxY = maxY > pt.X ? maxY : pt.Y;
            }

            return maxY;
        }
    }
}
