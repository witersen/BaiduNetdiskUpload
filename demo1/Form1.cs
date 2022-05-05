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



namespace demo1
{
    public partial class Form1 : Form
    {
        /*
         * preupload 参数
         */
        private string pre_url;
        private string access_token;
        private string pre_upload_message;
        private string upload_message;
        private string serverpath;
        private string size;
        private string isdir;
        private int rtype;
        private int autoinit;
        private string block_list;
        private string content_md5;
        private string slice_md5;

        /*
         * upload 参数
         */
        private string uploadid;
        private string up_url;
        private string up_method;
        private string up_type;
        private int up_partseq;
        private string localpath;

        public Form1()
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
                button3.Enabled = true;
                textBox3.Text = "/apps/" + Path.GetFileName(dialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PreUpload();//预上传
        }

        private void PreUpload()
        {
            access_token = textBox1.Text.Trim();
            pre_url = "http://pan.baidu.com/rest/2.0/xpan/file?method=precreate&access_token=" + access_token;
            serverpath = textBox3.Text;
            size = GetFileSize(textBox2.Text).ToString();
            isdir = "0";
            rtype = 3;//非必选 3为文件覆盖
            autoinit = 1;
            block_list = "[\"" + GetFileMD5(textBox2.Text) + "\"]";
            content_md5 = GetFileMD5(textBox2.Text); //非必选
            slice_md5 = GetFileMD5(textBox2.Text); //非必选
            PreUploadAsync();
        }

        private async void PreUploadAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), pre_url))
                {
                    request.Headers.TryAddWithoutValidation("User-Agent", "pan.baidu.com");

                    request.Content = new StringContent("path=" + serverpath + "&size=" + size + "&isdir=" + isdir + "&autoinit=" + autoinit + "&rtype=" + rtype + "&block_list=" + block_list + "&content-md5=" + content_md5 + "&slice-md5=" + slice_md5);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    
                    string result = await response.Content.ReadAsStringAsync();
                    richTextBox1.Text = result;
                    pre_upload_message = result;

                    //preupload 后根据return type判断是否上传
                    Upload();
                }
            }

        }

        private void Upload()
        {
            up_url = "https://d.pcs.baidu.com/rest/2.0/pcs/superfile2?access_token=" + access_token;
            up_method = "upload";
            up_type = "tmpfile";
            uploadid = "";
            up_partseq = 0;
            localpath = textBox2.Text.Trim();

            JObject json1 = (JObject)JsonConvert.DeserializeObject(pre_upload_message);
            //JArray array = (JArray)json1["return_type"];
            if (json1["return_type"].ToString() == "2")
            {
                /*
                 * 云端已有文件记录
                 */
            }
            else if(json1["return_type"].ToString() == "1")
            {
                /*
                 * 云端无文件记录 需要分片上传
                 */

                //获取request_id
                uploadid = json1["uploadid"].ToString();

                //分片上传
                //UploadAsync();
            }
        }

        private async void UploadAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), up_url + "&method=" + up_method + "&type=" + up_type + "&path=" + serverpath + "&uploadid=" + uploadid + "&partseq=" + up_partseq))
                {
                    var multipartContent = new MultipartFormDataContent();
                    multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(localpath)), "file", Path.GetFileName(localpath));
                    request.Content = multipartContent;
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Headers.TryAddWithoutValidation("User-Agent", "d.pcs.baidu.com");

                    var response = await httpClient.SendAsync(request);

                    string result = await response.Content.ReadAsStringAsync();
                    //JObject json1 = (JObject)JsonConvert.DeserializeObject(result);
                    richTextBox2.Text = result;
                    upload_message = result;
                }
            }
        }

        private string GetFileMD5(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            int bufferSize = 1048576;
            byte[] buff = new byte[bufferSize];
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.Initialize();
            long offset = 0;
            while (offset < fs.Length)
            {
                long readSize = bufferSize;
                if (offset + readSize > fs.Length)
                    readSize = fs.Length - offset;
                fs.Read(buff, 0, Convert.ToInt32(readSize));
                if (offset + readSize < fs.Length)
                    md5.TransformBlock(buff, 0, Convert.ToInt32(readSize), buff, 0);
                else
                    md5.TransformFinalBlock(buff, 0, Convert.ToInt32(readSize));
                offset += bufferSize;
            }
            if (offset >= fs.Length)
            {
                fs.Close();
                byte[] result = md5.Hash;
                md5.Clear();
                StringBuilder sb = new StringBuilder(32);
                for (int i = 0; i < result.Length; i++)
                    sb.Append(result[i].ToString("X2"));
                return sb.ToString();
            }
            else
            {
                fs.Close();
                return null;
            }
        }

        private long GetFileSize(string filepath)
        {
            long lSize = 0;
            if (File.Exists(filepath))
                lSize = new FileInfo(filepath).Length;
            return lSize;
        }
    }
}
