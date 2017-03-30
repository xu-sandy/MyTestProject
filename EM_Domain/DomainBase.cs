using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EM_Domain
{
    public abstract class DomainBase
    {
        public string Url { get; set; }
        /// <summary>
        /// 协议头
        /// </summary>
        public class HttpPara
        {
            public string Referer { get; set; }
            public string Accept { get; set; }
            public string ContentType { get; set; }
            public string UserAgent { get; set; }

        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="httpParas">协议头</param>
        /// <param name="encoding">网站支持的编码格式</param>
        /// <returns></returns>
        public string GetHtml(string url, HttpPara httpParas, Encoding encoding)
        {
            if (!url.Contains("http://"))
            {
                url = "http://" + url;
            }
            HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;

            //协议头的赋值
            req.Method = "GET";
            if (httpParas != null)
            {
                req.Referer = httpParas.Referer;
                req.Accept = httpParas.Accept;
                req.ContentType = httpParas.ContentType;
                req.UserAgent = httpParas.UserAgent;
            }
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;

            using (Stream stream = res.GetResponseStream())
            {

                using (StreamReader reader = new StreamReader(stream, encoding))
                {

                    string result = reader.ReadToEnd();
                    return result;
                }
            }

        }


        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="postData">账号参数</param>
        /// <param name="httpParas">协议头</param>
        /// <param name="encoding">网站支持的编码格式</param>
        /// <returns></returns>
        public string PostHtml(string url, string postData, HttpPara httpParas, Encoding encoding)
        {
            byte[] bt = encoding.GetBytes(postData);

            if (!url.Contains("http://"))
            {
                url = "http://" + url;
            }
            HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;

            //协议头的赋值
            req.Method = "POST";
            req.Referer = httpParas.Referer;
            req.Accept = httpParas.Accept;
            req.ContentType = httpParas.ContentType;
            req.UserAgent = httpParas.UserAgent;

            using (Stream streamReq = req.GetRequestStream())
            {
                streamReq.Write(bt, 0, bt.Length);
                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                using (Stream streamRes = res.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(streamRes, encoding))
                    {
                        string result = reader.ReadToEnd();
                        return result;
                    }
                }
            }
        }
    }
}
