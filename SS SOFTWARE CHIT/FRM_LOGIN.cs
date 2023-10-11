using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_LOGIN : Form
    {
        string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        OleDbConnection con;
        WhatsApp app;
        
        public FRM_LOGIN(WhatsApp whatsappInitialize)
        {
            InitializeComponent();
            try
            {
                app = whatsappInitialize;
            }
            catch (Exception)
            {

            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            ClearAll();
            this.KeyPreview = true;
            await Task.Run(() => app.Load());
        }

        private void ClearAll()
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtpassword.Focus();
            txtusername.Focus();
            txtpassword.SelectionLength = 0;
            txtusername.SelectionLength = 0;
        }

        private void Login()
        {
            if(txtusername.Text=="Harshit" && txtpassword.Text=="Harshit@7476")
            {
                FRM_ADMIN Admin = new FRM_ADMIN(app);
                MessageBox.Show("SIGN IN SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                Admin.Show();
                this.Hide();
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand();
                string str = "Select f_username,f_password from Login_db where f_username='" + txtusername.Text + "' and f_password='" + txtpassword.Text + "'";
                con = new OleDbConnection(path);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = str;
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    notifyIcon1.ShowBalloonTip(100);
                    MessageBox.Show("SIGN IN SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                    FRM_HOME Home = new FRM_HOME(app);
                    Home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("WRONG USER NAME & PASSWORD???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAll();
                }
            }
        }

        private void btnsignin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Enter_Only(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void lblfogotpassword_Click(object sender, EventArgs e)
        {
            ClearAll();
            FRM_FORGOT_PASSWORD ForgotPass = new FRM_FORGOT_PASSWORD(app);
            ForgotPass.Show();
            this.Hide();
        }

        private void FRM_LOGIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("DO YOU WANT TO CLOSE THE APPLICATION", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    Application.Exit();
                    app.driver.Dispose();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
