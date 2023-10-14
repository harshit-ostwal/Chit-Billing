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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_CUSTOMER_ACTIVITY : Form
    {
        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";
        int i = 0;
        WhatsApp app;

        public FRM_CUSTOMER_ACTIVITY(WhatsApp whatsappInitialize)
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

        private async void FRM_CUSTOMER_ACTIVITY_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mainDataSet.Company_db' table. You can move, or remove it, as needed.
            this.company_dbTableAdapter.Fill(this.mainDataSet.Company_db);
            Data();
            await LoadData();
        }

        private void Cal()
        {
            double v_totalamt = 0, v_totalbal = 0;
            for (int i = 0; i < dgw_view.Rows.Count; i++)
            {
                if (dgw_view.Rows[i].Cells[6].Value != null)
                { v_totalamt += double.Parse(dgw_view.Rows[i].Cells[6].Value.ToString()); }
                else { lblamount.Text = "₹0"; }

                if (dgw_view.Rows[i].Cells[7].Value != null)
                { v_totalbal += double.Parse(dgw_view.Rows[i].Cells[7].Value.ToString()); }
                else { lblbalance.Text = "₹0"; }

                lblamount.Text = Math.Round(v_totalamt, 2).ToString();
                lblamount.Text = "₹" + lblamount.Text;
                lblbalance.Text = Math.Round(v_totalbal, 2).ToString();
                lblbalance.Text = "₹" + lblbalance.Text;
            }
        }

        private async Task LoadData()
        {
            string str = "Select f_customer_id,f_customer_name,f_sno,f_date,f_month,f_type,f_amount,f_balance from Chit_Billing_db order by f_sno asc";
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter(str, Main);
            await Task.Run(() => ad.Fill(ds));
            dgw_view.DataSource = ds.Tables[0];
            dgw_view.Columns[0].HeaderText = "CARD NO";
            dgw_view.Columns[0].Visible = false;
            dgw_view.Columns[1].HeaderText = "CUSTOMER NAME";
            dgw_view.Columns[1].Visible = false;
            dgw_view.Columns[2].HeaderText = "S.NO";
            dgw_view.Columns[3].HeaderText = "DATE";
            dgw_view.Columns[4].HeaderText = "MONTH";
            dgw_view.Columns[5].HeaderText = "TYPE";
            dgw_view.Columns[6].HeaderText = "AMOUNT";
            dgw_view.Columns[7].HeaderText = "BALANCE";
        }

        private void Data()
        {
            string Data = "Select f_customer_id,f_customer_name,f_area,f_mobile_no,f_chit_type,f_chit_amount From Customer_db order by f_customer_id desc";
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter(Data, Main);
            ad.Fill(ds);
            dgw_customer.DataSource = ds.Tables[0];
            dgw_customer.Columns[0].HeaderText = "CUSTOMER ID";
            dgw_customer.Columns[1].HeaderText = "CUSTOMER NAME";
            dgw_customer.Columns[2].HeaderText = "AREA NAME";
            dgw_customer.Columns[3].HeaderText = "MOBILE NO";
            dgw_customer.Columns[4].HeaderText = "CHIT TYPE";
            dgw_customer.Columns[5].HeaderText = "CHIT AMOUNT";
        }

        private void Clear()
        {
            txtcustomerid.Clear();
            txtcustomername.Clear();
            txtarea.Clear();
            txtmobileno.Clear();
            txtchittype.Clear();
            txtmobileno.Clear();
            txtchitamount.Clear();
            txtcustomerid.Focus();
            dgw_view.Visible = false;
        }

        private void piclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO CLOSE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FRM_HOME HOME = new FRM_HOME(app);
                HOME.Show();
            }
        }

        private void picminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FRM_CUSTOMER_ACTIVITY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                if (dgw_view.Visible == false && dgw_customer.Visible == false)
                {
                    Clear();
                    if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        FRM_HOME Home = new FRM_HOME(app);
                        this.Hide();
                        Home.Show();
                    }
                }
                else
                {
                    if (dgw_view.Visible == false || dgw_customer.Visible == false)
                    {
                        Clear();
                        if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            FRM_HOME Home = new FRM_HOME(app);
                            this.Hide();
                            Home.Show();
                        }
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtcustomerid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgw_customer.Visible = true;
                (dgw_customer.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_id LIKE '%{0}%'", txtcustomerid.Text);
                (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_id LIKE '{0}'", txtcustomerid.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("INVAILD,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcustomername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgw_customer.Visible = true;
                (dgw_customer.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_name LIKE '%{0}%'", txtcustomername.Text);
                (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_name LIKE '{0}'", txtcustomername.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("INVAILD,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcustomername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    if (txtcustomername.Text == "")
                    {
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        dgw_customer.Focus();
                    }
                }
                if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    if (dgw_customer.Visible == true)
                    {
                        dgw_customer.Focus();
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcustomerid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    if (txtcustomerid.Text == "")
                    {
                        SendKeys.Send("{TAB}");
                    }
                    else
                    {
                        dgw_customer.Focus();
                    }
                }
                if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    if (dgw_customer.Visible == true)
                    {
                        dgw_customer.Focus();
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgw_customer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    txtcustomerid.Text = dgw_customer.SelectedRows[i].Cells[0].Value.ToString();
                    txtcustomername.Text = dgw_customer.SelectedRows[i].Cells[1].Value.ToString();
                    txtarea.Text = dgw_customer.SelectedRows[i].Cells[2].Value.ToString();
                    txtmobileno.Text = dgw_customer.SelectedRows[i].Cells[3].Value.ToString();
                    txtchittype.Text = dgw_customer.SelectedRows[i].Cells[4].Value.ToString();
                    txtchitamount.Text = dgw_customer.SelectedRows[i].Cells[5].Value.ToString();
                    dgw_customer.Visible = false;
                    dgw_view.Visible = true;
                    Cal();
                }
            }
            catch (Exception)
            {

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

        private void Pdf()
        {
            if (dgw_view.Rows.Count == 0)
            {
                MessageBox.Show("NO RECORDS FOUND!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clear();
            }
            else
            {
                CRY_CUSTOMER_ACTIVITY_REPORT cr = new CRY_CUSTOMER_ACTIVITY_REPORT();
                FRM_CRY_CUSTOMER_ACTIVITY_REPORT Print = new FRM_CRY_CUSTOMER_ACTIVITY_REPORT();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                TextObject CustomerId = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomercard"];
                CustomerId.Text = txtcustomerid.Text;
                TextObject CustomerName = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomername"];
                CustomerName.Text = txtcustomername.Text;
                TextObject Area = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblarea"];
                Area.Text = txtarea.Text;
                TextObject MobileNo = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblmobileno"];
                MobileNo.Text = txtmobileno.Text;
                TextObject ChitType = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblchittype"];
                ChitType.Text = txtchittype.Text;
                TextObject ChitAmount = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblchitamount"];
                ChitAmount.Text = txtchitamount.Text;
                TextObject TotalAmount = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalamount"];
                TotalAmount.Text = lblamount.Text;
                TextObject TotalBalance = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalbalance"];
                TotalBalance.Text = lblbalance.Text;
                dt.Columns.Add("S.NO");
                dt.Columns.Add("DATE");
                dt.Columns.Add("MONTH");
                dt.Columns.Add("TYPE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("BALANCE");
                dgw_view.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                foreach (DataGridViewRow dgw_detail in dgw_view.Rows)
                {
                    dt.Rows.Add(dgw_detail.Cells[2].Value, dgw_detail.Cells[3].Value, dgw_detail.Cells[4].Value, dgw_detail.Cells[5].Value, dgw_detail.Cells[6].Value, dgw_detail.Cells[7].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("CustomerReports.xml");
                cr.SetDataSource(ds);
                Print.View_Report.ReportSource = cr;
                cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "" + Application.StartupPath + "\\REPORTS\\" + txtcustomerid.Text + " - ACTIVTY REPORT" + ".pdf");
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
                CRY_CUSTOMER_ACTIVITY_REPORT cr = new CRY_CUSTOMER_ACTIVITY_REPORT();
                FRM_CRY_CUSTOMER_ACTIVITY_REPORT Print = new FRM_CRY_CUSTOMER_ACTIVITY_REPORT();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                TextObject CustomerId = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomercard"];
                CustomerId.Text = txtcustomerid.Text;
                TextObject CustomerName = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomername"];
                CustomerName.Text = txtcustomername.Text;
                TextObject Area = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblarea"];
                Area.Text = txtarea.Text;
                TextObject MobileNo = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblmobileno"];
                MobileNo.Text = txtmobileno.Text;
                TextObject ChitType = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblchittype"];
                ChitType.Text = txtchittype.Text;
                TextObject ChitAmount = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblchitamount"];
                ChitAmount.Text = txtchitamount.Text;
                TextObject TotalAmount = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalamount"];
                TotalAmount.Text = lblamount.Text;
                TextObject TotalBalance = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalbalance"];
                TotalBalance.Text = lblbalance.Text;
                dt.Columns.Add("S.NO");
                dt.Columns.Add("DATE");
                dt.Columns.Add("MONTH");
                dt.Columns.Add("TYPE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("BALANCE");
                dgw_view.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                foreach (DataGridViewRow dgw_detail in dgw_view.Rows)
                {
                    dt.Rows.Add(dgw_detail.Cells[2].Value, dgw_detail.Cells[3].Value, dgw_detail.Cells[4].Value, dgw_detail.Cells[5].Value, dgw_detail.Cells[6].Value, dgw_detail.Cells[7].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("CustomerReports.xml");
                cr.SetDataSource(ds);
                Print.View_Report.ReportSource = cr;
                cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, "" + Application.StartupPath + "\\REPORTS\\" + txtcustomerid.Text +" - ACTIVTY REPORT"+ ".xls");
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

        private void btnwhatsapp_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                CRY_CUSTOMER_ACTIVITY_REPORT cr = new CRY_CUSTOMER_ACTIVITY_REPORT();
                FRM_CRY_CUSTOMER_ACTIVITY_REPORT Print = new FRM_CRY_CUSTOMER_ACTIVITY_REPORT();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                TextObject CustomerId = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomercard"];
                CustomerId.Text = txtcustomerid.Text;
                TextObject CustomerName = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomername"];
                CustomerName.Text = txtcustomername.Text;
                TextObject Area = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblarea"];
                Area.Text = txtarea.Text;
                TextObject MobileNo = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblmobileno"];
                MobileNo.Text = txtmobileno.Text;
                TextObject ChitType = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblchittype"];
                ChitType.Text = txtchittype.Text;
                TextObject ChitAmount = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblchitamount"];
                ChitAmount.Text = txtchitamount.Text;
                TextObject TotalAmount = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalamount"];
                TotalAmount.Text = lblamount.Text;
                TextObject TotalBalance = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["lbltotalbalance"];
                TotalBalance.Text = lblbalance.Text;
                dt.Columns.Add("S.NO");
                dt.Columns.Add("DATE");
                dt.Columns.Add("MONTH");
                dt.Columns.Add("TYPE");
                dt.Columns.Add("AMOUNT");
                dt.Columns.Add("BALANCE");
                dgw_view.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                foreach (DataGridViewRow dgw_detail in dgw_view.Rows)
                {
                    dt.Rows.Add(dgw_detail.Cells[2].Value, dgw_detail.Cells[3].Value, dgw_detail.Cells[4].Value, dgw_detail.Cells[5].Value, dgw_detail.Cells[6].Value, dgw_detail.Cells[7].Value);
                }
                ds.Tables.Add(dt);
                ds.WriteXmlSchema("CustomerReports.xml");
                cr.SetDataSource(ds);
                Print.View_Report.ReportSource = cr;
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
                        string pdfMail = Path.Combine(Application.StartupPath, "REPORTS", txtcustomerid.Text + " - ACTIVTY REPORT" + ".pdf");
                        openFileDialog1.FileName = pdfMail;
                        string Url = "https://web.whatsapp.com/send?phone=" + txtmobileno.Text + "&text=" + "Dear *" + txtcustomername.Text + "*," + "%0a%0a_*" + "Greetings from " + lblusername.Text + @"!♥️*_%0a%0a_🎉 We're thrilled to share Your Activity Chit Billing Report with you. It's been an exciting day, and we want to keep you in the loop. 📊_%0a%0a_*Detailed Report 👇*_%0a%0a" + "_📎 For a closer look, please find the attached PDF containing all the details, including participant information, billing statements, balance histories, and more. 📄_%0a%0a_*🔗 Stay Connected 🤝*_%0a%0a_🤔 Got questions, suggestions, or just want to chat? We're here for you. Don't hesitate to reach out; we're just a click away. 😊_" + "_%0a%0a*_Best regards,_*%0a%0a*_SS SOFTWARE_*%0a*♥️ Developed By ♥️ Harshit Jain ♥️*";
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
                        catch (Exception)
                        {
                            app.driver.FindElement(By.XPath("//div[@title='Attach']")).Click();
                            app.driver.FindElement(By.XPath("//input[@accept='*']")).SendKeys(openFileDialog1.FileName.ToString());
                            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label='Send']")));
                            app.driver.FindElement(By.XPath("//div[@aria-label='Send']")).Click();
                            MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                        this.Focus();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private async void btnmailsender_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                if (txtemail.Text != "")
                {
                    Pdf();
                    Excel();
                    string pdfMail = Path.Combine(Application.StartupPath, "REPORTS", txtcustomerid.Text +" - ACTIVTY REPORT"+".pdf");
                    string XlsMail = Path.Combine(Application.StartupPath, "REPORTS", txtcustomerid.Text + " - ACTIVTY REPORT"+".xls");
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
                                Message.Subject = "" + txtcustomerid.Text + " Customer Activty Chit Billing Report";
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
                <p>Dear " + txtcustomername.Text + @",</p>
                <p>Greetings from " + lblusername.Text + @"!</p>
                <p>We're thrilled to share Your Activty Chit Billing Report with you. It's been an exciting day, and we want to keep you in the loop.</p>
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
                                Message.Attachments.Add(new Attachment(pdfMail));
                                Message.Attachments.Add(new Attachment(XlsMail));
                                await Client.SendMailAsync(Message);
                            }
                            MessageBox.Show("EMAIL SENT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnlmail.Hide();
                            Clear();
                            this.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pnlmail.Hide();
                    }
                }
            }
            catch (Exception)
            {
                pnlmail.Hide();
            }
        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnsendwhatsapp_Click(object sender, EventArgs e)
        {
            Send();
        }
    }
}
