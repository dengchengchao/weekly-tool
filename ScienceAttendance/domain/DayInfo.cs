using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAttendance.domain
{
   public class DayInfo
    {

        private string dataText;

        private string sbsj;

        private string zgs;

        private List<KqInfo> kqInfos;

        public string DataText
        {
            get
            {
                return dataText;
            }

            set
            {
                dataText = value;
            }
        }

        public string Sbsj
        {
            get
            {
                return sbsj;
            }

            set
            {
                sbsj = value;
            }
        }

        public string Zgs
        {
            get
            {
                return zgs;
            }

            set
            {
                zgs = value;
            }
        }

        public List<KqInfo> KqInfos
        {
            get
            {
                return kqInfos;
            }

            set
            {
                kqInfos = value;
            }
        }
    }
}
