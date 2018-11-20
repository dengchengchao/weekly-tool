using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ScienceAttendance.form
{
    public partial class Setting : UserControl
    {


      
       

        public Setting()
        {
            InitializeComponent();
        }

        public Action SuucessHandle { get; set; }

        public void setProMap(IDictionary<string, string> proMap) {
            foreach (var item in proMap)
            {
                this.cbxPro.Items.Add(item.Key + "###" + item.Value);
            }
            cbxPro.SelectedIndex = Properties.Settings.Default.xmbhIndex > cbxPro.Items.Count - 1 ? 0 : Properties.Settings.Default.xmbhIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = cbxPro.Items[cbxPro.SelectedIndex].ToString();
            Properties.Settings.Default.xmbh = number;
            Properties.Settings.Default.sbsj = Convert.ToDateTime(txtSbsj.Text);
            Properties.Settings.Default.xbsj = Convert.ToDateTime(txtXbsj.Text);
            Properties.Settings.Default.writeDaily = checkBox1.Checked;
            Properties.Settings.Default.xmbhIndex = cbxPro.SelectedIndex;
            Properties.Settings.Default.Save();
            SuucessHandle();
        }


    
        private void Setting_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = Properties.Settings.Default.writeDaily;         
            this.txtSbsj.Text = Properties.Settings.Default.sbsj.GetDateTimeFormats('t')[0].ToString();
            this.txtXbsj.Text = Properties.Settings.Default.xbsj.GetDateTimeFormats('t')[0].ToString();
        }
    }
}
