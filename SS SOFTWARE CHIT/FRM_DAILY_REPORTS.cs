using CrystalDecisions.CrystalReports.Engine;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_DAILY_REPORTS : Form
    {
        public string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";
        WhatsApp app;

        public FRM_DAILY_REPORTS(WhatsApp whatsappInitialize)
        {
            InitializeComponent();
            try
            {
                app = whatsappInitialize;
            }
            catch
            {

            }
        }

        private void HidePanel()
        {
            pnllbldate.Hide();
            pnlfilter.Hide();
            pnldgw.Hide();
            pnlamount.Hide();
            pnlbuttons.Hide();
            pnlmail.Hide();
            pnldate.Show();
        }

        private void ShowPanel()
        {
            pnllbldate.Show();
            pnlfilter.Show();
            pnldgw.Show();
            pnlamount.Show();
            pnlbuttons.Show();
            pnldate.Hide();
        }

        private void Clear()
        {
            txtdate.Refresh();
            txttype.Refresh();
            txtemail.Clear();
            txtmobileno.Clear();
            txttype.Text = null;
            lblamount.Text = null;
            lblbalance.Text = null;
        }

        private void Cal()
        {
            double v_totalamt = 0, v_totalbal = 0;
            for (int i = 0; i < dgw_view.Rows.Count; i++)
            {
                if (dgw_view.Rows[i].Cells[8].Value != null)
                { v_totalamt += double.Parse(dgw_view.Rows[i].Cells[8].Value.ToString()); }
                else { lblamount.Text = "₹0"; }

                if (dgw_view.Rows[i].Cells[9].Value != null)
                { v_totalbal += double.Parse(dgw_view.Rows[i].Cells[9].Value.ToString()); }
                else { lblbalance.Text = "₹0"; }

                lblamount.Text = Math.Round(v_totalamt, 2).ToString();
                lblamount.Text = "₹" + lblamount.Text;
                lblbalance.Text = Math.Round(v_totalbal, 2).ToString();
                lblbalance.Text = "₹" + lblbalance.Text;
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "Select f_customer_id,f_customer_name,f_area,f_mobile_no,f_sno,f_date,f_month,f_type,f_amount,f_balance from Chit_Billing_db where f_date=@date order by f_customer_id asc";
                DataSet ds = new DataSet();
                OleDbDataAdapter ad = new OleDbDataAdapter(str, Main);
                ad.SelectCommand.Parameters.AddWithValue("@date", txtdate.Value.ToString("dd/MM/yyyy"));
                ad.Fill(ds);
                dgw_view.DataSource = ds.Tables[0];
                dgw_view.Columns[0].HeaderText = "CARD NO";
                dgw_view.Columns[1].HeaderText = "CUSTOMER NAME";
                dgw_view.Columns[2].HeaderText = "AREA";
                dgw_view.Columns[3].HeaderText = "MOBILE NO";
                dgw_view.Columns[4].HeaderText = "S.NO";
                dgw_view.Columns[5].HeaderText = "DATE";
                dgw_view.Columns[6].HeaderText = "MONTH";
                dgw_view.Columns[7].HeaderText = "TYPE";
                dgw_view.Columns[8].HeaderText = "AMOUNT";
                dgw_view.Columns[9].HeaderText = "BALANCE";
                dgw_view.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                ShowPanel();
                Cal();
                lbldate.Text = txtdate.Text;
                MessageBox.Show("DATA LOADED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
        }

        private void FRM_DAILY_REPORTS_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mainDataSet.Company_db' table. You can move, or remove it, as needed.
            this.company_dbTableAdapter.Fill(this.mainDataSet.Company_db);
            HidePanel();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                CRY_DAILY_REPORTS cr = new CRY_DAILY_REPORTS();
                FRM_CRY_DAILY_REPORTS View_Daily_Reports = new FRM_CRY_DAILY_REPORTS();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                TextObject Date = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lbldate"];
                Date.Text = txtdate.Value.ToString("dd/MM/yyyy");
                TextObject TotalAmount = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalamount"];
                TotalAmount.Text = lblamount.Text;
                TextObject TotalBalance = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalbalance"];
                TotalBalance.Text = lblbalance.Text;
                dt.Columns.Add("CARD NO");
                dt.Columns.Add("CUSTOMER NAME");
                dt.Columns.Add("AREA");
                dt.Columns.Add("MOBILE NO");
                dt.Columns.Add("S.NO");
                dt.Columns.Add("DATE");
                dt.Columns.Add("MONTH");
                dt.Columns.Add("TYPE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("BALANCE");
                foreach (DataGridViewRow dgw_detail in dgw_view.Rows)
                {
                    dt.Rows.Add(dgw_detail.Cells[0].Value, dgw_detail.Cells[1].Value, dgw_detail.Cells[2].Value, dgw_detail.Cells[3].Value, dgw_detail.Cells[4].Value, dgw_detail.Cells[5].Value, dgw_detail.Cells[6].Value, dgw_detail.Cells[7].Value, dgw_detail.Cells[8].Value, dgw_detail.Cells[9].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("Reports.xml");
                cr.SetDataSource(ds);
                View_Daily_Reports.View_Report.ReportSource = cr;
                cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cr.PrintToPrinter(1, false, 0, 0);
                Cal();
                MessageBox.Show("PRINT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("PRINT ERROR???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pdf()
        {
            if (dgw_view.Rows.Count == 0)
            {
                MessageBox.Show("NO RECORDS FOUND!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clear();
            }
            else
            {
                CRY_DAILY_REPORTS cr = new CRY_DAILY_REPORTS();
                FRM_CRY_DAILY_REPORTS Print = new FRM_CRY_DAILY_REPORTS();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                TextObject Date = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lbldate"];
                Date.Text = txtdate.Value.ToString("dd/MM/yyyy");
                TextObject TotalAmount = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalamount"];
                TotalAmount.Text = lblamount.Text;
                TextObject TotalBalance = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalbalance"];
                TotalBalance.Text = lblbalance.Text;
                dt.Columns.Add("CARD NO");
                dt.Columns.Add("CUSTOMER NAME");
                dt.Columns.Add("AREA");
                dt.Columns.Add("MOBILE NO");
                dt.Columns.Add("S.NO");
                dt.Columns.Add("DATE");
                dt.Columns.Add("MONTH");
                dt.Columns.Add("TYPE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("BALANCE");
                dgw_view.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                foreach (DataGridViewRow dgw_detail in dgw_view.Rows)
                {
                    dt.Rows.Add(dgw_detail.Cells[0].Value, dgw_detail.Cells[1].Value, dgw_detail.Cells[2].Value, dgw_detail.Cells[3].Value, dgw_detail.Cells[4].Value, dgw_detail.Cells[5].Value, dgw_detail.Cells[6].Value, dgw_detail.Cells[7].Value, dgw_detail.Cells[8].Value, dgw_detail.Cells[9].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("Reports.xml");
                cr.SetDataSource(ds);
                Print.View_Report.ReportSource = cr;
                cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "" + Application.StartupPath + "\\REPORTS\\" + "DAILY REPORTS " + txtdate.Value.ToString("dd-MM-yyyy") + ".pdf");
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                Pdf();
                MessageBox.Show("PRINT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("PRINT ERROR???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                Excel();
                MessageBox.Show("PRINT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("PRINT ERROR???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Excel()
        {
            if (dgw_view.Rows.Count == 0)
            {
                MessageBox.Show("NO RECORDS FOUND!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clear();
            }
            else
            {
                CRY_DAILY_REPORTS cr = new CRY_DAILY_REPORTS();
                FRM_CRY_DAILY_REPORTS Print = new FRM_CRY_DAILY_REPORTS();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                TextObject Date = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lbldate"];
                Date.Text = txtdate.Value.ToString("dd/MM/yyyy");
                TextObject TotalAmount = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalamount"];
                TotalAmount.Text = lblamount.Text;
                TextObject TotalBalance = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalbalance"];
                TotalBalance.Text = lblbalance.Text;
                dt.Columns.Add("CARD NO");
                dt.Columns.Add("CUSTOMER NAME");
                dt.Columns.Add("AREA");
                dt.Columns.Add("MOBILE NO");
                dt.Columns.Add("S.NO");
                dt.Columns.Add("DATE");
                dt.Columns.Add("MONTH");
                dt.Columns.Add("TYPE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("BALANCE");
                dgw_view.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                foreach (DataGridViewRow dgw_detail in dgw_view.Rows)
                {
                    dt.Rows.Add(dgw_detail.Cells[0].Value, dgw_detail.Cells[1].Value, dgw_detail.Cells[2].Value, dgw_detail.Cells[3].Value, dgw_detail.Cells[4].Value, dgw_detail.Cells[5].Value, dgw_detail.Cells[6].Value, dgw_detail.Cells[7].Value, dgw_detail.Cells[8].Value, dgw_detail.Cells[9].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("Reports.xml");
                cr.SetDataSource(ds);
                Print.View_Report.ReportSource = cr;
                cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, "" + Application.StartupPath + "\\REPORTS\\" + "DAILY REPORTS " + txtdate.Value.ToString("dd-MM-yyyy") + ".xls");
            }
        }

        private void btnwhatsapp_Click(object sender, EventArgs e)
        {
            if (pnlwhatsapp.Visible == false)
            {
                pnlwhatsapp.Visible = true;
                txtmobileno.Focus();
            }
            else
            {
                pnlwhatsapp.Visible = false;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pnldate.Visible == false)
                {
                    (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_type LIKE '%{0}%'", txttype.Text);
                    Cal();
                }
            }
            catch
            {
                MessageBox.Show("INVAILD,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnmail_Click(object sender, EventArgs e)
        {
            if (pnlmail.Visible == false)
            {
                pnlmail.Visible = true;
                txtemail.Focus();
            }
            else
            {
                pnlmail.Visible = false;
            }
        }
        public void Send()
        {

            try
            {
                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    MessageBox.Show("WHATSAPP NOT AUTHORIZED?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (app.driver.PageSource.Contains("Loading your Chats"))
                {
                    MessageBox.Show("WHATSAPP LOADING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("DO YOU WANT TO SEND WHATSAPP?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Pdf();
                        string pdfMail = Path.Combine(Application.StartupPath, "REPORTS", "DAILY REPORTS " + txtdate.Value.ToString("dd-MM-yyyy") + ".pdf");
                        openFileDialog1.FileName = pdfMail;
                        string Url = "https://web.whatsapp.com/send?phone=" + txtmobileno.Text + "&text=" + "Dear *" + lblusername.Text + "*," + "%0a%0a_*" + "Greetings from SS SOFTWARE!♥️*_%0a%0a_🎉 We're thrilled to share today's Chit Billing Report with you. It's been an exciting day, and we want to keep you in the loop. 📊_%0a%0a_*Detailed Report 👇*_%0a%0a" + "_📎 For a closer look, please find the attached PDF containing all the details, including participant information, billing statements, balance histories, and more. 📄_%0a%0a_*🔗 Stay Connected 🤝*_%0a%0a_🤔 Got questions, suggestions, or just want to chat? We're here for you. Don't hesitate to reach out; we're just a click away. 😊_" + "_%0a%0a*_Best regards,_*%0a%0a*_SS SOFTWARE_*%0a*♥️ Developed By ♥️ Harshit Jain ♥️*";
                        WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(10));
                        app.driver.Navigate().GoToUrl(Url);

                        try
                        {
                            if (wait.Until(driver => driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
                            {
                                app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
                                MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtmobileno.Focus();
                            }
                        }
                        catch
                        {
                            app.driver.FindElement(By.XPath("//div[@title='Attach']")).Click();
                            app.driver.FindElement(By.XPath("//input[@accept='*']")).SendKeys(openFileDialog1.FileName.ToString());
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label='Send']")));
                            app.driver.FindElement(By.XPath("//div[@aria-label='Send']")).Click();
                            MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            pnlwhatsapp.Hide();
                        }
                        this.Focus();
                    }
                }
            }
            catch
            {

            }
        }

        private async void btnmailsender_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtemail.Text != "")
                {
                    Pdf();
                    Excel();
                    string pdfMail = Path.Combine(Application.StartupPath, "REPORTS", "DAILY REPORTS " + txtdate.Value.ToString("dd-MM-yyyy") + ".pdf");
                    string XlsMail = Path.Combine(Application.StartupPath, "REPORTS", "DAILY REPORTS " + txtdate.Value.ToString("dd-MM-yyyy") + ".xls");
                    string imagePath = Path.Combine(Application.StartupPath, "LOGO", "LOGO.png");
                    bool connection = NetworkInterface.GetIsNetworkAvailable();

                    if (connection)
                    {
                        using (SmtpClient Client = new SmtpClient("smtp.gmail.com"))
                        {
                            Client.Port = 587;
                            Client.EnableSsl = true;
                            Client.Credentials = new NetworkCredential("official.sssoftware@gmail.com", "zhxovvaxvngyacyr");

                            using (MailMessage Message = new MailMessage())
                            {
                                MailAddress FromEmail = new MailAddress("official.sssoftware@gmail.com", "SS SOFTWARE");
                                MailAddress ToEmail = new MailAddress(txtemail.Text);
                                Message.From = FromEmail;
                                Message.To.Add(ToEmail);
                                Message.Subject = "Daily Chit Billing Report - " + txtdate.Value.ToString("dd-MM-yyyy");
                                string emailBody = @"
  <!DOCTYPE html>
    <html>
    <head>
        <style>
            body {
                font-family: 'Arial', 'Helvetica', sans-serif;
                margin: 0;
                padding: 0;
                animation: fadeIn 1s ease-in-out;
            }
            .container {
                max-width: 600px;
                margin: 0 auto;
                padding: 20px;
                border-radius: 20px;
                background-color:  #ffa600;
                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            }
            .header {
                background-color: #003f5c;
                color: white;
                padding: 10px;
                margin-bottom: 30px;
                margin-top: 20px;
                border-radius: 20px;
                text-transform: capitalize;
                text-align: center;
            }
            .content {
                padding: 20px;
                line-height: 1.5;
                border-radius: 20px;
                color: white;
                background: black;
            }
            .highlight {
                font-weight: 700;
                color: #007acc;
            }
            @keyframes fadeIn {
                0% { opacity: 0; }
                100% { opacity: 1; }
            }
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <h2>Chit Billing Report</h2>
            </div>
            <div class='content'>
                <p>Dear " + lblusername.Text + @",</p>
                <p>Greetings from SS SOFTWARE!</p>
                <p>We're thrilled to share today's Chit Billing Report with you. It's been an exciting day, and we want to keep you in the loop.</p>
                <p><span class='highlight'>Detailed Report:</span></p>
                <p>For a closer look, please find the attached PDF containing all the details, including participant information, billing statements, balance histories, and more.</p>
                <p><span class='highlight'>Stay Connected:</span></p>
                <p>Got questions, suggestions, or just want to chat? We're here for you. Don't hesitate to reach out; we're just a click away.</p>
                <p>Thank you for choosing SS SOFTWARE. We appreciate your trust in our services.</p>
                <p>Best regards,<br>Harshit Jain</p>
            </div>
            <div class='header'>
                <h5>&copy; " + DateTime.Now.Year + @" SS SOFTWARE. All rights reserved.</h5>
            </div>
        </div>
    </body>
    </html>";

                                Message.Body = emailBody;
                                Message.IsBodyHtml = true;
                                Message.Priority = MailPriority.High;
                                Message.Attachments.Add(new Attachment(pdfMail));
                                Message.Attachments.Add(new Attachment(XlsMail));
                                await Client.SendMailAsync(Message);
                            }
                            MessageBox.Show("EMAIL SENT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnlmail.Hide();
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pnlmail.Hide();
                    }
                }
            }
            catch
            {
                pnlmail.Hide();
            }
        }

        private void FRM_DAILY_REPORTS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                if (pnlmail.Visible == true)
                {
                    pnlmail.Visible = false;
                }
                if (pnlwhatsapp.Visible == true)
                {
                    pnlwhatsapp.Visible = false;
                }
                if (pnldate.Visible == false)
                {
                    HidePanel();
                    Clear();
                }
                else
                {
                    if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Clear();
                        FRM_HOME Home = new FRM_HOME(app);
                        this.Hide();
                        Home.Show();
                    }
                }
            }
        }

        private void txtdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            string Email_Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtemail.Text, Email_Pattern) == false)
            {
                errorProvider1.SetError(txtemail, "Invalid Email Id");
                txtemail.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void picminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void piclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Clear();
                FRM_HOME Home = new FRM_HOME(app);
                this.Hide();
                Home.Show();
            }
        }


        private void btnsendwhatsapp_Click(object sender, EventArgs e)
        {
            Send();
        }
    }
}
