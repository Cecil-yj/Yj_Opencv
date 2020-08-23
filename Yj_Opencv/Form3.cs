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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Owner;
            numericUpDown1.Value = form1.timer1_change;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Owner;
            form1.timer1_change = (int)numericUpDown1.Value;

            form1.textBox1.AppendText("\r\n设置修改成功！");
            form1.textBox1.SelectionStart = form1.textBox1.TextLength;
            form1.textBox1.ScrollToCaret();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
