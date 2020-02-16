using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace OpenCVTutorial3
{
    public partial class Form1 : Form
    {
        Bitmap bitmapSrc, bitmapBinary, bitmapCanny, bitmapContours, bitmapMostOuter, bitmapPerspective;

        public Form1()
        {
            InitializeComponent();
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            String filePath = "C:/snue_scoring/제16회중등과학올림피아드_서술형/long_페이지_001.jpg";
            testImage(filePath);
        }

        private void buttonStart2_Click(object sender, EventArgs e)
        {
            String filePath = "C:/snue_scoring/답지스캔_서술형/long_페이지_478.jpg";
            testImage(filePath);
        }

        private void buttonStart3_Click(object sender, EventArgs e)
        {
            String filePath = "C:/snue_scoring/답지스캔_단답형/short_페이지_001.jpg";
            testImage(filePath);
        }


        private void testImage(String filePath)
        {
            int offset = 100;
            Mat src, gray, binary, canny, matContours, mostOuter, matPerspective;
            src = Cv2.ImRead(filePath);

            Rect rect = new Rect(offset, offset, src.Width - offset * 2, src.Height - offset * 2);
            src = src.SubMat(rect);

            gray = new Mat();
            binary = new Mat();
            canny = new Mat();


            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 150, 255, ThresholdTypes.Binary);
            Cv2.Canny(binary, canny, 0, 0, 3);
            matContours = findContours2(canny);
            mostOuter = findMostOuterbox(src, canny);
            OpenCvSharp.Point pt = projectPerspective(src, canny);



            bitmapSrc = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
            bitmapBinary = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(binary);
            bitmapCanny = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(canny);
            bitmapContours = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matContours);
            bitmapMostOuter = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mostOuter);
            //bitmapPerspective = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matPerspective);

            testOMR(pt);
        }

        const int SMALL_OBJECT_MIN_AREA = 12;
        Bitmap bitmapPContours;
        private void testOMR(OpenCvSharp.Point wh)
        {
            Mat src, gray, binary, canny;
            src = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmapPerspective);
            gray = new Mat();
            binary = new Mat();
            canny = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 150, 255, ThresholdTypes.Binary);
            Cv2.Canny(binary, canny, 0, 0, 3);

            Mat matContours = src.Clone();

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(canny, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<OpenCvSharp.Point> smallObjectList = new List<OpenCvSharp.Point>();
            List<int> yList = new List<int>();
            List<OpenCvSharp.Point[]> rectObjectList = new List<OpenCvSharp.Point[]>();
            
            foreach (OpenCvSharp.Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                if (length < 100 &&  area < 1000 || p.Length < 5) continue;

                OpenCvSharp.Point[] hull = Cv2.ConvexHull(p, true);
                OpenCvSharp.Point[] pp = Cv2.ApproxPolyDP(p, 0.02 * length, true);
                if (pp.Length > 7 && Math.Abs(area) < SMALL_OBJECT_MIN_AREA)
                {
                    OpenCvSharp.Point ppCenter = getCenterPoint(pp);
                    //if (ppCenter.X > binary.Width / 2 && ppCenter.Y > binary.Height / 2)
                    {
                        smallObjectList.Add(ppCenter);
                        Cv2.DrawContours(matContours, new OpenCvSharp.Point[][] { hull }, -1, Scalar.Blue, 2);
                        Console.WriteLine("small object area " + area);


                        bool isExist = false;
                        foreach(int y in yList)
                        {
                            if(Math.Abs(y - ppCenter.Y) < SMALL_OBJECT_MIN_AREA * 2)
                            {
                                isExist = true;
                            }
                        }
                        if(isExist == false)
                        {
                            yList.Add(ppCenter.Y);
                        }
                    }
                }

                // 수험번호 잘라내면 이 부분 에서 사각형이 찾아지지 않는 이유를 모르겠-_-
                //// 수험번호 사각형 찾기 
                //if (pp.Length == 4)
                //{
                //    bool convex = Cv2.IsContourConvex(pp);
                //    if (convex == false)
                //        continue;

                //    // 전체 이미지의 우측 하단
                //    OpenCvSharp.Point ppCenter = getCenterPoint(pp);
                //    //if (ppCenter.X > binary.Width / 2 && ppCenter.Y > binary.Height / 2)
                //    {
                //        rectObjectList.Add(pp);
                //    }
                //}
            }


            // // 포함하고 있는 small object 갯수 count 하기
            //List<OpenCvSharp.Point> rectExmineePtList = new List<OpenCvSharp.Point>();
            //foreach (OpenCvSharp.Point[] pp in rectObjectList)
            //{
            //    int minX = Util.rectMinX(pp);
            //    int maxX = Util.rectMaxX(pp);
            //    int minY = Util.rectMinY(pp);
            //    int maxY = Util.rectMaxY(pp);

            //    int count = 0;
            //    foreach (OpenCvSharp.Point pt in smallObjectList)
            //    {
            //        if (minX < pt.X && pt.X < maxX && minY < pt.Y && pt.Y < maxY)
            //        {
            //            count += 1;
            //        }
            //    }


            //    double minArea = double.MaxValue;
            //    if (count > 0)
            //    {
            //        double area = Cv2.ContourArea(pp, true);
            //        if (Math.Abs(area) < minArea)
            //        {
            //            minArea = Math.Abs(area);
            //            rectExmineePtList.Clear();
            //            foreach (OpenCvSharp.Point ePt in pp)
            //            {
            //                rectExmineePtList.Add(ePt);
            //            }
            //        }
            //    }
            //}

            //yList.Sort();
            //yList.Reverse();

            int minExamineeRectX = 0;       //Util.rectMinX(rectExmineePtList);
            int maxExamineeRectX = wh.X;    //Util.rectMaxX(rectExmineePtList);
            int maxExamineeRectY = wh.Y;    //Util.rectMaxY(rectExmineePtList);
            int widthExamineeRectItem = (maxExamineeRectX - minExamineeRectX)/6;


            try
            {
                for (int i = 0; i < 6; i++)
                {
                    int minIndex = 0, minCount = int.MaxValue;
                    for (int k = 0; k < 10; k++)
                    {
                        int x = minExamineeRectX + widthExamineeRectItem * i + widthExamineeRectItem / 2;
                        int y = yList[k];
                        //Cv2.Circle(matContours, x, y, 12, Scalar.Red, 1);
                        OpenCvSharp.Rect rect = new OpenCvSharp.Rect(x - 12, y - 12, 24, 24); // x, y, width, height
                        Cv2.Rectangle(matContours, rect, Scalar.Pink, 3);

                        Mat matCircle = binary.SubMat(rect);
                        int nonzeroCount = Cv2.CountNonZero(matCircle);
                        //Console.WriteLine("i" + i + "k" + k + " count : " + nonzeroCount);
                        matCircle.Dispose();

                        if (nonzeroCount < minCount)
                        {
                            minCount = nonzeroCount;
                            minIndex = 9 - k;
                        }
                    }
                    Console.WriteLine("i" + i + " index:" + minIndex);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }





            for (int i=0; i<6; i++)
            {
                int x = minExamineeRectX + widthExamineeRectItem * i;
                Cv2.Circle(matContours, new OpenCvSharp.Point(x, 1500), 3, Scalar.Green, 3);
            }

            
            for (int i = 0; i < yList.Count; i++)
            {
                Cv2.Circle(matContours, new OpenCvSharp.Point(1000, yList[i]), 3, Scalar.Green, 3);
            }

            //for (int i=0; i<rectExmineePtList.Count-1; i++)
            //{
            //    Cv2.Line(matContours, rectExmineePtList[i], rectExmineePtList[i + 1], Scalar.Red, 3);    
            //}
            //if(rectExmineePtList.Count >0)
            //    Cv2.Line(matContours, rectExmineePtList[rectExmineePtList.Count - 1], rectExmineePtList[0], Scalar.Red, 3);


            Cv2.Line(matContours, 0, binary.Height / 2, binary.Width, binary.Height / 2, Scalar.Yellow, 3);
            Cv2.Line(matContours, binary.Width / 2, 0, binary.Width / 2, binary.Height, Scalar.Yellow, 3);

            bitmapPContours = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(matContours);
        }

        private OpenCvSharp.Point getCenterPoint(OpenCvSharp.Point[] pp)
        {
            int totalX = 0, totalY = 0;
            for(int i=0; i<pp.Length; i++)
            {
                totalX += pp[i].X;
                totalY += pp[i].Y;
            }

            return new OpenCvSharp.Point( totalX/pp.Length, totalY/pp.Length );
        }


        private OpenCvSharp.Point projectPerspective(Mat src, Mat canny)
        {
            
            OpenCvSharp.Point[] alignedPoints = Util.getCCWList(findMostOuterBoxCorner(canny));
            int width = (int)distance(alignedPoints[0], alignedPoints[1]);
            int height = (int)distance(alignedPoints[1], alignedPoints[2]);
            
            Point2f[] srcs = new Point2f[4];
            srcs[0] = new Point2f(alignedPoints[0].X, alignedPoints[0].Y);
            srcs[1] = new Point2f(alignedPoints[1].X, alignedPoints[1].Y);
            srcs[2] = new Point2f(alignedPoints[2].X, alignedPoints[2].Y);
            srcs[3] = new Point2f(alignedPoints[3].X, alignedPoints[3].Y);


            Point2f[] dests = new Point2f[4];
            dests[0] = new Point2f(0, 0);
            dests[1] = new Point2f(width, 0);
            dests[2] = new Point2f(width, height);
            dests[3] = new Point2f(0, height);


            Mat perspective = new Mat();
            //CvMat mapMatrix = Cv.GetPerspectiveTransform(srcPoint, dstPoint);
            //Cv.WarpPerspective(src, perspective, mapMatrix, Interpolation.Linear, CvScalar.ScalarAll(0));
            Mat matrix = Cv2.GetPerspectiveTransform(srcs, dests);
            Cv2.WarpPerspective(src, perspective, matrix,  src.Size());


            bitmapPerspective = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(perspective);

            return new OpenCvSharp.Point(width, height);
        }

        

        private Mat findMostOuterbox(Mat src, Mat canny)
        {
            OpenCvSharp.Point[] points = findMostOuterBoxCorner(canny);
            // sorting 등을 해야? x,y 값이 가장 작은게 index 0 이도록, 순서는 유지해야함 (CLOCK WISE <- 이것도 AREA 크기가 0보다 작으면)
            Mat mat = src.Clone();
            for(int i=0; i<points.Length; i++)
            {
                Cv2.Circle(mat, points[i].X, points[i].Y, 3, Scalar.Red, 3);
                Console.WriteLine(points[i].ToString());
            }
            return mat;
            
        }

        private OpenCvSharp.Point[] findMostOuterBoxCorner(Mat canny)
        {
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(canny, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            int maxIndex = 0;
            double maxArea = double.MinValue;
            for (int i = 0; i < contours.Length; i++)
            {
                OpenCvSharp.Point[] p = contours[i];
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                //if (Math.Abs(area) > maxArea)


                if(area> maxArea)
                {
                    maxArea = area;//maxArea = Math.Abs(area);
                    maxIndex = i;
                }
            }
            OpenCvSharp.Point[] p1 = contours[maxIndex];
            double length1 = Cv2.ArcLength(p1, true);

            OpenCvSharp.Point[] pp = Cv2.ApproxPolyDP(p1, 0.02 * length1, true);
            return pp;
        }

        // approxPoly 이걸 적용해서 최외곽 사각형을 찾아보자
        private Mat findContours2(Mat mat)
        {
            Mat matContours = new Mat(new OpenCvSharp.Size(mat.Width, mat.Height), MatType.CV_8UC3);
            matContours.SetTo(Scalar.White);

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(mat, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);
            //Cv2.DrawContours(matContours, new OpenCvSharp.Point[][] { pp }, -1, Scalar.Red, 1);

            int maxIndex = 0;
            double maxArea = double.MinValue;
            for(int i=0; i<contours.Length; i++)
            {
                OpenCvSharp.Point[] p = contours[i];
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                if (length < 100 && area < 1000 || p.Length < 5) continue;                

                //OpenCvSharp.Point[] pp1 = Cv2.ApproxPolyDP(p, 0.02 * length, true);
                //if (pp1.Length == 4)
                //{
                //}
                //Console.WriteLine("111area " + area);

                if (area > maxArea)
                {
                    maxArea = area;
                    maxIndex = i;
                }
            }
            OpenCvSharp.Point[] p1 = contours[maxIndex];
            double length1 = Cv2.ArcLength(p1, true);
            OpenCvSharp.Point[] pp = Cv2.ApproxPolyDP(p1, 0.02 * length1, true);
            Cv2.DrawContours(matContours, new OpenCvSharp.Point[][] { pp }, -1, Scalar.Red, 3);
            Console.WriteLine("length: " + length1);
            Console.WriteLine("area: " + maxArea);
            Console.WriteLine("poly count: " + pp.Length);



            /**
             * 
             */
            int temp = 0;
            foreach (OpenCvSharp.Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                if (length < 100 && area < 1000 || p.Length < 5) continue;
                


                bool convex = Cv2.IsContourConvex(p);
                OpenCvSharp.Point[] hull = Cv2.ConvexHull(p, true);
                // Moments moments = Cv2.Moments(p, false);

                //Cv2.FillConvexPoly(matContours, hull, Scalar.Blue);
                //Cv2.Polylines(matContours, new OpenCvSharp.Point[][] { hull }, true, Scalar.Green, 1);
                Cv2.DrawContours(matContours, new OpenCvSharp.Point[][] { hull }, -1, Scalar.Yellow, 1);
                //Cv2.Circle(matContours, (int)(moments.M10 / moments.M00), (int)(moments.M01 / moments.M00), 5, Scalar.Red, -1);



                OpenCvSharp.Point[] pp1 = Cv2.ApproxPolyDP(p, 0.02 * length, true);
                if (pp1.Length == 4)
                {
                    temp += 1;
                    Cv2.DrawContours(matContours, new OpenCvSharp.Point[][] { pp1 }, -1, Scalar.Green, 1);
                    Console.WriteLine("length: " + length);
                    Console.WriteLine("area: " + area);
                }
            }
            Console.WriteLine("temp " + temp);
            






            return matContours;
        }

        private Mat findContours(Mat mat)
        {
            Mat matContours = new Mat(new OpenCvSharp.Size(mat.Width, mat.Height), MatType.CV_8UC3);
            matContours.SetTo(Scalar.White);

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(mat, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            foreach (OpenCvSharp.Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                double area = Cv2.ContourArea(p, true);

                if (length < 100 && area < 1000 || p.Length < 5) continue;

                Rect boundingRect = Cv2.BoundingRect(p);
                RotatedRect rotatedRect = Cv2.MinAreaRect(p);
                RotatedRect ellipse = Cv2.FitEllipse(p);

                Point2f center;
                float radius;
                Cv2.MinEnclosingCircle(p, out center, out radius);

                Cv2.Rectangle(matContours, boundingRect, Scalar.Red, 2);
                
                //Cv2.Ellipse(matContours, rotatedRect, Scalar.Blue, 2);
                //Cv2.Ellipse(matContours, ellipse, Scalar.Green, 2);
                //Cv2.Circle(matContours, (int)center.X, (int)center.Y, (int)radius, Scalar.Yellow, 2);
            }

            return matContours;
        }

        private void radioButtonMostOuter_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmapMostOuter;
        }

        private void radioButtonPerspective_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmapPerspective;
        }

        private void radioButtonContours_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmapPContours;
        }

        
        private void radioButtonBin_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmapSrc;
        }

        private void radioButtonSrc_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmapBinary;
        }
        private void radioButtonCanny_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmapCanny;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmapContours;
        }

        private static double distance(OpenCvSharp.Point pt1, OpenCvSharp.Point pt2)
        {
            double x = Math.Pow(pt2.X - pt1.X, 2);
            double y = Math.Pow(pt2.Y - pt1.Y, 2);
            double length = Math.Sqrt(x + y);
            //Console.WriteLine(length);
            return length;
        }
    }
}
