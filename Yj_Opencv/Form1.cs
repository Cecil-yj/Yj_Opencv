using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;    //添加相应的引用即可
using OpenCvSharp.Extensions;

/*    汇总知识点:
 *    1.Mat n维稠密数组类，可以等效为图片
      2.enum 枚举，列出所有的元素。 可以用来遍历元素然后自动计数
      3. \r 回车 \n 换行 \t 制表
    

      参考书籍：
      1.opencv的api用法（网址）链接：https://pan.baidu.com/s/1iXLshgX21Y-tVdA-MljTOw   提取码：d31n
     */

namespace Yj_Opencv
{
    public partial class Form1 : Form    // 偏函数 partial
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)  // 上方按钮组的布局框 不写
        {

        }

        private void button1_Click(object sender, EventArgs e)  //打开图片的api
        {
            if (cameraopen == false)  // 摄像头没开
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                //openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog1.InitialDirectory = "G:\\pics";  // 设置打开图片的起始位置

                openFileDialog1.Filter = "JPEG图像(*.jpg)|*.jpg|PNG图像(*.png)|*.png|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != string.Empty)  // 如果文件存在
                {
                    pictureBox1.Load(openFileDialog1.FileName);  //图片框载入图片

                    my_imagesource = openFileDialog1.FileName;  

                    textBox1.AppendText("\r\n打开文件路径：" + openFileDialog1.FileName);
                    textBox1.SelectionStart = this.textBox1.TextLength;
                    textBox1.ScrollToCaret();
                }
                else
                {
                    textBox1.AppendText("\r\n无法打开文件");
                    textBox1.SelectionStart = this.textBox1.TextLength;
                    textBox1.ScrollToCaret();
                }

            }
            else if (cameraopen == true)  // 摄像头打开了
            {
                textBox1.AppendText("\r\n将摄像头关闭后重试！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
        }

        private void button2_Click(object sender, EventArgs e)  //保存图片的api
        {
            if (pictureBox1.Image != null)    // 图片框中有图片
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();  // 新建保存图片的对话框
                //saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

                saveFileDialog1.InitialDirectory = "G:\\pics\\save_pic";  // 设置保存图片的起始位置

                saveFileDialog1.Filter = "JPEG图像(*.jpg)|*.jpg|PNG图像(*.png)|*.png|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*1";
                saveFileDialog1.ShowDialog();  // 显示保存图片的对话框
                if (saveFileDialog1.FileName != string.Empty)   //图片有文件名
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);

                    textBox1.AppendText("\r\n图片已保存至：" + saveFileDialog1.FileName);
                    textBox1.SelectionStart = this.textBox1.TextLength;
                    textBox1.ScrollToCaret();
                }
            }
            else
            {
                textBox1.AppendText("\r\n显示区域暂无图片！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
        }

        private VideoCapture camera;  //声明 摄像头
        public bool cameraopen = false;  // 初始化时 摄像头关闭状态
        private Mat image1; // 定义图1 图2
        private Mat image2;

        private void button3_Click(object sender, EventArgs e) // 打开摄像头的api
        {
            camera = new VideoCapture(0); // 0代表打开电脑摄像头
            cameraopen = true;  //Timer定时器 触发 设置为true，因此触发定时器了

            textBox1.AppendText("\r\n摄像头已打开！");
            textBox1.SelectionStart = this.textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private void button4_Click(object sender, EventArgs e)  // 关闭摄像头的api
        {
            if (cameraopen == true) //摄像头打开
            {
                camera.Dispose(); // 释放摄像头
                cameraopen = false; // 关闭摄像头

                textBox1.AppendText("\r\n摄像头已关闭！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
            else
            {
                textBox1.AppendText("\r\n摄像头不是早就关了吗？！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
        }

        public int timer1_change = 2, timer1_num = 0;   // 2s后进行处理
        private void timer1_Tick(object sender, EventArgs e) // 定时器的功能 //Timer事件产生的最小值不是1毫秒，而是55毫秒，windows系统定时器精度默认是15.625ms
        {
            timer1_num = timer1_num + 1;
            if (cameraopen == true && timer1_num >= timer1_change)  // 摄像头打开后，定义两个空图像，摄像头先读入图1
            {
                timer1_num = 0;   // 然后把图1送到图像操作方法里面去进行处理，得到的图像传给图2

                image1 = new Mat();
                image2 = new Mat();

                camera.Read(image1); // 相机抓取一帧图片传给img1
                image2 = myOPENCV_run(image1, image2);  //运行，得到经过图片处理的输出图片，给img2
                pictureBox1.Image = image2.ToBitmap();  //中间蓝色图片显示框，将mat格式的img2图片转为可显示的位图（jpg、png等）
            }
        }

        private void button5_Click(object sender, EventArgs e)  // 设置相机读取描述 的api 
        {
            Form3 form3 = new Form3();   // 打开表3
            form3.StartPosition = FormStartPosition.CenterScreen;   // 表3显示位置在屏幕中间
            form3.Text = "设置";
            form3.ShowDialog(this);  //表3的对话框所有者为开发者
        }

        private void button6_Click(object sender, EventArgs e)  // 初始化 的api，没写   
        {

        }

        private void button7_Click(object sender, EventArgs e)   // 使用说明 按键 
        {
            MessageBox.Show("若弹出出错消息框，请检查输入图像是否为正确格式！\r\n另有其他错误出现，也很正常。~\r\n本人博客地址:https://blog.csdn.net/weixin_45407668/article/details/100941594", "使用说明", MessageBoxButtons.OK);
        }

        public string my_imagesource, my_imagesource2;  // 定义两个图片，前图是图像处理前，后图是图像处理后 刷新图像操作后得到图片
        private void button8_Click(object sender, EventArgs e)   //刷新图像的api  时就运行程序
        {
            if (my_imagesource != null)  // 图片存在
            {
                image1 = new Mat(my_imagesource);
                image2 = new Mat();

                image2 = myOPENCV_run(image1, image2);//运行，图片传给图像处理操作
                pictureBox1.Image = image2.ToBitmap();//输出图片转换为 位图

                textBox1.AppendText("\r\n图片刷新完成！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
            else
            {
                textBox1.AppendText("\r\n没有图片，无法刷新！");
                textBox1.SelectionStart = this.textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)  // 参数说明 的api
        {
            //调用系统默认的浏览器 
            System.Diagnostics.Process.Start("https://blog.csdn.net/weixin_45407668");
        }

        public uint thisopencvfunction;  //  目前正在操作的图像处理方法

        public bool list_who = false;  // 先令列表中的选项为空
        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)    // 图像操作方法框 的api 定义函数
        {
            list_who = false;  //左边列表框 列表元素为空
            thisopencvfunction = (uint)listBox1.SelectedIndex;//得到选中的功能对应编码，直接在其他窗体引用控件也行
            if (listBox1.SelectedIndex >= 0)  // 添加元素存在
            {
                Form2 form2 = new Form2();   // 生成表2，在屏幕中间位置
                form2.StartPosition = FormStartPosition.CenterScreen;
                form2.Text = listBox1.SelectedItem.ToString();
                form2.ShowDialog(this);
            }
        }

        public void listBox2_SelectedIndexChanged(object sender, EventArgs e)  // 图像处理操作记录 的api 
        {
            list_who = true; //右边列表框 列表元素存在
            thisopencvfunction = (uint)listBox1.SelectedIndex;//得到选中的功能对应编码，直接在其他窗体引用控件也行
            if (listBox2.SelectedIndex >= 0)  //列表框中有元素
            {
                Form2 form2 = new Form2();  //创建表2
                form2.StartPosition = FormStartPosition.CenterScreen;
                form2.Text = listBox2.SelectedItem.ToString();
                form2.ShowDialog(this);  // 将表2的操作加到表1 的右边列表框内
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) // 中间图片框 的api，没写
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e) // 中下文本框 的api，没写
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) // 打开文件 的api 没写
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)  // 保存文件 的api 没写
        {

        }

        public bool thefirstload = false; //初始化为空
        private void Form1_Load(object sender, EventArgs e)  // 加载表1 的api，令初始加载运行
        {
            thefirstload = true;  
        }

        public int[,] myOPENCV_runlist = new int[20, 5];//运行步骤列表 与myOPENCV_value不同的是，运行步骤限定为20步，列的第一个元素存放运行函数下标
        // 二维数组，20行4列，数据类型是整型
        
        public enum MyOPENCV   //方法排排坐写这里面一一对应一个下标
        {
            cvt_color = 0, // 颜色转换
            boxfilter, // 方框滤波
            blur,  //均值滤波
            gaussianblur,  //高斯滤波
            medianblur,  //中值滤波
            bilateralfilter,  // 双边滤波
            dilate,  //膨胀
            erode,  //腐蚀
            morphologyex,  // 高级形态学转换
            floodfill,  //漫水填充
            pyrup,  //尺寸放大
            pyrdown,  //尺寸缩小
            resize,  //尺寸调整
            threshold,  //固定阈值化
            canny,  //边缘检测
            sobel,  //边缘检测
            laplacian,  //边缘检测
            scharr,  //边缘检测
            convertscaleabs,  //图像快速增强
            addweighted,  //图像融合
            houghlines,  //霍夫标准变换
            houghlinep,  //霍夫累计概率变换
            houghcircles,  //霍夫圆变换
            remap,  //重映射
            warpaffine,  //仿射变换
            equalizehist,  //直方图均衡化
            facedetection,  //人脸识别
            matchtemplate,  //匹配模板
            find_draw_contours,  //找出轮廓
            componentdefectdetecting,  // 零件缺陷检测

            //下面的方法没做api

            drawcontours,  //绘制轮廓
            convexhull,  //寻找凸包
            boundingrect,  //返回外部矩形边界
            minarearect,  //寻找最小包围矩形
            minenclosingcircle,  //寻找最小包围圆形
            fillellipse,  //用椭圆拟合二维点集
            approxpolydp,  //逼近多边形曲线
            moments,  //矩的计算
            contourarea,  //计算轮廓面积
            arclength,  //计算轮廓长度
            watershed,  //分水岭算法
            inpaint,  //图像修复
            calchist,  //计算直方图
            minmaxloc,  //寻找最值
            comparehist,  //比较直方图
            calcbackproject,    //反向投影
            cornerharris,       //HARRIS角点检测
            goodfeaturestotrack,    //ST特征检测
            cornersubpix,       //亚像素级角点检测
            drawkeypoints,      //SURF特征点提取
            drawmatches,        //绘制匹配点
            ORB,        // ORB特征提取


            number  //用于统计总数 ，没使用
        };

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // 主要内容，图像处理方法的api
        private Mat myOPENCV_run(Mat image_in, Mat image_out)
        {
            image_out = image_in;  // 入图传给出图
            for (int i = 0; i < listBox2.Items.Count; i++)  //执行 列表框2内的方法
            {
                switch ((MyOPENCV)myOPENCV_runlist[i, 0]) // 列表框2内的运行方法
                {
                    case MyOPENCV.cvt_color: //颜色转换 （入图，出图，颜色转换符，）
                        {
                            Cv2.CvtColor(image_out, image_out, (ColorConversionCodes)myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 2]);
                            break;
                        }
                    case MyOPENCV.boxfilter://方框滤波 
                        {
                            OpenCvSharp.Size size;
                            size.Width = myOPENCV_runlist[i, 2];
                            size.Height = myOPENCV_runlist[i, 3];
                            Cv2.BoxFilter(image_out, image_out, myOPENCV_runlist[i, 1], size);
                            break;
                        }
                    case MyOPENCV.blur: //均值滤波 
                        {
                            OpenCvSharp.Size size;
                            size.Width = myOPENCV_runlist[i, 1];
                            size.Height = myOPENCV_runlist[i, 2];
                            Cv2.Blur(image_out, image_out, size);
                            break;
                        }
                    case MyOPENCV.gaussianblur:  // 高斯滤波 
                        {
                            OpenCvSharp.Size size;
                            double sigmaX, sigmaY;
                            size.Width = myOPENCV_runlist[i, 1];
                            size.Height = myOPENCV_runlist[i, 2];
                            sigmaX = (double)myOPENCV_runlist[i, 3];
                            sigmaY = (double)myOPENCV_runlist[i, 4];

                            Cv2.GaussianBlur(image_out, image_out, size, sigmaX, sigmaY);
                            break;
                        }
                    case MyOPENCV.medianblur://中值滤波
                        {
                            Cv2.MedianBlur(image_in, image_out, myOPENCV_runlist[i, 1]);
                            break;
                        }
                    case MyOPENCV.bilateralfilter://双边滤波
                        {
                            Mat image_out2 = new Mat();
                            double sigmaColor, sigmaSpace;
                            sigmaColor = (double)myOPENCV_runlist[i, 2] * 2;
                            sigmaSpace = (double)myOPENCV_runlist[i, 3] / 2;
                            Cv2.BilateralFilter(image_out, image_out2, myOPENCV_runlist[i, 1], sigmaColor, sigmaSpace);
                            image_out = image_out2;
                            break;
                        }
                    case MyOPENCV.dilate://膨胀
                        {
                            Mat image_element = new Mat();
                            OpenCvSharp.Size size;
                            size.Width = myOPENCV_runlist[i, 2];
                            size.Height = myOPENCV_runlist[i, 3];
                            image_element = Cv2.GetStructuringElement((MorphShapes)myOPENCV_runlist[i, 1], size);
                            Cv2.Dilate(image_out, image_out, image_element);
                            break;
                        }
                    case MyOPENCV.erode://腐蚀
                        {
                            Mat image_element = new Mat();
                            OpenCvSharp.Size size;
                            size.Width = myOPENCV_runlist[i, 2];
                            size.Height = myOPENCV_runlist[i, 3];
                            image_element = Cv2.GetStructuringElement((MorphShapes)myOPENCV_runlist[i, 1], size);
                            Cv2.Erode(image_out, image_out, image_element);
                            break;
                        }
                    case MyOPENCV.morphologyex://高级形态学变换
                        {
                            Mat image_element = new Mat();
                            OpenCvSharp.Size size;
                            size.Width = myOPENCV_runlist[i, 3];
                            size.Height = myOPENCV_runlist[i, 4];
                            image_element = Cv2.GetStructuringElement((MorphShapes)myOPENCV_runlist[i, 2], size);
                            Cv2.MorphologyEx(image_out, image_out, (MorphTypes)myOPENCV_runlist[i, 1], image_element);
                            break;
                        }
                    case MyOPENCV.floodfill://漫水填充
                        {
                            OpenCvSharp.Point point;
                            point.X = myOPENCV_runlist[i, 1];
                            point.Y = myOPENCV_runlist[i, 2];
                            OpenCvSharp.Scalar scalar;
                            scalar = myOPENCV_runlist[i, 3];
                            Cv2.FloodFill(image_out, point, scalar);
                            break;
                        }
                    case MyOPENCV.pyrup://尺寸放大
                        {
                            OpenCvSharp.Size size;
                            size.Width = image_out.Cols * 2;
                            size.Height = image_out.Rows * 2;
                            Cv2.PyrUp(image_out, image_out, size);
                            break;
                        }
                    case MyOPENCV.pyrdown://尺寸缩小
                        {
                            OpenCvSharp.Size size;
                            size.Width = image_out.Cols / 2;
                            size.Height = image_out.Rows / 2;
                            Cv2.PyrDown(image_out, image_out, size);
                            break;
                        }
                    case MyOPENCV.resize://尺寸调整
                        {
                            OpenCvSharp.Size size;
                            InterpolationFlags interpolationFlags;
                            size.Width = image_out.Cols * myOPENCV_runlist[i, 1] / 10;
                            size.Height = image_out.Rows * myOPENCV_runlist[i, 2] / 10;
                            interpolationFlags = (InterpolationFlags)myOPENCV_runlist[i, 3];
                            Cv2.Resize(image_out, image_out, size, 0, 0, interpolationFlags);
                            break;
                        }
                    case MyOPENCV.threshold://固定阈值化
                        {
                            Cv2.Threshold(image_out, image_out, myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 2], (ThresholdTypes)myOPENCV_runlist[i, 3]);
                            break;
                        }
                    case MyOPENCV.canny://边缘检测CANNY
                        {
                            Mat image_out2 = new Mat();
                            Cv2.Canny(image_out, image_out2, myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 2], myOPENCV_runlist[i, 3]);
                            image_out = image_out2;
                            break;
                        }
                    case MyOPENCV.sobel://边缘检测SOBEL
                        {
                            Cv2.Sobel(image_out, image_out, -1, myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 2], myOPENCV_runlist[i, 3]);
                            break;
                        }
                    case MyOPENCV.laplacian://边缘检测LAPLACIAN
                        {
                            myOPENCV_runlist[i, 1] = 0;
                            Cv2.Laplacian(image_out, image_out, 0, myOPENCV_runlist[i, 2], myOPENCV_runlist[i, 3]);
                            break;
                        }
                    case MyOPENCV.scharr://边缘检测SCHARR
                        {
                            Cv2.Scharr(image_out, image_out, -1, myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 2]);
                            break;
                        }
                    case MyOPENCV.convertscaleabs://图像快速增强
                        {
                            double alpha, beta;
                            alpha = (double)myOPENCV_runlist[i, 1] / 10;
                            beta = (double)myOPENCV_runlist[i, 2] / 10;
                            Cv2.ConvertScaleAbs(image_out, image_out, alpha, beta);
                            break;
                        }
                    case MyOPENCV.addweighted://图像融合
                        {
                            Mat image_in2 = new Mat(my_imagesource2);
                            double alpha, beta, gamma;
                            alpha = (double)myOPENCV_runlist[i, 1] / 10;
                            beta = (double)myOPENCV_runlist[i, 2] / 10;
                            gamma = (double)myOPENCV_runlist[i, 3] / 10;
                            Cv2.AddWeighted(image_out, alpha, image_in2, beta, gamma, image_out);
                            break;
                        }
                    case MyOPENCV.houghlines://霍夫标准变换
                        {
                            Scalar scalar = new Scalar(0x00, 0xFF, 0x00);//绿色
                            LineSegmentPolar[] lines;
                            OpenCvSharp.Size size = new OpenCvSharp.Size(image_out.Width, image_out.Height);
                            Mat image_out3 = new Mat(size, MatType.CV_8UC3);
                            lines = Cv2.HoughLines(image_out, 1, Cv2.PI / 180, myOPENCV_runlist[i, 1]);
                            for (int ii = 0; ii < lines.Length; ii++)
                            {
                                //double rho, theta;                    
                                OpenCvSharp.Point pt1, pt2;
                                double a = Math.Cos(lines[ii].Theta), b = Math.Sin(lines[ii].Theta);
                                double x0 = a * lines[ii].Rho, y0 = b * lines[ii].Rho;
                                pt1.X = (int)Math.Round(x0 + 1000 * (-b));
                                pt1.Y = (int)Math.Round(y0 + 1000 * (a));
                                pt2.X = (int)Math.Round(x0 - 1000 * (-b));
                                pt2.Y = (int)Math.Round(y0 - 1000 * (a));
                                Cv2.Line(image_out3, pt1, pt2, scalar, 1, LineTypes.AntiAlias);
                            }
                            if (myOPENCV_runlist[i, 2] == 0)
                            {
                                Cv2.AddWeighted(image_out3, (double)myOPENCV_runlist[i, 3] / 10, image_in, (double)myOPENCV_runlist[i, 4] / 10, 0, image_out);
                            }
                            else
                            {
                                image_out = image_out3;
                            }
                            break;
                        }
                    case MyOPENCV.houghlinep://霍夫累计概率变换
                        {
                            Scalar scalar = new Scalar(0x00, 0xFF, 0x00);//绿色
                            LineSegmentPoint[] lines; // 线段检索
                            OpenCvSharp.Size size = new OpenCvSharp.Size(image_out.Width, image_out.Height);
                            Mat image_out3 = new Mat(size, MatType.CV_8UC3);
                            lines = Cv2.HoughLinesP(image_out, 1, Cv2.PI / 180, myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 3], myOPENCV_runlist[i, 4]);
                            for (int ii = 0; ii < lines.Length; ii++)
                            {
                                OpenCvSharp.Point point1, point2;
                                point1.X = lines[i].P1.X;
                                point1.Y = lines[i].P1.Y;
                                point2.X = lines[i].P2.X;
                                point2.Y = lines[i].P2.Y;
                                Cv2.Line(image_out3, point1, point2, scalar, 1, LineTypes.AntiAlias);
                            }
                            if (myOPENCV_runlist[i, 2] == 0)
                            {
                                Cv2.AddWeighted(image_out3, 1, image_in, 0.8, 0, image_out);
                            }
                            else
                            {
                                image_out = image_out3;
                            }
                            break;
                        }
                    case MyOPENCV.houghcircles://霍夫圆变换
                        {
                            Scalar scalar = new Scalar(0x00, 0xFF, 0x00);//绿色
                            CircleSegment[] circles;
                            OpenCvSharp.Size size = new OpenCvSharp.Size(image_out.Width, image_out.Height);
                            Mat image_out3 = new Mat(size, MatType.CV_8UC3);
                            circles = Cv2.HoughCircles(image_out, HoughMethods.Gradient, 1, myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 2], myOPENCV_runlist[i, 3], 0, myOPENCV_runlist[i, 4]);
                            for (int ii = 0; ii < circles.Length; ii++)
                            {
                                OpenCvSharp.Point center;
                                center.X = (int)Math.Round(circles[ii].Center.X);
                                center.Y = (int)Math.Round(circles[ii].Center.Y);
                                int radius = (int)Math.Round(circles[ii].Radius);
                                Cv2.Circle(image_out3, center.X, center.Y, radius, scalar);
                                Cv2.Circle(image_out3, center, radius, scalar);
                            }
                            Cv2.AddWeighted(image_out3, 1, image_in, 0.6, 0, image_out);

                            break;
                        }
                    case MyOPENCV.remap://重映射
                        {
                            OpenCvSharp.Size size = new OpenCvSharp.Size(image_out.Width, image_out.Height);

                            Mat map_x = new Mat(size, MatType.CV_32FC1), map_y = new Mat(size, MatType.CV_32FC1);
                            for (int ii = 0; ii < image_out.Rows; ii++)
                            {
                                for (int jj = 0; jj < image_out.Cols; jj++)
                                {
                                    if (myOPENCV_runlist[i, 1] == 0)
                                    {
                                        map_x.Set<float>(ii, jj, jj);//上下翻转
                                        map_y.Set<float>(ii, jj, image_out.Rows - ii);//上下翻转
                                    }
                                    else if (myOPENCV_runlist[i, 1] == 1)
                                    {
                                        map_x.Set<float>(ii, jj, image_out.Cols - jj);//左右翻转
                                        map_y.Set<float>(ii, jj, ii);//左右翻转
                                    }
                                    else if (myOPENCV_runlist[i, 1] == 2)
                                    {
                                        map_x.Set<float>(ii, jj, image_out.Cols - jj);//上下左右翻转
                                        map_y.Set<float>(ii, jj, image_out.Rows - ii);//上下左右翻转
                                    }
                                    else if (myOPENCV_runlist[i, 1] == 3)
                                    {
                                        map_x.Set<float>(ii, jj, (float)myOPENCV_runlist[i, 2] / 10 * jj);//放大缩小
                                        map_y.Set<float>(ii, jj, (float)myOPENCV_runlist[i, 2] / 10 * ii);//放大缩小
                                    }

                                }
                            }
                            Cv2.Remap(image_out, image_out, map_x, map_y);
                            break;
                        }
                    case MyOPENCV.warpaffine://仿射变换
                        {
                            if (0 == myOPENCV_runlist[i, 1])
                            {
                                Mat rot_mat = new Mat(2, 3, MatType.CV_32FC1);
                                OpenCvSharp.Point center = new OpenCvSharp.Point(image_out.Cols / 2, image_out.Rows / 2);
                                double angle = myOPENCV_runlist[i, 2];
                                double scale = (double)myOPENCV_runlist[i, 3] / 10;
                                ///// 通过上面的旋转细节信息求得旋转矩阵
                                rot_mat = Cv2.GetRotationMatrix2D(center, angle, scale);
                                ///// 旋转已扭曲图像
                                Cv2.WarpAffine(image_out, image_out, rot_mat, image_out.Size());
                            }
                            else
                            {
                                Point2f[] srcTri = new Point2f[3];
                                Point2f[] dstTri = new Point2f[3];
                                Mat warp_mat = new Mat(2, 3, MatType.CV_32FC1);
                                Mat warp_dst;
                                warp_dst = Mat.Zeros(image_out.Rows, image_out.Cols, image_out.Type());
                                srcTri[0] = new Point2f(0, 0);
                                srcTri[1] = new Point2f(image_out.Cols, 0);
                                srcTri[2] = new Point2f(0, image_out.Rows);
                                dstTri[0] = new Point2f((float)(image_out.Cols * myOPENCV_runlist[i, 2] / 100), (float)(image_out.Rows * myOPENCV_runlist[i, 2] / 100));
                                dstTri[1] = new Point2f((float)(image_out.Cols * (1 - (float)myOPENCV_runlist[i, 3] / 100)), (float)(image_out.Rows * myOPENCV_runlist[i, 3] / 100));
                                dstTri[2] = new Point2f((float)(image_out.Cols * myOPENCV_runlist[i, 4] / 100), (float)(image_out.Rows * (1 - (float)myOPENCV_runlist[i, 4] / 100)));
                                warp_mat = Cv2.GetAffineTransform(srcTri, dstTri);
                                Cv2.WarpAffine(image_out, image_out, warp_mat, image_out.Size());
                            }
                            break;
                        }
                    case MyOPENCV.equalizehist://直方图均衡化
                        {
                            Cv2.EqualizeHist(image_out, image_out);
                            break;
                        }
                    case MyOPENCV.facedetection://人脸识别
                        {
                            if (0 == myOPENCV_runlist[i, 1])  // 参数一为0 调用haar，其余数字调用lbp
                            {
                                var haarCascade = new CascadeClassifier(@"haarcascade_frontalface_alt.xml");
                                Mat haarResult = DetectFace(image_out, haarCascade);
                                image_out = haarResult;
                            }
                            else
                            {
                                var lbpCascade = new CascadeClassifier(@"lbpcascade_frontalface.xml");
                                Mat lbpResult = DetectFace(image_out, lbpCascade);
                                image_out = lbpResult;
                            }

                            break;
                        }
                    case MyOPENCV.matchtemplate:  // 模板匹配
                        {
                            Mat originalMat = Cv2.ImRead(my_imagesource,ImreadModes.AnyColor);  //母图
                            Mat modelMat = Cv2.ImRead(my_imagesource2,ImreadModes.AnyColor);      //模板
                            Mat resultMat = new Mat();  // 匹配结果

                            //resultMat.Create(mat1.Cols - modelMat.Cols + 1, mat1.Rows - modelMat.Cols + 1, MatType.CV_32FC1);//创建result的模板，就是MatchTemplate里的第三个参数
                            if (0 == myOPENCV_runlist[i, 1])
                            {
                                Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.SqDiff);//进行匹配(1母图,2模版子图,3返回的result，4匹配模式)
                            }
                            else if (1 == myOPENCV_runlist[i, 1])
                            {
                                Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.SqDiffNormed);
                            }
                            else if (2 == myOPENCV_runlist[i, 1])
                            {
                                Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.CCorr);
                            }
                            else if (3 == myOPENCV_runlist[i, 1])
                            {
                                Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.CCorrNormed);
                            }
                            else if (4 == myOPENCV_runlist[i, 1])
                            {
                                Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.CCoeff);
                            }
                            else if (5 == myOPENCV_runlist[i, 1])
                            {
                                Cv2.MatchTemplate(originalMat, modelMat, resultMat, TemplateMatchModes.CCoeffNormed);
                            }
                            OpenCvSharp.Point minLocation, maxLocation, matchLocation;
                            Cv2.MinMaxLoc(resultMat, out minLocation, out maxLocation);
                            matchLocation = maxLocation;
                            Mat mask = originalMat.Clone();

                            Cv2.Rectangle(mask, minLocation, new OpenCvSharp.Point(minLocation.X + modelMat.Cols, minLocation.Y + modelMat.Rows), Scalar.Green, 2); //画出匹配的矩  （图像，最小点，最大点，颜色，线宽）
                            
                            image_out = mask;
                            break;
                        }
                    case MyOPENCV.find_draw_contours:   // 找出并绘制轮廓
                        {
                            Cv2.CvtColor(image_out, image_out, ColorConversionCodes.RGB2GRAY);//转换为灰度图
                            //Cv2.Blur(image_out, image_out, new OpenCvSharp.Size(2, 2));  //滤波

                            Cv2.Canny(image_out, image_out, 100, 200);      //Canny边缘检测

                            OpenCvSharp.Point[][] contours;
                            HierarchyIndex[] hierarchly;
                            Cv2.FindContours(image_out, out contours, out hierarchly, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, new OpenCvSharp.Point(0, 0));   //获得轮廓

                            Mat dst_Image = Mat.Zeros(image_out.Size(), image_out.Type());  // 图片像素值归零
                            Random rnd = new Random();
                            for (int j = 0; j < contours.Length; j++)
                            {
                                Scalar color = new Scalar(myOPENCV_runlist[i,1], myOPENCV_runlist[i, 2], myOPENCV_runlist[i, 3]);
                                //Scalar color = new Scalar(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                                Cv2.DrawContours(dst_Image, contours, j,color, myOPENCV_runlist[i,4], LineTypes.Link8, hierarchly);       //画出轮廓
                            }
                            image_out = dst_Image;
                            break;
                        }
                    case MyOPENCV.componentdefectdetecting:  // 零件缺陷检测
                        {
                            Cv2.CvtColor(image_out, image_out, ColorConversionCodes.RGB2GRAY);//转换为灰度图
                            //Cv2.Blur(image_out, image_out, new OpenCvSharp.Size(2, 2));  //滤波

                            Cv2.Canny(image_out, image_out, 100, 200);      //Canny边缘检测

                            OpenCvSharp.Point[][] contours;
                            HierarchyIndex[] hierarchly;
                            Cv2.FindContours(image_out, out contours, out hierarchly, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, new OpenCvSharp.Point(0, 0));   //获得轮廓

                            Mat dst_Image = Mat.Zeros(image_out.Size(), image_out.Type());  // 图片像素值归零
                            Random rnd = new Random();
                            for (int j = 0; j < contours.Length; j++)
                            {
                                Scalar color = new Scalar(myOPENCV_runlist[i, 1], myOPENCV_runlist[i, 2], myOPENCV_runlist[i, 3]);
                                //Scalar color = new Scalar(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                                Cv2.DrawContours(dst_Image, contours, j, color, myOPENCV_runlist[i, 4], LineTypes.Link8, hierarchly);       //画出轮廓
                            }


                            Mat cnt = new Mat();
                            Cv2.ConvexHull(image_out, cnt);




                            break;
                        }

                    default: break;
                }
            }
            return image_out;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cascade"></param>   层叠，瀑布
        /// <returns></returns>
        private Mat DetectFace(Mat src, CascadeClassifier cascade)  // 人脸识别  （经过图像处理的结果图，用于对象检测的级联分类器）
        {
            Mat result; //定义结果图
            using (var gray = new Mat())  //新建空白图给gray
            {
                result = src.Clone();  //复制输入的图
                Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);  //灰度化

                // Detect faces
                Rect[] faces = cascade.DetectMultiScale(  //储存矩形的四点定位和尺寸 （输入图，比例因子，）
                    gray, 1.08, 2, HaarDetectionType.ScaleImage, new OpenCvSharp.Size(30, 30));
                //参考资料链接：http://blog.sina.com.cn/s/blog_9fcb9cbb01012b5b.html 

                // Render 表现 all detected faces
                foreach (Rect face in faces)
                {
                    // 画椭圆
                    //var center = new OpenCvSharp.Point
                    //{
                    //    X = (int)(face.X + face.Width * 0.5),
                    //    Y = (int)(face.Y + face.Height * 0.5)
                    //};
                    //var axes = new OpenCvSharp.Size
                    //{
                    //    Width = (int)(face.Width * 0.5),
                    //    Height = (int)(face.Height * 0.5)
                    //};
                    //Cv2.Ellipse(result, center, axes, 0, 0, 360, new Scalar(255, 0, 255), 4);
                    // 画矩形
                    int X = (int)(face.X);
                    int Y = (int)(face.Y);
                    var rect = new Rect(X, Y, Width, Height)
                    {

                        Width = (int)(face.Width * 1),
                        Height = (int)(face.Height * 1),
                    };
                    Cv2.Rectangle(result, rect, new Scalar(0, 0, 0), 4);
                }
            }

            return result;
        }  
    }
}
