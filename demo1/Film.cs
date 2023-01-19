using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiduPan
{
    public class MyFilm
    {
        public static string Path_Location = System.Environment.CurrentDirectory + "/baidu";
        public static string toPath = System.Environment.CurrentDirectory + "/baidu/";//切片缓存路径
        public static int num = 0;//切片数量




        /// <summary>
        /// 获取文件MD5
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileMD5(string filepath)
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


        /// <summary>
        /// 获取文件的MD5码
        /// </summary>
        /// <param name="fileName">传入的文件名（含路径及后缀名）</param>
        /// <returns></returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, System.IO.FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

        /// <summary>
        /// 获取文件大小,单位B
        /// </summary>
        /// <param name="filepath">路径</param>
        /// <returns></returns>
        public static long GetFileSize(string filepath)
        {
            long lSize = 0;
            if (File.Exists(filepath))
                lSize = new FileInfo(filepath).Length;
            return lSize;
        }


        /// <summary>
        /// 文件切片
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="size"></param>
        /// <param name="progressBar"></param>
        public static bool ProFileDeal(string filePath, long size)
        {

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (fs.Length % size == 0) num = (int)(fs.Length / size);
            else num = (int)(fs.Length / size) + 1;
            byte[] file_byte = new byte[size];
            string path = "";
            for (int i = 0; i < num - 1; i++)
            {

                string filename = "file" + i.ToString();
                path = System.Environment.CurrentDirectory + "/baidu/" + filename;
                FileStream streams = new FileStream(path, FileMode.Create, FileAccess.Write);
                fs.Position = i * size;
                fs.Read(file_byte, 0, (int)size);
                Application.DoEvents();
                streams.Write(file_byte, 0, (int)size);
                streams.Close();
            }
            string filenam = "file" + (num - 1).ToString();
            path = System.Environment.CurrentDirectory + "/baidu/" + filenam;
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            fs.Position = (num - 1) * size;
            fs.Read(file_byte, 0, (int)(fs.Length % size));
            stream.Write(file_byte, 0, (int)(fs.Length % size));
            stream.Close();
            fs.Close();
            //progressBar.Visible = false;

            int count = System.IO.Directory.GetFiles(Path_Location).Length;
            if (count == num) return true;
            else return false;

        }
    }
}
