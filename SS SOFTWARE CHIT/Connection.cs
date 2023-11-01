using CrystalDecisions.CrystalReports.Engine;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;
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
        public void Bill(TextBox txtcustomerid, TextBox txtcustomername, TextBox txtarea, TextBox txtmobileno, DataGridView dgw_view)
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
            DataTable dt = new DataTable();
            dt.Columns.Add("S.NO");
            dt.Columns.Add("DATE");
            dt.Columns.Add("MONTH");
            dt.Columns.Add("TYPE");
            dt.Columns.Add("AMOUNT");
            dgw_view.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
            foreach (DataGridViewRow dgw_detail in dgw_view.Rows)
            {
                dt.Rows.Add(dgw_detail.Cells[5].Value, dgw_detail.Cells[6].Value, dgw_detail.Cells[7].Value, dgw_detail.Cells[8].Value, dgw_detail.Cells[9].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("ChitBilling.xml");
            cr.SetDataSource(ds);
            Print.View_Report.ReportSource = cr;
            cr.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
            cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "" + Application.StartupPath + "\\REPORTS\\" + "BILL" + ".pdf");
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

        public async void MainSave(string MSaveData, TextBox txtcustomerid, TextBox txtcustomername, TextBox txtarea, TextBox txtmobileno, DataGridView dgw_view)
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
                    dgw_view.Refresh();
                    MessageBox.Show("ADDED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                    string SP = Application.StartupPath + "\\BACKUP\\";
                    string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                    File.Copy(ThisDB, Destitnation);
                    await Task.Run(() =>
                    {
                        Bill(txtcustomerid, txtcustomername, txtarea, txtmobileno, dgw_view);
                    });
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO SAVE???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void MainEdit(string MEditdata, TextBox txtcustomerid, TextBox txtcustomername, TextBox txtarea, TextBox txtmobileno, DataGridView dgw_view)
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
                    dgw_view.Refresh();
                    MessageBox.Show("UPDATED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await Task.Run(() =>
                    {
                        Bill(txtcustomerid, txtcustomername, txtarea, txtmobileno, dgw_view);
                    }); string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
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
                    con = new OleDbConnection(Main);
                    con.Open();
                    cmd.Connection = con;
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
