/// <summary>
/// 类说明：HttpHelper类，用来实现Http访问，Post或者Get方式的，直接访问，带Cookie的，带证书的等方式，可以设置代理
/// 重要提示：请不要自行修改本类，如果因为你自己修改后将无法升级到新版本。如果确实有什么问题请到官方网站提建议，
/// 我们一定会及时修改
/// 编码日期：2011-09-20
/// 编 码 人：苏飞
/// 联系方式：361983679  
/// 官方网址：http://www.sufeinet.com/thread-3-1-1.html
/// 修改日期：2013-07-02
/// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Web;
using System.Collections.Specialized;

namespace Common
{
    /// <summary>
    /// Http连接操作帮助类
    /// </summary>
    public class HttpHelper
    {
        public static string Post(string url, string paramData)
        {
            return Post(url, paramData, Encoding.UTF8);
        }

        public static string Post(string url, string paramData, Encoding encoding)
        {
            string result;

            if (url.ToLower().IndexOf("https", System.StringComparison.Ordinal) > -1)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((sender, certificate, chain, errors) => { return true; });
            }

            try
            {
                var wc = new WebClient();
                if (string.IsNullOrEmpty(wc.Headers["Content-Type"]))
                {
                    wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                }
                wc.Encoding = encoding;

                result = wc.UploadString(url, "POST", paramData);
            }
            catch (Exception e)
            {
                throw;
            }

            return result;
        }

        public static string Get(string url)
        {
            return Get(url, Encoding.UTF8);
        }

        public static string Get(string url, Encoding encoding)
        {
            try
            {
                var wc = new WebClient { Encoding = encoding };
                var readStream = wc.OpenRead(url);
                using (var sr = new StreamReader(readStream, encoding))
                {
                    var result = sr.ReadToEnd();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string PostData(string url, NameValueCollection parameters)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            Encoding encoding = Encoding.UTF8;
            var parassb = new StringBuilder();
            foreach (string key in parameters.Keys)
            {
                if (parassb.Length > 0)
                {
                    parassb.Append("&");
                }
                parassb.AppendFormat("{0}={1}", key, HttpUtility.UrlEncode(parameters[key]));
            }


            byte[] bs = Encoding.UTF8.GetBytes(parassb.ToString());

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }

            string result = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
        }
    }  


}

