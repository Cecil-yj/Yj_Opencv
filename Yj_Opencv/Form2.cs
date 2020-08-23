using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yj_Opencv
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public enum myOPENCV   //方法排排坐写这里面一一对应一个下标
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
            convexhull,  //凸包
            boundingrect,  //矩形边框
            minarearect,  //框选最小面积
            minenclosingcircle,  //最小封闭圆环
            fillellipse,  //椭圆
            approxpolydp,  //
            moments,  //阴影
            contourarea,  //轮廓面积
            arclength,  //周长
            watershed,  //分水岭算法
            inpaint,  //图像修复
            calchist,  //计算直方图
            minmaxloc,  //本地缩放
            comparehist,  //比较直方图
            calcbackproject,    //计算投影
            cornerharris,       //角点检测
            goodfeaturestotrack,    //特征检测
            cornersubpix,       //
            drawkeypoints,      //绘制关键点
            drawmatches,        //绘制匹配点
            ORB,        // 物体中介请求


            number  //用于统计总数 ，没使用
        };
        string[] myOPENCV_show =
            {
                "颜色空间转换"+"    函数原型为："+"\nvoid CvtColor(InputArray, OutputArray, " +
                        "\nColorConversionCodes,dstCn = 0)"+"\n参数一：颜色控件转换标识符；" +
                "\r \t       推荐值：11（灰度图） \r \t       取值范围：（0,53）"+"\n参数二：目标图像通道数；"
                +"\r \t       推荐值：（1,4）",

                "方框滤波"+"    函数原型为："+"\nvoid BoxFilter(OpenCvSharp.InputArray src, " +
                "OpenCvSharp.OutputArray dst, " +"OpenCvSharp.MatType ddepth, OpenCvSharp.Size ksize, " +
                "[OpenCvSharp.Point? anchor = null], [bool normalize = True], " +
                "[OpenCvSharp.BorderTypes borderType = 4]);"+"\n参数一：图像深度；\r \t       推荐值：-1"+"\n参数二：" +
                "size内核宽度；\r \t       推荐值：5"+"\n参数三：size内核高度；\r \t       推荐值：5",

                "均值滤波"+"    函数原型为："+"\nBlur(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst," +
                " OpenCvSharp.Size ksize, [OpenCvSharp.Point? anchor = null], [OpenCvSharp.BorderTypes " +
                "borderType = 4]);"+"\n参数一：size内核宽度；\r \t       推荐值：5"+"\n参数二：size内核高度；" +
                "\r \t       推荐值：5",

                "高斯滤波"+"    函数原型为："+"\nvoid GaussianBlur(OpenCvSharp.InputArray src, OpenCvSharp." +
                "OutputArray dst, OpenCvSharp.Size ksize, double sigmaX, [double sigmaY = 0], [OpenCvSharp." +
                "BorderTypes borderType = 4]);"+"\n参数一：size内核宽度；\r \t       推荐值：5"+"\n参数二：" +
                "size内核高度；\r \t       推荐值：5"+"\n参数三：sigmaX；\r \t       推荐值：0"+"\n参数四：" +
                "sigmaY；\r \t       推荐值：0",

                "中值滤波"+"    函数原型为："+"\nvoid MedianBlur(OpenCvSharp.InputArray src, OpenCvSharp." +
                "OutputArray dst, int ksize);"+"\n参数一：孔径线性尺寸；\r \t       推荐值：5",

                "双边滤波"+"    函数原型为："+"\nvoid BilateralFilter(OpenCvSharp.InputArray src, OpenCvSharp." +
                "OutputArray dst, int d, double sigmaColor, double sigmaSpace, [OpenCvSharp.BorderTypes " +
                "borderType = 4]);"+"\n参数一：像素相邻直径；\r \t       推荐值：25"+"\n参数二：" +
                "颜色空间滤波器sigmacolor；\r \t       推荐值：25"+"\n参数三：坐标空间滤波器sigmaspace；" +
                "\r \t       推荐值：25",

                "膨胀"+"    函数原型为："+"\nvoid Dilate(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray" +
                " dst, OpenCvSharp.InputArray element, [OpenCvSharp.Point? anchor = null], [int iterations = 1], " +
                "[OpenCvSharp.BorderTypes borderType = 0], [OpenCvSharp.Scalar? borderValue = null]) ;"
                +"\n参数一：MorphShapes；\r \t       推荐值：只能取0 1 2"+"\n参数二：size内核宽度；\r \t       " +
                "推荐值：5"+"\n参数三：size内核高度；\r \t       推荐值：5",

                "腐蚀"+"    函数原型为："+"\nvoid Erode(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray " +
                "dst, OpenCvSharp.InputArray element, [OpenCvSharp.Point? anchor = null], [int iterations = 1]," +
                " [OpenCvSharp.BorderTypes borderType = 0], [OpenCvSharp.Scalar? borderValue = null]) ;"
                +"\n参数一：MorphShapes；\r \t       推荐值：只能取0 1 2"+"\n参数二：size内核宽度；\r \t " +
                "      推荐值：5"+"\n参数三：size内核高度；\r \t       推荐值：5",

                "高级形态学变换"+"    函数原型为："+"\nvoid MorphologyEx(OpenCvSharp.InputArray src, OpenCvSharp." +
                "OutputArray dst, OpenCvSharp.MorphTypes op, OpenCvSharp.InputArray element, [OpenCvSharp.Point? " +
                "anchor = null], [int iterations = 1], [OpenCvSharp.BorderTypes borderType = 0], [OpenCvSharp.Scalar? " +
                "borderValue = null]);"+"\n参数一：MorphTypes；\r \t       推荐值：只能取0 1 2 3 4 5 6 ，7不能用"
                +"\n参数二：MorphShapes；\r \t       推荐值：只能取0 1 2"+"\n参数三：size内核宽度；\r \t       推荐值：5"
                +"\n参数四：size内核高度；\r \t       推荐值：5",

                "漫水填充"+"    函数原型为："+"\nint FloodFill(OpenCvSharp.InputOutputArray image, OpenCvSharp.InputOutputArray " +
                "mask, OpenCvSharp.Point seedPoint, OpenCvSharp.Scalar newVal);"+"\n参数一：目标点X；\r \t       " +
                "推荐值：100"+"\n参数二：目标点Y；\r \t       推荐值：100"+"\n参数三：Scalar 颜色；\r \t       推荐值：100",

                "尺寸放大"+"    函数原型为："+"\nvoid PyrUp(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst, " +
                "[OpenCvSharp.Size? dstSize = null], [OpenCvSharp.BorderTypes borderType = 4]);"+"\n参数一：只能放大2倍；\r \t       推荐值：0",

                "尺寸缩小"+"    函数原型为："+"\nvoid PyrDown(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst, " +
                "[OpenCvSharp.Size? dstSize = null], [OpenCvSharp.BorderTypes borderType = 4]);"+"\n参数一：只能缩小2倍；\r \t       推荐值：0",

                "尺寸调整"+"    函数原型为："+"\nvoid Resize(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst, " +
                "OpenCvSharp.Size dsize, [double fx = 0], [double fy = 0], [OpenCvSharp.InterpolationFlags interpolation = 1]);"
                +"\n参数一：宽度放大倍数/10；\r \t       推荐值：20"+"\n参数二：高度放大倍数/10；\r \t       推荐值：20"+"\n参数三：插值方式；" +
                "\r \t       推荐值：0 1 2 3 4 5",

                "固定阈值化"+"    函数原型为："+"\ndouble Threshold(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst, double thresh, " +
                "double maxval, OpenCvSharp.ThresholdTypes type);"+"\n参数一：阈值；\r \t       推荐值：100"+"\n参数二：阈值最大值；\r \t       " +
                "推荐值：255"+"\n参数三：ThresholdTypes；\r \t       推荐值：0 1 2 3 4 7 8 16",

                "边缘检测CANNY"+"    函数原型为："+"\nvoid Canny(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray edges, double threshold1, " +
                "double threshold2, [int apertureSize = 3], [bool L2gradient = False]);"+"\n参数一：阈值1   推荐两个比例为2：1到3：1中间；\r \t " +
                "      推荐值：150"+"\n参数二：阈值2  两个阈值一大一小 无先后顺序；\r \t   " +
                "    推荐值：50"+"\n参数三：sobel算子孔径大小；\r \t       推荐值：3 5 7",

                "边缘检测SOBEL"+"    函数原型为："+"\nvoid Sobel(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst, OpenCvSharp.MatType " +
                "ddepth, int xorder, int yorder, [int ksize = 3], [double scale = 1], [double delta = 0], [OpenCvSharp.BorderTypes borderType = 4]);"
                +"\n参数一：X方向向上差分数；\r \t       推荐值：1"+"\n参数二：Y方向向上差分数；\r \t       推荐值：0"+"\n参数三：sobel算子核大小；" +
                "\r \t       推荐值：只能是1 3 5 7",

                "边缘检测LAPLACIAN"+"    函数原型为："+"\nvoid Laplacian(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst, OpenCvSharp." +
                "MatType ddepth, [int ksize = 1], [double scale = 1], [double delta = 0], [OpenCvSharp.BorderTypes borderType = 4]);"+"\n" +
                "参数一：图像深度 MatType  0-7；\r \t       推荐值：0 暂时只能用cv8u"+"\n参数二： laplacian算子孔径大小 正奇数；\r \t       " +
                "推荐值：3"+"\n参数三：比例因子；\r \t       推荐值：1",

                "边缘检测SCHARR"+"    函数原型为："+"\nvoid Scharr(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst, OpenCvSharp.MatType" +
                " ddepth, int xorder, int yorder, [double scale = 1], [double delta = 0], [OpenCvSharp.BorderTypes borderType = 4]);"+"\n" +
                "参数一：X方向向上差分数；\r \t       推荐值：1"+"\n参数二：Y方向向上差分数；\r \t       推荐值：.0",

                "图像快速增强"+"    函数原型为："+"\nvoid ConvertScaleAbs(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray " +
                "dst, [double alpha = 1], [double beta = 0]);"+"\n参数一：乘数因子 alpha = 1.0；\r \t       推荐值：10"
                +"\n参数二：偏移量；\r \t       推荐值：0"+"\n参数三：输入值为其十倍；\r \t       推荐值：0",

                "图像融合"+"    函数原型为："+"\nvoid AddWeighted(OpenCvSharp.InputArray src1, double alpha, OpenCvSharp.InputArray " +
                "src2, double beta, double gamma, OpenCvSharp.OutputArray dst, [int dtype = -1]);"+"\n参数一： 图片1的融合比例 alpha 0.5 放大了十倍；" +
                "\r \t       推荐值：5"+"\n参数二：图片1的融合比例 beta 0.5；\r \t       推荐值：5"+"\n参数三：误差 gamma；\r \t       " +
                "推荐值：0"+"\n参数四：此参数由打开文件替代；\r \t       推荐值：0",

                "霍夫标准变换"+"    函数原型为："+"\nOpenCvSharp.LineSegmentPolar[] HoughLines(OpenCvSharp.InputArray image, " +
                "double rho, double theta, int threshold, [double srn = 0], [double stn = 0]);"+"\n参数一：累加平面的阈值 ；" +
                "\r \t       推荐值：150"+"\n参数二：选择是否显示原图像 0显示 其他不显示；\r \t       推荐值：0"
                +"\n参数三：线条阿尔法值 默认为1 放大十倍；\r \t       推荐值：10"+"\n参数四：原图阿尔法值 默认为0.8放大十倍；" +
                "\r \t       推荐值：8",

                "霍夫累计概率变换"+"    函数原型为："+"\nOpenCvSharp.LineSegmentPoint[] HoughLinesP(OpenCvSharp.InputArray " +
                "image, double rho, double theta, int threshold, [double minLineLength = 0], [double maxLineGap = 0]);"
                +"\n参数一：累加平面的阈值；\r \t       推荐值：150"+"\n参数二：选择是否显示原图像 0显示 其他不显示；" +
                "\r \t       推荐值：0"+"\n参数三：min线段长度；\r \t       推荐值：50"+"\n参数四：max线段长度；" +
                "\r \t       推荐值：10",

                "霍夫圆变换"+"    函数原型为："+"\nOpenCvSharp.CircleSegment[] HoughCircles(OpenCvSharp.InputArray" +
                " image, OpenCvSharp.HoughMethods method, double dp, double minDist, [double param1 = 100], " +
                "[double param2 = 100], [int minRadius = 0], [int maxRadius = 0]);"+"\n参数一：圆心之间最小距离；" +
                "\r \t       推荐值：5"+"\n参数二：canny的高阈值；\r \t       推荐值：200"+"\n参数三：圆心累加器阈值；" +
                "\r \t       推荐值：100"+"\n参数四：圆半径最大值  最小值已设置为0；\r \t       推荐值：0",

                "重映射"+"    函数原型为："+"\nvoid Remap(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray dst," +
                " OpenCvSharp.InputArray map1, OpenCvSharp.InputArray map2, [OpenCvSharp.InterpolationFlags " +
                "interpolation = 1], [OpenCvSharp.BorderTypes borderMode = 0], [OpenCvSharp.Scalar? borderValue = null]);"
                +"\n参数一：0 1 2 3；\r \t       推荐值：0"+"\n参数二：放大缩小倍数；\r \t       推荐值：1",

                "仿射变换"+"    函数原型为："+"\nvoid WarpAffine(OpenCvSharp.InputArray src, OpenCvSharp.OutputArray" +
                " dst, OpenCvSharp.InputArray m, OpenCvSharp.Size dsize, [OpenCvSharp.InterpolationFlags flags = 1]," +
                " [OpenCvSharp.BorderTypes borderMode = 0], [OpenCvSharp.Scalar? borderValue = null]);"+"\n参数一：" +
                "0为对图像进行翻转旋转  其他为（1）进行压缩旋转 ；\r \t       推荐值：0"+"\n参数二：0旋转角度1倍  " +
                "1左上角往中心移动比例100倍；\r \t       推荐值：10"+"\n参数三： 0尺寸大小10倍  1右上角往中心移动" +
                "比例100倍；\r \t       推荐值：10"+"\n参数四：1左下角往中心移动比例100倍；\r \t       推荐值：20",

                "直方图均衡化"+"    函数原型为："+"\nvoid EqualizeHist(OpenCvSharp.InputArray src, OpenCvSharp" +
                ".OutputArray dst);"+"无参数 输入灰度图即可",

                "人脸识别"+"    函数原型为："+"\nRect[] faces = cascade.DetectMultiScale(gray, 1.08, 2," +
                " HaarDetectionType.ScaleImage, new OpenCvSharp.Size(30, 30));"
                +"\n参数一：0为使用Haar 其他为使用LBP；\r \t       推荐值：0",

                "模板匹配"+"    函数原型为："+"\nvoid MatchTemplate(OpenCvSharp.InputArray image, " +
                "OpenCvSharp.InputArray templ, OpenCvSharp.OutputArray result, OpenCvSharp.TemplateMatchModes method," +
                " [OpenCvSharp.InputArray mask = null])"+"\n参数一：模板匹配的方法；\r \t       推荐值：0 - 5",

                "寻找并绘制轮廓"+"    函数原型为："+"\n    "+"\n参数一：   ；\r \t       推荐值：0 - 5",


                "零件缺陷检测"+"    函数原型为："+"\n    "+"\n参数一：   ；\r \t       推荐值：0 - 5",
                
                
                // 下面还没有开始做

                "绘制轮廓",

                "寻找凸包",

                "返回外部矩形边界",

                "寻找最小包围矩形",

                "寻找最小包围圆形",

                "用椭圆拟合二维点集",

                "逼近多边形曲线",

                "矩的计算",

                "计算轮廓面积",

                "计算轮廓长度",

                "分水岭算法",

                "图像修补",

                "计算直方图",

                "寻找最值",

                "对比直方图",

                "反向投影",

                "HARRIS角点检测",

                "ST角点检测",

                "亚像素级角点检测",

                "SURF特征点提取",

                "SURF特征点匹配",

                "FLANN特征点寻找透视变换",

                "FLANN特征点向量透视矩阵变换",

                "ORB特征提取",

            };
        public static int[,] myOPENCV_value = new int[60, 4];  //二维数组，60行4列，放60组图像处理操作的参数，每组4参数  
        //new int[(int)myOPENCV.number , 4];//用于存放各opencv方法中的参数

        private void Form2_Load(object sender, EventArgs e)  // 载入表2 的api
        {
            Form1 form1 = (Form1)this.Owner;
            form1.Opacity = 1;

            if (form1.thefirstload == true)
            {
                myOPENCV_value_int();
                form1.thefirstload = false;
            }

            if (form1.list_who == false)//listbox1被点击
            {
                button3.Enabled = true;
                button3.Visible = true;
                opencv_load((myOPENCV)form1.listBox1.SelectedIndex);
            }
            else
            {
                opencv_load((myOPENCV)form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 0]);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)  // 关闭表2 的api
        {
            Form1 form1 = (Form1)this.Owner;  // 打开表1 的窗体
            form1.Opacity = 1;   // 窗体设置 完全不透明
        }

        private void button1_Click(object sender, EventArgs e) // 删除 的api
        {
            Form1 form1 = (Form1)this.Owner;

            form1.textBox1.AppendText("\r\n成功删除：" + form1.listBox2.SelectedItem.ToString() + "！");
            form1.textBox1.SelectionStart = form1.textBox1.TextLength;
            form1.textBox1.ScrollToCaret();

            for (int i = 0; i < form1.listBox2.Items.Count - form1.listBox2.SelectedIndex - 1; i++)//后面的数据全部前移
            {
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i, 0] = form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i + 1, 0];
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i, 1] = form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i + 1, 1];
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i, 2] = form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i + 1, 2];
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i, 3] = form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i + 1, 3];
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i, 4] = form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + i + 1, 4];
            }
            form1.myOPENCV_runlist[form1.listBox2.Items.Count, 1] = (int)numericUpDown1.Value;
            form1.myOPENCV_runlist[form1.listBox2.Items.Count, 2] = (int)numericUpDown2.Value;
            form1.myOPENCV_runlist[form1.listBox2.Items.Count, 3] = (int)numericUpDown3.Value;
            form1.myOPENCV_runlist[form1.listBox2.Items.Count, 4] = (int)numericUpDown4.Value;

            form1.listBox2.Items.Remove(form1.listBox2.SelectedItem);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  // IMG2 的api
        {
            Form1 form1 = (Form1)this.Owner;  // 获取表1 的窗体
            OpenFileDialog openFileDialog1 = new OpenFileDialog();  // 新建个 打开文件 的任务
            openFileDialog1.InitialDirectory = "G:\\pics";  // 打开文件 的初始位置
            openFileDialog1.Filter = "JPEG图像(*.jpg)|*.jpg|PNG图像(*.png)|*.png|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";  // 筛选使用的图片的类型
            openFileDialog1.ShowDialog();  // 显示 打开文件 对话框
            if (openFileDialog1.FileName != string.Empty)  //如果 图片不为空，图片存在
            {
                form1.my_imagesource2 = openFileDialog1.FileName;   //传给表1 的my_imagesource2 ，进行图像处理操作

                form1.textBox1.AppendText("\r\n打开文件路径：" + openFileDialog1.FileName);    //文字消息 添加到表1 的文本框中
                form1.textBox1.SelectionStart = form1.textBox1.TextLength;  //表1 的文本框的长度从起点开始，自动的
                form1.textBox1.ScrollToCaret();  //  控件内容从当前插入符位置开始显示
            }
            else  // 图片不存在
            {
                form1.textBox1.AppendText("\r\n不打开文件你瞎点个啥？！");  // 表1 的文本框显示文字消息
                form1.textBox1.SelectionStart = form1.textBox1.TextLength;  // 同上
                form1.textBox1.ScrollToCaret();     // 同上
            }
        }

        private void button3_Click(object sender, EventArgs e)  // 取消 的api
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)  //确定 的api
        {
            Form1 form1 = (Form1)this.Owner;

            if (form1.list_who == false)//listbox1被点击
            {
                myOPENCV_value[form1.listBox1.SelectedIndex, 0] = (int)numericUpDown1.Value;
                myOPENCV_value[form1.listBox1.SelectedIndex, 1] = (int)numericUpDown2.Value;
                myOPENCV_value[form1.listBox1.SelectedIndex, 2] = (int)numericUpDown3.Value;
                myOPENCV_value[form1.listBox1.SelectedIndex, 3] = (int)numericUpDown4.Value;

                form1.textBox1.AppendText("\r\n成功添加：" + form1.listBox1.SelectedItem.ToString() + "！");
                form1.textBox1.SelectionStart = form1.textBox1.TextLength;
                form1.textBox1.ScrollToCaret();

                if (form1.listBox2.SelectedIndex >= 0)
                {
                    form1.listBox2.Items.Insert(form1.listBox2.SelectedIndex + 1, form1.listBox1.SelectedItem);

                    for (int i = 0; i < form1.listBox2.Items.Count - form1.listBox2.SelectedIndex - 1; i++)//后面的数据全部后移
                    {
                        form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 1, 0] = form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 2, 0];
                        form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 1, 1] = form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 2, 1];
                        form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 1, 2] = form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 2, 2];
                        form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 1, 3] = form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 2, 3];
                        form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 1, 4] = form1.myOPENCV_runlist[form1.listBox2.Items.Count - i - 2, 4];
                    }
                    form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + 1, 0] = form1.listBox1.SelectedIndex;
                    form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + 1, 1] = (int)numericUpDown1.Value;
                    form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + 1, 2] = (int)numericUpDown2.Value;
                    form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + 1, 3] = (int)numericUpDown3.Value;
                    form1.myOPENCV_runlist[form1.listBox2.SelectedIndex + 1, 4] = (int)numericUpDown4.Value;

                    form1.listBox2.ClearSelected();
                }
                else
                {
                    form1.listBox2.Items.Add(form1.listBox1.SelectedItem);//直接在后面添加

                    form1.myOPENCV_runlist[form1.listBox2.Items.Count - 1, 0] = form1.listBox1.SelectedIndex;
                    form1.myOPENCV_runlist[form1.listBox2.Items.Count - 1, 1] = (int)numericUpDown1.Value;
                    form1.myOPENCV_runlist[form1.listBox2.Items.Count - 1, 2] = (int)numericUpDown2.Value;
                    form1.myOPENCV_runlist[form1.listBox2.Items.Count - 1, 3] = (int)numericUpDown3.Value;
                    form1.myOPENCV_runlist[form1.listBox2.Items.Count - 1, 4] = (int)numericUpDown4.Value;

                }

                this.Close();
            }
            else//listbox2被点击
            {
                myOPENCV_value[form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 0], 0] = (int)numericUpDown1.Value;
                myOPENCV_value[form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 0], 1] = (int)numericUpDown2.Value;
                myOPENCV_value[form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 0], 2] = (int)numericUpDown3.Value;
                myOPENCV_value[form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 0], 3] = (int)numericUpDown4.Value;

                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 1] = (int)numericUpDown1.Value;
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 2] = (int)numericUpDown2.Value;
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 3] = (int)numericUpDown3.Value;
                form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 4] = (int)numericUpDown4.Value;

                this.Close();
            }
        }

        private void opencv_load(myOPENCV opencv_number) //用于点击form1的list时，出现的form2文字说明，同时具备参数加载功能
        { 

            Form1 form1 = (Form1)this.Owner;
            if (form1.list_who == false && form1.listBox1.SelectedIndex == (int)myOPENCV.addweighted)//listbox1被点击的同时是需要打开第二幅图片
            {
                button4.Enabled = true;//启用打开文件按钮
                button4.Visible = true;
            }
            else if (form1.list_who == true && form1.myOPENCV_runlist[form1.listBox2.SelectedIndex, 0] == (int)myOPENCV.addweighted)//listbox2被点击d的同时是需要打开第二幅图片
            {
                button4.Enabled = true;//启用打开文件按钮
                button4.Visible = true;
            }
            else
            {
                //button4.Enabled = false;//关闭打开文件按钮
                //button4.Visible = false;
            }

            label1.Text = myOPENCV_show[(int)opencv_number];
            numericUpDown1.Value = myOPENCV_value[(int)opencv_number, 0];
            numericUpDown2.Value = myOPENCV_value[(int)opencv_number, 1];
            numericUpDown3.Value = myOPENCV_value[(int)opencv_number, 2];
            numericUpDown4.Value = myOPENCV_value[(int)opencv_number, 3];
        }

        public void myOPENCV_value_int()  // 每个方法四个参数的初始值
        {
            myOPENCV_value[(int)myOPENCV.cvt_color, 0] = 11;//颜色空间转换   参数一   转换标识符
            myOPENCV_value[(int)myOPENCV.cvt_color, 1] = 0;//颜色空间转换   参数二   通道
            myOPENCV_value[(int)myOPENCV.cvt_color, 2] = 0;//颜色空间转换
            myOPENCV_value[(int)myOPENCV.cvt_color, 3] = 0;//颜色空间转换
            myOPENCV_value[(int)myOPENCV.boxfilter, 0] = -1;//方框滤波  参数一  图像深度
            myOPENCV_value[(int)myOPENCV.boxfilter, 1] = 5;//方框滤波   参数二   size内核宽度
            myOPENCV_value[(int)myOPENCV.boxfilter, 2] = 5;//方框滤波   参数三   size内核高度
            myOPENCV_value[(int)myOPENCV.boxfilter, 3] = 0;//方框滤波
            myOPENCV_value[(int)myOPENCV.blur, 0] = 5;//均值滤波   参数一  size内核宽度
            myOPENCV_value[(int)myOPENCV.blur, 1] = 5;//均值滤波   参数二   size内核高度
            myOPENCV_value[(int)myOPENCV.blur, 2] = 0;//均值滤波
            myOPENCV_value[(int)myOPENCV.blur, 3] = 0;//均值滤波
            myOPENCV_value[(int)myOPENCV.gaussianblur, 0] = 5;//高斯滤波   参数一   size内核宽度
            myOPENCV_value[(int)myOPENCV.gaussianblur, 1] = 5;//高斯滤波   参数二   size内核宽度
            myOPENCV_value[(int)myOPENCV.gaussianblur, 2] = 0;//高斯滤波   参数三   sigmaX
            myOPENCV_value[(int)myOPENCV.gaussianblur, 3] = 0;//高斯滤波   参数四   sigmaY
            myOPENCV_value[(int)myOPENCV.medianblur, 0] = 5;//中值滤波   参数一  孔径线性尺寸
            myOPENCV_value[(int)myOPENCV.medianblur, 1] = 0;//中值滤波   
            myOPENCV_value[(int)myOPENCV.medianblur, 2] = 0;//中值滤波
            myOPENCV_value[(int)myOPENCV.medianblur, 3] = 0;//中值滤波
            myOPENCV_value[(int)myOPENCV.bilateralfilter, 0] = 25;//双边滤波  参数一  像素相邻直径
            myOPENCV_value[(int)myOPENCV.bilateralfilter, 1] = 25;//双边滤波   参数二   颜色空间滤波器sigmacolor
            myOPENCV_value[(int)myOPENCV.bilateralfilter, 2] = 25;//双边滤波   参数三   坐标空间滤波器sigmaspace
            myOPENCV_value[(int)myOPENCV.bilateralfilter, 3] = 0;//双边滤波
            myOPENCV_value[(int)myOPENCV.dilate, 0] = 0;//膨胀  参数一  MorphShapes 只能取0 1 2
            myOPENCV_value[(int)myOPENCV.dilate, 1] = 5;//膨胀   参数二   size内核宽度
            myOPENCV_value[(int)myOPENCV.dilate, 2] = 5;//膨胀   参数三   size内核高度
            myOPENCV_value[(int)myOPENCV.dilate, 3] = 0;//膨胀  
            myOPENCV_value[(int)myOPENCV.erode, 0] = 0;//腐蚀  参数一  MorphShapes 只能取0 1 2
            myOPENCV_value[(int)myOPENCV.erode, 1] = 5;//腐蚀   参数二   size内核宽度
            myOPENCV_value[(int)myOPENCV.erode, 2] = 5;//腐蚀   参数三   size内核高度
            myOPENCV_value[(int)myOPENCV.erode, 3] = 0;//腐蚀   
            myOPENCV_value[(int)myOPENCV.morphologyex, 0] = 0;//高级形态学变换  参数一  MorphTypes 只能取0 1 2 ..5 6 ，7不能用
            myOPENCV_value[(int)myOPENCV.morphologyex, 1] = 0;//高级形态学变换   参数二  MorphShapes 只能取0 1 2
            myOPENCV_value[(int)myOPENCV.morphologyex, 2] = 5;//高级形态学变换   参数三   size内核宽度
            myOPENCV_value[(int)myOPENCV.morphologyex, 3] = 5;//高级形态学变换   参数四   size内核高度
            myOPENCV_value[(int)myOPENCV.floodfill, 0] = 100;//漫水填充  参数一  目标点X
            myOPENCV_value[(int)myOPENCV.floodfill, 1] = 100;//漫水填充   参数二   目标点Y
            myOPENCV_value[(int)myOPENCV.floodfill, 2] = 100;//漫水填充   参数三   Scalar 颜色
            myOPENCV_value[(int)myOPENCV.floodfill, 3] = 0;//漫水填充 
            myOPENCV_value[(int)myOPENCV.pyrup, 0] = 0;//尺寸放大     只能放大2倍
            myOPENCV_value[(int)myOPENCV.pyrup, 1] = 0;//尺寸放大     
            myOPENCV_value[(int)myOPENCV.pyrup, 2] = 0;//尺寸放大
            myOPENCV_value[(int)myOPENCV.pyrup, 3] = 0;//尺寸放大
            myOPENCV_value[(int)myOPENCV.pyrdown, 0] = 0;//尺寸缩小     只能缩小2倍
            myOPENCV_value[(int)myOPENCV.pyrdown, 1] = 0;//尺寸缩小     
            myOPENCV_value[(int)myOPENCV.pyrdown, 2] = 0;//尺寸缩小
            myOPENCV_value[(int)myOPENCV.pyrdown, 3] = 0;//尺寸缩小
            myOPENCV_value[(int)myOPENCV.resize, 0] = 20;//尺寸调整   参数一  宽度放大倍数/10
            myOPENCV_value[(int)myOPENCV.resize, 1] = 20;//尺寸调整   参数二   高度放大倍数/10
            myOPENCV_value[(int)myOPENCV.resize, 2] = 0;//尺寸调整   参数三   插值方式 0 1 2 3 4 7 8 16
            myOPENCV_value[(int)myOPENCV.resize, 3] = 0;//尺寸调整
            myOPENCV_value[(int)myOPENCV.threshold, 0] = 100;//固定阈值化   参数一  阈值
            myOPENCV_value[(int)myOPENCV.threshold, 1] = 255;//固定阈值化   参数二   阈值最大值
            myOPENCV_value[(int)myOPENCV.threshold, 2] = 3;//固定阈值化   参数三   ThresholdTypes 0 1 2 3 4 7 8 16
            myOPENCV_value[(int)myOPENCV.threshold, 3] = 0;//固定阈值化
            myOPENCV_value[(int)myOPENCV.canny, 0] = 150;//边缘检测CANNY   参数一  阈值1   推荐两个比例为2：1到3：1中间
            myOPENCV_value[(int)myOPENCV.canny, 1] = 50;//边缘检测CANNY   参数二   阈值2  两个阈值一大一小 无先后顺序
            myOPENCV_value[(int)myOPENCV.canny, 2] = 3;//边缘检测CANNY   参数三   sobel算子孔径大小
            myOPENCV_value[(int)myOPENCV.canny, 3] = 0;//边缘检测CANNY
            myOPENCV_value[(int)myOPENCV.sobel, 0] = 1;//边缘检测SOBEL     参数一  X方向向上差分数
            myOPENCV_value[(int)myOPENCV.sobel, 1] = 0;//边缘检测SOBEL     参数二   Y方向向上差分数
            myOPENCV_value[(int)myOPENCV.sobel, 2] = 3;//边缘检测SOBEL     参数三   sobel算子核大小  只能是1 3 5 7
            myOPENCV_value[(int)myOPENCV.sobel, 3] = 0;//边缘检测SOBEL
            myOPENCV_value[(int)myOPENCV.laplacian, 0] = 0;//边缘检测LAPLACIAN     参数一    图像深度 MatType  0-7  暂时只能用cv8u
            myOPENCV_value[(int)myOPENCV.laplacian, 1] = 3;//边缘检测LAPLACIAN     参数二·   laplacian算子孔径大小 正奇数
            myOPENCV_value[(int)myOPENCV.laplacian, 2] = 1;//边缘检测LAPLACIAN      参数三   比例因子
            myOPENCV_value[(int)myOPENCV.laplacian, 3] = 0;//边缘检测LAPLACIAN
            myOPENCV_value[(int)myOPENCV.sobel, 0] = 1;//边缘检测SCHARR     参数一  X方向向上差分数
            myOPENCV_value[(int)myOPENCV.sobel, 1] = 0;//边缘检测SCHARR     参数二   Y方向向上差分数
            myOPENCV_value[(int)myOPENCV.sobel, 2] = 0;//边缘检测SCHARR     
            myOPENCV_value[(int)myOPENCV.sobel, 3] = 0;//边缘检测SCHARR
            myOPENCV_value[(int)myOPENCV.convertscaleabs, 0] = 10;//图像快速增强     参数一  alpha = 1.0, // 乘数因子
            myOPENCV_value[(int)myOPENCV.convertscaleabs, 1] = 0;//图像快速增强     参数二   beta = 0.0 // 偏移量
            myOPENCV_value[(int)myOPENCV.convertscaleabs, 2] = 0;//图像快速增强     输入值为其十倍
            myOPENCV_value[(int)myOPENCV.convertscaleabs, 3] = 0;//图像快速增强
            myOPENCV_value[(int)myOPENCV.addweighted, 0] = 5;//图像融合  参数一  图片1的融合比例 0.5 放大了十倍
            myOPENCV_value[(int)myOPENCV.addweighted, 1] = 5;//图像融合   参数二  图片1的融合比例 0.5
            myOPENCV_value[(int)myOPENCV.addweighted, 2] = 0;//图像融合   参数三   误差
            myOPENCV_value[(int)myOPENCV.addweighted, 3] = 0;//图像融合   参数四   此参数由打开文件替代
            myOPENCV_value[(int)myOPENCV.houghlines, 0] = 150;//霍夫标准变换     参数一    累加平面的阈值 
            myOPENCV_value[(int)myOPENCV.houghlines, 1] = 0;//霍夫标准变换     参数二  选择是否显示原图像 0显示 其他不显示
            myOPENCV_value[(int)myOPENCV.houghlines, 2] = 10;//霍夫标准变换      参数三   线条阿尔法值 默认为1 放大十倍
            myOPENCV_value[(int)myOPENCV.houghlines, 3] = 8;//霍夫标准变换   参数四   原图阿尔法值 默认为0.8放大十倍
            myOPENCV_value[(int)myOPENCV.houghlinep, 0] = 150;//霍夫累计概率变换     参数一    累加平面的阈值 
            myOPENCV_value[(int)myOPENCV.houghlinep, 1] = 0;//霍夫累计概率变换     参数二  选择是否显示原图像 0显示 其他不显示
            myOPENCV_value[(int)myOPENCV.houghlinep, 2] = 50;//霍夫累计概率变换      参数三   min线段长度
            myOPENCV_value[(int)myOPENCV.houghlinep, 3] = 10;//霍夫累计概率变换   参数四   max线段长度
            myOPENCV_value[(int)myOPENCV.houghcircles, 0] = 5;//霍夫圆变换     参数一    圆心之间最小距离 
            myOPENCV_value[(int)myOPENCV.houghcircles, 1] = 200;//霍夫圆变换     参数二  canny的高阈值
            myOPENCV_value[(int)myOPENCV.houghcircles, 2] = 100;//霍夫圆变换      参数三   圆心累加器阈值
            myOPENCV_value[(int)myOPENCV.houghcircles, 3] = 0;//霍夫圆变换   参数四   圆半径最大值 //最小值已设置为0
            myOPENCV_value[(int)myOPENCV.remap, 0] = 0;//重映射     参数一    0 1 2 3
            myOPENCV_value[(int)myOPENCV.remap, 1] = 0;//重映射      参数二   放大缩小倍数
            myOPENCV_value[(int)myOPENCV.remap, 2] = 0;//重映射   
            myOPENCV_value[(int)myOPENCV.remap, 3] = 0;//重映射 
            myOPENCV_value[(int)myOPENCV.warpaffine, 0] = 0;// 仿射变换    参数一    0为对图像进行翻转旋转  其他为（1）进行压缩旋转 
            myOPENCV_value[(int)myOPENCV.warpaffine, 1] = 10;//仿射变换     参数二  0旋转角度1倍  1左上角往中心移动比例100倍
            myOPENCV_value[(int)myOPENCV.warpaffine, 2] = 10;//仿射变换     参数三   0尺寸大小10倍  1右上角往中心移动比例100倍
            myOPENCV_value[(int)myOPENCV.warpaffine, 3] = 20;//仿射变换     参数四   1左下角往中心移动比例100倍
            myOPENCV_value[(int)myOPENCV.equalizehist, 0] = 0;//直方图均衡化     无参数 输入灰度图即可
            myOPENCV_value[(int)myOPENCV.equalizehist, 1] = 0;//直方图均衡化  
            myOPENCV_value[(int)myOPENCV.equalizehist, 2] = 0;//直方图均衡化   
            myOPENCV_value[(int)myOPENCV.equalizehist, 3] = 0;//直方图均衡化  
            myOPENCV_value[(int)myOPENCV.facedetection, 0] = 0;//人脸识别     参数一   0为使用Haar 其他为使用LBP
            myOPENCV_value[(int)myOPENCV.facedetection, 1] = 0;//人脸识别  
            myOPENCV_value[(int)myOPENCV.facedetection, 2] = 0;//人脸识别   
            myOPENCV_value[(int)myOPENCV.facedetection, 3] = 0;//人脸识别  
            myOPENCV_value[(int)myOPENCV.matchtemplate, 0] = 0;//模板匹配
            myOPENCV_value[(int)myOPENCV.matchtemplate, 1] = 0;//模板匹配
            myOPENCV_value[(int)myOPENCV.matchtemplate, 2] = 0;//模板匹配
            myOPENCV_value[(int)myOPENCV.matchtemplate, 3] = 0;//模板匹配
        }

        private void label1_Click(object sender, EventArgs e)  // 显示框的api 不写
        {

        }

        private void label2_Click(object sender, EventArgs e) // 参数一 的api 不写
        {

        }

        private void label3_Click(object sender, EventArgs e)  // 参数二 的api 不写
        {

        }

        private void label4_Click(object sender, EventArgs e)  // 参数三 的api 不写
        {

        }

        private void label5_Click(object sender, EventArgs e)  // 参数四 的api 不写
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)  // 参数一的数值调节框 的api，不写
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)   // 参数二的数值调节框 的api，不写
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)   // 参数三的数值调节框 的api，不写
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)   // 参数四的数值调节框 的api，不写
        {

        }
    }
}
