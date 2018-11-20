using log4net;
using ScienceAttendance.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAttendance.util
{
    public class AttendanceHelper
    {
        private static readonly IDictionary<string, string> DEFAULT_LOG_DATA = new Dictionary<string, string>() {
            {"screen","1600*900" },
            {"sysID","kqgl" }
        };

        private static readonly IDictionary<string, string> DEFAULT_DATA_DATA = new Dictionary<string, string>() {
            { "action","parseItem"},
            { "aty_parseId","5d37ded02229bd7077a3c32595a161f7"},
            { "formType","1"},
            { "itemid","jqContainerRb"},        
            { "fetchFormid","true" }
        };


        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private string m_name;

        private string m_password;

        private CookieContainer m_cookie;

        public  CookieContainer GetCookie() {

            IDictionary<string, string> parameters = new Dictionary<string, string>(DEFAULT_LOG_DATA);
            parameters.Add("jusername", m_name);
            parameters.Add("jpassword", m_password);
            return HttpHelper.GetCookie(Urls.LOGIN, parameters);    
        }

        //获取周报html
        public  string GetWeeklyHtml(string time) {
            IDictionary<string, string> parameters = new Dictionary<string, string>(DEFAULT_DATA_DATA);
            parameters.Add("data", time);
            return HttpHelper.Post(Urls.WEEK_GET, parameters, m_cookie);
        }


        public AttendanceHelper(string name, string pwd) {
            this.m_name = name;
            this.m_password = pwd;
            InitCookies();
        }

        private void InitCookies() {
            m_cookie = GetCookie();
            Uri cookieUri = new Uri("http://kq.thunisoft.com");
            m_cookie.Add(cookieUri, new Cookie("kq.thunisoft.com/kqgl", m_name));
            m_cookie.Add(cookieUri, new Cookie("kq.thunisoft.com/kqgl", MD5Utils.MD5Encrypt32(m_password)));
        }

       
    }
}
