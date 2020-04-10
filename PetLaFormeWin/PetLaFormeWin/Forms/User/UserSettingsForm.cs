using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetLaFormeWin.Forms
{
    public partial class UserSettingsForm : Form
    {
        public UserSettingsForm()
        {
            InitializeComponent();
            this.FormClosing += delegate { Program.mainBoard.UserSettingsForm = null; };
            cbAllowAutoConnect.Checked = Properties.Settings.Default.AllowAutoLogin;
        }

        private void cbAllowAutoConnect_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AllowAutoLogin = cbAllowAutoConnect.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
