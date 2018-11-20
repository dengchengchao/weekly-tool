using ScienceAttendance.domain;
using ScienceAttendance.form;
using ScienceAttendance.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScienceAttendance
{
    public partial class zido : Form
    {

        private Login loginForm = new Login();
        private Setting settingForm = new Setting();
        private WriteWeekly writeForm = new WriteWeekly();
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(WeeklyUtils));

        private static SessionLisener secc=new SessionLisener(); 
        public zido()
        {
            InitializeComponent();
            secc.SessionUnlockAction += BeginSessionUnlock;
            secc.SessionLockAction += BeginSessionLock;
            WeeklyUtils.UpLoadHandle= ShowNeedUploadPanel;
            loginForm.LoginSuccess = loginSuccess;
            settingForm.SuucessHandle += hideForm;
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.writeForm.WritedHandle += writeFormHandle;
            ThreadPool.RegisterWaitForSingleObject(Program.ProgramStarted, OnProgramStarted, null, -1, false);
            this.panel1.Controls.Add(loginForm);
            this.panel1.Controls.Add(settingForm);
            this.panel1.Controls.Add(writeForm);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            TimeHelper.initFirst();
            if (!WeeklyUtils.checkPyRun())
            {
                MessageBox.Show("爬虫程序异常,可能是本地缺少运行Python的系统库，请联系dengchengchao");
            }
        }


        private void checkLoginStatus() {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.user) || string.IsNullOrWhiteSpace(Properties.Settings.Default.pwd)) {
                loginForm.Show();
            }
        }

        //登录成功
        private void loginSuccess() {
            loginForm.Hide();
            settingForm.setProMap(loginForm.ProMap);
            settingForm.Show();
        }

        //解锁
        private void BeginSessionUnlock() {
            recordSbsj();
            //处理昨天的考勤信息
            DateTime preDateTime = getLastWorkingDay(); ;//
            string shortDate = preDateTime.ToString("yyyy-MM-dd");
            if (TimeHelper.OnWorkTime.ContainsKey(shortDate))
            {
                postSign();
                //需要填写周报
                if (Properties.Settings.Default.writeDaily)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        this.Visible = true;
                        this.WindowState = FormWindowState.Normal;
                        this.Activate();
                        settingForm.Hide();
                        postWeekly(true);
                    }));
             
                   
                }
                else {
                    postWeekly(false);
                }

 
            }
    
        }

        //获取上一个工作日，主要用于周一填写周五的考勤
        public static DateTime getLastWorkingDay() {
            DateTime preDateTime = DateTime.Now.AddHours(-6).AddDays(-1); ;//
            // 昨天是周末并且这个周末不用上班
            // 昨天不是周末，但是也不用上班
            while ((preDateTime.DayOfWeek== DayOfWeek.Sunday || preDateTime.DayOfWeek==DayOfWeek.Saturday && !CalendayUtil.NoNoNoDays.Contains(preDateTime.ToString("yyyy-MM-dd"))||
               CalendayUtil.GoGoGoDays.Contains(preDateTime.ToString("yyyy-MM-dd"))))
            {
                preDateTime = preDateTime.AddDays(-1);
            }
            return preDateTime;
        }


        private void postSign() {

            DateTime preDateTime = getLastWorkingDay();
            WeeklyUtils.postSign(getLastDayOnWorkTime(preDateTime), preDateTime);      
                
        }


        private void writeFormHandle(bool result) {
            //postWeekly(writeForm.WeeklyStr);
            writeForm.Hide();
            settingForm.Show();
            hideForm();
            if (result)
            {

                this.notifyIcon1.ShowBalloonTip(500, "ScienceAttendance", "自动考勤成功", ToolTipIcon.Info);
            }
            else
            {
                this.notifyIcon1.ShowBalloonTip(500, "ScienceAttendance", "自动考勤失败", ToolTipIcon.Info);
            }
        }




        private void postWeekly(bool showForm) {
            //处理昨天的考勤信息
            DateTime preDateTime = getLastWorkingDay();
            string shortDate = preDateTime.ToString("yyyy-MM-dd");
            DateTime preOnWorkTime = getLastDayOnWorkTime(preDateTime);
            DateTime preOffWorkTime = getYestodayOffWorkTime(preDateTime);
            TimeSpan timeSpan = new TimeSpan(preOffWorkTime.Ticks).Subtract(new TimeSpan(preOnWorkTime.AddHours(1).Ticks)).Duration();
            string timesDis = timeSpan.TotalHours.ToString("0.0");
            if (showForm)
            {
                writeForm.ShowForm(preDateTime, preOnWorkTime, preOffWorkTime, timesDis);
            }
            else
            {
                string xmbh = Properties.Settings.Default.xmbh;
                if (WeeklyUtils.postWeekly(preOnWorkTime, timesDis, "#", xmbh, preDateTime)) {      
                        this.notifyIcon1.ShowBalloonTip(500, "ScienceAttendance", preDateTime.ToString("yyyy-MM-dd") + "自动考勤成功", ToolTipIcon.Info);
                    }
                    else
                    {
                        this.notifyIcon1.ShowBalloonTip(500, "ScienceAttendance", preDateTime.ToString("yyyy-MM-dd") +"考勤失败~", ToolTipIcon.Info);
                    }              
            }
            deleteTimeHelper(shortDate);
        }


        private static void deleteTimeHelper(string shortDate) {

            TimeHelper.OnWorkTime.Remove(shortDate);
            if (TimeHelper.OffWorkTime.ContainsKey(shortDate))
            {
                TimeHelper.OffWorkTime.Remove(shortDate);
            }
        }


        private DateTime getLastDayOnWorkTime(DateTime dateTime) {

            DateTime proTime = Properties.Settings.Default.sbsj;
            DateTime realProTime= new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, proTime.Hour, proTime.Minute, proTime.Second);
            if (TimeHelper.OnWorkTime.Count > 0)
            {              
                List<DateTime> timeList = TimeHelper.OnWorkTime[dateTime.ToString("yyyy-MM-dd")];
                timeList.Sort();
                return timeList[0] > realProTime ? realProTime : timeList[0];
            }
            else
            {        
                return realProTime;
            }
        }

        private DateTime getYestodayOffWorkTime(DateTime dateTime) {
            DateTime proTime = Properties.Settings.Default.xbsj;
            DateTime realProTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, proTime.Hour, proTime.Minute, proTime.Second);

            if (TimeHelper.OffWorkTime.Count > 0)
            {           
                List<DateTime> timeList = TimeHelper.OffWorkTime[dateTime.ToString("yyyy-MM-dd")];
                timeList.Sort();
                return timeList[timeList.Count-1] < realProTime ? realProTime : timeList[timeList.Count - 1];
            }
            else
            {
                return realProTime;
            }
        }


        //锁定
        private void BeginSessionLock() {
            recordXbsj();
        }

        private void recordSbsj() {
            DateTime now = DateTime.Now;
            string key = now.AddHours(-6).ToString("yyyy-MM-dd");
            if (TimeHelper.OnWorkTime.ContainsKey(key))
            {
                TimeHelper.OnWorkTime[key].Add(now);
            }
            else
            {
                TimeHelper.OnWorkTime.Add(key, new List<DateTime>() { now });

            }
          
        }

        private void recordXbsj() {
            DateTime now = DateTime.Now;
            string key = now.AddHours(-6).ToString("yyyy-MM-dd");
            if (TimeHelper.OffWorkTime.ContainsKey(key))
            {
                TimeHelper.OffWorkTime[key].Add(now);

            }
            else
            {
                TimeHelper.OffWorkTime.Add(key, new List<DateTime>() { now });

            }
           
        }

        
        private void checkValidBeforePostWeekly() {
 

        }





        #region UI

        private void Form1_SizeChanged(object sender, EventArgs e)

        {

            if (this.WindowState == FormWindowState.Minimized)

            {
       
                this.Hide();//隐藏主窗体

                this.notifyIcon1.Visible = true;

            }
        }



        private void hideForm() {
            this.Hide();//隐藏主窗体
            this.notifyIcon1.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true; // 取消关闭窗体 

                //使关闭时窗口向右下角缩小的效果
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                //this.m_cartoonForm.CartoonClose();
                this.Hide();
                //this.notifyIcon1.ShowBalloonTip(20, "ScienceAttendance", "我已经藏在这里啦", ToolTipIcon.Info);
                return;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.WindowState = FormWindowState.Minimized;
                this.notifyIcon1.Visible = true;
                this.Hide();
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("即将退出程序，确定要退出？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                System.Environment.Exit(System.Environment.ExitCode);

            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show();

            }
        }
        #endregion

        public void ShowNeedUploadPanel(bool isShow) {
            this.BeginInvoke(new Action(() => {
                this.panel2.Visible = isShow;
            }));
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(WeeklyUtils.STATISTICS_UPLOAD);
        }

        // 当收到第二个进程的通知时，显示窗体
        void OnProgramStarted(object state, bool timeout)
        {       
            this.Show();
            this.WindowState = FormWindowState.Normal; //注意：一定要在窗体显示后，再对属性进行设置
        }

    }
}
