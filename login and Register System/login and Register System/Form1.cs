using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace login_and_Register_System
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();

        }


        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter de = new OleDbDataAdapter(); 

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" && txtpassword .Text == "" && txtcompassword.Text == "")
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtpassword.Text == txtcompassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('"+txtusername.Text+"','" + txtpassword.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtusername.Text = "";
                txtpassword.Text = "";
                txtcompassword.Text = "";

                MessageBox.Show("Your Account Has Been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Passwords Does Not Match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Text = "";
                txtcompassword.Text = "";
                txtpassword.Focus();
            }
        }

        private void checkbxshowpas_CheckedChanged(object sender, EventArgs e)
        {
             if (checkbxshowpas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtcompassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtcompassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtcompassword.Text = "";
            txtusername.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
