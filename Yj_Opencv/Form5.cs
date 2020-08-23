using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Yj_Opencv
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private string[] FileNmae = null;//读取文件夹下的文件
        private int times = 0;//上一张/下一张按钮点击次数（对应图片数组的索引）
        private int ErodeVaule = 1, DelitVaule = 1;//膨胀/腐蚀运算
        private Image<Bgr, byte> picture = null;//原始图片
        private int BinVaule = 0;//二值化阈值
        private int y = 0, cr_min = 0, cb_min = 0, cr_max = 0, cb_max = 0;//YCC颜色阈值
        private double area1 = 0, area2 = 0;//缺陷面积

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        // Erode值
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            //ErodeVaule = Convert.ToInt16(domainUpDown1.Text);
        }
        // 选择图片
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "G:\\pics";
            ofd.Filter = "JPEG图像(*.jpg)|*.jpg|PNG图像(*.png)|*.png|BMP图像(*.bmp)|*.bmp|所有文件(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(ofd.FileName);
                picture = new Image<Bgr, byte>(ofd.FileName);
                Image<Bgr, byte> pic = new Image<Bgr, byte>(PicSubtraction(ContourFilling(ToBin(picture)), ContourFilling2(ToBin(picture))).Bitmap);
                pictureBox1.Image = ContourFilling3(pic).Bitmap;
                //PicSubtraction(ContourFilling(ToBin(picture)), ContourFilling2(ToBin(picture)));
                //ContourFilling3(picture);
                //<Bgr, byte> pic = new Image<Bgr, byte>(picture);
                //Bitmap pic = picture.ToBitmap();
                //pictureBox1.Image = pic;
                label4.Text = ofd.FileName;
            }
        }
        // 上一张
        private void button2_Click(object sender, EventArgs e)
        {
            
            //FileNmae = Directory.GetFiles(@"D:\work\HCI\工件样品");
            times--;
            if (times < 0)
                times = FileNmae.Length - 1;
            picture = new Image<Bgr, byte>(FileNmae[times]);
            pictureBox2.Image = Image.FromFile(FileNmae[times]);
            //label4.Text = ofd.FileName;
            Image<Bgr, byte> pic = new Image<Bgr, byte>(PicSubtraction(ContourFilling(ToBin(picture)), ContourFilling2(ToBin(picture))).Bitmap);
            pictureBox1.Image = ContourFilling3(pic).Bitmap;
        }
        // 下一张
        private void button3_Click(object sender, EventArgs e)
        {
            //FileNmae = Directory.GetFiles(@"D:\work\HCI\工件样品");
            times++;
            if (times > FileNmae.Length - 1)
                times = 0;
            picture = new Image<Bgr, byte>(FileNmae[times]);
            pictureBox2.Image = Image.FromFile(FileNmae[times]);
            //label4.Text = Path.GetFileName(FileNmae[times]);
            Image<Bgr, byte> pic = new Image<Bgr, byte>(PicSubtraction(ContourFilling(ToBin(picture)), ContourFilling2(ToBin(picture))).Bitmap);
            pictureBox1.Image = ContourFilling3(pic).Bitmap;
        }
        // Erode值
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ErodeVaule = Convert.ToInt16(numericUpDown1.Text);
        }
        // Delite值
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            DelitVaule = Convert.ToInt16(numericUpDown2.Text);
        }

        // 二值化
        private Image<Gray, byte> ToBin(Image<Bgr, byte> pic)
        {
            Image<Gray, byte> outpic = pic.Convert<Gray, byte>();
            outpic = outpic.ThresholdBinary(new Gray(100), new Gray(255));
            outpic = outpic.Erode(ErodeVaule);
            outpic = outpic.Dilate(DelitVaule);
            return outpic;
        }
        // 补全轮廓并填充
        private Image<Bgr, byte> ContourFilling(Image<Gray, byte> pic)
        {
            Image<Bgr, byte> outpic = new Image<Bgr, byte>(pic.Size);
            pic = pic.Canny(100, 255);
            Image<Gray, byte> outcon = new Image<Gray, byte>(pic.Size);
            VectorOfVectorOfPoint con = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(pic, con, outcon, RetrType.External, ChainApproxMethod.ChainApproxNone);
            Point[][] con1 = con.ToArrayOfArray();
            PointF[][] con2 = Array.ConvertAll(con1, new Converter<Point[], PointF[]>(PointToPointF));
            PointF[] hull = new PointF[con[0].Size];
            for (int i = 0; i < con.Size; i++)
            {
                hull = CvInvoke.ConvexHull(con2[i], true);
                for (int j = 0; j < hull.Length; j++)
                {
                    Point p1 = new Point((int)(hull[j].X + 0.5), (int)(hull[j].Y + 0.5));
                    Point p2;
                    if (j == hull.Length - 1)
                    {
                        p2 = new Point((int)(hull[0].X + 0.5), (int)(hull[0].Y + 0.5));
                    }
                    else
                        p2 = new Point((int)(hull[j + 1].X + 0.5), (int)(hull[j + 1].Y + 0.5));
                    CvInvoke.Line(outpic, p1, p2, new MCvScalar(255, 0, 255, 255), 2, 0, 0);
                }
            }

            Image<Gray, byte> gray = new Image<Gray, byte>(pic.Size);
            gray = outpic.Convert<Gray, byte>();
            gray = gray.ThresholdBinary(new Gray(100), new Gray(255));
            gray = gray.Canny(100, 255);
            VectorOfVectorOfPoint con3 = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(gray, con3, outcon, RetrType.External, ChainApproxMethod.ChainApproxNone);
            for (int i = 0; i < con3.Size; i++)
            {
                CvInvoke.DrawContours(outpic, con3, i, new MCvScalar(255, 0, 0), -1);
            }

            return outpic;
        }
        // 填充缺陷轮廓
        private Image<Bgr, byte> ContourFilling2(Image<Gray, byte> pic)
        {
            Image<Bgr, byte> outpic = new Image<Bgr, byte>(pic.Size);
            pic = pic.Canny(100, 255);
            Image<Gray, byte> outcon = new Image<Gray, byte>(pic.Size);
            VectorOfVectorOfPoint con = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(pic, con, outcon, RetrType.External, ChainApproxMethod.ChainApproxNone);
            for (int i = 0; i < con.Size; i++)
            {
                CvInvoke.DrawContours(outpic, con, i, new MCvScalar(0, 255, 255, 0), -1);
            }
            for (int i = 0; i < con.Size; i++)
            {
                CvInvoke.DrawContours(outpic, con, i, new MCvScalar(0, 255, 255, 0), 10);
            }
            return outpic;
        }
        // 叠加图像
        private Image<Bgr, byte> PicSubtraction(Image<Bgr, byte> pic1, Image<Bgr, byte> pic2)
        {
            Image<Bgr, byte> outpic = new Image<Bgr, byte>(pic1.Size);
            pic1 = ContourFilling(ToBin(picture));
            pic2 = ContourFilling2(ToBin(picture));
            CvInvoke.AddWeighted(pic1, 0.5, pic2, 0.5, 1, outpic);

            return outpic;
        }
        // Point转换为PointF
        private PointF[] PointToPointF(Point[] pt)
        {
            PointF[] aaa = new PointF[pt.Length];
            int num = 0;
            foreach (var point in pt)
            {
                aaa[num].X = point.X;
                aaa[num++].Y = (int)point.Y;
            }
            return aaa;
        }
        // 填充缺陷轮廓
        private Image<Bgr, byte> ContourFilling3(Image<Bgr, byte> pic)
        {
            Image<Bgr, byte> outpic = new Image<Bgr, byte>(pic.Size);
            Image<Ycc, byte> ycc = pic.Convert<Ycc, byte>();
            for (int i = 0; i < ycc.Height; i++)
                for (int j = 0; j < ycc.Width; j++)
                {
                    if (ycc[i, j].Cr > 35 && ycc[i, j].Cr < 148 &&
                        ycc[i, j].Cb > 48 && ycc[i, j].Cb < 141)
                    {
                        ycc[i, j] = new Ycc(0, 0, 0);
                    }
                    else ycc[i, j] = new Ycc(255, 255, 255);
                }
            Image<Gray, byte> gray = ycc.Convert<Gray, byte>();
            gray = gray.ThresholdBinary(new Gray(100), new Gray(255));
            gray = gray.Canny(100, 60);
            Image<Gray, byte> outcon = new Image<Gray, byte>(pic.Size);
            VectorOfVectorOfPoint con = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(gray, con, outcon, RetrType.External, ChainApproxMethod.ChainApproxNone);
            int n = 0;

            for (int i = 0; i < con.Size; i++)
            {
                if (CvInvoke.ContourArea(con[i]) > 0)
                {
                    n++;
                }
            }
            textBox1.Text = "共" + n.ToString() + "个缺陷" + "      "+"\n";
            n = 0;
            for (int i = 0; i < con.Size; i++)
            {
                if (CvInvoke.ContourArea(con[i]) > 0)
                {
                    CvInvoke.DrawContours(outpic, con, i, new MCvScalar(0, 255, 0), 5);
                    textBox1.Text = textBox1.Text + "第" + (++n).ToString() + "个缺陷的面积为" + CvInvoke.ContourArea(con[i])+"    \n";
                }
            }
            CvInvoke.AddWeighted(outpic, 0.5, picture, 0.5, 0, outpic);
            return outpic;
        }
    }
}
