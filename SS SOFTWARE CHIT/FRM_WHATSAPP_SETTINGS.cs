using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_WHATSAPP_SETTINGS : Form
    {
        string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        WhatsApp app;

        public FRM_WHATSAPP_SETTINGS(WhatsApp whatsappInitialize)
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

        private async void lbl()
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(20));
                        wait.Until(driver => driver.Url.Contains("web.whatsapp.com"));
                        wait.Until(driver => app.driver.PageSource.Contains("Use WhatsApp on your computer"));
                    }
                    catch (Exception)
                    {

                    }
                });

                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    lblstatus.Text = "WHATSAPP NOT AUTHORIZED";
                }
                else
                {
                    lblstatus.Text = "WHATSAPP READY";
                }
            }
            catch (Exception)
            {

            }
        }

        private async Task Initialize()
        {
            lblstatus.Text = "LOADING...";
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    await Task.Run(() => app.Load());
                    lbl();
                    MessageBox.Show("WHATSAPP IS INITIALIZED...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("WHATSAPP IS NOT RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnterminate_Click(object sender, EventArgs e)
        {
            try
            {
                app.driver.Dispose();
                timer2.Stop();
                MessageBox.Show("WHATSAPP IS TERMINATED...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picqrcode.Image = picqrcode.InitialImage;
            }
            catch (Exception)
            {

            }
        }

        private void piclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                FRM_SETTINGS Settings = new FRM_SETTINGS(app);
                Settings.Show();
            }
        }

        private async void btninitialize_Click(object sender, EventArgs e)
        {
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    MessageBox.Show("WHATSAPP IS RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                app.InitializeDriver();
                await Initialize();
                this.Focus();
                timer2.Start();
                lblstatus.Text = "NOT WHATSAPP READY";
            }
        }
        private void QrCode()
        {
            app.CaptureAndDisplayQrCode(picqrcode);
            timer1.Stop();
        }

        private void btnqrcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (app.driver.PageSource.Contains("Use WhatsApp on your computer") == true)
                {
                    if (app.driver.WindowHandles.Count > 0)
                    {
                        timer1.Start();
                    }
                }
                else
                {
                    MessageBox.Show("ALREADY CONNECTED TO WHATSAPP!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                lblstatus.Text = "WHATSAPP NOT READY";
                MessageBox.Show("WHATSAPP IS NOT RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            try
            {
                app.Logout();
                picqrcode.Image = picqrcode.InitialImage;
                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    lblstatus.Text = "WHATSAPP NOT AUTHORIZED";
                }
                else
                {
                    lblstatus.Text = "WHATSAPP READY";
                    picqrcode.Image = picqrcode.InitialImage;
                }
            }
            catch (Exception)
            {
                lblstatus.Text = "WHATSAPP NOT READY";
                MessageBox.Show("WHATSAPP IS NOT RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void picminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FRM_WHATSAPP_SETTINGS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'settings_dbDataSet.Whatsapp_db' table. You can move, or remove it, as needed.
            this.whatsapp_dbTableAdapter.Fill(this.settings_dbDataSet.Whatsapp_db);
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    lbl();
                    picqrcode.Image = picqrcode.InitialImage;
                    this.Focus();
                    timer2.Start();
                }
            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            QrCode();
            this.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    lblstatus.Text = "WHATSAPP NOT AUTHORIZED";
                }
                else
                {
                    lblstatus.Text = "WHATSAPP READY";
                }
            }
            catch (Exception)
            {
                lblstatus.Text = "WHATSAPP NOT READY";
            }
        }

        private void FRM_WHATSAPP_SETTINGS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnlmain.Visible == true)
                {
                    if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.Hide();
                        FRM_SETTINGS Settings = new FRM_SETTINGS(app);
                        Settings.Show();
                    }
                }
                else
                {
                    pnlmsg.Hide();
                    pnlmain.Show();
                }
            }
        }

        private void btnbold_Click(object sender, EventArgs e)
        {
            if (txtmsg.SelectionLength > 1)
            {
                txtmsg.SelectedText = "%20" + "*" + txtmsg.SelectedText + "*" + "%20";
            }
            else
            {
                MessageBox.Show("SELECT THE TEXT?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmsg.Focus();
            }
        }

        private void btnitalic_Click(object sender, EventArgs e)
        {
            if (txtmsg.SelectionLength > 1)
            {
                txtmsg.SelectedText = "%20" + "_" + txtmsg.SelectedText + "_" + "%20";
            }
            else
            {
                MessageBox.Show("SELECT THE TEXT?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmsg.Focus();
            }
            txtmsg.Focus();
        }

        private void chkdate_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            string msg = txtmsg.Text;
            string dateRemove = "{DATE}";
            if (chkdate.Checked == true)
            {
                txtmsg.Text = txtmsg.Text + "{DATE}";
            }
            else
            {
                msg = msg.Replace(dateRemove, string.Empty);
                txtmsg.Text = msg;
            }
            txtmsg.Focus();
        }

        private void chkamount_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            string msg = txtmsg.Text;
            string amountRemove = "{AMOUNT}";
            if (chkamount.Checked == true)
            {
                txtmsg.Text = txtmsg.Text + "{AMOUNT}";
            }
            else
            {
                msg = msg.Replace(amountRemove, string.Empty);
                txtmsg.Text = msg;
            }
            txtmsg.Focus();
        }

        private void chktype_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            string msg = txtmsg.Text;
            string typeRemove = "{TYPE}";
            if (chktype.Checked == true)
            {
                txtmsg.Text = txtmsg.Text + "{TYPE}";
            }
            else
            {
                msg = msg.Replace(typeRemove, string.Empty);
                txtmsg.Text = msg;
            }
            txtmsg.Focus();
        }

        private void chkcustomername_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            string msg = txtmsg.Text;
            string customerNameRemove = "{CUSTOMER_NAME}";
            if (chkcustomername.Checked == true)
            {
                txtmsg.Text = txtmsg.Text + "{CUSTOMER_NAME}";
            }
            else
            {
                msg = msg.Replace(customerNameRemove, string.Empty);
                txtmsg.Text = msg;
            }
            txtmsg.Focus();
        }

        private void chkcustomerid_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            string msg = txtmsg.Text;
            string customerIdRemove = "{CUSTOMER_ID}";
            if (chkcustomerid.Checked == true)
            {
                txtmsg.Text = txtmsg.Text + "{CUSTOMER_ID}";
            }
            else
            {
                msg = msg.Replace(customerIdRemove, string.Empty);
                txtmsg.Text = msg;
            }
            txtmsg.Focus();
        }

        private void chkmobileno_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            string msg = txtmsg.Text;
            string mobileNoRemove = "{MOBILE_NO}";
            if (chkmobileno.Checked == true)
            {
                txtmsg.Text = txtmsg.Text + "{MOBILE_NO}";
            }
            else
            {
                msg = msg.Replace(mobileNoRemove, string.Empty);
                txtmsg.Text = msg;
            }
            txtmsg.Focus();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            txtmsg.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtmsg.Text.Contains(" "))
            {
                txtmsg.Text = txtmsg.Text.Replace(" ", "%20");
            }
            else
            {
                if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con = new OleDbConnection(path);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE Whatsapp_db set f_msg='" + txtmsg.Text + "' , f_customer_id ='" + chkcustomerid.Checked + "' , f_customer_name ='" + chkcustomername.Checked + "', f_mobile_no ='" + chkmobileno.Checked + "', f_type ='" + chktype.Checked + "',f_amount ='" + chkamount.Checked + "', f_date ='" + chkdate.Checked + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    string SP = Application.StartupPath + "\\BACKUP\\";
                    string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                    string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                    File.Copy(ThisDB, Destitnation);
                    MessageBox.Show("UPDATED SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnmsg_Click(object sender, EventArgs e)
        {
            pnlmsg.Show();
            pnlmain.Hide();
        }
    }
}
