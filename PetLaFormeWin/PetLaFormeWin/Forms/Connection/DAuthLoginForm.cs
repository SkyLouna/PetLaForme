using PetLaFormeWin.Helper;
using PLFAPI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetLaFormeWin.Forms.Connection
{
    public partial class DAuthLoginForm : Form
    {
        public DAuthLoginForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(delegate { Program.formRegisterLogin.Enabled = true; Program.formRegisterLogin.Show(); Program.formRegisterLogin.DAuthLoginForm = null; });
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(tbCodeBox.Text))
            {
                MessageBox.Show(MSGBank.ERROR_FILL_ALL_FIELDS, MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String userCode = DAuthHelper.GetUserCode(Program.actualUserPrivateKey);

            if(tbCodeBox.Text.ToLower() != userCode.ToLower())
            {
                MessageBox.Show("Ce code est erroné", MSGBank.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //hide register form and show main board
            Program.formRegisterLogin.Enabled = true;
            Program.formRegisterLogin.Hide();
            Program.formRegisterLogin.DAuthLoginForm = null;
            Program.mainBoard = new MainBoard();
            Program.mainBoard.Show();
            this.Dispose();

        }
    }
}
