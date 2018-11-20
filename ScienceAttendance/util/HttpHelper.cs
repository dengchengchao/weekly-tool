using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// By：https://blog.csdn.net/lai444132348/article/details/26351903
/// </summary>
namespace ScienceAttendance.util
{

    public abstract class HttpHelper {

        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(WeeklyUtils));

        //获取Cookie信息
        public static CookieContainer GetCookie(string url, IDictionary<string, string> parameters)
        {
            HttpWebResponse response = HttpHelper.PostForWebResponse(url, parameters);
            CookieContainer cookieContainer = new CookieContainer();
            if (response!=null)
            {
                CookieCollection cookies = response.Cookies;

                for (int i = 0; i < cookies.Count; i++)
                {
                    cookieContainer.Add(new Uri("http://kq.thunisoft.com/kqgl"), cookies[i]);
                }
                response.Close();
            }
          
            return cookieContainer;
        }

        //想网页模拟发送Post消息
        public static string Post(string url, IDictionary<string, string> parameters, CookieContainer cookies=null) {
            HttpWebResponse response = PostForWebResponse(url, parameters, cookies);
            if (response!=null)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                string data = reader.ReadToEnd();
                reader.Close();
                return data;
            }

            return "error";
        }



        //获取完request后，记得自行关闭
        private static HttpWebResponse PostForWebResponse(string url, IDictionary<string, string> data,CookieContainer cookeis=null) {
            if (cookeis==null) cookeis = new CookieContainer();
            StringBuilder postStr = new StringBuilder();
            foreach (string key in data.Keys)
            {
                postStr.Append(key).Append( "=").Append(data[key]).Append( "&");
            }
            if (postStr.Length>1)
            {
                postStr.Remove(postStr.Length - 1, 1);
            }
          
            byte[] postData = Encoding.UTF8.GetBytes(postStr.ToString());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.Method = "POST";
                request.AllowAutoRedirect = true;
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                request.CookieContainer = cookeis;
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11";
                request.ContentLength = postData.Length;
                request.Host = "kq.thunisoft.com:8080";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length);
                requestStream.Close();
                return (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e) {

                log.Error("网络请求失败", e);
            
            }
            return null;
         
        }

    }
}
