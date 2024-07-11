using OpenQA.Selenium;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_BULK_MSG : Form
    {

        int i;
        WhatsApp app;
        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";
        DataTable dataTable = new DataTable();

        public FRM_BULK_MSG(WhatsApp whatsappInitialize)
        {
            InitializeComponent();
            dataTable.Columns.Add(" ", typeof(bool));
            dataTable.Columns.Add("CUSTOMER NAME", typeof(string));
            dataTable.Columns.Add("MOBILE NO", typeof(string));
            dataTable.Columns.Add("STATUS", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["CustomerName"], dataTable.Columns["MobileNo"] };
            dgw_view.DataSource = dataTable;
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

        private void Display()
        {
            string Data = "Select f_customer_name,f_mobile_no From Customer_db order by f_customer_id desc";
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter(Data, Main);
            ad.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dataTable.Rows.Add(false, row["f_customer_name"], row["f_mobile_no"], string.Empty);
            }
        }

        private void FRM_BULK_MSG_Load(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            for (i = 0; i < dgw_view.Rows.Count; i++)
            {
                dgw_view.Rows[i].Cells[3].Value = "";
            }
        }

        public void GenerateFestivalMessage(TextBox txt, TextBox festival, TextBox discountDetails)
        {
            txt.Text = $"*📢✨ {festival.Text} Wishes ✨📢*%0a%0a" +
           "_We hope this message finds you and your family in great health and happiness._%0a%0a" +
           $"*_Special Offer: {discountDetails.Text}_*%0a%0a" +
           $"_On this joyous occasion of {festival.Text}, we are thrilled to offer you a special discount. Visit our store to take advantage of this limited-time offer._%0a%0a";
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO SEND WHATSAPP?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    txtMsg.Enabled = false;
                    string pdf = Path.Combine(Application.StartupPath, "REPORTS", "SS SOFTWARE" + ".pdf");
                    openFileDialog1.FileName = pdf;
                    for (i = 0; i < dgw_view.Rows.Count; i++)
                    {
                        try
                        {
                            if (Convert.ToBoolean(dgw_view.Rows[i].Cells[0].Value) == true)
                            {
                                if (dgw_view.Rows[i].Cells[2].Value.ToString() == "0")
                                {
                                    dgw_view.Rows[i].Cells[3].Value = "FAILED";
                                }
                                else
                                {
                                    WebDriverWait web = new WebDriverWait(app.driver, TimeSpan.FromSeconds(30));
                                    string Url = "https://web.whatsapp.com/send?phone=" + dgw_view.Rows[i].Cells[2].Value + "&text=" + "Hi *" + dgw_view.Rows[i].Cells[1].Value + "*," + "%0a%0a_*" + "Greetings from M.S JEWELLERY!*_%0a%0a" + txtMsg.Text + "*_Thank You!♥️_*%0a*_Warm Regards,_*%0a*_M.S JEWELLERY_*";
                                    app.driver.Navigate().GoToUrl(Url);
                                    Thread.Sleep(5000);
                                    if (app.driver.PageSource.Contains("Phone number shared via url is invalid.") == true)
                                    {
                                        app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 fhf7t426 sap93d0t r6jd426a niluw8xz']")).Click();
                                        dgw_view.Rows[i].Cells[3].Value = "FAILED";
                                    }
                                    else if (dgw_view.Rows[i].Cells[2].Value.ToString().Length == 10)
                                    {
                                        web.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@title='Attach']")));
                                        app.driver.FindElement(By.XPath("//div[@title='Attach']")).Click();
                                        web.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@accept='*']")));
                                        app.driver.FindElement(By.XPath("//input[@accept='*']")).SendKeys(openFileDialog1.FileName.ToString());
                                        web.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label='Send']")));
                                        app.driver.FindElement(By.XPath("//div[@aria-label='Send']")).Click();
                                        dgw_view.Rows[i].Cells[3].Value = "SUCEESS";
                                        dgw_view.CurrentCell = dgw_view.Rows[i].Cells[0];
                                        dgw_view.Rows[i].Selected = true;
                                        dgw_view.FirstDisplayedScrollingRowIndex = i;
                                        Thread.Sleep(3000);
                                        this.Focus();
                                    }
                                    else
                                    {
                                        dgw_view.Rows[i].Cells[3].Value = "FAILED";
                                    }
                                }
                            }
                        }
                        catch
                        {
                            dgw_view.Rows[i].Cells[3].Value = "FAILED";
                        }
                    }
                    txtMsg.Enabled = true;
                    MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
                catch
                {
                    txtMsg.Enabled = true;
                    MessageBox.Show($"An error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
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

        private void FRM_BULK_MSG_KeyDown(object sender, KeyEventArgs e)
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

        private void btnDeselectAll_Click(object sender, EventArgs e)
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

        private void btnExportPdf_Click(object sender, EventArgs e)
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
                    dt.Columns.Add("STATUS");
                    foreach (DataGridViewRow dgw_details in dgw_view.Rows)
                    {
                        dt.Rows.Add(dgw_details.Cells[1].Value, dgw_details.Cells[2].Value, dgw_details.Cells[3].Value);
                    }

                    ds.Tables.Add(dt);
                    ds.WriteXmlSchema("Export.xml");
                    BULK_EXPORT.SetDataSource(ds);
                    VIEW_BULK_EXPORT.View_Report.ReportSource = BULK_EXPORT;
                    BULK_EXPORT.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    BULK_EXPORT.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    BULK_EXPORT.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "" + Application.StartupPath + "\\REPORTS\\" + "BULK WHATSAPP REPORT" + ".pdf");
                    MessageBox.Show("PRINT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("PRINT ERROR???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
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
                    dt.Columns.Add("STATUS");
                    foreach (DataGridViewRow dgw_details in dgw_view.Rows)
                    {
                        dt.Rows.Add(dgw_details.Cells[1].Value, dgw_details.Cells[2].Value, dgw_details.Cells[3].Value);
                    }

                    ds.Tables.Add(dt);
                    ds.WriteXmlSchema("Export.xml");
                    BULK_EXPORT.SetDataSource(ds);
                    VIEW_BULK_EXPORT.View_Report.ReportSource = BULK_EXPORT;
                    BULK_EXPORT.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    BULK_EXPORT.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    BULK_EXPORT.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, "" + Application.StartupPath + "\\REPORTS\\" + "BULK WHATSAPP REPORT" + ".xls");
                    MessageBox.Show("PRINT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("PRINT ERROR???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngetdata_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "SS SOFTWARE";
                Microsoft.Office.Interop.Excel.Application application;
                Microsoft.Office.Interop.Excel.Workbook workbook;
                Microsoft.Office.Interop.Excel.Worksheet worksheet;
                Microsoft.Office.Interop.Excel.Range range;
                int xlrow;
                string strfilename;
                openFileDialog1.Filter = "Excel Office |*.xls; *.xlsx";
                openFileDialog1.ShowDialog();
                strfilename = openFileDialog1.FileName;
                if (strfilename != "")
                {
                    application = new Microsoft.Office.Interop.Excel.Application();
                    workbook = application.Workbooks.Open(strfilename);
                    worksheet = workbook.Worksheets["Sheet1"];
                    range = worksheet.UsedRange;

                    bool chk = false;
                    for (xlrow = 2; xlrow <= range.Rows.Count; xlrow++)
                    {
                        dataTable.Rows.Add(chk, range.Cells[xlrow, 1].Text, range.Cells[xlrow, 2].Text, range.Cells[xlrow, 3].Text);
                    }
                    workbook.Close();
                    application.Quit();
                    Display();
                    MessageBox.Show("DATA IMPORTED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("ERROR WHILE IMPORTING DATA??? , TRY AGAIN???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btndelete_Click(object sender, EventArgs e)
        {
            GenerateFestivalMessage(txtMsg, txtfestival, txtoffer);
        }

        private void btnitalic_Click(object sender, EventArgs e)
        {
            if (txtMsg.SelectionLength > 1)
            {
                txtMsg.SelectedText = "%20_" + txtMsg.SelectedText + "_%20";
            }
            else
            {
                MessageBox.Show("SELECT THE TEXT?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMsg.Focus();
            }
            txtMsg.Focus();
        }

        private void btnnewline_Click(object sender, EventArgs e)
        {
            txtMsg.Text = txtMsg.Text + "%0a";
            txtMsg.Focus();
        }

        private void btnbold_Click(object sender, EventArgs e)
        {
            if (txtMsg.SelectionLength > 1)
            {
                txtMsg.SelectedText = "%20*" + txtMsg.SelectedText + "*%20";
            }
            else
            {
                MessageBox.Show("SELECT THE TEXT?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMsg.Focus();
            }
            txtMsg.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtfestival_Leave_1(object sender, EventArgs e)
        {
            GenerateFestivalMessage(txtMsg, txtfestival, txtoffer);
        }
    }
}
