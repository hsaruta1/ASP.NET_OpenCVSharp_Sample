using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp.Extensions;

namespace OpenCVSharpSample
{
    public partial class Default : System.Web.UI.Page
    {
        System.Drawing.Bitmap bmp;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            bmp = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(@"./Images/Car.png"); 
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            /*
            using (IplImage src = Cv.LoadImage("./Images/Car.png", LoadMode.Color))
            using (IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 1))
            {
                Cv.CvtColor(src, dst, ColorConversion.BgrToGray);

                using (new CvWindow("src", src))
                using (new CvWindow("dst", dst))
                {
                    Cv.WaitKey();
                }
            }
            */
        }

        protected void GrayScale_Click(object sender, EventArgs e)
        {

            /*
            // Bitmap to IplImage
            //IplImage src = (OpenCvSharp.IplImage)BitmapConverter.ToIplImage(bmp);
            IplImage dst;
            using (dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 1))
            {
                Cv.CvtColor(src, dst, ColorConversion.BgrToGray);
            }

            // IplImage to Bitmap
            System.Drawing.Bitmap bmp = BitmapConverter.ToBitmap(dst);

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            */

            using (IplImage src = Cv.LoadImage("./Images/Car.png", LoadMode.Color))
            using (IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 1))
            {
                Cv.CvtColor(src, dst, ColorConversion.BgrToGray);
                System.Drawing.Bitmap bmp = BitmapConverter.ToBitmap(dst);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                var base64Data = Convert.ToBase64String(ms.ToArray());
                imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            }
        }

        protected void Sobel_Click(object sender, EventArgs e)
        {
            using (IplImage src = Cv.LoadImage("./Images/Car.png", LoadMode.Color))
            using (IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 1))
            {
                Cv.Canny(src, dst, 100, 200, ApertureSize.Size3);

                System.Drawing.Bitmap bmp = BitmapConverter.ToBitmap(dst);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                var base64Data = Convert.ToBase64String(ms.ToArray());
                imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            }
        }

        protected void snooth_Click(object sender, EventArgs e)
        {
            using (IplImage src = Cv.LoadImage("./Images/Car.png", LoadMode.Color))
            using (IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 3))
            {
                //Cv.Smooth(src, dst, SmoothType.Median, 3, 3);
                Cv.Smooth(src, dst, SmoothType.Blur, 3, 3);

                System.Drawing.Bitmap bmp = BitmapConverter.ToBitmap(dst);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                var base64Data = Convert.ToBase64String(ms.ToArray());
                imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            }
        }

        protected void Dilate_Click(object sender, EventArgs e)
        {
            using (IplImage src = Cv.LoadImage("./Images/Car.png", LoadMode.Color))
            using (IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 3))
            {
                Cv.Dilate(src, dst, null, 1);

                System.Drawing.Bitmap bmp = BitmapConverter.ToBitmap(dst);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                var base64Data = Convert.ToBase64String(ms.ToArray());
                imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            }
        }

        protected void Erode_Click(object sender, EventArgs e)
        {
            using (IplImage src = Cv.LoadImage("./Images/Car.png", LoadMode.Color))
            using (IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 3))
            {
                Cv.Erode(src, dst, null, 1);

                System.Drawing.Bitmap bmp = BitmapConverter.ToBitmap(dst);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                var base64Data = Convert.ToBase64String(ms.ToArray());
                imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            }
        }

        protected void Hough_Click(object sender, EventArgs e)
        {
            using (IplImage src = Cv.LoadImage("./Images/Car.png", LoadMode.Color))
            using (IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 3))
            {
                IplImage gray = new IplImage(src.Size, BitDepth.U8, 1);
                src.CvtColor(gray, ColorConversion.BgraToGray);
                IplImage bin = gray.Clone();
                Cv.Threshold(gray, bin, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
                // 輪郭の検出
                CvSeq<CvPoint> contours;
                CvMemStorage storage = new CvMemStorage();
                Cv.FindContours(bin, storage, out contours, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                //輪郭の描画
                Cv.DrawContours(src, contours, new CvScalar(0, 0, 255), new CvScalar(0, 255, 0), 3);


                System.Drawing.Bitmap bmp = BitmapConverter.ToBitmap(src);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                var base64Data = Convert.ToBase64String(ms.ToArray());
                imgCtrl.Src = "data:image/jpg;base64," + base64Data;
            }
        }

        protected void origin_Click(object sender, EventArgs e)
        {
            bmp = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(@"./Images/Car.png");
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            imgCtrl.Src = "data:image/jpg;base64," + base64Data;
        }

    }
}