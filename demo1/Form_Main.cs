using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace BaiduPan
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "所有文件|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.FileName;

                textBox3.Text = "/apps/" + Path.GetFileName(dialog.FileName);
            }
        }

        private void bt_UploadAsync_Click(object sender, EventArgs e)
        {
            label_upload.Text = "处理中。。。";

            MyBaidu.Upload();
            MyBaidu.UploadAsync(richTextBox2);

            label_upload.Text = "已完成";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            label_file_cut.Text = "处理中。。。";

            if (Directory.Exists(System.Environment.CurrentDirectory + "/baidu/"))
            {
             
                    DirectoryInfo dir = new DirectoryInfo(System.Environment.CurrentDirectory + "/baidu/");
                    FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                    foreach (FileSystemInfo i in fileinfo)
                    {
                        if (i is DirectoryInfo)            //判断是否文件夹
                        {
                            DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                            subdir.Delete(true);          //删除子目录和文件
                        }
                        else
                        {
                            File.Delete(i.FullName);      //删除指定文件
                        }
                    }
            }
            else {
                Directory.CreateDirectory(System.Environment.CurrentDirectory + "/baidu/");
            }

            MyFilm.ProFileDeal(textBox2.Text, 4 * 1024 * 1024);

            label_file_cut.Text = "已完成";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label_pre_upload.Text = "处理中";

            MyBaidu.PreUpload(textBox1.Text.Trim(), textBox3.Text, textBox2.Text);//预上传

            label_pre_upload.Text = "已完成";
        }

        private void bt_PreUploadAsync_Click(object sender, EventArgs e)
        {
            label_precreate.Text = "处理中";

            MyBaidu.PreUploadAsync(richTextBox1);

            label_precreate.Text = "已完成";
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //合并自己仿照上面的请求方式 自己写下就可以成功上传了
        }
    }
}
