﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_REMINDER : Form
    {
        int i;
        WhatsApp app;
        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";

        public FRM_REMINDER(WhatsApp whatsappInitialize)
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
            for (i = 0; i < dgw_view.Rows.Count; i++)
            {
                dgw_view.Rows[i].Cells[10].Value = "";
            }
        }

        public void Send()
        {
            if (MessageBox.Show("DO YOU WANT TO SEND WHATSAPP?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    string pdf = Path.Combine(Application.StartupPath, "REPORTS", "CHIT REMINDER" + ".pdf");
                    openFileDialog1.FileName = pdf;
                    for (i = 0; i < dgw_view.Rows.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToBoolean(dgw_view.Rows[i].Cells[0].Value) == true)
                            {
                                if (dgw_view.Rows[i].Cells[7].Value.ToString() == "0")
                                {
                                    dgw_view.Rows[i].Cells[10].Value = "FAILED";
                                }
                                else
                                {
                                    WebDriverWait web = new WebDriverWait(app.driver, TimeSpan.FromSeconds(30));
                                    string Url = "https://web.whatsapp.com/send?phone=" + dgw_view.Rows[i].Cells[7].Value + "&text=" + "Hi *" + dgw_view.Rows[i].Cells[3].Value + "*," + "%0a%0a_*" + "Greetings from M.S JEWELLERY!*_%0a%0a" + "*📢Monthly Chit Scheme Payment Reminder📢*%0a%0a" + "_*Customer ID - " + dgw_view.Rows[i].Cells[2].Value + "*_%0a*_Amount - ₹" + dgw_view.Rows[i].Cells[9].Value + ".00_*%0a%0a_📢 Friendly reminder for your Monthly Chit Scheme Payment. Kindly ensure your payment is made by this month. Please ignore if you have already paid the payment._%0a%0a*You can do Online Payment also.*%0a%0a_*Phone No : 6379742362*_%0a*All UPI Payments Available.*%0a_Share us a screenshot in this Phone No._%0a%0aThank You!♥️";
                                    app.driver.Navigate().GoToUrl(Url);
                                    Thread.Sleep(5000);
                                    if (app.driver.PageSource.Contains("Phone number shared via url is invalid.") == true)
                                    {
                                        app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 fhf7t426 sap93d0t r6jd426a niluw8xz']")).Click();
                                        dgw_view.Rows[i].Cells[10].Value = "FAILED";
                                    }
                                    else if (dgw_view.Rows[i].Cells[7].Value.ToString().Length == 10)
                                    {
                                        web.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@title='Attach']")));
                                        app.driver.FindElement(By.XPath("//div[@title='Attach']")).Click();
                                        web.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@accept='*']")));
                                        app.driver.FindElement(By.XPath("//input[@accept='*']")).SendKeys(openFileDialog1.FileName.ToString());
                                        web.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label='Send']")));
                                        app.driver.FindElement(By.XPath("//div[@aria-label='Send']")).Click();
                                        dgw_view.Rows[i].Cells[10].Value = "SUCEESS";
                                        dgw_view.CurrentCell = dgw_view.Rows[i].Cells[0];
                                        dgw_view.Rows[i].Selected = true;
                                        dgw_view.FirstDisplayedScrollingRowIndex = i;
                                        Thread.Sleep(3000);
                                        this.Focus();
                                    }
                                    else
                                    {
                                        dgw_view.Rows[i].Cells[10].Value = "FAILED";
                                    }
                                }
                            }
                        }
                        catch
                        {
                            dgw_view.Rows[i].Cells[10].Value = "FAILED";
                        }
                    }
                    MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
                catch
                {
                    MessageBox.Show($"An error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            dgw_view.Columns[1].HeaderText = "ID";
            dgw_view.Columns[2].HeaderText = "CUSTOMER ID";
            dgw_view.Columns[3].HeaderText = "CUSTOMER NAME";
            dgw_view.Columns[4].HeaderText = "ADDRESS";
            dgw_view.Columns[5].HeaderText = "AREA NAME";
            dgw_view.Columns[6].HeaderText = "PINCODE";
            dgw_view.Columns[7].HeaderText = "MOBILE NO";
            dgw_view.Columns[8].HeaderText = "CHIT TYPE";
            dgw_view.Columns[9].HeaderText = "CHIT AMOUNT";
            dgw_view.Columns.Add("MsgStatus", "STATUS");
        }

        private void btngetdata_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void FRM_REMINDER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (dgw_view.Rows.Count == 0)
            {
                MessageBox.Show("PLEASE GET DATA!!! , TRY AGAIN???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < dgw_view.Rows.Count; i++)
                {
                    Convert.ToBoolean(dgw_view.Rows[i].Cells[0].Value = true);
                }
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (dgw_view.Rows.Count == 0)
            {
                MessageBox.Show("PLEASE GET DATA!!! , TRY AGAIN???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < dgw_view.Rows.Count; i++)
                {
                    Convert.ToBoolean(dgw_view.Rows[i].Cells[0].Value = false);
                }
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgw_view.Rows.Count == 0)
                {
                    MessageBox.Show("NO RECORDS FOUND!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CRY_BULK_EXPORT BULK_EXPORT = new CRY_BULK_EXPORT();
                    FRM_CRY_BULK_EXPORT VIEW_BULK_EXPORT = new FRM_CRY_BULK_EXPORT();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();

                    dt.Columns.Add("CUSTOMER NAME");
                    dt.Columns.Add("MOBILE NO");
                    dt.Columns.Add("CHIT AMOUNT");
                    dt.Columns.Add("STATUS");
                    foreach (DataGridViewRow dgw_details in dgw_view.Rows)
                    {
                        dt.Rows.Add(dgw_details.Cells[3].Value, dgw_details.Cells[7].Value, dgw_details.Cells[9].Value, dgw_details.Cells[10].Value);
                    }

                    ds.Tables.Add(dt);
                    ds.WriteXmlSchema("Export.xml");
                    BULK_EXPORT.SetDataSource(ds);
                    VIEW_BULK_EXPORT.View_Report.ReportSource = BULK_EXPORT;
                    BULK_EXPORT.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    BULK_EXPORT.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    BULK_EXPORT.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "" + Application.StartupPath + "\\REPORTS\\" + "REMINDER WHATSAPP REPORT" + ".pdf");
                    MessageBox.Show("PRINT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("PRINT ERROR???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgw_view.Rows.Count == 0)
                {
                    MessageBox.Show("NO RECORDS FOUND!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CRY_BULK_EXPORT BULK_EXPORT = new CRY_BULK_EXPORT();
                    FRM_CRY_BULK_EXPORT VIEW_BULK_EXPORT = new FRM_CRY_BULK_EXPORT();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();

                    dt.Columns.Add("CUSTOMER NAME");
                    dt.Columns.Add("MOBILE NO");
                    dt.Columns.Add("CHIT AMOUNT");
                    dt.Columns.Add("STATUS");
                    foreach (DataGridViewRow dgw_details in dgw_view.Rows)
                    {
                        dt.Rows.Add(dgw_details.Cells[3].Value, dgw_details.Cells[7].Value, dgw_details.Cells[9].Value, dgw_details.Cells[10].Value);
                    }

                    ds.Tables.Add(dt);
                    ds.WriteXmlSchema("Export.xml");
                    BULK_EXPORT.SetDataSource(ds);
                    VIEW_BULK_EXPORT.View_Report.ReportSource = BULK_EXPORT;
                    BULK_EXPORT.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    BULK_EXPORT.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    BULK_EXPORT.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, "" + Application.StartupPath + "\\REPORTS\\" + "REMINDER WHATSAPP REPORT" + ".xls");
                    MessageBox.Show("PRINT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("PRINT ERROR???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
