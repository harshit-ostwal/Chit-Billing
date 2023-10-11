using CrystalDecisions.CrystalReports.Engine;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    class Connection
    {
        // Main Database Path File Location Access Database
        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";

        // Settings Database Path File Location Access Database
        public static string Settings = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";

        //Initailize The Connection
        public static OleDbConnection con;
        public static OleDbCommand cmd = new OleDbCommand();
        public static DataSet ds = new DataSet();

        //Bill
        public void Bill(TextBox txtcustomerid, TextBox txtcustomername, TextBox txtarea, TextBox txtmobileno, TextBox txtsno, DateTimePicker txtdate, TextBox txtmonth, TextBox txttype, TextBox txtamount)
        {
            CRY_CHIT_BILLING cr = new CRY_CHIT_BILLING();
            FRM_CRY_CHIT_BILLING Print = new FRM_CRY_CHIT_BILLING();
            DataSet ds = new DataSet();

            TextObject CustomerId = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomercard"];
            CustomerId.Text = txtcustomerid.Text;
            TextObject CustomerName = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblcustomername"];
            CustomerName.Text = txtcustomername.Text;
            TextObject Area = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblarea"];
            Area.Text = txtarea.Text;
            TextObject MobileNo = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["lblmobileno"];
            MobileNo.Text = txtmobileno.Text;
            TextObject Sno = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["lblsno"];
            Sno.Text = txtsno.Text;
            TextObject Date = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["lbldate"];
            Date.Text = txtdate.Text;
            TextObject Month = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["lblmonth"];
            Month.Text = txtmonth.Text;
            TextObject Type = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["lbltype"];
            Type.Text = txttype.Text;
            TextObject Amount = (TextObject)cr.ReportDefinition.Sections["Section3"].ReportObjects["lblamount"];
            Amount.Text = txtamount.Text;
            ds.WriteXmlSchema("ChitBilling.xml");
            cr.SetDataSource(ds);
            Print.View_Report.ReportSource = cr;
            cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
            cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "" + Application.StartupPath + "\\REPORTS\\" + "BILL" +".pdf");
        }

        //Save
        public void MainSaveData(string MSaveData, string ASaveData)
        {
            try
            {
                if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (OleDbConnection con = new OleDbConnection(Main))
                    {
                        con.Open();
                        using (OleDbCommand cmd = new OleDbCommand(ASaveData, con))
                        {
                            int Count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (Count > 0)
                            {
                                MessageBox.Show("ALREADY EXISTED???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                cmd.CommandText = MSaveData;
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("ADDED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                                string SP = Application.StartupPath + "\\BACKUP\\";
                                string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                                File.Copy(ThisDB, Destitnation);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO SAVE???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void Send(Label lblstatus,TextBox txtmobileno,TextBox txtmsg)
        //{
        //    string Url = "https://web.whatsapp.com/send?phone=" + txtmobileno.Text + "&text=" + "*" + txtmsg.Text + "*";
        //    if (lblstatus.Text == "WHATSAPP READY")
        //    {
        //        //if (lblattach.Text == "")
        //        //{
        //        try
        //        {
        //            WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(10));
        //            app.driver.Navigate().GoToUrl(Url);
        //            try
        //            {
        //                if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
        //                {
        //                    app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
        //                    MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    txtmobileno.Focus();
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                app.driver.FindElement(By.XPath("// span[@data-icon='send']")).Click();
        //                MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(20));
        //            app.driver.Navigate().GoToUrl(Url);
        //            try
        //            {
        //                if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
        //                {
        //                    app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
        //                    MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    txtmobileno.Focus();
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                app.driver.FindElement(By.XPath("// span[@data-icon='send']")).Click();
        //                MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        //}
        //        //else
        //        //{
        //        //    //try
        //        //    //{
        //        //    //    WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(10));
        //        //    //    app.driver.Navigate().GoToUrl(Url);
        //        //    //    try
        //        //    //    {
        //        //    //        if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
        //        //    //        {
        //        //    //            app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
        //        //    //            MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //    //            txtmobileno.Focus();
        //        //    //        }
        //        //    //    }
        //        //    //    catch (Exception)
        //        //    //    {
        //        //    //        app.driver.FindElement(By.XPath("// div[@title='Attach']")).Click();
        //        //    //        wait.Until(driver => app.driver.FindElement(By.XPath("//input[@accept='*']"))).SendKeys(openFileDialog1.FileName.ToString());
        //        //    //        wait.Until(driver => app.driver.FindElement(By.XPath("// span[@data-icon='send']"))).Click();
        //        //    //        MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //    //    }
        //        //    //    this.Focus();
        //        //    //}
        //        //    //catch (Exception)
        //        //    //{
        //        //    //    WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(30));
        //        //    //    app.driver.Navigate().GoToUrl(Url);
        //        //    //    try
        //        //    //    {
        //        //    //        if (wait.Until(driver => app.driver.PageSource.Contains("Phone number shared via url is invalid.")) == true)
        //        //    //        {
        //        //    //            app.driver.FindElement(By.XPath("// div[@class='tvf2evcx m0h2a7mj lb5m6g5c j7l1k36l ktfrpxia nu7pwgvd p357zi0d dnb887gk gjuq5ydh i2cterl7 i6vnu1w3 qjslfuze ac2vgrno sap93d0t gndfcl4n']")).Click();
        //        //    //            MessageBox.Show("WRONG MOBILE NO?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //    //            txtmobileno.Focus();
        //        //    //        }
        //        //    //    }
        //        //    //    catch (Exception)
        //        //    //    {
        //        //    //        app.driver.FindElement(By.XPath("// div[@title='Attach']")).Click();
        //        //    //        app.driver.FindElement(By.XPath("//input[@accept='*']")).SendKeys(openFileDialog1.FileName.ToString());
        //        //    //        wait.Until(driver => app.driver.FindElement(By.XPath("// span[@data-icon='send']"))).Click();
        //        //    //        MessageBox.Show("SMS SENT SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //    //    }
        //        //    //    this.Focus();
        //        //    //}
        //        //}
        //    }
        //    else
        //    {
        //        MessageBox.Show("WHATSAPP NOT AUTHORIZED?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        public void MainSave(string MSaveData,TextBox txtcustomerid, TextBox txtcustomername, TextBox txtarea, TextBox txtmobileno, TextBox txtsno, DateTimePicker txtdate, TextBox txtmonth, TextBox txttype, TextBox txtamount)
        {
            try
            {
                if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con = new OleDbConnection(Main);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = MSaveData;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Bill(txtcustomerid, txtcustomername, txtarea, txtmobileno, txtsno, txtdate, txtmonth, txttype, txtamount);
                    //Send(lblstatus,txtmobileno,txtmsg);
                    MessageBox.Show("ADDED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                    string SP = Application.StartupPath + "\\BACKUP\\";
                    string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                    File.Copy(ThisDB, Destitnation);
                }
        }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO SAVE???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        public void MainEdit(string MEditdata, TextBox txtcustomerid, TextBox txtcustomername, TextBox txtarea, TextBox txtmobileno, TextBox txtsno, DateTimePicker txtdate, TextBox txtmonth, TextBox txttype, TextBox txtamount)
        {
            try
            {
                if (MessageBox.Show("DO YOU WANT TO EDIT???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con = new OleDbConnection(Main);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = MEditdata;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Bill(txtcustomerid, txtcustomername, txtarea, txtmobileno, txtsno, txtdate, txtmonth, txttype, txtamount);
                    //Send(lblstatus, txtmobileno, txtmsg);
                    MessageBox.Show("UPDATED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                    string SP = Application.StartupPath + "\\BACKUP\\";
                    string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                    File.Copy(ThisDB, Destitnation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO SAVE???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MainEditData(string MEditdata, string AEditData)
        {
            try
            {
                if (MessageBox.Show("DO YOU WANT TO EDIT???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (OleDbConnection con = new OleDbConnection(Main))
                    {
                        con.Open();
                        using (OleDbCommand cmd = new OleDbCommand(AEditData, con))
                        {
                            int Count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (Count > 0)
                            {
                                MessageBox.Show("ALREADY EXISTED???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                cmd.CommandText = MEditdata;
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("UPDATED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                                string SP = Application.StartupPath + "\\BACKUP\\";
                                string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                                File.Copy(ThisDB, Destitnation);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO EDIT???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MainDeleteData(string MDeleteData)
        {
            try
            {
                if (MessageBox.Show("DO YOU WANT TO DELETE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con = new OleDbConnection(Main);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = MDeleteData;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("DELETED SUCCESSFULLY", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                    string SP = Application.StartupPath + "\\BACKUP\\";
                    string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                    File.Copy(ThisDB, Destitnation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO DELETE???,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Save,Update,Edit
        public void SettingData(string SData)
        {
            con = new OleDbConnection(Settings);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = SData;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
