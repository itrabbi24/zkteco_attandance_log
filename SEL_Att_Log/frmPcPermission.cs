using SEL_Att_Log.Others;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEL_Att_Log
{
    public partial class frmPcPermission : Form
    {
        SqlConnection conn = new SqlConnection(ServerConn.connetionString);
        private string sql;

        public frmPcPermission()
        {
            InitializeComponent();
        }

        private void frmPcPermission_Load(object sender, EventArgs e)
        {
            txtPCName.Text = GetPCInfo.GetPCName();
            txtPCName.Enabled = false;

            Att_Log att_Log = new Att_Log();
            att_Log.Hide();
        }

        private void frmPcPermission_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnPCPermission_Click(object sender, EventArgs e)
        {
            if (txtBranchCode.Text == "")
            {
                MessageBox.Show("Please Fill UP Branch Code !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBranchCode.Focus();
                return;
            }            
            
            if (txtIPAddress.Text == "")
            {
                MessageBox.Show("Please Fill UP IP Address !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIPAddress.Focus();
                return;
            }            
            
            if (txtPort.Text == "")
            {
                MessageBox.Show("Please Fill UP Port !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPort.Focus();
                return;
            }


            conn.Open();
            sql = "INSERT INTO PC_Request_Log (PC_Name, Branch_Code, IP_Address, Port, InputDate, Status) ";
            sql = sql + "VALUES('" + GetPCInfo.GetPCName() + "', '" + txtBranchCode.Text + "', '" + txtIPAddress.Text + "', '" + txtPort.Text + "', getdate(), 0 ) ";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Request Send Success !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnPCPermission.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
