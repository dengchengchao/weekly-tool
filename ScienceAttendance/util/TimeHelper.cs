using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAttendance.util
{
   public class TimeHelper
    {
        //上班时间
        private static IDictionary<string, List<DateTime>> onWorkTime = new Dictionary<string, List<DateTime>>();

        

        //下班时间
        private static IDictionary<string, List<DateTime>> offWorkTime = new Dictionary<string, List<DateTime>>() ;

        public static void initFirst() {

            onWorkTime.Add( DateTime.Now.ToString("yyyy-MM-dd"), new List<DateTime>() { DateTime.Now } );
            offWorkTime.Add(DateTime.Now.ToString("yyyy-MM-dd"), new List<DateTime>() { DateTime.Now });
        }


        public static IDictionary<string, List<DateTime>> OnWorkTime
        {
            get
            {
                return onWorkTime;
            }

            set
            {
                onWorkTime = value;
            }
        }

        public static IDictionary<string, List<DateTime>> OffWorkTime
        {
            get
            {
                return offWorkTime;
            }

            set
            {
                offWorkTime = value;
            }
        }
    }
}
