using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace WindowsFormsApp16
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        BLLUser blu = new BLLUser();
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.CheckOldUser(Program.username, txtOldPassword.Text);
            if (dt.Rows.Count > 0)
            {
                if (txtNewPassword.Text == txtConfirmNew.Text)
                {
                    int i = blu.UpdatePassword(Program.username, txtNewPassword.Text);
                    if(i>0)
                    {
                        MessageBox.Show("Password Changed Successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Password Mismatch");
                    txtNewPassword.Text = "";
                    txtOldPassword.Text = "";
                    txtNewPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Password Milena");
            }
        }
    }
}
