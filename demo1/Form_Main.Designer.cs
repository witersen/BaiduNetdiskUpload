namespace BaiduPan
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_UploadAsync = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.bt_PreUploadAsync = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_pre_upload = new System.Windows.Forms.Label();
            this.label_file_cut = new System.Windows.Forms.Label();
            this.label_precreate = new System.Windows.Forms.Label();
            this.label_pan_path = new System.Windows.Forms.Label();
            this.label_access_token = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label_upload = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(199, 60);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(908, 36);
            this.textBox2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(16, 60);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "选择本地文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(199, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(908, 36);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "第一步的toke这里拿做测试：https://pan.baidu.com/union/devtool/upload?menuKey=union-devtool-u" +
    "pload";
            this.textBox1.WordWrap = false;
            // 
            // bt_UploadAsync
            // 
            this.bt_UploadAsync.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_UploadAsync.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_UploadAsync.Location = new System.Drawing.Point(16, 505);
            this.bt_UploadAsync.Margin = new System.Windows.Forms.Padding(4);
            this.bt_UploadAsync.Name = "bt_UploadAsync";
            this.bt_UploadAsync.Size = new System.Drawing.Size(175, 38);
            this.bt_UploadAsync.TabIndex = 12;
            this.bt_UploadAsync.Text = "分片上传";
            this.bt_UploadAsync.UseVisualStyleBackColor = true;
            this.bt_UploadAsync.Click += new System.EventHandler(this.bt_UploadAsync_Click);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(199, 105);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(907, 36);
            this.textBox3.TabIndex = 14;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(199, 365);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(907, 119);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(199, 560);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(907, 119);
            this.richTextBox2.TabIndex = 18;
            this.richTextBox2.Text = "";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.Location = new System.Drawing.Point(16, 161);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(175, 38);
            this.button7.TabIndex = 19;
            this.button7.Text = "文件预处理(文件切片)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(16, 230);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(175, 60);
            this.button8.TabIndex = 22;
            this.button8.Text = "预上传准备(计算每个分片的md5 准备precreate的url)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // bt_PreUploadAsync
            // 
            this.bt_PreUploadAsync.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_PreUploadAsync.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_PreUploadAsync.Location = new System.Drawing.Point(16, 309);
            this.bt_PreUploadAsync.Margin = new System.Windows.Forms.Padding(4);
            this.bt_PreUploadAsync.Name = "bt_PreUploadAsync";
            this.bt_PreUploadAsync.Size = new System.Drawing.Size(175, 38);
            this.bt_PreUploadAsync.TabIndex = 24;
            this.bt_PreUploadAsync.Text = "预上传(precreate)";
            this.bt_PreUploadAsync.UseVisualStyleBackColor = true;
            this.bt_PreUploadAsync.Click += new System.EventHandler(this.bt_PreUploadAsync_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 38);
            this.label1.TabIndex = 26;
            this.label1.Text = "预上传返回值";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 560);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 38);
            this.label2.TabIndex = 27;
            this.label2.Text = "分片上传返回值";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label_pre_upload
            // 
            this.label_pre_upload.Location = new System.Drawing.Point(208, 252);
            this.label_pre_upload.Name = "label_pre_upload";
            this.label_pre_upload.Size = new System.Drawing.Size(158, 23);
            this.label_pre_upload.TabIndex = 28;
            this.label_pre_upload.Text = "待进行";
            this.label_pre_upload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_file_cut
            // 
            this.label_file_cut.Location = new System.Drawing.Point(208, 169);
            this.label_file_cut.Name = "label_file_cut";
            this.label_file_cut.Size = new System.Drawing.Size(158, 23);
            this.label_file_cut.TabIndex = 29;
            this.label_file_cut.Text = "待进行";
            this.label_file_cut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_precreate
            // 
            this.label_precreate.Location = new System.Drawing.Point(208, 317);
            this.label_precreate.Name = "label_precreate";
            this.label_precreate.Size = new System.Drawing.Size(158, 23);
            this.label_precreate.TabIndex = 30;
            this.label_precreate.Text = "待进行";
            this.label_precreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_pan_path
            // 
            this.label_pan_path.Location = new System.Drawing.Point(17, 105);
            this.label_pan_path.Name = "label_pan_path";
            this.label_pan_path.Size = new System.Drawing.Size(175, 36);
            this.label_pan_path.TabIndex = 31;
            this.label_pan_path.Text = "网盘路径";
            this.label_pan_path.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_access_token
            // 
            this.label_access_token.Location = new System.Drawing.Point(17, 15);
            this.label_access_token.Name = "label_access_token";
            this.label_access_token.Size = new System.Drawing.Size(175, 36);
            this.label_access_token.TabIndex = 32;
            this.label_access_token.Text = "access_token";
            this.label_access_token.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(16, 684);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 38);
            this.button2.TabIndex = 33;
            this.button2.Text = "合并文件(未来得及写 仿照前面就可以)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_upload
            // 
            this.label_upload.Location = new System.Drawing.Point(208, 514);
            this.label_upload.Name = "label_upload";
            this.label_upload.Size = new System.Drawing.Size(158, 23);
            this.label_upload.TabIndex = 34;
            this.label_upload.Text = "待进行";
            this.label_upload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 735);
            this.Controls.Add(this.label_upload);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_access_token);
            this.Controls.Add(this.label_pan_path);
            this.Controls.Add(this.label_precreate);
            this.Controls.Add(this.label_file_cut);
            this.Controls.Add(this.label_pre_upload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_PreUploadAsync);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.bt_UploadAsync);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Main";
            this.Text = "BaiDuPan";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_UploadAsync;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button bt_PreUploadAsync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_pre_upload;
        private System.Windows.Forms.Label label_file_cut;
        private System.Windows.Forms.Label label_precreate;
        private System.Windows.Forms.Label label_pan_path;
        private System.Windows.Forms.Label label_access_token;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_upload;
    }
}

