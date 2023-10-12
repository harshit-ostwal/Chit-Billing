using OpenQA.Selenium.Support.UI;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_HOME : Form
    {
        WhatsApp app;

        private async void FRM_HOME_Load(object sender, EventArgs e)
        {
            try
            {
                //timer2.Start();
                if (app.driver.WindowHandles.Count > 0)
                {
                    if (app.driver.Url.Contains("https://web.whatsapp.com/") == false)
                    {
                        await Task.Run(() => Initialize());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("WHATSAPP NOT LOADED?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.company_dbTableAdapter.Fill(this.mainDataSet.Company_db);
            timer1.Start();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
        }

        private async Task Initialize()
        {
            lblstatus.Text = "LOADING...";
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    await Task.Run(() =>
                    {
                        app.Load();
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
                    else if(app.driver.PageSource.Contains("Loading your Chats"))
                    {
                        lblstatus.Text = "WHATSAPP LOADING...";
                    }
                    else
                    {
                        lblstatus.Text = "WHATSAPP READY";
                    }
                    this.Focus();
                }
                else
                {
                    MessageBox.Show("WHATSAPP IS NOT RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

            }
        }

        public FRM_HOME(WhatsApp whatsappInitialize)
        {
            InitializeComponent();
            app = whatsappInitialize;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
                app.driver.Dispose();
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO LOGOUT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                FRM_LOGIN Login = new FRM_LOGIN(app);
                Login.Show();
                this.Hide();
                pnltransaction.Visible = false;
                pnlreports.Visible = false;
                pnlmaster.Visible = false;
            }
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            FRM_SETTINGS Settings = new FRM_SETTINGS(app);
            Settings.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btncontact_Click(object sender, EventArgs e)
        {
            FRM_CONTACT_US Contact = new FRM_CONTACT_US(app);
            Contact.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btncalculator_Click(object sender, EventArgs e)
        {
            FRM_CALCULATOR Calculator = new FRM_CALCULATOR(app);
            Calculator.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            if(pnlreports.Visible == false)
            {
                pnltransaction.Visible = false;
                pnlreports.Visible = true;
                pnlmaster.Visible = false;
            }
            else
            {
                pnltransaction.Visible = false;
                pnlreports.Visible = false;
                pnlmaster.Visible = false;
            }
        }

        private void btntransaction_Click(object sender, EventArgs e)
        {
            if (pnltransaction.Visible == false)
            {
                pnltransaction.Visible = true;
                pnlreports.Visible = false;
                pnlmaster.Visible = false;
            }
            else
            {
                pnltransaction.Visible = false;
                pnlreports.Visible = false;
                pnlmaster.Visible = false;
            }
        }

        private void btnmaster_Click(object sender, EventArgs e)
        {
            if (pnlmaster.Visible == false)
            {
                pnltransaction.Visible = false;
                pnlreports.Visible = false;
                pnlmaster.Visible = true;
            }
            else
            {
                pnltransaction.Visible = false;
                pnlreports.Visible = false;
                pnlmaster.Visible = false;
            }
        }

        private void btncompanymaster_Click(object sender, EventArgs e)
        {
            FRM_COMPANY_MASTER ComapanyMaster = new FRM_COMPANY_MASTER(app);
            ComapanyMaster.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btncustomermaster_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMER_MASTER CustomerMaster = new FRM_CUSTOMER_MASTER(app);
            CustomerMaster.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btndailyreport_Click(object sender, EventArgs e)
        {
            FRM_DAILY_REPORTS Daily_Reports = new FRM_DAILY_REPORTS(app);
            Daily_Reports.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btnmonthlyreport_Click(object sender, EventArgs e)
        {
            FRM_MONTHLY_REPORTS Monthly_Reports = new FRM_MONTHLY_REPORTS(app);
            Monthly_Reports.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btnyearlyreport_Click(object sender, EventArgs e)
        {
            FRM_YEARLY_REPORTS Yearly_Reports = new FRM_YEARLY_REPORTS(app);
            Yearly_Reports.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void btncustomerreport_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMER_ACTIVITY Customer_Activity = new FRM_CUSTOMER_ACTIVITY(app);
            Customer_Activity.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void FRM_HOME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Application.Exit();
                    app.driver.Dispose();
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                if (btntransaction.Enabled == false)
                {

                }
                else
                {
                    pnltransaction.Visible = true;
                    btnchitbilling.PerformClick();
                    pnltransaction.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F2)
            {
                if (btnmaster.Enabled == false)
                {

                }
                else
                {
                    pnlmaster.Visible = true;
                    btncustomermaster.PerformClick();
                    pnlmaster.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                if (btnmaster.Enabled == false)
                {

                }
                else
                {
                    pnlmaster.Visible = true;
                    btncompanymaster.PerformClick();
                    pnlmaster.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (btnreports.Enabled == false)
                {

                }
                else
                {
                    pnlreports.Visible = true;
                    btndailyreport.PerformClick();
                    pnlreports.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (btnreports.Enabled == false)
                {

                }
                else
                {
                    pnlreports.Visible = true;
                    btnmonthlyreport.PerformClick();
                    pnlreports.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                if (btnreports.Enabled == false)
                {

                }
                else
                {
                    pnlreports.Visible = true;
                    btnyearlyreport.PerformClick();
                    pnlreports.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                if (btnreports.Enabled == false)
                {

                }
                else
                {
                    pnlreports.Visible = true;
                    btncustomerreport.PerformClick();
                    pnlreports.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                btncalculator.PerformClick();
            }
            if (e.KeyCode == Keys.F9)
            {
                btncontact.PerformClick();
            }
            if (e.KeyCode == Keys.F10)
            {
                btnsettings.PerformClick();
            }
            if (e.KeyCode == Keys.F11)
            {
                btnlogout.PerformClick();
            }
            if (e.KeyCode == Keys.F12)
            {
                btnexit.PerformClick();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("DO YOU WANT TO EXIT?","SS SOFTWARE",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                Application.Exit();
                app.driver.Dispose();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnchitbilling_Click(object sender, EventArgs e)
        {
            FRM_CHIT_BILLING ChitBilling = new FRM_CHIT_BILLING(app);
            ChitBilling.Show();
            pnltransaction.Visible = false;
            pnlreports.Visible = false;
            pnlmaster.Visible = false;
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {

                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    lblstatus.Text = "WHATSAPP NOT AUTHORIZED";
                }
                else if (app.driver.PageSource.Contains("Loading your Chats"))
                {
                    lblstatus.Text = "WHATSAPP LOADING...";
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
    }
}
