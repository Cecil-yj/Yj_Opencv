using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;


// 因为输出类型是windows应用程序，所以不会产生命令提示行界面
namespace Yj_Opencv
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]  //单线程 single thread apartment
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();  //应用程序可视化
            Application.SetCompatibleTextRenderingDefault(false); //设置控件的一些默认值
            Application.Run(new Form5());  //运行表1
            Application.Run(new Form6());  // 运行表4

            //muban.muban1();
            //os_tra.cv_05();
            //os_tra.cv_17();

        }
    }
}
