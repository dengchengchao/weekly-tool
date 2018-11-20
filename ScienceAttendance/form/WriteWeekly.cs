using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScienceAttendance.util;
using System.Threading;

namespace ScienceAttendance.form
{
    public partial class WriteWeekly : UserControl
    {
        public WriteWeekly()
        {
            InitializeComponent();
        }

        private string weeklyStr;

        public Action<bool>  WritedHandle { get; set; }

        public string WeeklyStr
        {
            get
            {
                return weeklyStr;
            }

            set
            {
                weeklyStr = value;
            }
        }

        private DateTime sbsj;

        private DateTime xbsj;

        private DateTime date;

        private string zgs;

        public void ShowForm(DateTime dateTime, DateTime sbsj, DateTime xbsj, string zgs) {
            this.sbsj = sbsj;
            this.xbsj =xbsj;
            this.zgs = zgs;
            this.date = dateTime;
            Initxmbh();
            //this.lblxmbh.Text = Properties.Settings.Default.xmbh;
            string userName = Properties.Settings.Default.user;
            this.lblsbsj.Text = "Hi~" + userName +" "+date.ToString("yyyy-MM-dd") + " 上班时间： " + sbsj.GetDateTimeFormats('t')[0].ToString() + "   下班时间： " + xbsj.GetDateTimeFormats('t')[0].ToString() + "  总工时：" + zgs;
            this.Show();
          
        }


        private void Initxmbh() {
            new Thread(() =>
            {
                this.BeginInvoke(new Action(()=>{
                 IDictionary<string, string> proMap = WeekSettingHelper.getXmbhWithName(Properties.Settings.Default.user, Properties.Settings.Default.pwd);
                foreach (var item in proMap)
                {
                    this.cbxPro.Items.Add(item.Key + "###" + item.Value);
                }
                cbxPro.SelectedIndex = Properties.Settings.Default.xmbhIndex > cbxPro.Items.Count - 1 ? 0 : Properties.Settings.Default.xmbhIndex;

            }));             
            }).Start();

        }

        private void WriteWeekly_Load(object sender, EventArgs e)
        {
           
 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string xmbh = cbxPro.Items[cbxPro.SelectedIndex].ToString();
            string gznr = string.IsNullOrEmpty(txtWeekly.Text) ? "#" : txtWeekly.Text;
            bool result= WeeklyUtils.postWeekly(sbsj, zgs, gznr, xmbh, date);
            this.weeklyStr = this.txtWeekly.Text;
            this.txtWeekly.Clear();
            WritedHandle(result);
        }

        private void WriteWeekly_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
