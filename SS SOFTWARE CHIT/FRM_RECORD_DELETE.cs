using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_RECORD_DELETE : Form
    {
        int i = 0;
        Connection connection = new Connection();
        public static string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";
        public static string Setting = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        WhatsApp app;
        OleDbCommand cmd = new OleDbCommand();
        OleDbConnection con;


        public FRM_RECORD_DELETE(WhatsApp whatsappInitialize)
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
        private void Display()
        {
            string Data = "Select ID,f_customer_id,f_customer_name,f_address,f_area,f_pincode,f_mobile_no,f_chit_type,f_chit_amount From Customer_db order by ID desc";
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter(Data, Main);
            ad.Fill(ds);
            dgw_customer.DataSource = ds.Tables[0];
            dgw_customer.Columns[0].HeaderText = "ID";
            dgw_customer.Columns[1].HeaderText = "CUSTOMER ID";
            dgw_customer.Columns[2].HeaderText = "CUSTOMER NAME";
            dgw_customer.Columns[3].HeaderText = "ADDRESS";
            dgw_customer.Columns[4].HeaderText = "AREA NAME";
            dgw_customer.Columns[5].HeaderText = "PINCODE";
            dgw_customer.Columns[6].HeaderText = "MOBILE NO";
            dgw_customer.Columns[7].HeaderText = "CHIT TYPE";
            dgw_customer.Columns[8].HeaderText = "CHIT AMOUNT";
        }

        private void Data()
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

        private void FRM_RECORD_DELETE_Load(object sender, EventArgs e)
        {
            Display();
            Data();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtcustomerid.Clear();
            txtcustomername.Clear();
            txtarea.Clear();
            txtmobileno.Clear();
            txtcustomerid.Focus();
            dgw_view.Visible = false;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgw_view.Visible = true;
                dgw_customer.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("INVAILD,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (e.KeyCode == Keys.Enter)
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
                if (e.KeyCode == Keys.Down)
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
                if (e.KeyCode == Keys.Enter)
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
                if (e.KeyCode == Keys.Down)
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtcustomerid.Text = dgw_customer.SelectedRows[i].Cells[1].Value.ToString();
                    txtcustomername.Text = dgw_customer.SelectedRows[i].Cells[2].Value.ToString();
                    txtarea.Text = dgw_customer.SelectedRows[i].Cells[4].Value.ToString();
                    txtmobileno.Text = dgw_customer.SelectedRows[i].Cells[6].Value.ToString();
                    dgw_view.Visible = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void DeleteCustomer()
        {
            if (txtcustomerid.Text != "" && txtcustomername.Text != "" && txtarea.Text != "" && txtmobileno.Text != "")
            {
                string MDeleteData = "DELETE FROM Customer_db Where ID=" + dgw_customer.SelectedRows[i].Cells[0].Value.ToString() + "";
                con = new OleDbConnection(Main);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = MDeleteData;
                cmd.ExecuteNonQuery();
                con.Close();
                DeleteChitData();
                Data();
                Display();
                MessageBox.Show("RECORD DELETED SUCCESSFULLY!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteChitData()
        {
            if (txtcustomerid.Text != "" && txtcustomername.Text != "" && txtarea.Text != "" && txtmobileno.Text != "")
            {
                foreach (DataGridViewRow row in dgw_view.Rows)
                {
                    string MDeleteData = "DELETE FROM Chit_Billing_db  Where ID=" + row.Cells[0].Value.ToString() + "";
                    con = new OleDbConnection(Main);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = MDeleteData;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Clear();
                string ThisDB = Application.StartupPath + "\\DATABASE\\Main_db.accdb";
                string SP = Application.StartupPath + "\\BACKUP\\";
                string Destitnation = SP + "\\Main_db " + DateTime.Now.ToString(" dd-MM-yyyy hh-mm-ss") + ".bak";
                File.Copy(ThisDB, Destitnation);
                dgw_customer.Show();
            }
        }

        private void picminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void FRM_RECORD_DELETE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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
    }
}
