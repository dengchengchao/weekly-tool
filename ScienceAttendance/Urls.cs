using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAttendance
{
    abstract class Urls
    {
        //登录
       public static string LOGIN = "http://kq.thunisoft.com:8080/kqgl/login";

        //重定向源
        public static string REFERE = "http://kq.thunisoft.com:8080/kqgl/login";

        //获取周报
        public static string WEEK_GET ="http://kq.thunisoft.com:8080/kqgl/form/kqglKqQjxxDetail/insert?action=parseItem&";

        //发送上班时间
        public static string ONWORK_TIME = "http://kq.thunisoft.com:8080/kqgl/form/kqglKqQjxxDetail/insert?action=runItemLogic&";

    }
}
