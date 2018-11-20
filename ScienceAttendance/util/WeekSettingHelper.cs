using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScienceAttendance.util
{

   

    public class WeekSettingHelper
    {
        //正则匹配
        private static readonly string pattern = "<span.*?class=\\\\\"jqInput jqInput-task title input-display\\\\\".*?title=\\\\\"(.*?)\\\\\".*?>.*?<input.*?name=\\\\\"kqglKqRb\\.xgxm\\\\\".*?value=\\\\\"(.*?)\\\\\".*?>";
        private static readonly Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

        public static IDictionary<string, string> getXmbhWithName(string user,string pwd) {
            AttendanceHelper attend = new AttendanceHelper(user,pwd);
            IDictionary<string, string> result = new Dictionary<string, string>();
            string html = attend.GetWeeklyHtml(DateTime.Now.ToString("yyyy-MM-dd"));
            Match match = regex.Match(html);
            while (match.Success)
            {
                result.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }
            return result;

        }
    }
}
