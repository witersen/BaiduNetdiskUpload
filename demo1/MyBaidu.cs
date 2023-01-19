
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace BaiduPan
{
    /// <summary>
    /// 表单数据项
    /// </summary>
    public class FormItemModel
    {
        /// <summary>
        /// 表单键，request["key"]
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 表单值,上传文件时忽略，request["key"].value
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 是否是文件
        /// </summary>
        public bool IsFile
        {
            get
            {
                if (FileContent == null || FileContent.Length == 0)
                    return false;

                if (FileContent != null && FileContent.Length > 0 && string.IsNullOrWhiteSpace(FileName))
                    throw new Exception("上传文件时 FileName 属性值不能为空");
                return true;
            }
        }
        /// <summary>
        /// 上传的文件名
        /// </summary>
        public string FileName { set; get; }
        /// <summary>
        /// 上传的文件内容
        /// </summary>
        public Stream FileContent { set; get; }
    }

    public class MyBaidu
    {
        /*
        * preupload 参数
        */
        public static string pre_url;
        public static string access_token;
        public static string pre_upload_message;
        public static string upload_message;
        public static string serverpath;
        public static string size;
        public static string isdir;
        public static int rtype;
        public static int autoinit;
        public static string block_list;
        public static string content_md5;
        public static string slice_md5;

        /*
         * upload 参数
         */
        public static string uploadid;
        public static string up_url;
        public static string up_method;
        public static string up_type;
        public static int up_partseq;
        public static string localpath;



        /// <summary>
        /// 预上传准备
        /// </summary>
        /// <param name="Access_token"></param>
        /// <param name="Serverpath"></param>
        /// <param name="filePath"></param>
        /// <param name="Bar"></param>
        public static void PreUpload(string Access_token, string Serverpath, string filePath)
        {
            access_token = Access_token; //textBox1.Text.Trim();
            pre_url = "http://pan.baidu.com/rest/2.0/xpan/file?method=precreate&access_token=" + access_token;
            serverpath = Serverpath;//textBox3.Text;
            localpath = filePath;
            size = MyFilm.GetFileSize(localpath).ToString();//textbox2
            isdir = "0";
            rtype = 3;//非必选 3为文件覆盖
            autoinit = 1;
            block_list = "[\"";
            for (int i = 0; i < MyFilm.num - 1; i++)
            {

                string path = System.Environment.CurrentDirectory + "/baidu/file" + i.ToString();
                block_list += MyFilm.GetMD5HashFromFile(path) + "\",\"";
            }

            string pathn = System.Environment.CurrentDirectory + "/baidu/file" + (MyFilm.num - 1).ToString();
            block_list += MyFilm.GetMD5HashFromFile(pathn) + "\"]";
            pre_url = "http://pan.baidu.com/rest/2.0/xpan/file?method=precreate&access_token=" + access_token;

            //MessageBox.Show(block_list);

            //content_md5 = GetFileMD5(textBox2.Text); //非必选
            //slice_md5 = GetFileMD5(textBox2.Text); //非必选
            //PreUploadAsync();
        }


        /// <summary>
        /// 预上传
        /// </summary>
        /// <param name="richTextBox1"></param>
        public static async void PreUploadAsync(RichTextBox richTextBox1)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), pre_url))
                {
                    request.Headers.TryAddWithoutValidation("User-Agent", "pan.baidu.com");

                    request.Content = new StringContent("path=" + serverpath + "&size=" + size
                        + "&isdir=" + isdir + "&autoinit=" + autoinit + "&rtype="
                        + rtype + "&block_list=" + block_list + "&autoinit=1");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);

                    string result = await response.Content.ReadAsStringAsync();
                    richTextBox1.Text = result;
                    pre_upload_message = result;

                    //preupload 后根据return type判断是否上传
                    //Upload();
                }
            }

        }

        public static void Upload()
        {
            up_url = "https://d.pcs.baidu.com/rest/2.0/pcs/superfile2?access_token=" + access_token;
            up_method = "upload";
            up_type = "tmpfile";
            uploadid = "";
            up_partseq = 0;

            JObject json1 = (JObject)JsonConvert.DeserializeObject(pre_upload_message);
            //JArray array = (JArray)json1["return_type"];
            if (json1["return_type"].ToString() == "2")
            {
                MessageBox.Show("该文件已存在!");
                return;
            }
            else if (json1["return_type"].ToString() == "1")
            {
                //MessageBox.Show(json1.ToString());



                //云端无文件记录 需要分片上传
                //获取request_id
                uploadid = json1["uploadid"].ToString();

                //分片上传
                //UploadAsync();
            }
        }

        public static async void UploadAsync(RichTextBox richTextBox2)
        {
            string path = MyFilm.toPath + @"/file";
            for (int i = 0; i < MyFilm.num; i++)
            {
                string url = "https://d.pcs.baidu.com/rest/2.0/pcs/superfile2?method=upload&access_token=" + access_token
                    + "&type=tmpfile&uploadid=" + uploadid + "&path=" + serverpath + "&partseq=" + i.ToString();
                path = MyFilm.toPath + "file" + i;
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                    {
                        richTextBox2.Text += url + "\r\n\r\n";

                        //MessageBox.Show(url);
                        //request.Headers.TryAddWithoutValidation("User-Agent", "d.pcs.baidu.com");
                        //var multipartContent = new MultipartFormDataContent();
                        //multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(path)), "file", Path.GetFileName(path));
                        //request.Content = multipartContent;
                        //
                        //request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
                        //request.Content.Headers.ContentType = new MediaTypeHeaderValueClass("application/json");
                        //request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        //var response = await httpClient.SendAsync(request);
                        //string result = await response.Content.ReadAsStringAsync();
                        //JObject json1 = (JObject)JsonConvert.DeserializeObject(result);
                        //richTextBox2.Text += result + "\r\n\r\n";
                        //upload_message = result;



                        // var url = "http://127.0.0.1/testformdata.aspx?aa=1&bb=2&ccc=3";
                        // var log1 = @"D:\temp\log1.txt";
                        //var log2 = @"D:\temp\log2.txt";
                        var formDatas = new List<FormItemModel>();
                        //添加文件
                        formDatas.Add(new FormItemModel()
                        {
                            Key = "file",
                            Value = "",
                            FileName = "file0",
                            FileContent = File.OpenRead(path)
                        });
                        //formDatas.Add(new FormItemModel()
                        //{
                        // Key = "log2",
                        // Value = "",
                        // FileName = "log2.txt",
                        //  FileContent = File.OpenRead(log2)
                        //});
                        //添加文本
                        //formDatas.Add(new FormItemModel()
                        //{
                        //   Key = "id",
                        //  Value = "id-test-id-test-id-test-id-test-id-test-"
                        //});
                        //formDatas.Add(new FormItemModel()
                        //{
                        //    Key = "name",
                        //   Value = "name-test-name-test-name-test-name-test-name-test-"
                        //});
                        //提交表单

                        string result = PostForm(url, formDatas);

                        richTextBox2.Text += result + "\r\n\r\n";
                        upload_message = result;
                    }
                }
            }
        }

        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formItems">Post表单内容</param>
        /// <param name="cookieContainer"></param>
        /// <param name="timeOut">默认20秒</param>
        /// <param name="encoding">响应内容的编码类型（默认utf-8）</param>
        /// <returns></returns>
        public static string PostForm(string url, List<FormItemModel> formItems, CookieContainer cookieContainer = null, string refererUrl = null, Encoding encoding = null, int timeOut = 20000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            #region 初始化请求对象
            request.Method = "POST";
            request.Timeout = timeOut;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.KeepAlive = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            if (!string.IsNullOrEmpty(refererUrl))
                request.Referer = refererUrl;
            if (cookieContainer != null)
                request.CookieContainer = cookieContainer;
            #endregion

            string boundary = "----" + DateTime.Now.Ticks.ToString("x");//分隔符
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            //请求流
            var postStream = new MemoryStream();
            #region 处理Form表单请求内容
            //是否用Form上传文件
            var formUploadFile = formItems != null && formItems.Count > 0;
            if (formUploadFile)
            {
                //文件数据模板
                string fileFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"" +
                    "\r\nContent-Type: application/octet-stream" +
                    "\r\n\r\n";
                //文本数据模板
                string dataFormdataTemplate =
                    "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                    "\r\n\r\n{1}";
                foreach (var item in formItems)
                {
                    string formdata = null;
                    if (item.IsFile)
                    {
                        //上传文件
                        formdata = string.Format(
                            fileFormdataTemplate,
                            item.Key, //表单键
                            item.FileName);
                    }
                    else
                    {
                        //上传文本
                        formdata = string.Format(
                            dataFormdataTemplate,
                            item.Key,
                            item.Value);
                    }

                    //统一处理
                    byte[] formdataBytes = null;
                    //第一行不需要换行
                    if (postStream.Length == 0)
                        formdataBytes = Encoding.UTF8.GetBytes(formdata.Substring(2, formdata.Length - 2));
                    else
                        formdataBytes = Encoding.UTF8.GetBytes(formdata);
                    postStream.Write(formdataBytes, 0, formdataBytes.Length);

                    //写入文件内容
                    if (item.FileContent != null && item.FileContent.Length > 0)
                    {
                        using (var stream = item.FileContent)
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead = 0;
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                postStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                //结尾
                var footer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                postStream.Write(footer, 0, footer.Length);

            }
            else
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            #endregion

            request.ContentLength = postStream.Length;

            #region 输入二进制流
            if (postStream != null)
            {
                postStream.Position = 0;
                //直接写入流
                Stream requestStream = request.GetRequestStream();

                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = postStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                }

                //debug
                //postStream.Seek(0, SeekOrigin.Begin);
                //StreamReader sr = new StreamReader(postStream);
                //var postStr = sr.ReadToEnd();
                postStream.Close();//关闭文件访问
            }
            #endregion

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (cookieContainer != null)
            {
                response.Cookies = cookieContainer.GetCookies(response.ResponseUri);
            }

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(responseStream, encoding ?? Encoding.UTF8))
                {
                    string retString = myStreamReader.ReadToEnd();
                    return retString;
                }
            }
        }

    }
}
