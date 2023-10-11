using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_ADMIN : Form
    {

        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";
        public static string Setting = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        WhatsApp app;

        public FRM_ADMIN(WhatsApp whatsappInitialize)
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

        private void FRM_ADMIN_Load(object sender, EventArgs e)
        {
            this.admin_dbTableAdapter.Fill(this.settings_dbDataSet.Admin_db);
            this.login_dbTableAdapter.Fill(this.settings_dbDataSet.Login_db);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void picclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
                app.driver.Dispose();
            }
        }

        private void picmin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                FRM_LOGIN Login = new FRM_LOGIN(app);
                Login.Show();
                this.Hide();
            }
        }

        private void txtarea_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_ADMIN_KeyDown(object sender, KeyEventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection();
            if (e.KeyCode==Keys.Escape)
            {
                if (MessageBox.Show("DO YOU WANT TO SAVE ❔", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    con = new OleDbConnection(Setting);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update Login_db set f_username = '" + txtusername.Text + "',f_password ='" + txtpassword.Text + "'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "Update Admin_db set f_company_master ='" + chkcompanymaster.Checked + "',f_customer_master ='" + chkcustomermaster.Checked + "',f_chit_billing='" + chkchitbilling.Checked + "',f_daily_report='" + chkdailyreport.Checked + "',f_monthly_report='" + chkmonthlyreport.Checked + "',f_yearly_report='" + chkyearlyreport.Checked + "',f_customer_report='" + chkcustomerreport.Checked + "',f_setting_user_master='" + chksettingusermaster.Checked + "',f_setting_company_master='" + chksettingcompanymaster.Checked + "',f_setting_customer_master='" + chksettingcustomermaster.Checked + "',f_setting_chit_billing='" + chksettingchitbilling.Checked + "',f_setting_record_delete='" + chksettingrecorddelete.Checked + "',f_setting_whatsapp='" + chksettingwhatsapp.Checked + "',f_setting_email='" + chksettingemail.Checked + "',f_setting_backup='" + chksettingbackup.Checked + "',f_setting_restore='" + chksettingrestore.Checked + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("👍 UPDATED SUCCESSFULLY 👍", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("DO YOU WANT TO EXIT ❔", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        FRM_LOGIN Login = new FRM_LOGIN(app);
                        Login.Show();
                        this.Hide();
                    }
                }
            }
        }
    }
}
