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

namespace ScienceAttendance
{
    public partial class Login : UserControl
    {
        //登录成功回调
        public Action LoginSuccess{get;set;}

        public Login()
        {
            InitializeComponent();
            this.txtPwd.Text = Properties.Settings.Default.pwd;
            this.txtUser.Text = Properties.Settings.Default.user;
        }

        private IDictionary<string, string> proMap = new Dictionary<string, string>();

        public IDictionary<string, string> ProMap
        {
            get
            {
                return proMap;
            }

            set
            {
                proMap = value;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.lblHint.Text = "";
            ProMap = WeekSettingHelper.getXmbhWithName(txtUser.Text, txtPwd.Text);
            if (ProMap.Count<1)
            {
                this.lblHint.Text = "未成功登录，请检查账号和密码相关信息";
                return;
            }
            Properties.Settings.Default.user = txtUser.Text;
            Properties.Settings.Default.pwd = txtPwd.Text;
            Properties.Settings.Default.Save();
            this.txtUser.Clear();
            this.txtPwd.Clear();
            LoginSuccess();
        }

  
    }
}
