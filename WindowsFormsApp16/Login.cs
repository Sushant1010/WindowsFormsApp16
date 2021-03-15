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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        BLLUser blu = new BLLUser();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.CheckUserLogin(txtUsername.Text, txtPassword.Text, cboUsertype.Text);
            if (dt.Rows.Count > 0)
            {
                Program.username = txtUsername.Text;
                if (cboUsertype.Text == "Admin")
                {
                    MainForm frm = new MainForm();
                    frm.Show();
                    this.Hide();
                }
                else if(cboUsertype.Text=="User")
                {
                    MainForm frm = new MainForm();
                    frm.adminToolStripMenuItem.Enabled = false;
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username and Password");
            }
        }
    }
}
