namespace Yj_Opencv
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ContentTxt = new System.Windows.Forms.TextBox();
            this.ImgPathTxt = new System.Windows.Forms.TextBox();
            this.OpenImgBtn = new System.Windows.Forms.Button();
            this.Create1DBtn = new System.Windows.Forms.Button();
            this.Read1DBtn = new System.Windows.Forms.Button();
            this.Create2DBtn = new System.Windows.Forms.Button();
            this.Read2DBtn = new System.Windows.Forms.Button();
            this.Create2DOfHaveLogoBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.barCodeImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.barCodeImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "条码内容：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "图片路径：";
            // 
            // ContentTxt
            // 
            this.ContentTxt.Location = new System.Drawing.Point(76, 16);
            this.ContentTxt.Name = "ContentTxt";
            this.ContentTxt.Size = new System.Drawing.Size(224, 21);
            this.ContentTxt.TabIndex = 2;
            this.ContentTxt.Text = "9787302380979";
            // 
            // ImgPathTxt
            // 
            this.ImgPathTxt.Location = new System.Drawing.Point(76, 45);
            this.ImgPathTxt.Name = "ImgPathTxt";
            this.ImgPathTxt.Size = new System.Drawing.Size(143, 21);
            this.ImgPathTxt.TabIndex = 3;
            // 
            // OpenImgBtn
            // 
            this.OpenImgBtn.Location = new System.Drawing.Point(225, 43);
            this.OpenImgBtn.Name = "OpenImgBtn";
            this.OpenImgBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenImgBtn.TabIndex = 4;
            this.OpenImgBtn.Text = "打开图片";
            this.OpenImgBtn.UseVisualStyleBackColor = true;
            this.OpenImgBtn.Click += new System.EventHandler(this.OpenImgBtn_Click);
            // 
            // Create1DBtn
            // 
            this.Create1DBtn.Location = new System.Drawing.Point(343, 14);
            this.Create1DBtn.Name = "Create1DBtn";
            this.Create1DBtn.Size = new System.Drawing.Size(75, 23);
            this.Create1DBtn.TabIndex = 5;
            this.Create1DBtn.Text = "生成一维码";
            this.Create1DBtn.UseVisualStyleBackColor = true;
            this.Create1DBtn.Click += new System.EventHandler(this.Create1DBtn_Click);
            // 
            // Read1DBtn
            // 
            this.Read1DBtn.Location = new System.Drawing.Point(343, 43);
            this.Read1DBtn.Name = "Read1DBtn";
            this.Read1DBtn.Size = new System.Drawing.Size(75, 23);
            this.Read1DBtn.TabIndex = 6;
            this.Read1DBtn.Text = "读取一维码";
            this.Read1DBtn.UseVisualStyleBackColor = true;
            this.Read1DBtn.Click += new System.EventHandler(this.Read1DBtn_Click);
            // 
            // Create2DBtn
            // 
            this.Create2DBtn.Location = new System.Drawing.Point(433, 14);
            this.Create2DBtn.Name = "Create2DBtn";
            this.Create2DBtn.Size = new System.Drawing.Size(75, 23);
            this.Create2DBtn.TabIndex = 7;
            this.Create2DBtn.Text = "生成二维码";
            this.Create2DBtn.UseVisualStyleBackColor = true;
            this.Create2DBtn.Click += new System.EventHandler(this.Create2DBtn_Click);
            // 
            // Read2DBtn
            // 
            this.Read2DBtn.Location = new System.Drawing.Point(433, 43);
            this.Read2DBtn.Name = "Read2DBtn";
            this.Read2DBtn.Size = new System.Drawing.Size(75, 23);
            this.Read2DBtn.TabIndex = 8;
            this.Read2DBtn.Text = "读取二维码";
            this.Read2DBtn.UseVisualStyleBackColor = true;
            this.Read2DBtn.Click += new System.EventHandler(this.Read2DBtn_Click);
            // 
            // Create2DOfHaveLogoBtn
            // 
            this.Create2DOfHaveLogoBtn.Location = new System.Drawing.Point(343, 73);
            this.Create2DOfHaveLogoBtn.Name = "Create2DOfHaveLogoBtn";
            this.Create2DOfHaveLogoBtn.Size = new System.Drawing.Size(165, 23);
            this.Create2DOfHaveLogoBtn.TabIndex = 9;
            this.Create2DOfHaveLogoBtn.Text = "生成带Logo二维码";
            this.Create2DOfHaveLogoBtn.UseVisualStyleBackColor = true;
            this.Create2DOfHaveLogoBtn.Click += new System.EventHandler(this.Create2DOfHaveLogoBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "图片：";
            // 
            // barCodeImg
            // 
            this.barCodeImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barCodeImg.Location = new System.Drawing.Point(15, 99);
            this.barCodeImg.Name = "barCodeImg";
            this.barCodeImg.Size = new System.Drawing.Size(285, 200);
            this.barCodeImg.TabIndex = 11;
            this.barCodeImg.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(534, 313);
            this.Controls.Add(this.barCodeImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Create2DOfHaveLogoBtn);
            this.Controls.Add(this.Read2DBtn);
            this.Controls.Add(this.Create2DBtn);
            this.Controls.Add(this.Read1DBtn);
            this.Controls.Add(this.Create1DBtn);
            this.Controls.Add(this.OpenImgBtn);
            this.Controls.Add(this.ImgPathTxt);
            this.Controls.Add(this.ContentTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "条形码";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barCodeImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ContentTxt;
        private System.Windows.Forms.TextBox ImgPathTxt;
        private System.Windows.Forms.Button OpenImgBtn;
        private System.Windows.Forms.Button Create1DBtn;
        private System.Windows.Forms.Button Read1DBtn;
        private System.Windows.Forms.Button Create2DBtn;
        private System.Windows.Forms.Button Read2DBtn;
        private System.Windows.Forms.Button Create2DOfHaveLogoBtn;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.PictureBox barCodeImg;
    }
}