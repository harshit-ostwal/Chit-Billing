using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_CUSTOMER_MASTER : Form
    {
        int i = 0;
        Connection connection = new Connection();
        string Main = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Main_db.accdb;Jet OLEDB:Database Password = SS9975";
        string Setting = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        WhatsApp app;

        public FRM_CUSTOMER_MASTER(WhatsApp whatsappInitialize)
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

        private void FRM_CUSTOMER_MASTER_Load(object sender, EventArgs e)
        {
            this.customer_dbTableAdapter.Fill(this.settings_dbDataSet.Customer_db);
            dgw_view.Hide();
            AutoNumber();
        }

        private void AutoNumber()
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(Setting);
            string Data = "Select f_customer_master_no from Customer_db";
            OleDbDataReader dr;
            con.Open();
            cmd = new OleDbCommand(Data, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtcustomerid.Text = dr.GetValue(0).ToString();
            }
            con.Close();
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
            if (dgw_view.Visible == true)
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
                if (lbladdress.Text == "False")
                {
                    dgw_view.Columns[3].Visible = false;
                }
                else
                {
                    dgw_view.Columns[3].Visible = true;
                }
                if (lblarea.Text == "False")
                {
                    dgw_view.Columns[4].Visible = false;
                }
                else
                {
                    dgw_view.Columns[4].Visible = true;
                }
                if (lblpincode.Text == "False")
                {
                    dgw_view.Columns[5].Visible = false;
                }
                else
                {
                    dgw_view.Columns[5].Visible = true;
                }
                if (lblmobileno.Text == "False")
                {
                    dgw_view.Columns[6].Visible = false;
                }
                else
                {
                    dgw_view.Columns[6].Visible = true;
                }
                if (lblchittype.Text == "False")
                {
                    dgw_view.Columns[7].Visible = false;
                }
                else
                {
                    dgw_view.Columns[7].Visible = true;
                }
                if (lblchitamount.Text == "False")
                {
                    dgw_view.Columns[8].Visible = false;
                }
                else
                {
                    dgw_view.Columns[8].Visible = true;
                }
            }
            OleDbConnection con1 = new OleDbConnection(Main);
            string str = "select last(f_customer_id) from Customer_db";
            cmd = new OleDbCommand(str, con1);
            con1.Open();
            var maxid = cmd.ExecuteScalar() as string;
            if (maxid == null)
            {
                txtcustomerid.Text = txtcustomerid.Text + "1";
            }
            else
            {
                double i = double.Parse(maxid.Substring(1));
                i++;
                txtcustomerid.Text = string.Format("" + txtcustomerid.Text + "{0:0}", i++);
            }
            con1.Close();
        }

        private void Display()
        {
            string Data = "Select ID,f_customer_id,f_customer_name,f_address,f_area,f_pincode,f_mobile_no,f_chit_type,f_chit_amount From Customer_db order by ID desc";
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
            dgw_view.Show();
            AutoNumber();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            grpcustomer.Text = "Edit";
            if (grpcustomer.Text == "Edit")
            {
                Clear();
                grpcustomer.Text = "Edit";
                Display();
            }
            else
            {
                Clear();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtmobileno.TextLength >= 10 && txtmobileno.TextLength <= 10 || txtmobileno.Text == "0")
            {
                if (btnsave.Text == "F2 Save")
                {
                    if (txtcustomername.Text != "" && txtaddress.Text != "" && txtarea.Text != "" && txtpincode.Text != "" && txtmobileno.Text != "" && txtchittype.Text != "" && txtchitamount.Text != "")
                    {
                        string CSaveData = "Select * from Customer_db where f_customer_name ='" + txtcustomername.Text + "'";
                        string MSaveData = "Insert into Customer_db (f_customer_id,f_customer_name,f_address,f_area,f_pincode,f_mobile_no,f_chit_type,f_chit_amount) Values('" + txtcustomerid.Text + "', '" + txtcustomername.Text + "', '" + txtaddress.Text + "', '" + txtarea.Text + "', '" + txtpincode.Text + "', '" + txtmobileno.Text + "', '" + txtchittype.Text + "', '" + txtchitamount.Text + "')";
                        connection.MainSaveData(MSaveData, CSaveData);
                        AutoNumber();
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
                    if (grpcustomer.Text == "Update")
                    {
                        if (txtpincode.Text != "" && txtmobileno.Text != "" && txtchittype.Text != "" && txtchitamount.Text != "")
                        {
                            string CEditData = "Select * from Customer_db where f_customer_name ='" + txtcustomername.Text + "'";
                            string MEditData = "Update Customer_db set f_customer_id='" + txtcustomerid.Text + "', f_customer_name='" + txtcustomername.Text + "', f_address= '" + txtaddress.Text + "', f_area = '" + txtarea.Text + "',f_pincode='" + txtpincode.Text + "',f_mobile_no='" + txtmobileno.Text + "',f_chit_type='" + txtchittype.Text + "',f_chit_amount='" + txtchitamount.Text + "'  where ID=" + dgw_view.SelectedRows[i].Cells[0].Value.ToString() + "";
                            connection.MainEditData(MEditData, CEditData);
                            AutoNumber();
                            Clear();
                            btnsave.Text = "F2 Save";
                            grpcustomer.Text = "Create";
                        }
                        else
                        {
                            MessageBox.Show("FILL ALL THE BOXES!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Clear();
                            btnsave.Text = "F2 Save";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("MOBILE NO MUST BE 10 DIGITS?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clear();
            }
            if (grpcustomer.Text == "Create")
            {
                btnsave.Text = "F2 Save";
            }
            if (grpcustomer.Text == "Edit")
            {
                Clear();
                MessageBox.Show("PLEASE SELECT THE DATA???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (grpcustomer.Text == "View")
            {
                Clear();
                MessageBox.Show("YOU ARE IN THE VIEW MODE?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtcustomername.Clear();
            txtaddress.Clear();
            txtarea.Clear();
            txtpincode.Clear();
            txtmobileno.Clear();
            txtchitamount.Clear();
            txtcustomername.Focus();
            grpcustomer.Text = "Create";
            dgw_view.Hide();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtcustomername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grpcustomer.Text == "Edit" || grpcustomer.Text == "View" && dgw_view.Visible == true)
                {
                    (dgw_view.DataSource as DataTable).DefaultView.RowFilter = string.Format("f_customer_name LIKE '%{0}%'", txtcustomername.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("INVAILD,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            grpcustomer.Text = "View";
            if (grpcustomer.Text == "View")
            {
                Clear();
                grpcustomer.Text = "View";
                Display();
            }
            else
            {
                Clear();
            }
        }

        private void txtcustomername_KeyDown(object sender, KeyEventArgs e)
        {
            if (grpcustomer.Text == "Edit")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtcustomername.Text == "")
                    {
                        if (dgw_view.Visible == true)
                        {
                            SendKeys.Send("{TAB}");
                            dgw_view.Hide();
                        }
                        else
                        {
                            dgw_view.Focus();
                        }
                    }
                    else
                    {
                        dgw_view.Focus();
                    }
                }
            }
            else if (grpcustomer.Text == "View")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtcustomername.Text == "")
                    {
                        if (dgw_view.Visible == true)
                        {
                            SendKeys.Send("{TAB}");
                            dgw_view.Hide();
                        }
                        else
                        {
                            dgw_view.Focus();
                        }
                    }
                    else if (dgw_view.Visible == false)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            SendKeys.Send("{TAB}");
                        }
                        if (e.KeyCode == Keys.Down)
                        {
                            SendKeys.Send("{TAB}");
                        }
                    }
                    else
                    {
                        dgw_view.Focus();
                    }
                }
            }
            else if (grpcustomer.Text == "Update")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
                if (e.KeyCode == Keys.Down)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
                if (e.KeyCode == Keys.Down)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void dgw_view_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (grpcustomer.Text == "Edit")
                {
                    txtcustomerid.Text = dgw_view.SelectedRows[0].Cells[1].Value.ToString();
                    txtcustomername.Text = dgw_view.SelectedRows[0].Cells[2].Value.ToString();
                    txtaddress.Text = dgw_view.SelectedRows[0].Cells[3].Value.ToString();
                    txtarea.Text = dgw_view.SelectedRows[0].Cells[4].Value.ToString();
                    txtpincode.Text = dgw_view.SelectedRows[0].Cells[5].Value.ToString();
                    txtmobileno.Text = dgw_view.SelectedRows[0].Cells[6].Value.ToString();
                    txtchittype.Text = dgw_view.SelectedRows[0].Cells[7].Value.ToString();
                    txtchitamount.Text = dgw_view.SelectedRows[0].Cells[8].Value.ToString();
                    dgw_view.Hide();
                    txtcustomername.Focus();
                    grpcustomer.Text = "Update";
                    btnsave.Text = "F2 Update";
                }
                else if (grpcustomer.Text == "View")
                {
                    txtcustomerid.Text = dgw_view.SelectedRows[0].Cells[1].Value.ToString();
                    txtcustomername.Text = dgw_view.SelectedRows[0].Cells[2].Value.ToString();
                    txtaddress.Text = dgw_view.SelectedRows[0].Cells[3].Value.ToString();
                    txtarea.Text = dgw_view.SelectedRows[0].Cells[4].Value.ToString();
                    txtpincode.Text = dgw_view.SelectedRows[0].Cells[5].Value.ToString();
                    txtmobileno.Text = dgw_view.SelectedRows[0].Cells[6].Value.ToString();
                    txtchittype.Text = dgw_view.SelectedRows[0].Cells[7].Value.ToString();
                    txtchitamount.Text = dgw_view.SelectedRows[0].Cells[8].Value.ToString();
                    dgw_view.Hide();
                    txtcustomername.Focus();
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO DISPLAY DATA???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgw_view_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (grpcustomer.Text == "Edit")
                    {
                        txtcustomerid.Text = dgw_view.SelectedRows[0].Cells[1].Value.ToString();
                        txtcustomername.Text = dgw_view.SelectedRows[0].Cells[2].Value.ToString();
                        txtaddress.Text = dgw_view.SelectedRows[0].Cells[3].Value.ToString();
                        txtarea.Text = dgw_view.SelectedRows[0].Cells[4].Value.ToString();
                        txtpincode.Text = dgw_view.SelectedRows[0].Cells[5].Value.ToString();
                        txtmobileno.Text = dgw_view.SelectedRows[0].Cells[6].Value.ToString();
                        txtchittype.Text = dgw_view.SelectedRows[0].Cells[7].Value.ToString();
                        txtchitamount.Text = dgw_view.SelectedRows[0].Cells[8].Value.ToString();
                        dgw_view.Hide();
                        txtcustomername.Focus();
                        grpcustomer.Text = "Update";
                        btnsave.Text = "F2 Update";
                    }
                    else if (grpcustomer.Text == "View")
                    {
                        txtcustomerid.Text = dgw_view.SelectedRows[0].Cells[1].Value.ToString();
                        txtcustomername.Text = dgw_view.SelectedRows[0].Cells[2].Value.ToString();
                        txtaddress.Text = dgw_view.SelectedRows[0].Cells[3].Value.ToString();
                        txtarea.Text = dgw_view.SelectedRows[0].Cells[4].Value.ToString();
                        txtpincode.Text = dgw_view.SelectedRows[0].Cells[5].Value.ToString();
                        txtmobileno.Text = dgw_view.SelectedRows[0].Cells[6].Value.ToString();
                        txtchittype.Text = dgw_view.SelectedRows[0].Cells[7].Value.ToString();
                        txtchitamount.Text = dgw_view.SelectedRows[0].Cells[8].Value.ToString();
                        dgw_view.Hide();
                        txtcustomername.Focus();
                    }
                    else
                    {
                        Clear();
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UNABLE TO DISPLAY DATA???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgw_view.Rows.Count > 0)
            {
                if (grpcustomer.Text == "Update" || grpcustomer.Text == "View" || dgw_view.Visible == true)
                {
                    if (txtpincode.Text != "" && txtmobileno.Text != "" && txtchittype.Text != "" && txtchitamount.Text != "")
                    {
                        string MDeleteData = "Delete From Customer_db where ID=" + dgw_view.SelectedRows[i].Cells[0].Value.ToString() + "";
                        connection.MainDeleteData(MDeleteData);
                        AutoNumber();
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

        private void FRM_CUSTOMER_MASTER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dgw_view.Visible == false)
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
                    if (dgw_view.Visible == false)
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
            if (e.KeyCode == Keys.F1)
            {
                btnnew.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                btnsave.PerformClick();
            }
            if (e.KeyCode == Keys.F3)
            {
                btnedit.PerformClick();
            }
            if (e.KeyCode == Keys.F4)
            {
                btndelete.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                btnview.PerformClick();
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

        private void txtpincode_TextChanged(object sender, EventArgs e)
        {
            while (System.Text.RegularExpressions.Regex.IsMatch(txtpincode.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpincode.Text = "";
                txtpincode.Focus();
            }
        }

        private void txtchitamount_TextChanged(object sender, EventArgs e)
        {
            while (System.Text.RegularExpressions.Regex.IsMatch(txtchitamount.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtchitamount.Text = "";
                txtchitamount.Focus();
            }
        }

        private void Enter_Only(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtmobileno_TextChanged(object sender, EventArgs e)
        {
            while (System.Text.RegularExpressions.Regex.IsMatch(txtmobileno.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmobileno.Text = "";
                txtmobileno.Focus();
            }
        }

        private void txtchittype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (txtchittype.Text == "DAILY")
                {
                    txtchittype.Text = "MONTHLY";
                }
                else
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        if (txtchittype.Text == "DAILY")
                        {
                            txtchittype.Text = "MONTHLY";
                        }
                        else
                        {
                            if (e.KeyCode == Keys.Space)
                            {
                                if (txtchittype.Text == "MONTHLY")
                                {
                                    txtchittype.Text = "YEARLY";
                                }
                                else
                                {
                                    if (e.KeyCode == Keys.Space)
                                    {
                                        if (txtchittype.Text == "YEARLY")
                                        {
                                            txtchittype.Text = "DAILY";
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {

            }
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
