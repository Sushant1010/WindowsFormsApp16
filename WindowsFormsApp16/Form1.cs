using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BLL.BLLUser blu = new BLL.BLLUser();
        private void btnSave_Click(object sender, EventArgs e)
        {
          int i=  blu.CreateUser(txtUsername.Text, txtPassword.Text, cboUsertype.Text, txtFullname.Text);
            if(i>0)
            {
                LoadGrid();
                ClearFields();
                MessageBox.Show("User Created");
            }
        }
        public void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cboUsertype.SelectedIndex = 0;
            txtFullname.Text = "";
            txtUsername.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            LoadGrid();
        }
        public void LoadGrid()
        {
            DataTable dt = blu.GetAllUser();
            dataGridView1.DataSource = dt;
        }

        int userid = 0;
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            userid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtUsername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPassword.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cboUsertype.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtFullname.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            groupBox1.Text = "Update User";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = blu.UpdateUser(txtUsername.Text, txtPassword.Text, cboUsertype.Text, txtFullname.Text, userid);
            if(i>0)
            {
                LoadGrid();
                ClearFields();
                MessageBox.Show("User Updated");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int i = blu.DeleteUser(userid);
                if (i > 0)
                {
                    LoadGrid();
                    ClearFields();
                    MessageBox.Show("User Deleted");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }
}
