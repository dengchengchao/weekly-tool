using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScienceAttendance.util
{
    public class WeeklyUtils
    {
        public static Action<bool> UpLoadHandle { get; set; }
        private static log4net.ILog log = log4net.LogManager.GetLogger( typeof( WeeklyUtils));

        public static readonly string STATISTICS_URL = "";
        public static readonly string STATISTICS_PARAM = "info";
        public static readonly string STATISTICS_VERSION ="";
        public static readonly string STATISTICS_UPLOAD = "";
        public static int version_now = 1;


        //填写周报
        public static bool postWeekly(DateTime sbsj,string zgs,string whatDo,string xmbh,DateTime signDate) {
            int index = xmbh.IndexOf("###");
            string xmbhNum = xmbh.Substring(index+3, xmbh.Length - index-3);

            IDictionary<string, string> param = new Dictionary<string, string>() {
                {"-action","weekly" },
                {"-user",Properties.Settings.Default.user },
                {"-pwd",Properties.Settings.Default.pwd },
                {"-date",signDate.ToString("yyyy-MM-dd")  },
                {"-sbsj",sbsj.ToString("HH:mm")},
                {"-zgs",zgs },
                {"-gznr",whatDo },
                {"-xmbh",xmbhNum }
            };

            bool result= cmdExeStart(param).Contains("\"success\":\"true\"");

            string postInfo = "已为:" + Properties.Settings.Default.user + "自动考勤，考勤时间为：\t" + param["-date"] + " 考勤结果：\t" + result;

            try
            {
                postUserInfo(postInfo);

            }
            catch (Exception e) { log.Error(e); }
            return result;

        }

        //检测升级
        private static void checkLatestVersion()
        {
            try
            {
                string result = HttpHelper.Post(STATISTICS_VERSION, new Dictionary<string, string>());
                if (result != null && result != "error")
                {
                    int version = Convert.ToInt16(result);
                    UpLoadHandle(version > version_now);
                }
            }
            catch (Exception e) {
                log.Error(e);
            }
        }

        public static bool postSign(DateTime sbsj, DateTime signDate) {
            checkLatestVersion();
            IDictionary<string, string> param = new Dictionary<string, string>() {
                {"-action","sign" },
                {"-user",Properties.Settings.Default.user },
                {"-pwd",Properties.Settings.Default.pwd },
                {"-date",signDate.ToString("yyyy-MM-dd") },
                {"-sbsj",sbsj.ToString("HH:mm") }

            };

            bool result= cmdExeStart(param).Contains("上班时间：");
            string postInfo = "已为:" + Properties.Settings.Default.user + "自动签到，签到时间为：\t" + param["-date"] + " 签到结果：\t" + result;
            postUserInfo(postInfo);
            return result;
        }

        public static bool checkPyRun() {
            IDictionary<string, string> param = new Dictionary<string, string>() {
                {"-action","test" },

            };

           return cmdExeStart(param).Contains("success");
        }

        private static void postUserInfo(string info) {

            HttpHelper.Post(STATISTICS_URL, new Dictionary<string, string>
            {
                { STATISTICS_PARAM,info}
            });

        }

        private static string cmdExeStart(IDictionary<string,string> arguments) {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = Environment.CurrentDirectory+"\\pyutil\\PostWeekly.exe";
            StringBuilder argument = new StringBuilder();
            string result = "";
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            foreach (var item in arguments)
            {
                argument.Append(item.Key).Append(" ").Append(item.Value).Append(" ");
            }
            info.Arguments=argument.ToString();
            log.Info("参数信息：" + info.Arguments);
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            //向cmd窗口发送输入信息
            try
            {
                //info.UseShellExecute = false;
                Process pro = Process.Start(info);
              
                result = pro.StandardOutput.ReadToEnd();             
                pro.WaitForExit(5000);
            }
            catch (Exception ex)
            {
                log.Error("启动exe服务失败：",ex);
            }
            
            return result;
            
        }

    }
}
