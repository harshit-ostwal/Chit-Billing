using CrystalDecisions.CrystalReports.Engine;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_CHIT_BILLING : Form
    {
        Connection connection = new Connection();
        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";
        public static string Setting = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        int i = 0;
        WhatsApp app;

        public FRM_CHIT_BILLING(WhatsApp whatsappInitialize)
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
        private void lbl()
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

            }
        }

        private void FRM_CHIT_BILLING_Load(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    lbl();
                    this.Focus();
                }
            }
            catch (Exception)
            {

            }
            this.chit_Billing_dbTableAdapter.Fill(this.settings_dbDataSet.Chit_Billing_db);
            dgw_customer.Hide();
            CustomerData();
            Display1();
        }

        private void Calc()
        {
            lbltotalbal.Visible = true;
            lbltotalamount.Visible = true;
            lbltxtamt.Visible = true;
            lbltxtbal.Visible = true;
            double v_totalamt = 0, v_total_balance = 0;
            for (int i = 0; i < dgw_view.Rows.Count; i++)
            {
                if (dgw_view.Rows[i].Cells[9].Value != null)
                { v_totalamt += double.Parse(dgw_view.Rows[i].Cells[9].Value.ToString()); }
                if (dgw_view.Rows[i].Cells[10].Value != null)
                { v_total_balance += double.Parse(dgw_view.Rows[i].Cells[10].Value.ToString()); }

                lbltotalbal.Text = Math.Round(v_total_balance, 2).ToString();
                lbltotalamount.Text = Math.Round(v_totalamt, 2).ToString();
                lbltotalamount.Text = "₹" + lbltotalamount.Text;
                lbltotalbal.Text = "₹" + lbltotalbal.Text;
            }
        }

        private void Display1()
        {
            if (lblsave.Text == "False")
            {
                btnsave.Enabled = false;
            }
            else
            {
                btnsave.Enabled = true;
            }
            if (lbledit.Text == "False")
            {
                btnedit.Enabled = false;
            }
            else
            {
                btnedit.Enabled = true;
            }
            if (lbldelete.Text == "False")
            {
                btndelete.Enabled = false;
            }
            else
            {
                btndelete.Enabled = true;
            }
            if (lblcustomerid1.Text == "False")
            {
                dgw_customer.Columns[0].Visible = false;
            }
            else
            {
                dgw_customer.Columns[0].Visible = true;
            }
            if (lblcustomername1.Text == "False")
            {
                dgw_customer.Columns[1].Visible = false;
            }
            else
            {
                dgw_customer.Columns[1].Visible = true;
            }
            if (lblarea1.Text == "False")
            {
                dgw_customer.Columns[2].Visible = false;
            }
            else
            {
                dgw_customer.Columns[2].Visible = true;
            }
            if (lblmobileno1.Text == "False")
            {
                dgw_customer.Columns[3].Visible = false;
            }
            else
            {
                dgw_customer.Columns[3].Visible = true;
            }
            if (lblamount1.Text == "False")
            {
                dgw_customer.Columns[4].Visible = false;
            }
            else
            {
                dgw_customer.Columns[4].Visible = true;
            }
        }

        private void CustomerData()
        {
            string str2 = "Select f_customer_id,f_customer_name,f_area,f_mobile_no,f_chit_amount from Customer_db order by f_customer_id asc";
            DataSet ds1 = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter(str2, Main);
            ad.Fill(ds1);
            dgw_customer.DataSource = ds1.Tables[0];
            dgw_customer.Columns[0].HeaderText = "CARD NO";
            dgw_customer.Columns[1].HeaderText = "CUSTOMER NAME";
            dgw_customer.Columns[2].HeaderText = "AREA";
            dgw_customer.Columns[3].HeaderText = "MOBILE NO";
            dgw_customer.Columns[4].HeaderText = "CHIT AMOUNT";
        }

        private void display()
        {
            if (lblid.Text == "False")
            {
                dgw_view.Columns[0].Visible = false;
            }
            else
            {
                dgw_view.Columns[0].Visible = true;
            }
            if (lblcustomerid.Text == "False")
            {
                dgw_view.Columns[1].Visible = false;
            }
            else
            {
                dgw_view.Columns[1].Visible = true;
            }
            if (lblcustomername.Text == "False")
            {
                dgw_view.Columns[2].Visible = false;
            }
            else
            {
                dgw_view.Columns[2].Visible = true;
            }
            if (lblarea.Text == "False")
            {
                dgw_view.Columns[3].Visible = false;
            }
            else
            {
                dgw_view.Columns[3].Visible = true;
            }
            if (lblmobileno.Text == "False")
            {
                dgw_view.Columns[4].Visible = false;
            }
            else
            {
                dgw_view.Columns[4].Visible = true;
            }
            if (lblsno.Text == "False")
            {
                dgw_view.Columns[5].Visible = false;
            }
            else
            {
                dgw_view.Columns[5].Visible = true;
            }
            if (lbldate.Text == "False")
            {
                dgw_view.Columns[6].Visible = false;
            }
            else
            {
                dgw_view.Columns[6].Visible = true;
            }
            if (lblmonth.Text == "False")
            {
                dgw_view.Columns[7].Visible = false;
            }
            else
            {
                dgw_view.Columns[7].Visible = true;
            }
            if (lbltype.Text == "False")
            {
                dgw_view.Columns[8].Visible = false;
            }
            else
            {
                dgw_view.Columns[8].Visible = true;
            }
            if (lblamount.Text == "False")
            {
                dgw_view.Columns[9].Visible = false;
            }
            else
            {
                dgw_view.Columns[9].Visible = true;
            }
            if (lblbalance.Text == "False")
            {
                dgw_view.Columns[10].Visible = false;
            }
            else
            {
                dgw_view.Columns[10].Visible = true;
            }
        }

        private void ChitBillingData()
        {
            string str = "Select ID,f_customer_id,f_customer_name,f_area,f_mobile_no,f_sno,f_date,f_month,f_type,f_amount,f_balance from Chit_Billing_db order by f_sno asc";
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter(str, Main);
            ad.Fill(ds);
            dgw_view.DataSource = ds.Tables[0];
            dgw_view.Columns[0].HeaderText = "ID";
            dgw_view.Columns[1].HeaderText = "CARD NO";
            dgw_view.Columns[2].HeaderText = "CUSTOMER NAME";
            dgw_view.Columns[3].HeaderText = "AREA";
            dgw_view.Columns[4].HeaderText = "MOBILE NO";
            dgw_view.Columns[5].HeaderText = "S.NO";
            dgw_view.Columns[6].HeaderText = "DATE";
            dgw_view.Columns[7].HeaderText = "MONTH";
            dgw_view.Columns[8].HeaderText = "TYPE";
            dgw_view.Columns[9].HeaderText = "AMOUNT";
            dgw_view.Columns[10].HeaderText = "BALANCE";
        }

        private void Send()
        {
            string pdf = Path.Combine(Application.StartupPath, "REPORTS", "BILL" + ".pdf");
            openFileDialog1.FileName = pdf;
            string Url = "https://web.whatsapp.com/send?phone=" + txtmobileno.Text + "&text=" + "*" + txtcustomername.Text + "*";
            if (lblstatus.Text == "WHATSAPP READY")
            {
                //if (lblattach.Text == "")
                //{
                //try
                //{
                WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(10));
                app.driver.Navigate().GoToUrl(Url);
                try
                {
                    if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
                    {
                        app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
                        MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtmobileno.Focus();
                    }
                }
                catch (Exception)
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@title='Attach']")));
                    app.driver.FindElement(By.XPath("//div[@title='Attach']")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@accept='*']")));
                    app.driver.FindElement(By.XPath("//input[@accept='*']")).SendKeys(openFileDialog1.FileName.ToString());
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label='Send']")));
                    app.driver.FindElement(By.XPath("//div[@aria-label='Send']")).Click();
                    MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Focus();
                //}
                //catch (Exception)
                //{
                //    WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(20));
                //    app.driver.Navigate().GoToUrl(Url);
                //    try
                //    {
                //        if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
                //        {
                //            app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
                //            MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            txtmobileno.Focus();
                //        }
                //    }
                //    catch (Exception)
                //    {
                //        app.driver.FindElement(By.XPath("// span[@data-icon='send']")).Click();
                //        MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //    this.Focus();
                //}
                //}
                //else
                //{
                //    //try
                //    //{
                //    //    WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(10));
                //    //    app.driver.Navigate().GoToUrl(Url);
                //    //    try
                //    //    {
                //    //        if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
                //    //        {
                //    //            app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
                //    //            MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //            txtmobileno.Focus();
                //    //        }
                //    //    }
                //    //    catch (Exception)
                //    //    {
                //    //        app.driver.FindElement(By.XPath("// div[@title='Attach']")).Click();
                //    //        wait.Until(driver => app.driver.FindElement(By.XPath("//input[@accept='*']"))).SendKeys(openFileDialog1.FileName.ToString());
                //    //        wait.Until(driver => app.driver.FindElement(By.XPath("// span[@data-icon='send']"))).Click();
                //    //        MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //    }
                //    //    this.Focus();
                //    //}
                //    //catch (Exception)
                //    //{
                //    //    WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(30));
                //    //    app.driver.Navigate().GoToUrl(Url);
                //    //    try
                //    //    {
                //    //        if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
                //    //        {
                //    //            app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
                //    //            MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    //            txtmobileno.Focus();
                //    //        }
                //    //    }
                //    //    catch (Exception)
                //    //    {
                //    //        app.driver.FindElement(By.XPath("// div[@title='Attach']")).Click();
                //    //        app.driver.FindElement(By.XPath("//input[@accept='*']")).SendKeys(openFileDialog1.FileName.ToString());
                //    //        wait.Until(driver => app.driver.FindElement(By.XPath("// span[@data-icon='send']"))).Click();
                //    //        MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //    }
                //    //    this.Focus();
                //    //}
                //}
            }
            else
            {
                MessageBox.Show("WHATSAPP NOT AUTHORIZED?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "F2 Save")
            {
                if (txtcustomername.Text != "" && txtamount.Text != "" && txtarea.Text != "" && txtbalance.Text != "" && txtmobileno.Text != "" && txtmonth.Text != "" && txttype.Text != "")
                {
                    string MSaveData = "Insert into Chit_Billing_db (f_customer_id,f_customer_name,f_area,f_mobile_no,f_sno,f_date,f_month,f_type,f_amount,f_balance) Values ('" + txtcustomerid.Text + "', '" + txtcustomername.Text + "', '" + txtarea.Text + "', '" + txtmobileno.Text + "', '" + txtsno.Text + "', '" + txtdate.Text + "', '" + txtmonth.Text + "', '" + txttype.Text + "', '" + txtamount.Text + "', '" + txtbalance.Text + "')";
                    connection.MainSave(MSaveData, txtcustomerid, txtcustomername, txtarea, txtmobileno, txtsno, txtdate, txtmonth, txttype, txtamount);
                    Send();
                    Clear();
                }
                else
                {
                    MessageBox.Show("FILL ALL THE BOXES!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Clear();
                }
            }
            if (btnsave.Text == "F2 Update")
            {
                if (grpchit.Text == "Update")
                {
                    if (txtcustomername.Text != "" && txtamount.Text != "" && txtarea.Text != "" && txtbalance.Text != "" && txtmobileno.Text != "" && txtmonth.Text != "" && txttype.Text != "")
                    {
                        string MEditData = "Update Chit_Billing_db set f_customer_id='" + txtcustomerid.Text + "', f_customer_name='" + txtcustomername.Text + "',f_area='" + txtarea.Text + "',f_mobile_no='" + txtmobileno.Text + "',f_sno='" + txtsno.Text + "',f_date='" + txtdate.Text + "',f_month='" + txtmonth.Text + "',f_type='" + txttype.Text + "',f_amount='" + txtamount.Text + "',f_balance='" + txtbalance.Text + "'  where ID=" + dgw_view.SelectedRows[i].Cells[0].Value.ToString() + "";
                        connection.MainEdit(MEditData, txtcustomerid, txtcustomername, txtarea, txtmobileno, txtsno, txtdate, txtmonth, txttype, txtamount);
                        Send();
                        Clear();
                        btnsave.Text = "F2 Save";
                        grpchit.Text = "Create";
                    }
                    else
                    {
                        MessageBox.Show("FILL ALL THE BOXES!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Clear();
                        btnsave.Text = "F2 Save";
                    }
                }
            }
            if (grpchit.Text == "Create")
            {
                btnsave.Text = "F2 Save";
            }
            if (grpchit.Text == "Edit")
            {
                Clear();
                MessageBox.Show("PLEASE SELECT THE DATA???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (grpchit.Text == "View")
            {
                Clear();
                MessageBox.Show("YOU ARE IN THE VIEW MODE?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtcustomerid.Clear();
            txtcustomername.Clear();
            txtarea.Clear();
            txtmobileno.Clear();
            txtsno.Clear();
            txtdate.Refresh();
            txtmonth.Clear();
            txtamount.Clear();
            txtbalance.Clear();
            txtcustomerid.Focus();
            dgw_customer.Hide();
            dgw_view.Hide();
            grpchit.Text = "Create";
            lbltotalbal.Visible = false;
            lbltotalamount.Visible = false;
            lbltxtamt.Visible = false;
            lbltxtbal.Visible = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            grpchit.Text = "Edit";
            if (grpchit.Text == "Edit")
            {
                Clear();
                grpchit.Text = "Edit";
                CustomerData();
            }
            else
            {
                Clear();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgw_view.Rows.Count > 0)
            {
                if (grpchit.Text == "Update" || grpchit.Text == "View" || dgw_view.Visible == true)
                {
                    if (txtcustomerid.Text != "" && txtcustomername.Text != "" && lblamount.Text != "" && txtbalance.Text != "")
                    {
                        string MDeleteData = "DELETE FROM Chit_Billing_db  Where ID=" + dgw_view.SelectedRows[i].Cells[0].Value.ToString() + "";
                        connection.MainDeleteData(MDeleteData);
                        Clear();
                    }
                    else
                    {
                        Clear();
                        MessageBox.Show("PLEASE SELECT THE DATA???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Clear();
                    MessageBox.Show("PLEASE SELECT THE DATA???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Clear();
                MessageBox.Show("NO DATA???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            grpchit.Text = "View";
            if (grpchit.Text == "View")
            {
                Clear();
                grpchit.Text = "View";
                CustomerData();
            }
            else
            {
                Clear();
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtcustomerid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgw_customer.Visible = true;
                (dgw_customer.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_id LIKE '%{0}%'", txtcustomerid.Text);
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
            }
            catch (Exception)
            {
                MessageBox.Show("INVAILD,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgw_customer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    if (grpchit.Text == "Edit")
                    {
                        grpchit.Text = "Update";
                        btnsave.Text = "F2 Update";
                    }
                    ChitBillingData();
                    txtcustomerid.Text = dgw_customer.SelectedRows[i].Cells[0].Value.ToString();
                    txtcustomername.Text = dgw_customer.SelectedRows[i].Cells[1].Value.ToString();
                    txtarea.Text = dgw_customer.SelectedRows[i].Cells[2].Value.ToString();
                    txtmobileno.Text = dgw_customer.SelectedRows[i].Cells[3].Value.ToString();
                    txtamount.Text = dgw_customer.SelectedRows[i].Cells[4].Value.ToString();
                    txtsno.Focus();
                    dgw_view.Visible = true;
                    (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_id LIKE '{0}'", txtcustomerid.Text);
                    (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_name LIKE '{0}'", txtcustomername.Text);
                    dgw_customer.Visible = false;
                    display();
                    try
                    {
                        int lastRow = dgw_view.Rows.Count - 1;
                        txtsno.Text = dgw_view.Rows[lastRow].Cells[5].Value.ToString();
                        double a;
                        double b;
                        double.TryParse(txtsno.Text, out a);
                        b = a + 01;
                        txtsno.Text = (b).ToString();
                    }
                    catch
                    {
                        txtsno.Text = "01";
                    }
                    Calc();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgw_customer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (grpchit.Text == "Edit")
                {
                    grpchit.Text = "Update";
                    btnsave.Text = "F2 Update";
                }
                ChitBillingData();
                txtcustomerid.Text = dgw_customer.SelectedRows[i].Cells[0].Value.ToString();
                txtcustomername.Text = dgw_customer.SelectedRows[i].Cells[1].Value.ToString();
                txtarea.Text = dgw_customer.SelectedRows[i].Cells[2].Value.ToString();
                txtmobileno.Text = dgw_customer.SelectedRows[i].Cells[3].Value.ToString();
                txtamount.Text = dgw_customer.SelectedRows[i].Cells[4].Value.ToString();
                txtsno.Focus();
                dgw_view.Visible = true;
                (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_id LIKE '{0}'", txtcustomerid.Text);
                (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_name LIKE '{0}'", txtcustomername.Text);
                dgw_customer.Visible = false;
                display();
                try
                {
                    int lastRow = dgw_view.Rows.Count - 1;
                    txtsno.Text = dgw_view.Rows[lastRow].Cells[5].Value.ToString();
                    double a;
                    double b;
                    double.TryParse(txtsno.Text, out a);
                    b = a + 01;
                    txtsno.Text = (b).ToString();
                }
                catch
                {
                    txtsno.Text = "01";
                }
                Calc();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgw_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (grpchit.Text == "Update" || grpchit.Text == "Edit" || grpchit.Text == "View")
                {
                    txtcustomerid.Text = dgw_view.SelectedRows[i].Cells[1].Value.ToString();
                    txtcustomername.Text = dgw_view.SelectedRows[i].Cells[2].Value.ToString();
                    txtarea.Text = dgw_view.SelectedRows[i].Cells[3].Value.ToString();
                    txtmobileno.Text = dgw_view.SelectedRows[i].Cells[4].Value.ToString();
                    txtsno.Text = dgw_view.SelectedRows[i].Cells[5].Value.ToString();
                    txtdate.Value = Convert.ToDateTime(dgw_view.Rows[e.RowIndex].Cells[6].Value.ToString());
                    txtmonth.Text = dgw_view.SelectedRows[i].Cells[7].Value.ToString();
                    txttype.Text = dgw_view.SelectedRows[i].Cells[8].Value.ToString();
                    txtamount.Text = dgw_view.SelectedRows[i].Cells[9].Value.ToString();
                    txtbalance.Text = dgw_view.SelectedRows[i].Cells[10].Value.ToString();
                    txtcustomername.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO DISPLAY DATA???,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtamount.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtamount.Text = "";
                txtamount.Focus();
            }
        }

        private void txtbalance_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtbalance.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbalance.Text = "";
                txtbalance.Focus();
            }
        }

        private void Enter_Only(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Up)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txttype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Space)
            {
                if (txttype.Text == "CASH")
                {
                    txttype.Text = "ONLINE";
                }
                else
                {
                    if (e.KeyCode == System.Windows.Forms.Keys.Space)
                    {
                        if (txttype.Text == "ONLINE")
                        {
                            txttype.Text = "CASH";
                        }
                    }
                }
            }
            else
            {

            }
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dgw_view_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgw_view.Columns[1].DefaultCellStyle.Format = "{0:00}";
        }

        private void txtsno_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtsno.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsno.Text = "01";
                txtsno.Focus();
            }
            double a;
            double.TryParse(txtsno.Text, out a);
            txtsno.Text = string.Format("{0:00}", a);
        }

        private void txtamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (txtamount.Text == "")
                {
                    txtamount.Text = "0";
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                if (txtamount.Text == "")
                {
                    txtamount.Text = "0";
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void txtbalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                if (txtbalance.Text == "")
                {
                    txtbalance.Text = "0";
                    btnsave.Focus();
                }
                else
                {
                    btnsave.Focus();
                }
            }
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                if (txtbalance.Text == "")
                {
                    txtbalance.Text = "0";
                    btnsave.Focus();
                }
                else
                {
                    btnsave.Focus();
                }
            }
        }

        private void FRM_CHIT_BILLING_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == System.Windows.Forms.Keys.F1)
            {
                btnnew.PerformClick();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.F2)
            {
                btnsave.PerformClick();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.F3)
            {
                btnedit.PerformClick();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.F4)
            {
                btndelete.PerformClick();
            }
            if (e.KeyCode == System.Windows.Forms.Keys.F5)
            {
                btnview.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
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
