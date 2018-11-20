using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScienceAttendance
{
    /// <summary>
    /// 当前登录的用户变化（登录、注销和解锁屏）
    /// </summary>
    class SessionLisener
    {
        /// <summary>
        /// 解屏后执行的委托
        /// </summary>
        public Action SessionUnlockAction { get; set; }

        /// <summary>
        /// 锁屏后执行的委托
        /// </summary>
        public Action SessionLockAction { get; set; }

        public SessionLisener()
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
        }

        //析构，防止句柄泄漏
        ~SessionLisener()
        {
            //Do this during application close to avoid handle leak
            SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
        }

        //当前登录的用户变化（登录、注销和解锁屏）
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
              
                //解锁屏
                case SessionSwitchReason.SessionUnlock:
                    SessionUnlockAction();
                    break;
                //锁屏
                case SessionSwitchReason.SessionLock:
                    SessionLockAction();
                    break;       
            }
        }

    }

}
