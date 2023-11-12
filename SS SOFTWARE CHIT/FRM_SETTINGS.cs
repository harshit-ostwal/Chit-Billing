using System;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_SETTINGS : Form
    {

        string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        WhatsApp app;

        public FRM_SETTINGS(WhatsApp whatsappInitialize)
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

        private async void FRM_SETTINGS_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                this.login_dbTableAdapter.Fill(this.settings_dbDataSet.Login_db);
                this.customer_dbTableAdapter.Fill(this.settings_dbDataSet.Customer_db);
                this.chit_Billing_dbTableAdapter.Fill(this.settings_dbDataSet.Chit_Billing_db);
                this.company_dbTableAdapter1.Fill(this.settings_dbDataSet.Company_db);
                this.company_dbTableAdapter.Fill(this.mainDataSet.Company_db);
            });
            this.KeyPreview = true;
        }

        private void piclose_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlmain.Visible == true)
                {
                    if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        FRM_HOME Home = new FRM_HOME(app);
                        this.Hide();
                        Home.Show();
                    }
                }
                else
                {
                    if (pnlcompanymaster.Visible == true)
                    {
                        if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con = new OleDbConnection(path);
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE Company_db set f_company_master_no='" + txtcompanyid.Text + "', f_company_save='" + chkcompanysave.Checked + "', f_company_edit='" + chkcompanyedit.Checked + "', f_company_delete='" + chkcompanydelete.Checked + "', f_company_id='" + chkcompanyid.Checked + "', f_company_master_id='" + chkcompanymasterid.Checked + "', f_company_master_name='" + chkcompanymastername.Checked + "', f_company_master_address='" + chkcompanymasteraddress.Checked + "', f_company_master_area='" + chkcompanymasterarea.Checked + "', f_company_master_district='" + chkcompanymasterdistrict.Checked + "', f_company_master_state='" + chkcompanymasterstate.Checked + "', f_company_master_pincode='" + chkcompanymasterpincode.Checked + "', f_company_master_mobile_no='" + chkcompanymastermobileno.Checked + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            string SP = Application.StartupPath + "\\BACKUP\\";
                            string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                            string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                            File.Copy(ThisDB, Destitnation);
                            pnlmain.Visible = true;
                            txtsearch.Visible = true;
                            pnlcompanymaster.Visible = false;
                        }
                        else
                        {
                            if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                FRM_HOME Home = new FRM_HOME(app);
                                this.Hide();
                                Home.Show();
                            }
                            else
                            {

                            }

                        }
                    }
                    else if (pnlcustomermaster.Visible == true)
                    {
                        if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con = new OleDbConnection(path);
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE Customer_db set f_customer_master_no='" + txtcustomerid.Text + "', f_customer_save='" + chkcustomersave.Checked + "', f_customer_edit='" + chkcustomeredit.Checked + "', f_customer_delete ='" + chkcustomerdelete.Checked + "', f_customer_id='" + chkcustomerid.Checked + "', f_customer_master_id='" + chkcustomermasterid.Checked + "', f_customer_master_name  ='" + chkcustomermastername.Checked + "', f_customer_master_address='" + chkcustomermasteraddress.Checked + "', f_customer_master_area='" + chkcustomermasterarea.Checked + "', f_customer_master_pincode ='" + chkcustomermasterpincode.Checked + "', f_customer_master_mobile_no ='" + chkcustomermastermobileno.Checked + "',f_customer_master_chit_type='" + chkcustomermasterchittype.Checked + "', f_customer_master_chit_amount='" + chkcustomermasterchitmaount.Checked + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            string SP = Application.StartupPath + "\\BACKUP\\";
                            string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                            string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                            File.Copy(ThisDB, Destitnation);
                            pnlmain.Visible = true;
                            txtsearch.Visible = true;
                            pnlcustomermaster.Visible = false;
                        }
                        else
                        {
                            if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                FRM_HOME Home = new FRM_HOME(app);
                                this.Hide();
                                Home.Show();
                            }
                            else
                            {
                            }
                        }
                    }
                    else if (pnlchit.Visible == true)
                    {
                        if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con = new OleDbConnection(path);
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE Chit_Billing_db set f_chit_id='" + chkchitid.Checked + "', f_chit_save='" + chkchitsave.Checked + "',f_chit_area='" + chkchitarea.Checked + "', f_chit_mobile_no='" + chkchitmobileno.Checked + "',f_chit_edit='" + chkchitedit.Checked + "',f_chit_delete='" + chkchitdelete.Checked + "',f_chit_customer_id='" + chkchitcustomerid.Checked + "',f_chit_customer_id_1='" + chkchitcustomerid1.Checked + "',f_chit_customer_name='" + chkchitcustomername.Checked + "',f_chit_customer_name_1='" + chkchitcustomername1.Checked + "',f_chit_area_1='" + chkchitarea1.Checked + "',f_chit_mobile_no_1='" + chkchitmobileno1.Checked + "',f_chit_sno='" + chkchitsno.Checked + "',f_chit_date='" + chkchitdate.Checked + "',f_chit_month='" + chkchitmonth.Checked + "',f_chit_type='" + chkchittype.Checked + "',f_chit_amount='" + chkchitamount.Checked + "',f_chit_balance ='" + chkchitbalance.Checked + "',f_chit_amount_1 ='" + chkchitamount1.Checked + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            string SP = Application.StartupPath + "\\BACKUP\\";
                            string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                            string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                            File.Copy(ThisDB, Destitnation);
                            pnlmain.Visible = true;
                            txtsearch.Visible = true;
                            pnlchit.Visible = false;
                        }
                        else
                        {
                            if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                FRM_HOME Home = new FRM_HOME(app);
                                this.Hide();
                                Home.Show();
                            }
                            else
                            {
                            }
                        }
                    }
                    else if (pnluser.Visible == true)
                    {
                        if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            con = new OleDbConnection(path);
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE Login_db set f_username='" + txtusername.Text + "', f_password='" + txtpassword.Text + "'";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            string SP = Application.StartupPath + "\\BACKUP\\";
                            string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                            string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                            File.Copy(ThisDB, Destitnation);
                            pnlmain.Visible = true;
                            txtsearch.Visible = true;
                            pnluser.Visible = false;
                            MessageBox.Show("UPDATED SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            FRM_LOGIN Login = new FRM_LOGIN(app);
                            Login.Show();
                        }
                        else
                        {
                            if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                FRM_HOME Home = new FRM_HOME(app);
                                this.Hide();
                                Home.Show();
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void picminimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtcustomerid_TextChanged(object sender, EventArgs e)
        {
            if (txtcustomerid.TextLength > 1)
            {
                MessageBox.Show("ONLY ONE LETTER!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcustomerid.Text = "";
            }
        }

        private void btncompanymaster_Click(object sender, EventArgs e)
        {
            if (pnlcompanymaster.Visible == false)
            {
                txtsearch.Visible = false;
                pnlmain.Visible = false;
                pnlcompanymaster.Visible = true;
            }
            else
            {
                txtsearch.Visible = true;
                pnlmain.Visible = true;
                pnlcompanymaster.Visible = false;
            }
        }

        private void btnbackcompany_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                con = new OleDbConnection(path);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Company_db set f_company_master_no='" + txtcompanyid.Text + "', f_company_save='" + chkcompanysave.Checked + "', f_company_edit='" + chkcompanyedit.Checked + "', f_company_delete='" + chkcompanydelete.Checked + "', f_company_id='" + chkcompanyid.Checked + "', f_company_master_id='" + chkcompanymasterid.Checked + "', f_company_master_name='" + chkcompanymastername.Checked + "', f_company_master_address='" + chkcompanymasteraddress.Checked + "', f_company_master_area='" + chkcompanymasterarea.Checked + "', f_company_master_district='" + chkcompanymasterdistrict.Checked + "', f_company_master_state='" + chkcompanymasterstate.Checked + "', f_company_master_pincode='" + chkcompanymasterpincode.Checked + "', f_company_master_mobile_no='" + chkcompanymastermobileno.Checked + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                string SP = Application.StartupPath + "\\BACKUP\\";
                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                File.Copy(ThisDB, Destitnation);
                pnlmain.Visible = true;
                txtsearch.Visible = true;
                pnlcompanymaster.Visible = false;
            }
            else
            {

            }
        }

        private void btncustomermaster_Click(object sender, EventArgs e)
        {
            if (pnlcustomermaster.Visible == false)
            {
                txtsearch.Visible = false;
                pnlmain.Visible = false;
                pnlcustomermaster.Visible = true;
            }
            else
            {
                txtsearch.Visible = true;
                pnlmain.Visible = true;
                pnlcustomermaster.Visible = false;
            }
        }

        private void btnbackcustomer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con = new OleDbConnection(path);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Customer_db set f_customer_master_no='" + txtcustomerid.Text + "', f_customer_save='" + chkcustomersave.Checked + "', f_customer_edit='" + chkcustomeredit.Checked + "', f_customer_delete ='" + chkcustomerdelete.Checked + "', f_customer_id='" + chkcustomerid.Checked + "', f_customer_master_id='" + chkcustomermasterid.Checked + "', f_customer_master_name  ='" + chkcustomermastername.Checked + "', f_customer_master_address='" + chkcustomermasteraddress.Checked + "', f_customer_master_area='" + chkcustomermasterarea.Checked + "', f_customer_master_pincode ='" + chkcustomermasterpincode.Checked + "', f_customer_master_mobile_no ='" + chkcustomermastermobileno.Checked + "',f_customer_master_chit_type='" + chkcustomermasterchittype.Checked + "', f_customer_master_chit_amount='" + chkcustomermasterchitmaount.Checked + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                string SP = Application.StartupPath + "\\BACKUP\\";
                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                File.Copy(ThisDB, Destitnation);
                pnlmain.Visible = true;
                txtsearch.Visible = true;
                pnlcustomermaster.Visible = false;
            }
            else
            {

            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var btn in pnlmain.Controls)
                {
                    var bunifubtn = (Bunifu.UI.WinForms.BunifuButton.BunifuButton)btn;
                    bunifubtn.Visible = bunifubtn.Text.ToLower().Contains(txtsearch.Text.ToLower().Trim());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("INVAILD,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void FRM_SETTINGS_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (pnlmain.Visible == true)
                    {
                        if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            FRM_HOME Home = new FRM_HOME(app);
                            this.Hide();
                            Home.Show();
                        }
                    }
                    else
                    {
                        if (pnlcompanymaster.Visible == true)
                        {
                            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                con = new OleDbConnection(path);
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandText = "UPDATE Company_db set f_company_master_no='" + txtcompanyid.Text + "', f_company_save='" + chkcompanysave.Checked + "', f_company_edit='" + chkcompanyedit.Checked + "', f_company_delete='" + chkcompanydelete.Checked + "', f_company_id='" + chkcompanyid.Checked + "', f_company_master_id='" + chkcompanymasterid.Checked + "', f_company_master_name='" + chkcompanymastername.Checked + "', f_company_master_address='" + chkcompanymasteraddress.Checked + "', f_company_master_area='" + chkcompanymasterarea.Checked + "', f_company_master_district='" + chkcompanymasterdistrict.Checked + "', f_company_master_state='" + chkcompanymasterstate.Checked + "', f_company_master_pincode='" + chkcompanymasterpincode.Checked + "', f_company_master_mobile_no='" + chkcompanymastermobileno.Checked + "'";
                                cmd.ExecuteNonQuery();
                                con.Close();
                                string SP = Application.StartupPath + "\\BACKUP\\";
                                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                                File.Copy(ThisDB, Destitnation);
                                pnlmain.Visible = true;
                                txtsearch.Visible = true;
                                pnlcompanymaster.Visible = false;
                            }
                            else
                            {
                                if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    FRM_HOME Home = new FRM_HOME(app);
                                    this.Hide();
                                    Home.Show();
                                }
                                else
                                {
                                }

                            }
                        }
                        else if (pnlcustomermaster.Visible == true)
                        {
                            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                con = new OleDbConnection(path);
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandText = "UPDATE Customer_db set f_customer_master_no='" + txtcustomerid.Text + "', f_customer_save='" + chkcustomersave.Checked + "', f_customer_edit='" + chkcustomeredit.Checked + "', f_customer_delete ='" + chkcustomerdelete.Checked + "', f_customer_id='" + chkcustomerid.Checked + "', f_customer_master_id='" + chkcustomermasterid.Checked + "', f_customer_master_name  ='" + chkcustomermastername.Checked + "', f_customer_master_address='" + chkcustomermasteraddress.Checked + "', f_customer_master_area='" + chkcustomermasterarea.Checked + "', f_customer_master_pincode ='" + chkcustomermasterpincode.Checked + "', f_customer_master_mobile_no ='" + chkcustomermastermobileno.Checked + "',f_customer_master_chit_type='" + chkcustomermasterchittype.Checked + "', f_customer_master_chit_amount='" + chkcustomermasterchitmaount.Checked + "'";
                                cmd.ExecuteNonQuery();
                                con.Close();
                                string SP = Application.StartupPath + "\\BACKUP\\";
                                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                                File.Copy(ThisDB, Destitnation);
                                pnlmain.Visible = true;
                                txtsearch.Visible = true;
                                pnlcustomermaster.Visible = false;
                            }
                            else
                            {
                                if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    FRM_HOME Home = new FRM_HOME(app);
                                    this.Hide();
                                    Home.Show();
                                }
                                else
                                {

                                }
                            }
                        }
                        else if (pnlchit.Visible == true)
                        {
                            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                con = new OleDbConnection(path);
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandText = "UPDATE Chit_Billing_db set f_chit_id='" + chkchitid.Checked + "', f_chit_save='" + chkchitsave.Checked + "',f_chit_area='" + chkchitarea.Checked + "', f_chit_mobile_no='" + chkchitmobileno.Checked + "',f_chit_edit='" + chkchitedit.Checked + "',f_chit_delete='" + chkchitdelete.Checked + "',f_chit_customer_id='" + chkchitcustomerid.Checked + "',f_chit_customer_id_1='" + chkchitcustomerid1.Checked + "',f_chit_customer_name='" + chkchitcustomername.Checked + "',f_chit_customer_name_1='" + chkchitcustomername1.Checked + "',f_chit_area_1='" + chkchitarea1.Checked + "',f_chit_mobile_no_1='" + chkchitmobileno1.Checked + "',f_chit_sno='" + chkchitsno.Checked + "',f_chit_date='" + chkchitdate.Checked + "',f_chit_month='" + chkchitmonth.Checked + "',f_chit_type='" + chkchittype.Checked + "',f_chit_amount='" + chkchitamount.Checked + "',f_chit_balance ='" + chkchitbalance.Checked + "',f_chit_amount_1 ='" + chkchitamount1.Checked + "'";
                                cmd.ExecuteNonQuery();
                                con.Close();
                                string SP = Application.StartupPath + "\\BACKUP\\";
                                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                                File.Copy(ThisDB, Destitnation);
                                pnlmain.Visible = true;
                                txtsearch.Visible = true;
                                pnlchit.Visible = false;
                            }
                            else
                            {
                                if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    FRM_HOME Home = new FRM_HOME(app);
                                    this.Hide();
                                    Home.Show();
                                }
                                else
                                {
                                }
                            }
                        }
                        else if (pnluser.Visible == true)
                        {
                            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                con = new OleDbConnection(path);
                                con.Open();
                                cmd.Connection = con;
                                cmd.CommandText = "UPDATE Login_db set f_username='" + txtusername.Text + "', f_password='" + txtpassword.Text + "'";
                                cmd.ExecuteNonQuery();
                                con.Close();
                                string SP = Application.StartupPath + "\\BACKUP\\";
                                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                                File.Copy(ThisDB, Destitnation);
                                pnlmain.Visible = true;
                                txtsearch.Visible = true;
                                pnluser.Visible = false;
                                MessageBox.Show("UPDATED SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                FRM_LOGIN Login = new FRM_LOGIN(app);
                                Login.Show();
                            }
                            else
                            {
                                if (MessageBox.Show("DO YOU WANT TO CLOSE?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    FRM_HOME Home = new FRM_HOME(app);
                                    this.Hide();
                                    Home.Show();
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnbackchit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con = new OleDbConnection(path);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Chit_Billing_db set f_chit_id='" + chkchitid.Checked + "', f_chit_save='" + chkchitsave.Checked + "',f_chit_area='" + chkchitarea.Checked + "', f_chit_mobile_no='" + chkchitmobileno.Checked + "',f_chit_edit='" + chkchitedit.Checked + "',f_chit_delete='" + chkchitdelete.Checked + "',f_chit_customer_id='" + chkchitcustomerid.Checked + "',f_chit_customer_id_1='" + chkchitcustomerid1.Checked + "',f_chit_customer_name='" + chkchitcustomername.Checked + "',f_chit_customer_name_1='" + chkchitcustomername1.Checked + "',f_chit_area_1='" + chkchitarea1.Checked + "',f_chit_mobile_no_1='" + chkchitmobileno1.Checked + "',f_chit_sno='" + chkchitsno.Checked + "',f_chit_date='" + chkchitdate.Checked + "',f_chit_month='" + chkchitmonth.Checked + "',f_chit_type='" + chkchittype.Checked + "',f_chit_amount='" + chkchitamount.Checked + "',f_chit_balance ='" + chkchitbalance.Checked + "',f_chit_amount_1 ='" + chkchitamount1.Checked + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                string SP = Application.StartupPath + "\\BACKUP\\";
                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                File.Copy(ThisDB, Destitnation);
                pnlmain.Visible = true;
                txtsearch.Visible = true;
                pnlchit.Visible = false;
            }
            else
            {
            }
        }

        private void btnchitbilling_Click(object sender, EventArgs e)
        {
            if (pnlchit.Visible == false)
            {
                txtsearch.Visible = false;
                pnlmain.Visible = false;
                pnlchit.Visible = true;
            }
            else
            {
                txtsearch.Visible = true;
                pnlmain.Visible = true;
                pnlchit.Visible = false;
            }
        }

        private void btnrecorddelete_Click(object sender, EventArgs e)
        {
            FRM_RECORD_DELETE1 Record_Delete = new FRM_RECORD_DELETE1(app);
            Record_Delete.Show();
            this.Hide();
        }

        private void btnbackupdata_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void Backup()
        {
            try
            {
                if (MessageBox.Show("DO YOU WANT BACKUP DATABASE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                    folderBrowserDialog1.ShowDialog();
                    string SP = folderBrowserDialog1.SelectedPath;
                    string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                    File.Copy(ThisDB, Destitnation);
                    string ThisDB1 = Application.StartupPath + "\\DATABASE\\Mpath_db.accdb";
                    string Destitnation1 = SP + "\\Mpath_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                    File.Copy(ThisDB1, Destitnation1);
                    MessageBox.Show("BACKUP SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnrestoredata_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("DO YOU WANT RESTORE DATABASE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string RestoreLocation = Application.StartupPath + "\\DATABASE\\Main_db_Restore" + ".accdb";
                    string RestoreLocation1 = Application.StartupPath + "\\DATABASE\\Mpath_db_Restore" + ".accdb";
                    OpenFileDialog OFD = new OpenFileDialog();
                    OpenFileDialog OFD1 = new OpenFileDialog();
                    OFD.Filter = "BAK File|*.bak";
                    if (OFD.ShowDialog() == DialogResult.OK)
                    {
                        string PickedFile = OFD.FileName;
                        File.Copy(PickedFile, RestoreLocation);
                        MessageBox.Show("RESTORED SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("RESTORED CANCELLED!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (OFD1.ShowDialog() == DialogResult.OK)
                    {
                        string PickedFile1 = OFD1.FileName;
                        File.Copy(PickedFile1, RestoreLocation1);
                        MessageBox.Show("RESTORED CANCELLED!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("RESTORED CANCELLED!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void picuserback_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO SAVE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con = new OleDbConnection(path);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Login_db set f_username='" + txtusername.Text + "', f_password='" + txtpassword.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                string SP = Application.StartupPath + "\\BACKUP\\";
                string ThisDB = Application.StartupPath + "\\DATABASE\\Settings_db.accdb";
                string Destitnation = SP + "\\Settings_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                File.Copy(ThisDB, Destitnation);
                pnlmain.Visible = true;
                txtsearch.Visible = true;
                pnluser.Visible = false;
                MessageBox.Show("UPDATED SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FRM_LOGIN Login = new FRM_LOGIN(app);
                Login.Show();
            }
            else
            {
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus();
            }
        }

        private void btnusermaster_Click(object sender, EventArgs e)
        {
            if (pnluser.Visible == false)
            {
                txtsearch.Visible = false;
                pnlmain.Visible = false;
                pnluser.Visible = true;
            }
            else
            {
                txtsearch.Visible = true;
                pnlmain.Visible = true;
                pnluser.Visible = false;
            }
        }

        private void btnwhatsapp_Click(object sender, EventArgs e)
        {
            FRM_WHATSAPP_SETTINGS WASetting = new FRM_WHATSAPP_SETTINGS(app);
            WASetting.Show();
            this.Hide();
        }

        private void btnreminder_Click(object sender, EventArgs e)
        {
            FRM_REMINDER Reminder = new FRM_REMINDER(app);
            Reminder.Show();
            this.Hide();
        }
    }
}
