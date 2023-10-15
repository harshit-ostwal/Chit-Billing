using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_REMINDER : Form
    {
        WhatsApp app;
        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";

        public FRM_REMINDER(WhatsApp whatsappInitialize)
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

        private void picminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnreset_Click(object sender, EventArgs e)
        {

        }

        public async void Send()
        {
            if (MessageBox.Show("DO YOU WANT TO SEND WHATSAPP BILL?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                for (int i = 0; i < dgw_view.RowCount; i++)
                {
                    string Url = "https://web.whatsapp.com/send?phone=" + dgw_view.Rows[i].Cells[6].Value + "&text=" + "Hi *" + dgw_view.Rows[i].Cells[2].Value + "*," + "%0a%0a_*" + "Greetings from M.S JEWELLERY!*_%0a%0a" + "*📢Monthly Chit Scheme Payment Reminder📢*%0a%0a" + "_*Customer ID - "+dgw_view.Rows[i].Cells[1].Value + "*_%0a*_Amount - ₹"+dgw_view.Rows[i].Cells[8].Value + ".00_*%0a%0a_📢 Friendly reminder for your Monthly Chit Scheme Payment. Kindly ensure your payment is made by this month._%0a%0a*You can do Online Payment also.*%0a%0a_*Phone No : 6379742362*_%0a*All UPI Payments Available.*%0a_Share us a screenshot in this Phone No._%0a%0aThank You!♥️";
                    app.driver.Navigate().GoToUrl(Url);
                    WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(10));
                    await Task.Run(() =>
                    {
                        try
                        {
                            if (wait.Until(driver => driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
                            {
                                wait.Until(driver => app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']"))).Click();
                                dgw_view.Rows[i].Cells[9].Value = "FAILED";
                            }
                        }
                        catch (Exception)
                        {
                            wait.Until(driver => app.driver.FindElement(By.XPath("// span[@data-icon='send']"))).Click();
                            dgw_view.Rows[i].Cells[9].Value = "SUCCESS";
                            MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    });
                }
                this.Focus();
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void Display()
        {
            string Data = "Select ID,f_customer_id,f_customer_name,f_address,f_area,f_pincode,f_mobile_no,f_chit_type,f_chit_amount From Customer_db order by f_customer_id desc";
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter(Data, Main);
            ad.Fill(ds);
            dgw_view.DataSource = ds.Tables[0];
            dgw_view.Columns[0].HeaderText = "ID";
            dgw_view.Columns[1].HeaderText = "CUSTOMER ID";
            dgw_view.Columns[2].HeaderText = "CUSTOMER NAME";
            dgw_view.Columns[3].HeaderText = "ADDRESS";
            dgw_view.Columns[4].HeaderText = "AREA NAME";
            dgw_view.Columns[5].HeaderText = "PINCODE";
            dgw_view.Columns[6].HeaderText = "MOBILE NO";
            dgw_view.Columns[7].HeaderText = "CHIT TYPE";
            dgw_view.Columns[8].HeaderText = "CHIT AMOUNT";
            dgw_view.Columns.Add("MsgStatus", "STATUS");
        }

        private void btngetdata_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void FRM_REMINDER_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==System.Windows.Forms.Keys.Escape)
            {
                if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Hide();
                    FRM_SETTINGS Settings = new FRM_SETTINGS(app);
                    Settings.Show();
                }
            }
        }

        private void FRM_REMINDER_Load(object sender, EventArgs e)
        {

        }
    }
}
