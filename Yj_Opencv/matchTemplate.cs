using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

using OpenCvSharp;    //添加相应的引用即可
using OpenCvSharp.Extensions;
using ZXing;  // 识别条码类库

namespace Yj_Opencv
{
    class matchTemplate
    {

    }
    public class muban
    {
        public static void muban1()
        {
            Mat mat1=new Mat();

            Mat originalMat = new Mat(@"G:\\pics\4.jpg", ImreadModes.AnyColor);  //母图
            Mat modelMat = new Mat(@"G:\\pics\4.jpg", ImreadModes.AnyColor);      //模板

            Mat resultMat = new Mat();
            resultMat.Create(mat1.Cols - modelMat.Cols + 1, mat1.Rows - modelMat.Cols + 1, MatType.CV_32FC1);  //创建result的模板，就是MatchTemplate里的第三个参数

            Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.SqDiff);//进行匹配(1母图,2模版子图,3返回的result，4匹配模式)
            Point minLocation, maxLocation;
            Cv2.MinMaxLoc(resultMat, out minLocation, out maxLocation);

            Cv2.Rectangle(originalMat, minLocation, new OpenCvSharp.Point(minLocation.X + modelMat.Cols, minLocation.Y + modelMat.Rows), Scalar.Red, 2); //画出匹配的矩
            Cv2.ImShow("母图", originalMat);
            Cv2.ImShow("模板", modelMat);
            Cv2.ImWrite("G:\\pics\\save_pic\\d1.jpg", resultMat);
            Console.ReadLine();
        }



    }

    //public class OpencvHelper
    //{
    //    /// <summary>
    //    /// 灰度图
    //    /// </summary>
    //    /// <param name="srcImage">未处理的mat容器</param>
    //    /// <param name="grayImage">灰度图mat容器</param>
    //    public static void CvGrayImage(Mat srcImage, Mat grayImage)
    //    {
    //        if (srcImage.Channels() == 3)
    //        {
    //            Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGR2GRAY);
    //        }
    //        else
    //        {
    //            grayImage = srcImage.Clone();
    //        }
    //        //Imshow("灰度图", grayImage);
    //    }
    //    /// <summary>
    //    /// 图像的梯度幅值
    //    /// </summary>
    //    /// <param name="grayImage"></param>
    //    public static void CvConvertScaleAbs(Mat grayImage, Mat gradientImage)
    //    {
    //        //建立图像的梯度幅值
    //        Mat gradientXImage = new Mat();
    //        Mat gradientYImage = new Mat();
    //        Cv2.Sobel(grayImage, gradientXImage, MatType.CV_32F, xorder: 1, yorder: 0, ksize: -1);
    //        Cv2.Sobel(grayImage, gradientYImage, MatType.CV_32F, xorder: 0, yorder: 1, ksize: -1);
    //        //Cv2.Scharr(grayImage, gradientXImage, MatType.CV_32F, 1, 0);//CV_16S  CV_32F
    //        //Cv2.Scharr(grayImage, gradientYImage, MatType.CV_32F, 0, 1);
    //        //因为我们需要的条形码在需要X方向水平,所以更多的关注X方向的梯度幅值,而省略掉Y方向的梯度幅值
    //        Cv2.Subtract(gradientXImage, gradientYImage, gradientImage);
    //        //归一化为八位图像
    //        Cv2.ConvertScaleAbs(gradientImage, gradientImage);
    //        //看看得到的梯度图像是什么样子
    //        //Imshow("图像的梯度幅值", gradientImage);
    //    }
    //    /// <summary>
    //    /// 二值化图像
    //    /// </summary>
    //    public static void BlurImage(Mat gradientImage, Mat blurImage, Mat thresholdImage)
    //    {
    //        //对图片进行相应的模糊化,使一些噪点消除
    //        //new OpenCvSharp.Size(12, 12);   (9,9)
    //        Cv2.Blur(gradientImage, blurImage, new OpenCvSharp.Size(6, 6));
    //        //Cv2.GaussianBlur(gradientImage, blurImage, new OpenCvSharp.Size(7, 7), 0);//Size必须是奇数
    //        //模糊化以后进行阈值化,得到到对应的黑白二值化图像,二值化的阈值可以根据实际情况调整
    //        Cv2.Threshold(blurImage, thresholdImage, 210, 255, ThresholdTypes.Binary);
    //        //看看二值化图像
    //        //Imshow("二值化图像", thresholdImage);
    //    }
    //    /// <summary>
    //    /// 闭运算
    //    /// </summary>
    //    public static void MorphImage(Mat thresholdImage, Mat morphImage)
    //    {
    //        //二值化以后的图像,条形码之间的黑白没有连接起来,就要进行形态学运算,消除缝隙,相当于小型的黑洞,选择闭运算
    //        //因为是长条之间的缝隙,所以需要选择宽度大于长度
    //        Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(21, 7));
    //        Cv2.MorphologyEx(thresholdImage, morphImage, MorphTypes.Close, kernel);
    //        //看看形态学操作以后的图像
    //        //Imshow("闭运算", morphImage);
    //    }
    //    /// <summary>
    //    /// 膨胀腐蚀
    //    /// </summary>
    //    public static void DilationErosionImage(Mat morphImage)
    //    {
    //        //现在要让条形码区域连接在一起,所以选择膨胀腐蚀,而且为了保持图形大小基本不变,应该使用相同次数的膨胀腐蚀
    //        //先腐蚀,让其他区域的亮的地方变少最好是消除,然后膨胀回来,消除干扰,迭代次数根据实际情况选择
    //        OpenCvSharp.Size size = new OpenCvSharp.Size(3, 3);
    //        OpenCvSharp.Point point = new OpenCvSharp.Point(-1, -1);
    //        Cv2.Erode(morphImage, morphImage, Cv2.GetStructuringElement(MorphShapes.Rect, size), point, 4);
    //        Cv2.Dilate(morphImage, morphImage, Cv2.GetStructuringElement(MorphShapes.Rect, size), point, 4);
    //        //看看形态学操作以后的图像
    //        //Imshow("膨胀腐蚀", morphImage);
    //    }
    //    /// <summary>
    //    /// 显示处理后的图片
    //    /// </summary>
    //    /// <param name="name">处理过程名称</param>
    //    /// <param name="srcImage">图片盒子</param>
    //    public static void Imshow(string name, Mat srcImage)
    //    {
    //        using (var window = new Window(name, image: srcImage, flags: WindowMode.AutoSize))
    //        {
    //            Cv2.WaitKey(0);
    //        }
    //        //Cv2.ImShow(name, srcImage);
    //        //Cv2.WaitKey(0);
    //    }
    //    /// <summary>
    //    /// 旋转图片
    //    /// </summary>
    //    public static void RotateImage(Mat src, Mat dst, double angle, double scale)
    //    {
    //        var imageCenter = new Point2f(src.Cols / 2f, src.Rows / 2f);
    //        var rotationMat = Cv2.GetRotationMatrix2D(imageCenter, angle, scale);
    //        Cv2.WarpAffine(src, dst, rotationMat, src.Size());
    //    }

    //    /// <summary>
    //    /// 读取图片
    //    /// </summary>
    //    private void DiscernImage()
    //    {
    //        string filename = FileHelper.OpenImageFile();
    //        if (string.IsNullOrEmpty(filename)) return;
    //        Image image = Image.FromFile(filename);
    //        picImage.Image = image;
    //        _imageFilePath = filename;
    //    }

    //    private void OpenCV()
    //    {
    //        if (string.IsNullOrEmpty(_imageFilePath)) return;
    //        Mat srcImage = new Mat(_imageFilePath, ImreadModes.Color);
    //        if (srcImage.Empty()) { return; }

    //        //图像转换为灰度图像
    //        Mat grayImage = new Mat();
    //        OpencvHelper.CvGrayImage(srcImage, grayImage);
    //        ShowImage("灰度图像", grayImage);

    //        //OpencvHelper.RotateImage(grayImage, grayImage, 50, 1);
    //        //OpencvHelper.Imshow("旋转", grayImage);

    //        //建立图像的梯度幅值
    //        Mat gradientImage = new Mat();
    //        OpencvHelper.CvConvertScaleAbs(grayImage, gradientImage);
    //        ShowImage("梯度幅值", gradientImage);

    //        //对图片进行相应的模糊化,使一些噪点消除
    //        Mat blurImage = new Mat();
    //        Mat thresholdImage = new Mat();
    //        OpencvHelper.BlurImage(gradientImage, blurImage, thresholdImage);
    //        ShowImage("二值化", blurImage);

    //        //二值化以后的图像,条形码之间的黑白没有连接起来,就要进行形态学运算,消除缝隙,相当于小型的黑洞,选择闭运算
    //        //因为是长条之间的缝隙,所以需要选择宽度大于长度
    //        Mat morphImage = new Mat();
    //        OpencvHelper.MorphImage(thresholdImage, morphImage);
    //        ShowImage("闭运算", morphImage);

    //        //现在要让条形码区域连接在一起,所以选择膨胀腐蚀,而且为了保持图形大小基本不变,应该使用相同次数的膨胀腐蚀
    //        //先腐蚀,让其他区域的亮的地方变少最好是消除,然后膨胀回来,消除干扰,迭代次数根据实际情况选择
    //        OpencvHelper.DilationErosionImage(morphImage);
    //        ShowImage("膨胀腐蚀", morphImage);


    //        Mat[] contours = new Mat[10000];
    //        List<double> OutArray = new List<double>();
    //        //接下来对目标轮廓进行查找,目标是为了计算图像面积
    //        Cv2.FindContours(morphImage, out contours, OutputArray.Create(OutArray), RetrievalModes.External, ContourApproximationModes.ApproxSimple);
    //        //看看轮廓图像
    //        //Cv2.DrawContours(srcImage, contours, -1, Scalar.Yellow);
    //        //OpencvHelper.Imshow("目标轮廓", srcImage);

    //        //计算轮廓的面积并且存放
    //        for (int i = 0; i < OutArray.Count; i++)
    //        {
    //            OutArray[i] = contours[i].ContourArea(false);
    //        }

    //        List<string> codes = new List<string>();
    //        int num = 0;
    //        while (num < 10) //找出10个面积最大的矩形
    //        {
    //            //找出面积最大的轮廓
    //            double minValue, maxValue;
    //            OpenCvSharp.Point minLoc, maxLoc;
    //            Cv2.MinMaxLoc(InputArray.Create(OutArray), out minValue, out maxValue, out minLoc, out maxLoc);
    //            //计算面积最大的轮廓的最小的外包矩形
    //            RotatedRect minRect = Cv2.MinAreaRect(contours[maxLoc.Y]);
    //            //找到了矩形的角度,但是这是一个旋转矩形,所以还要重新获得一个外包最小矩形
    //            Rect myRect = Cv2.BoundingRect(contours[maxLoc.Y]);
    //            //将扫描的图像裁剪下来,并保存为相应的结果,保留一些X方向的边界,所以对rect进行一定的扩张
    //            myRect.X = myRect.X - (myRect.Width / 20);
    //            myRect.Width = (int)(myRect.Width * 1.1);

    //            //TermCriteria termc = new TermCriteria(CriteriaType.MaxIter, 1, 1);
    //            //Cv2.CamShift(srcImage, myRect, termc);

    //            //一次最大面积的
    //            var a = contours.ToList();
    //            a.Remove(contours[maxLoc.Y]);
    //            contours = a.ToArray();
    //            OutArray.Remove(OutArray[maxLoc.Y]);

    //            string code = DiscernBarCode(srcImage, myRect);
    //            if (!string.IsNullOrEmpty(code))
    //            {
    //                //Cv2.Rectangle(srcImage, myRect, new Scalar(0, 255, 255), 3, LineTypes.AntiAlias);
    //                codes.Add(code);
    //            }
    //            Cv2.Rectangle(srcImage, myRect, new Scalar(0, 255, 255), 3, LineTypes.AntiAlias);
    //            num++;
    //            if (contours.Count() <= 0)
    //                break;
    //        }
    //        Image img2 = CreateImage(srcImage);
    //        picFindContours.Image = img2;
    //        txtcodess.Text = string.Join("\r\n", codes);
    //        ////找出面积最大的轮廓
    //        //double minValue, maxValue;
    //        //OpenCvSharp.Point minLoc, maxLoc;
    //        //Cv2.MinMaxLoc(InputArray.Create(OutArray), out minValue, out maxValue, out minLoc, out maxLoc);
    //        ////计算面积最大的轮廓的最小的外包矩形
    //        //RotatedRect minRect = Cv2.MinAreaRect(contours[maxLoc.Y]);
    //        ////为了防止找错,要检查这个矩形的偏斜角度不能超标
    //        ////如果超标,那就是没找到
    //        //if (minRect.Angle < 2.0)
    //        //{
    //        //    //找到了矩形的角度,但是这是一个旋转矩形,所以还要重新获得一个外包最小矩形
    //        //    Rect myRect = Cv2.BoundingRect(contours[maxLoc.Y]);
    //        //    //把这个矩形在源图像中画出来
    //        //    //Cv2.Rectangle(srcImage, myRect, new Scalar(0, 255, 255), 3, LineTypes.AntiAlias);
    //        //    //看看显示效果,找的对不对
    //        //    //Imshow("裁剪图片", srcImage);
    //        //    //将扫描的图像裁剪下来,并保存为相应的结果,保留一些X方向的边界,所以对rect进行一定的扩张
    //        //    myRect.X = myRect.X - (myRect.Width / 20);
    //        //    myRect.Width = (int)(myRect.Width * 1.1);
    //        //    Mat resultImage = new Mat(srcImage, myRect);
    //        //    //OpencvHelper.Imshow("结果图片", resultImage);
    //        //    Image img = CreateImage(resultImage);
    //        //    picCode.Image = img;
    //        //    DiscernBarcode(img);
    //        //    //看看轮廓图像
    //        //    Cv2.DrawContours(srcImage, contours, -1, Scalar.Red);
    //        //    //把这个矩形在源图像中画出来
    //        //    Cv2.Rectangle(srcImage, myRect, new Scalar(0, 255, 255), 3, LineTypes.AntiAlias);
    //        //    Image img2 = CreateImage(srcImage);
    //        //    picFindContours.Image = img2;

    //        //    //string path = Path.GetDirectoryName(@g_sFilePath) + "\\Ok.png";
    //        //    //if (File.Exists(@path)) File.Delete(@path);//如果文件存在 则删除
    //        //    //if (!Cv2.ImWrite(@path, resultImage))
    //        //}
    //        srcImage.Dispose();
    //    }



    //    private void HandelCode(Mat srcImage, Rect myRect, Mat[] contours)
    //    {
    //        Mat resultImage = new Mat(srcImage, myRect);
    //        Image img = CreateImage(resultImage);
    //        picCode.Image = img;
    //        DiscernBarcode(img);
    //        //看看轮廓图像
    //        Cv2.DrawContours(srcImage, contours, -1, Scalar.Red);
    //        //把这个矩形在源图像中画出来
    //        Cv2.Rectangle(srcImage, myRect, new Scalar(0, 255, 255), 3, LineTypes.AntiAlias);
    //        //Image img2 = CreateImage(srcImage);
    //        //picFindContours.Image = img2;
    //    }

    //    private Image CreateImage(Mat resultImage)
    //    {
    //        byte[] bytes = resultImage.ToBytes();
    //        MemoryStream ms = new MemoryStream(bytes);
    //        return Bitmap.FromStream(ms, true);
    //    }

    //    private void ShowImage(string name, Mat resultImage)
    //    {
    //        //Image img = CreateImage(resultImage);
    //        //frmShowImage frm = new frmShowImage(name, img);
    //        //frm.ShowDialog();
    //    }

    //    /// <summary>
    //    /// 解析条形码图片
    //    /// </summary>
    //    private string DiscernBarCode(Mat srcImage, Rect myRect)
    //    {
    //        try
    //        {
    //            Mat resultImage = new Mat(srcImage, myRect);
    //            Image img = CreateImage(resultImage);
    //            Bitmap pImg = MakeGrayscale3((Bitmap)img);
    //            BarcodeReader reader = new BarcodeReader();
    //            reader.Options.CharacterSet = "UTF-8";
    //            Result result = reader.Decode(new Bitmap(pImg));
    //            Console.Write(result);
    //            if (result != null)
    //                return result.ToString();
    //            else
    //                return "";
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.Write(ex);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// 解析条形码图片
    //    /// </summary>
    //    private void DiscernBarcode(Image primaryImage)
    //    {
    //        //Bitmap pImg = MakeGrayscale3((Bitmap)primaryImage);
    //        picHandel.Image = primaryImage;
    //        BarcodeReader reader = new BarcodeReader();
    //        reader.Options.CharacterSet = "UTF-8";
    //        Result result = reader.Decode(new Bitmap(primaryImage));//Image.FromFile(path)
    //        Console.Write(result);
    //        if (result != null)
    //            txtBarCode.Text = result.ToString();
    //        else
    //            txtBarCode.Text = "";

    //        //watch.Start();
    //        //watch.Stop();
    //        //TimeSpan timeSpan = watch.Elapsed;
    //        //MessageBox.Show("扫描执行时间：" + timeSpan.TotalMilliseconds.ToString());


    //        //using (ZBar.ImageScanner scanner = new ZBar.ImageScanner())
    //        //{
    //        //    scanner.SetConfiguration(ZBar.SymbolType.None, ZBar.Config.Enable, 0);
    //        //    scanner.SetConfiguration(ZBar.SymbolType.CODE39, ZBar.Config.Enable, 1);
    //        //    scanner.SetConfiguration(ZBar.SymbolType.CODE128, ZBar.Config.Enable, 1);

    //        //    List<ZBar.Symbol> symbols = new List<ZBar.Symbol>();
    //        //    symbols = scanner.Scan((Image)pImg);
    //        //    if (symbols != null && symbols.Count > 0)
    //        //    {
    //        //        //string result = string.Empty;
    //        //        //symbols.ForEach(s => result += "条码内容:" + s.Data + " 条码质量:" + s.Type + Environment.NewLine);
    //        //        txtBarCode.Text = symbols.FirstOrDefault().Data;
    //        //    }
    //        //    else
    //        //    {
    //        //        txtBarCode.Text = "";
    //        //    }
    //        //}
    //    }

    //    /// <summary>
    //    /// 处理图片灰度
    //    /// </summary>
    //    /// <param name="original"></param>
    //    /// <returns></returns>
    //    public static Bitmap MakeGrayscale3(Bitmap original)
    //    {
    //        //create a blank bitmap the same size as original
    //        Bitmap newBitmap = new Bitmap(original.Width, original.Height);
    //        //get a graphics object from the new image
    //        Graphics g = Graphics.FromImage(newBitmap);
    //        //create the grayscale ColorMatrix
    //        System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
    //           new float[][]
    //          {
    //             new float[] {.3f, .3f, .3f, 0, 0},
    //             new float[] {.59f, .59f, .59f, 0, 0},
    //             new float[] {.11f, .11f, .11f, 0, 0},
    //             new float[] {0, 0, 0, 1, 0},
    //             new float[] {0, 0, 0, 0, 1}
    //          });
    //        //create some image attributes
    //        ImageAttributes attributes = new ImageAttributes();
    //        //set the color matrix attribute
    //        attributes.SetColorMatrix(colorMatrix);
    //        //draw the original image on the new image
    //        //using the grayscale color matrix
    //        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
    //           0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
    //        //dispose the Graphics object
    //        g.Dispose();
    //        return newBitmap;
    //    }
    //}

    //微信公众号 opencvsharp 代码练习 os_tra
    public class os_tra
    {
        public static void cv_01()  //图像创建 显示 保存
        {
            Mat img = new Mat(@"G:\\pics\\4.jpg", ImreadModes.Color);
            Cv2.ImShow("Demo", img);
            Cv2.WaitKey(); // 填数字代表毫秒,保证图片一直显示
            Cv2.ImWrite("G:\\pics\\save_pic\\s1.jpg", img);
        }
        public static void cv_02()  //图像叠加
        {
            // 例一
            Mat img1 = new Mat("G:\\pics\\1.jpg",ImreadModes.Color);
            //Mat img2 = img1.CvtColor(ColorConversionCodes.BGR2GRAY);  //二值化
            Rect rectROI = new Rect(200, 200, 100, 100); // 使用rect确定区域，矩形左上角的点（x,y），宽高（width,height）
            Mat imgROI = new Mat(img1, rectROI); // 截取img1中rectroi标示的矩形位置,生成图片大小为矩形大小
            Rect rect1 = new Rect(0, 0, imgROI.Cols, imgROI.Rows); // 新建一个矩形，和imgroi一样大
            Mat pos = new Mat(img1, rect1); //截取img1上rect1位置的图像
            imgROI.CopyTo(pos); // 将rectroi区域内的图像叠加到目标位置
            Console.Write(img1.Height+"\t");  //高度 375像素  宽度 500像素
            Console.Write(img1.Width);  // 在windows应用程序输出类型下无法显示
            Cv2.ImShow("demo", img1);
            //Cv2.ImShow("ROI", imgROI); //和下方图片一致
            Cv2.ImShow("rect1", pos); 
            //Cv2.ImShow("demo1", img2);  //显示灰度图
            Cv2.WaitKey();
            Cv2.ImWrite("G:\\pics\\save_pic\\s2.jpg", pos);
            Cv2.ImWrite("G:\\pics\\save_pic\\s3.jpg", img1);

            // 例二
            Mat img2 = new Mat(@"G:\\pics\\save_pic\\s2.jpg", ImreadModes.AnyColor);  // 读取贴图
            Mat mask = img2.CvtColor(ColorConversionCodes.BGR2GRAY);  //贴图转化为灰度图
            Cv2.Threshold(mask, mask, 125, 255, ThresholdTypes.BinaryInv);  //灰度图二值化，125以上变为黑色，其他白色
            Rect rect = new Rect(0, 0, img2.Cols, img2.Rows);    //目标图片的复制位置
            Mat pos1 = new Mat(img1, rect);
            img2.CopyTo(pos1, mask);  //忽略掩模黑色区域
            Cv2.ImShow("mask", mask);
            Cv2.ImShow("effect_img", img1);
            Cv2.WaitKey();
            
            //跟例一的结果没什么区别，就不保存图片了
        }
        public static void cv_03()  // 图像翻转 绘字 圆 线 矩形
        {
            // 1.图像翻转
            Mat dst = new Mat();
            Mat src = new Mat(@"G:\\pics\\2.jpg", ImreadModes.Color);

            Cv2.Flip(src, dst, FlipMode.X);  // X 垂直翻转 Y 水平翻转 XY 水平垂直翻转
            Cv2.ImShow("src", src);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();

            // 2.绘字
            Cv2.PutText(src,  // 绘字的图像
                "CuiRu",  // 内容
                new Point(30, 220),  //  字的左下角位置
                HersheyFonts.HersheyDuplex,  //  字体
                8, //  字的大小
                Scalar.Red);  //  字色 
            Cv2.ImShow("put_text", src);
            Cv2.WaitKey();
            Cv2.ImWrite("G:\\pics\\save_pic\\s4.jpg", src);

            // 3.圆
            Cv2.Circle(src,  // 目标图片
                new Point(400, 350),   // 圆心
                180,  // 半径
                Scalar.PowderBlue,  //  线色
                -1);  // -1为实心 数值为线宽
            Cv2.ImShow("circle", src);
            Cv2.WaitKey();

            // 4.线
            Cv2.Line(src,  // 目标图像
                new Point (250, 150),  // 线段起始点
                new Point (250, 550),  // 终点
                Scalar.Peru,  // 线色
                6);  // 线宽
            Cv2.ImShow("src", src);
            Cv2.WaitKey();

            // 5.矩形
            Rect rect = new Rect(200, 200, 300, 180);
            Cv2.Rectangle(src,  // 目标图像
                rect,  // 矩形位置
                Scalar.Beige,  // 线色
                5);  // 线宽
            Cv2.ImShow("rect", src);
            Cv2.WaitKey();

            Cv2.ImWrite("G:\\pics\\save_pic\\s5.jpg", src);

        }
        public static void cv_04()  // 操作像素点 读写
        {
            // 1.单通道灰度图  写 
            Mat img1 = new Mat(@"G:\\pics\\3.jpg", ImreadModes.Grayscale);
            char black = Convert.ToChar(0);
            //img1.Set(Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox1.Text), black);
            Cv2.ImShow("img1", img1);
            Cv2.WaitKey();

            // 2.三通道彩色图  写
            Mat img2 = new Mat(@"G:\\pics\\3.jpg", ImreadModes.AnyColor);
            Vec3b black1 = new Vec3b(0, 0, 0);     //3 个char，对应BGR
            //img2.Set(Convert.ToInt16(textBox4.Text), Convert.ToInt16(textBox5.Text), black);  //指定行、列，并设置成指定颜色
            Cv2.ImShow("img2", img2);
            Cv2.WaitKey();

            // 3.单通道灰度图  读 
            Mat img3 = new Mat(@"G:\\pics\\3.jpg", ImreadModes.Grayscale); //读取图像为灰度图
            byte color = (byte)Math.Abs(img3.Get<byte>(200, 200) - 100);//读取原来的通道值并减100
            img3.Set(200, 200, color);
            Cv2.ImShow("img3", img3);
            Cv2.WaitKey();

            // 4.三通道彩色图  读
            Mat img4 = new Mat(@"G:\\pics\\3.jpg", ImreadModes.AnyColor); //读取图像为彩色图
            Vec3b color1 = new Vec3b();//新建vec3b的对象,
            color1.Item0 = (byte)Math.Abs(img4.Get<Vec3b>(200, 200).Item0 - 50);//读取原来的通道值并减50
            color1.Item1 = (byte)Math.Abs(img4.Get<Vec3b>(200, 200).Item1 - 50);//读取原来的通道值并减50
            color1.Item2 = (byte)Math.Abs(img4.Get<Vec3b>(200, 200).Item2 - 50);//读取原来的通道值并减50
            img4.Set(200, 200, color);
            Cv2.ImShow("img13", img4);
            Cv2.WaitKey();

        }
        public static void cv_05()  // 模板匹配 
        {
            Mat originalMat = new Mat(@"G:\pics\1.jpg", ImreadModes.AnyColor);  //母图
            Mat modelMat = new Mat(@"G:\pics\save_pic\s2.jpg", ImreadModes.AnyColor);      //模板
            Mat resultMat = new Mat();  // 匹配结果
            
            //resultMat.Create(mat1.Cols - modelMat.Cols + 1, mat1.Rows - modelMat.Cols + 1, MatType.CV_32FC1);//创建result的模板，就是MatchTemplate里的第三个参数

            Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.SqDiff);//进行匹配(1母图,2模版子图,3返回的result，4匹配模式)
            OpenCvSharp.Point minLocation, maxLocation, matchLocation;
            Cv2.MinMaxLoc(resultMat, out minLocation, out maxLocation);
            matchLocation = maxLocation;
            Mat mask = originalMat.Clone();

            Cv2.Rectangle(mask, minLocation, new OpenCvSharp.Point(minLocation.X + modelMat.Cols, minLocation.Y + modelMat.Rows), Scalar.Green, 2); //画出匹配的矩
            Cv2.ImShow("mask", mask);
            //Cv2.ImShow("模板", modelMat);
            Cv2.WaitKey();
            Cv2.ImWrite(@"G:\pics\\save_pic\\s6.jpg", originalMat);

        }
        public static void cv_06()  // 边缘轮廓的检测/查找 
        {
            Mat srcImage = Cv2.ImRead(@"G:\\pics\\123.jpg", ImreadModes.Color);
            Mat src_gray = new Mat();
            Cv2.CvtColor(srcImage, src_gray, ColorConversionCodes.RGB2GRAY);//转换为灰度图
            Cv2.Blur(src_gray, src_gray, new OpenCvSharp.Size(2, 2));     //滤波

            Mat canny_Image = new Mat();
            Cv2.Canny(src_gray, canny_Image, 100, 200);      //Canny边缘检测

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchly;
            Cv2.FindContours(canny_Image, out contours, out hierarchly, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, new OpenCvSharp.Point(0, 0));   //获得轮廓

            Mat dst_Image = Mat.Zeros(canny_Image.Size(), srcImage.Type());  // 图片像素值归零
            Random rnd = new Random();
            for (int i = 0; i < contours.Length; i++)
            {
                Scalar color = new Scalar(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                Cv2.DrawContours(dst_Image, contours, i, color, 2, LineTypes.Link8, hierarchly);       //画出轮廓
            }
            //return dst_Image;   //返回结果
            Cv2.ImShow("dst_Image", dst_Image);
            Cv2.ImShow("canny_Image", canny_Image);
            Cv2.WaitKey();
            //return canny_Image;   
        }
        public static void cv_07()  // 透视变换（视角变换）
        {
            //透视变换(Perspective Transformation)是将图片投影到一个新的视平面(ViewingPlane)，也称作投影映射(Projective Mapping)。
            //透视变换不能保证物体形状的“平行性”。
            //仿射变换保证物体形状的“平直性”和“平行性”。仿射变换是透视变换的特殊形式。仿射变换包括旋转，平移，缩放等。
            Mat srcImage = Cv2.ImRead(@"G:\\pics\\123.jpg");        //读取待变换图 
            Mat dstImage = new Mat();

            var srcPoints = new Point2f[]       //指定变换前的四角点
            {
                 new Point2f(500,450),   //手工测量的坐标位置，实际使用中可以通过鼠标获取
                 new Point2f(3300,505),
                 new Point2f(190,1945),
                 new Point2f(3660,1900),
            };

            var dstPoints = new Point2f[]        ////指定变换后的四角点
            {
                new Point2f(173, 265),
                new Point2f(3300, 265),
                new Point2f(189, 1945),
                new Point2f(3300, 1945),
            };

            Mat TransformMatrix = Cv2.GetPerspectiveTransform(srcPoints, dstPoints);      //根据变换前后四个角点坐标,计算变换矩阵

            Cv2.WarpPerspective(srcImage, dstImage, TransformMatrix, srcImage.Size());   //透视变换函数

            Cv2.ImShow("原始图", srcImage);
            Cv2.ImShow("透视图", dstImage);
            Cv2.WaitKey();

            //Cv2.ImWrite("srcImage.jpg", srcImage);
            //Cv2.ImWrite("dstImage.jpg", dstImage);


        }
        public static void cv_08()  // 仿射变换 Cv2.WarpAffine（）
        {
            Mat srcImage = Cv2.ImRead(@"G:\\pics\\2.jpg");
            Cv2.ImShow("src", srcImage);

            Mat grayImage = new Mat();
            Mat binaryImage = new Mat();
            Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(grayImage, binaryImage, 20, 150, ThresholdTypes.Binary);//转换为二值图像
            Cv2.ImShow("二值化图", binaryImage);

            OpenCvSharp.Point[][] contours;   //创建存储轮廓的数组
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(binaryImage, out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxNone);  //从二值图中检索轮廓，参数：1，寻找轮廓的图像；2，返回轮廓数组；4，轮廓的检索模式5，轮廓近似模式

            RotatedRect[] outRect = new RotatedRect[contours.Length];   //创建存储外接矩形的数组
            OpenCvSharp.Point[][] contours_poly = new OpenCvSharp.Point[contours.Length][];
            for (int i = 0; i < contours.Length; i++)
            {
                contours_poly[i] = Cv2.ApproxPolyDP(contours[i], 10, true);//Cv2.ApproxPolyDP()对指定的点集进行多边形逼近的函数；参数：1，输入的点集；2，指定的精度，也即是原始曲线与近似曲线之间的最大距离；3，若为true，则说明近似曲线是闭合的；反之，若为false，则断开。

                outRect[i] = Cv2.MinAreaRect(contours_poly[i]);//最小外接矩形集合

                Point2f[] pot = new Point2f[4];//新建点集合接收点集合

                float angle = outRect[i].Angle;//矩形角度
                pot = outRect[i].Points();//矩形的4个角点
                double line1 = Math.Sqrt((pot[0].X - pot[1].X) * (pot[0].X - pot[1].X) + (pot[0].Y - pot[1].Y) * (pot[0].Y - pot[1].Y));
                double line2 = Math.Sqrt((pot[0].X - pot[3].X) * (pot[0].X - pot[3].X) + (pot[0].Y - pot[3].Y) * (pot[0].Y - pot[3].Y));
                if (line1 * line2 < 1000)//过滤太小的矩形
                {
                    continue;
                }
                if (line1 > line2)//依据实际情况进行判断
                {
                    angle += 90;
                }

                Mat Roi = new Mat(srcImage.Size(), MatType.CV_8UC3);
                Roi.SetTo(0);//设置黑像素

                Cv2.DrawContours(binaryImage, contours, -1, Scalar.White, -1);//在二值化图像中画出轮廓区域并染白
                Cv2.ImShow("bin", binaryImage);

                srcImage.CopyTo(Roi, binaryImage);//将原图通过掩码抠图到Roi
                Cv2.ImShow("Roi", Roi);

                Mat afterRotato = new Mat(srcImage.Size(), MatType.CV_8UC3);
                afterRotato.SetTo(0);
                Point2f center = outRect[i].Center;
                Mat matrixWarpAffine = Cv2.GetRotationMatrix2D(center, angle, 1);//计算变换矩阵，参数：1，旋转中心点；2，旋转的角度，正值是逆时针，负值是顺时针；3，缩放因子
                Cv2.WarpAffine(Roi, afterRotato, matrixWarpAffine, Roi.Size(), InterpolationFlags.Linear, BorderTypes.Constant);//得到变换后的图像，滤除其他信息
                Cv2.ImShow("仿射变换旋转后", afterRotato);
                Cv2.WaitKey();
            }

        }
        public static void cv_09()  // 图像的滤波处理：均值滤波/高斯滤波/中值滤波
        {
            //  滤波作用：在进行图像处理之前的预处理，降低图像的噪点，提高图像的平滑度。
            //  中值滤波是取卷积计算的中间值，中值滤波的好处是对图像的椒盐噪声有很好的抑制作用，因为图像的椒盐噪点，是图像某一片区域像素的极大值或者极小值，使用中值滤波可以过滤掉这些噪点，同时它可以保护图像尖锐的边缘，选择适当的点来替代污染点的值，所以处理效果好。
            //  高斯滤波也叫高斯模糊，高斯平滑。对图像邻域内像素进行平滑时，邻域内不同位置的像素被赋予不同的权值，对图像进行平滑的同时，同时能够更多的保留图像的总体灰度分布特征。
            //  均值滤波是把每个像素都用周围的N个像素来做均值操作，幅值近似相等且随机分布在不同位置上，这样可以平滑图像，速度较快，算法简单。但是无法去掉噪声，只能微弱的减弱它。

            Mat src_img = Cv2.ImRead(@"G:\\pics\\5.jpg");

            Mat meanBlur = new Mat();
            Mat gaussBlur = new Mat();
            Mat medianBlur = new Mat();

            Cv2.Blur(src_img, meanBlur, new OpenCvSharp.Size(15, 15), new OpenCvSharp.Point(-1, -1));  //均值模糊。参数：1，输入；2，输出；3，卷积核；4，卷积核中心点位置
            Cv2.GaussianBlur(src_img, gaussBlur, new OpenCvSharp.Size(15, 15), 11, 11);   //高斯模糊。参数：1，输入；2，输出；3，卷积核，为正奇数；4，X方向上高斯核标准偏差；5，Y方向上高斯核标准偏差
            Cv2.MedianBlur(src_img, medianBlur, 15);   //中值滤波。参数：1，输入；2，输出；3，卷积核，大于1的奇数

            Cv2.ImShow("src_img", src_img);
            Cv2.ImShow("meanBlur", meanBlur);
            Cv2.ImShow("gaussBlur", gaussBlur);
            Cv2.ImShow("medianBlur", medianBlur);
            Cv2.WaitKey();
        }
        public static void cv_10()  // 边缘检测系列之 Sobel算子​
        {
            //  Sobel算子是像素图像边缘检测中最重要的算子之一
            //  Sobel算子是一个离散微分算子（discrete differentiation operator），用来计算图像灰度的近似值
            //  Sobel算子功能集合了高斯平滑和微分求导
            //  又被称为一阶微分算子，求导算子，在水平和垂直两个方向上求导，得到图像X方向和Y方向的梯度图像。
            //  Sobel算子是基于权重比，来扩大像素之间的差异，从而更好的寻找边缘。下面两个矩阵都是对称的
            Mat src_img = Cv2.ImRead(@"G:\\pics\\4.jpg");

            Mat dst = new Mat();
            Cv2.GaussianBlur(src_img, dst, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Default);   //高斯平滑，Sobel算子对噪声较敏感，可先进行降噪

            Mat grayImage = new Mat();
            Cv2.CvtColor(dst, grayImage, ColorConversionCodes.BGR2GRAY);   //转换为灰度图

            Mat X = new Mat();
            Mat Y = new Mat();
            Cv2.Sobel(grayImage, X, MatType.CV_16S, 1, 0, 3);  //Sobel边缘查找，参数：1，输入；2，输出X方向梯度图像；3，输出图像的深度；4，X方向几阶导数；5，Y方向几阶导数；6，卷积核大小，必须为奇数。
            Cv2.Sobel(grayImage, Y, MatType.CV_16S, 0, 1, 3);   //输出Y方向梯度图像

            Cv2.ConvertScaleAbs(X, X);//缩放、计算绝对值并将结果转换为8位，显示图相只能是8U类型
            Cv2.ConvertScaleAbs(Y, Y);

            Cv2.ImShow("src_img", src_img);
            Cv2.ImShow("X方向梯度图", X);
            Cv2.ImShow("Y方向梯度图", Y);

            int width = X.Cols;
            int hight = Y.Rows;
            Mat output = new Mat(X.Size(), X.Type());

            for (int x = 0; x < hight; x++)    //合并X和Y,G= (Gx*Gx +Gy*Gy)的开平方根
            {
                for (int y = 0; y < width; y++)
                {
                    int xg = X.At<byte>(x, y);
                    int yg = Y.At<byte>(x, y);

                    double v1 = Math.Pow(xg, 2);   //平方
                    double v2 = Math.Pow(yg, 2);
                    int val = (int)Math.Sqrt(v1 + v2);    //开平方根
                    if (val > 255) //确保像素值在 0至255之间
                    {
                        val = 255;
                    }
                    if (val < 0)
                    {
                        val = 0;
                    }
                    byte xy = (byte)val;
                    output.Set<byte>(x, y, xy);
                }
            }
            Cv2.ImShow("outputX+Y", output);
            Cv2.WaitKey();

        }
        public static void cv_11()  // 边缘检测系列之 Laplacian算子
        {
            //Sobel 算子进行一阶求导，得到边缘像素是最大值（最高点）。
            //这是基于：在边缘区域中，像素强度显示出“跳跃”或强度的高度变化。
            //获得强度的一阶导数，我们观察到边缘的特征是最大值。
            //Laplace算子是进行二阶求导，从图上观察到二阶导数为零。
            //因此，我们也可以使用此标准来尝试检测图像中的边缘。
            //但请注意，零不仅会出现在边缘（它们实际上可能出现在其他无意义的位置）;
            //这可以通过在需要时应用过滤来解决。
            //Laplacian 算子对噪声比较敏感，所以图像一般先经过平滑处理。 
            Mat srcImg = Cv2.ImRead(@"G:\\pics\\3.jpg");
            Mat LaplacianImg = new Mat();

            Mat gussImage = new Mat();
            Cv2.GaussianBlur(srcImg, gussImage, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Default);    //高斯模糊

            Mat grayImage = new Mat();
            Cv2.CvtColor(gussImage, grayImage, ColorConversionCodes.RGB2GRAY);   //灰度图

            Cv2.Laplacian(grayImage, LaplacianImg, -1, 3); //Laplacian运算， 计算二阶导数。参数：1，源图像；2，输出图像；3，目标图像的所需深度 默认填 -1，与源图一致；4，用于计算二阶导数滤波器的卷积核大小，需奇数。

            Cv2.ConvertScaleAbs(LaplacianImg, LaplacianImg);  ////缩放、计算绝对值并将结果转换为8位，显示图相只能是8U类型

            Cv2.ImShow("srcImg", srcImg);
            Cv2.ImShow("gussImage", gussImage);
            Cv2.ImShow("dstImg", LaplacianImg);

            Cv2.WaitKey();

        }
        public static void cv_12()  // 边缘检测系列之 Canny算子
        {
            //Canny算法中，先在 X 和 Y 方向求得一阶导数，
            //然后将它们组合成4个方向 的导数。
            //其中方向导数是局部最大值的点是组成边缘的候选项。
            //Canny算法最明显的创新，就是将单个的边缘候选像素加入轮廓。

            Mat srcImg = Cv2.ImRead(@"G:\\pics\\6.jpg");
            Mat CannyImg = new Mat();

            Mat gussImage = new Mat();
            Cv2.GaussianBlur(srcImg, gussImage, new OpenCvSharp.Size(3, 3), 0, 0, BorderTypes.Default);    //高斯模糊

            Mat grayImage = new Mat();
            Cv2.CvtColor(gussImage, grayImage, ColorConversionCodes.RGB2GRAY);   //灰度图

            Cv2.Canny(grayImage, CannyImg, 50, 150, 3, true);
            //cannny算子。参数：1，8 bit 输入图像；2，输出边缘图像，一般是二值图像，背景是黑色；
            //3，低阈值。值越大，找到的边缘越少；4，高阈值；5，表示应用Sobel算子的孔径大小，其有默认值3；6，计算图像梯度幅值的标识，有默认值false。
            //低于阈值1的像素点会被认为不是边缘；
            //高于阈值2的像素点会被认为是边缘；
            //在阈值1和阈值2之间的像素点,若与一阶偏导算子计算梯度得到的边缘像素点相邻，则被认为是边缘，否则被认为不是边缘。

            Cv2.ImShow("srcImg", srcImg);
            Cv2.ImShow("gussImage", gussImage);
            Cv2.ImShow("CannyImg", CannyImg);

            Cv2.WaitKey();


        }
        public static void cv_13()  // 霍夫变换之 直线检测
        {
            //霍夫变换(Hough)是一个非常重要的检测间断点边界形状的方法。
            //它通过将图像坐标空间变换到参数空间，来实现直线与曲线的拟合。
            //也是图像处理中从图像中识别几何形状的基本方法之一（如，直线，圆等）

            Mat src = new Mat(@"G:\\pics\\3.jpg", ImreadModes.Color);

            //Cv2.Resize(src,src, new OpenCvSharp.Size(src.Width*2, src.Height*2)); //重新调整尺寸

            Cv2.ImShow("src", src);
            Mat gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);   //转灰度图

            Mat thresholdImage = new Mat();
            Cv2.Threshold(gray, thresholdImage, 100, 255, ThresholdTypes.Binary);//阈值二值化
            Cv2.ImShow("thresholdImage", thresholdImage);

            //此处可以添加一些形态学处理，对图形进行修补

            Mat cannyImage = new Mat();
            Cv2.Canny(thresholdImage, cannyImage, 20, 50, 3);      //canny边缘检测
            Cv2.ImShow("cannyImage", cannyImage);

            LineSegmentPoint[] lineSegmentPoint;
            lineSegmentPoint = Cv2.HoughLinesP(cannyImage, 1.0, Cv2.PI / 180, 200, 50, 20);
            /*使用概率霍夫变换查找二进制图像中的线段。最终输出的是直线的两个点坐标,返回值类型：LineSegmentPoint[]
            参数：1，输入图像，8位、单通道、二进制源图像。
                 2，累加器的距离分辨率(以像素为单位)，(生成极坐标时的像素扫描的步长)
                   3，累加器的角度分辨率(以弧度为单位) （生成极坐标的角度步长，一般为 1°）
                   4，阈值参数，只有获取足够交点的极坐标才能看作直线
                   5，最小线长度。比这短的线段将被拒绝。[默认值为0]
                   6，同一条线上的点之间连接它们的最大允许间隙。[默认值为0]
               */

            Cv2.CvtColor(cannyImage, cannyImage, ColorConversionCodes.GRAY2BGR);  //转换为BGR图，为后面输出彩线
            for (int i = 0; i < lineSegmentPoint.Length; i++)
            {
                //Cv2.Line(cannyImage,lineSegmentPoint[i].P1, lineSegmentPoint[i].P2, Scalar.RandomColor(), 1);   //依据点集画线
                Cv2.Line(cannyImage, lineSegmentPoint[i].P1, lineSegmentPoint[i].P2, Scalar.Red, 1);   //依据点集画线
            }
            Cv2.ImShow("dst", cannyImage);
            Cv2.WaitKey();

        }
        public static void cv_14()  // 霍夫变换之 圆检测
        {
            Mat src = new Mat(@"G:\\pics\\6.jpg", ImreadModes.Color);
            Cv2.ImShow("src", src);

            //此处可以使用二值化，对图形进行预处理

            Mat blurImg = new Mat();
            Cv2.MedianBlur(src, blurImg, 5);   //中值滤波去噪声
            Cv2.ImShow("blurImg", blurImg);

            Mat grayImg = new Mat();
            Cv2.CvtColor(blurImg, grayImg, ColorConversionCodes.BGR2GRAY);   //转灰度图

            CircleSegment[] circleSegment;
            circleSegment = Cv2.HoughCircles(grayImg, HoughMethods.Gradient, 1, 80, 70, 30, 10, 200);
            //霍夫圆检测：使用霍夫变换查找灰度图像中的圆。
            /*
            * 参数：
            *      1：输入参数：8位、单通道、灰度输入图像
            *      2：实现方法
            *      3: dp     :累加器分辨率与图像分辨率的反比。默认=1
            *      4：minDist: 检测到的圆的中心之间的最小距离。
            *      5:param1:   第一个方法特定的参数。[默认值是100]canny边缘检测阈值低
            *      6:param2:   第二个方法特定于参数。[默认值是100]中心点累加器阈值 – 候选圆心
            *      7:minRadius: 最小半径
            *      8:maxRadius: 最大半径
            */
            Mat dstImg = new Mat();
            blurImg.CopyTo(dstImg);
            for (int i = 0; i < circleSegment.Count(); i++)
            {
                //画圆
                Cv2.Circle(dstImg, (int)circleSegment[i].Center.X, (int)circleSegment[i].Center.Y, (int)circleSegment[i].Radius, new Scalar(0, 0, 255), 2, LineTypes.AntiAlias);
                //加强圆心显示
                Cv2.Circle(dstImg, (int)circleSegment[i].Center.X, (int)circleSegment[i].Center.Y, 3, new Scalar(0, 0, 255), 2, LineTypes.AntiAlias);
            }

            Cv2.ImShow("dstImg", dstImg);

            Cv2.WaitKey();

        }
        public static void cv_15()  // 形态学系列之 腐蚀/膨胀
        {
            //膨胀原理：跟卷积操作相似，假设有图像A和结构元素B，结构元素B在A上面移动，其中B定义其中心点为锚点，计算B覆盖下A的最大像素值用来替换锚点的像素，其中结构体B可以是任意形状。
            //腐蚀原理：腐蚀与膨胀的操作的过程一样，不同的是以最小值替换锚点重叠下的像素值。
            //Cv2.GetStructuringElement(): 获取结构元素
            //Cv2.Dilate(): 膨胀，通过使用特定的结构元素来扩展图像。
            //Cv2.Erode(): 腐蚀，通过使用特定的结构元素来侵蚀图像。

            Mat src = new Mat(@"G:\\pics\7.jpg", ImreadModes.Color);
            Cv2.ImShow("src", src);

            int size = 5; //要为奇数
            Mat structuringElement = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(size, size), new OpenCvSharp.Point(-1, -1));
            /* 参数     1，MorphShapes shape   结果元素的形状
                       2，Size ksize  结构元素的大小
                       3，Point anchor    结构元素的锚点（中心点）
            */

            Mat DilateImg = new Mat();
            Cv2.Dilate(src, DilateImg, structuringElement, new OpenCvSharp.Point(-1, -1), 1);  //膨胀
                                                                                               /*   参数：1，   源图像
                                                                                                        2，   输出图像
                                                                                                        3，   结构元素,奇数
                                                                                                        4，   锚点位置，默认是null
                                                                                                        5，   应用膨胀的次数。[默认情况下这是1]
                                                                                               */

            Mat ErodeImg = new Mat();
            Cv2.Erode(src, ErodeImg, structuringElement, new OpenCvSharp.Point(-1, -1), 1);    //腐蚀
                                                                                               /*   参数：1，源图像
                                                                                                         2，输出图像
                                                                                                         3，结构元素,奇数
                                                                                                         4， 锚点位置，默认是null
                                                                                                         5，应用膨胀的次数。[默认情况下这是1]
                                                                                               */

            Cv2.ImShow("ErodeImg", ErodeImg);
            Cv2.ImShow("DilateImg", DilateImg);
            Cv2.WaitKey();
        }
        public static void cv_16()  // 形态学系列之 开运算/闭运算
        {
            //开运算 Open：先腐蚀后膨胀，可以去掉小的对象。
            //闭运算 Close：先膨胀后腐蚀，可以填充图像的噪点。
            Mat src = new Mat(@"C:\Users\yjj\Pictures\cy\me\106.jpg", ImreadModes.AnyColor);
            Cv2.ImShow("src", src);

            Mat openImg = new Mat();
            Mat closeImg = new Mat();

            InputArray kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(7, 7), new OpenCvSharp.Point(-1, -1));   //结构元素
                                                                                                                                          /* 参数     1，MorphShapesshape    结果元素的形状
                                                                                                                                                  2，Sizeksize  结构元素的大小
                                                                                                                                                      3，Pointanchor结构元素的锚点（中心点）
                                                                                                                                            */

            Cv2.MorphologyEx(src, openImg, MorphTypes.Open, kernel, new OpenCvSharp.Point(-1, -1)); //开运算
                                                                                                    /* 参数     1，源图像
                                                                                                                2, 输出图像
                                                                                                                3, 形态操作类型
                                                                                                                4, 结构数组
                                                                                                                5, 锚点位置（中心点）
                                                                                                                6， 应用腐蚀和膨胀的次数。[默认情况下这是1]
                                                                                                                7， 边缘处理方法
                                                                                                    */
            Cv2.MorphologyEx(src, closeImg, MorphTypes.Close, kernel, new OpenCvSharp.Point(-1, -1)); //闭运算
            Cv2.ImShow("openImg", openImg);
            Cv2.ImShow("closeImg", closeImg);
            Cv2.WaitKey();
        }
        public static void cv_17()  // 形态学系列之 顶帽/黑帽
        {
            //顶帽 Top hat: 原图像与开操作之间的差值操作。
            //黑帽 Black hat: 闭操作图像与原图像的差值图像
            Mat src = new Mat(@"C:\Users\yjj\Pictures\cy\me\99.jpg", ImreadModes.AnyColor);
            Cv2.ImShow("src", src);

            Mat tophatImg = new Mat();
            Mat blackhatImg = new Mat();

            InputArray kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(5, 5), new OpenCvSharp.Point(-1, -1));   //结构元素
                                                                                                                                          /* 参数     1，MorphShapesshape    结果元素的形状
                                                                                                                                                      2，Sizeksize  结构元素的大小
                                                                                                                                                      3，Pointanchor结构元素的锚点（中心点）
                                                                                                                                           */

            Cv2.MorphologyEx(src, tophatImg, MorphTypes.TopHat, kernel, new OpenCvSharp.Point(-1, -1));//顶帽，原图像与开操作之间的差值操作
                                                                                                       /* 参数     1，源图像
                                                                                                               2, 输出图像
                                                                                                                   3, 形态操作类型
                                                                                                                   4, 结构数组
                                                                                                                   5, 锚点位置（中心点）
                                                                                                                   6，应用腐蚀和膨胀的次数。[默认情况下是1]
                                                                                                                   7，边缘处理方法
                                                                                                       */
            Cv2.MorphologyEx(src, blackhatImg, MorphTypes.BlackHat, kernel, new OpenCvSharp.Point(-1, -1));//黑帽，闭操作图像与原图像的差值图像

            Cv2.ImShow("tophatImg", tophatImg);
            Cv2.ImShow("blackhatImg", blackhatImg);
            Cv2.WaitKey();

        }
        public static void cv_18()
        {



        }
    }
}
