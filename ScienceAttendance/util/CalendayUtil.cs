using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAttendance.util
{


   public class CalendayUtil
    {
        //工作日不上班日
        public static readonly IList<String> GoGoGoDays = new List<String>()
        {
            {"2018-12-31"},
            {"2019-01-01"},
            {"2019-05-05"},
            {"2019-04-29"},
            {"2019-04-30"},
            {"2019-05-01"},
            {"2019-06-07"},
            {"2019-09-13"},
            {"2019-09-30"},
            {"2019-10-01"},
            {"2019-10-02"},
            {"2019-10-03"},
            {"2019-10-04"},

        };

        //周末正常上班日
        public static readonly IList<string> NoNoNoDays = new List<string>() {

            {"2018-12-29"},
            {"2019-02-02"},
            {"2019-02-03"},
            {"2019-04-27"},
            {"2019-04-28"},
            {"2019-09-28"},
            {"2019-09-29"},
        };
    }
}
