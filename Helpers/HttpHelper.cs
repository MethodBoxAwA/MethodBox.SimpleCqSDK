using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MethodBox.SimpleCqSDK.Helpers
{
    internal static class HttpHelper
    {
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append('&');
                builder.Append($"{item.Key}={item.Value}");
                i++;
            }

            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        /// <summary>
        /// http Post请求
        /// </summary>
        /// <param name="parameterData">参数</param>
        /// <param name="serviceUrl">访问地址</param>
        /// <param name="ContentType">默认 application/json , application/x-www-form-urlencoded,multipart/form-data,raw,binary </param>
        /// <param name="Accept">默认application/json</param>
        /// <returns></returns>
        public static string Post(string parameterData, string serviceUrl, string ContentType = "application/json",
            string Accept = "application/json")
        {
            //先根据用户请求的uri构造请求地址
            //string serviceUrl = string.Format("{0}/{1}", this.BaseUri, uri);

            //创建Web访问对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            //把用户传过来的数据转成“UTF-8”的字节流
            byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(parameterData);

            myRequest.Method = "POST";
            //myRequest.Accept = "application/json";
            //myRequest.ContentType = "application/json";  // //Content-Type: application/x-www-form-urlencoded 
            myRequest.AutomaticDecompression = DecompressionMethods.GZip;
            myRequest.Accept = Accept;
            //myRequest.ContentType = ContentType;
            myRequest.ContentType = "application/json; charset=UTF-8";
            myRequest.ContentLength = buf.Length;
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;

            //myRequest.Headers.Add("content-type", "application/json");
            //myRequest.Headers.Add("accept-encoding", "gzip");
            //myRequest.Headers.Add("accept-charset", "utf-8");

            //发送请求
            Stream stream = myRequest.GetRequestStream();
            stream.Write(buf, 0, buf.Length);
            stream.Close();

            //通过Web访问对象获取响应内容
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
            string returnData = reader.ReadToEnd(); //利用StreamReader就可以从响应内容从头读到尾

            reader.Close();
            myResponse.Close();

            return returnData;
        }
    }
}
