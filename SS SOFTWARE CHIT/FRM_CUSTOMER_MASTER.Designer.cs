
namespace SS_SOFTWARE_CHIT
{
    partial class FRM_CUSTOMER_MASTER
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CUSTOMER_MASTER));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picminimize = new System.Windows.Forms.PictureBox();
            this.piclose = new System.Windows.Forms.PictureBox();
            this.grpcustomer = new System.Windows.Forms.GroupBox();
            this.dgw_view = new System.Windows.Forms.DataGridView();
            this.txtarea = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtcustomername = new System.Windows.Forms.TextBox();
            this.txtcustomerid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtchitamount = new System.Windows.Forms.TextBox();
            this.txtchittype = new System.Windows.Forms.TextBox();
            this.txtmobileno = new System.Windows.Forms.TextBox();
            this.txtpincode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.customerdbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.settings_dbDataSet = new SS_SOFTWARE_CHIT.Settings_dbDataSet();
            this.customer_dbTableAdapter = new SS_SOFTWARE_CHIT.Settings_dbDataSetTableAdapters.Customer_dbTableAdapter();
            this.lblid = new System.Windows.Forms.Label();
            this.lblmobileno = new System.Windows.Forms.Label();
            this.lblpincode = new System.Windows.Forms.Label();
            this.lblarea = new System.Windows.Forms.Label();
            this.lblchitamount = new System.Windows.Forms.Label();
            this.lblchittype = new System.Windows.Forms.Label();
            this.lbldelete = new System.Windows.Forms.Label();
            this.lbledit = new System.Windows.Forms.Label();
            this.lblsave = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            this.lblcustomername = new System.Windows.Forms.Label();
            this.lblcustomerid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclose)).BeginInit();
            this.grpcustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_view)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerdbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picminimize);
            this.panel1.Controls.Add(this.piclose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 40);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Std Book", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(546, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 25);
            this.label1.TabIndex = 67;
            this.label1.Text = "CUSTOMER MASTER";
            // 
            // picminimize
            // 
            this.picminimize.Image = ((System.Drawing.Image)(resources.GetObject("picminimize.Image")));
            this.picminimize.Location = new System.Drawing.Point(48, 5);
            this.picminimize.MaximumSize = new System.Drawing.Size(30, 30);
            this.picminimize.MinimumSize = new System.Drawing.Size(30, 30);
            this.picminimize.Name = "picminimize";
            this.picminimize.Size = new System.Drawing.Size(30, 30);
            this.picminimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picminimize.TabIndex = 59;
            this.picminimize.TabStop = false;
            this.picminimize.Click += new System.EventHandler(this.picminimize_Click);
            // 
            // piclose
            // 
            this.piclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.piclose.Image = ((System.Drawing.Image)(resources.GetObject("piclose.Image")));
            this.piclose.Location = new System.Drawing.Point(12, 5);
            this.piclose.MaximumSize = new System.Drawing.Size(30, 30);
            this.piclose.MinimumSize = new System.Drawing.Size(30, 30);
            this.piclose.Name = "piclose";
            this.piclose.Size = new System.Drawing.Size(30, 30);
            this.piclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piclose.TabIndex = 58;
            this.piclose.TabStop = false;
            this.piclose.Click += new System.EventHandler(this.piclose_Click);
            // 
            // grpcustomer
            // 
            this.grpcustomer.Controls.Add(this.dgw_view);
            this.grpcustomer.Controls.Add(this.txtarea);
            this.grpcustomer.Controls.Add(this.txtaddress);
            this.grpcustomer.Controls.Add(this.txtcustomername);
            this.grpcustomer.Controls.Add(this.txtcustomerid);
            this.grpcustomer.Controls.Add(this.label3);
            this.grpcustomer.Controls.Add(this.label4);
            this.grpcustomer.Controls.Add(this.label8);
            this.grpcustomer.Controls.Add(this.label9);
            this.grpcustomer.Controls.Add(this.txtchitamount);
            this.grpcustomer.Controls.Add(this.txtchittype);
            this.grpcustomer.Controls.Add(this.txtmobileno);
            this.grpcustomer.Controls.Add(this.txtpincode);
            this.grpcustomer.Controls.Add(this.label2);
            this.grpcustomer.Controls.Add(this.label7);
            this.grpcustomer.Controls.Add(this.label6);
            this.grpcustomer.Controls.Add(this.label5);
            this.grpcustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.grpcustomer.Location = new System.Drawing.Point(140, 89);
            this.grpcustomer.Name = "grpcustomer";
            this.grpcustomer.Size = new System.Drawing.Size(1000, 500);
            this.grpcustomer.TabIndex = 5;
            this.grpcustomer.TabStop = false;
            this.grpcustomer.Text = "Create";
            // 
            // dgw_view
            // 
            this.dgw_view.AllowUserToAddRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgw_view.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgw_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgw_view.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.dgw_view.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgw_view.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgw_view.ColumnHeadersHeight = 30;
            this.dgw_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw_view.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgw_view.EnableHeadersVisualStyles = false;
            this.dgw_view.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.dgw_view.Location = new System.Drawing.Point(6, 253);
            this.dgw_view.Name = "dgw_view";
            this.dgw_view.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw_view.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgw_view.RowHeadersVisible = false;
            this.dgw_view.RowHeadersWidth = 40;
            this.dgw_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgw_view.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgw_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_view.Size = new System.Drawing.Size(988, 241);
            this.dgw_view.TabIndex = 14;
            this.dgw_view.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgw_view_CellMouseDoubleClick);
            this.dgw_view.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_view_KeyDown);
            // 
            // txtarea
            // 
            this.txtarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtarea.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtarea.Location = new System.Drawing.Point(192, 286);
            this.txtarea.Name = "txtarea";
            this.txtarea.Size = new System.Drawing.Size(312, 27);
            this.txtarea.TabIndex = 4;
            this.txtarea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // txtaddress
            // 
            this.txtaddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtaddress.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.Location = new System.Drawing.Point(192, 253);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(312, 27);
            this.txtaddress.TabIndex = 3;
            this.txtaddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // txtcustomername
            // 
            this.txtcustomername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcustomername.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomername.Location = new System.Drawing.Point(192, 220);
            this.txtcustomername.Name = "txtcustomername";
            this.txtcustomername.Size = new System.Drawing.Size(312, 27);
            this.txtcustomername.TabIndex = 2;
            this.txtcustomername.TextChanged += new System.EventHandler(this.txtcustomername_TextChanged);
            this.txtcustomername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcustomername_KeyDown);
            // 
            // txtcustomerid
            // 
            this.txtcustomerid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcustomerid.Enabled = false;
            this.txtcustomerid.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomerid.Location = new System.Drawing.Point(192, 187);
            this.txtcustomerid.Name = "txtcustomerid";
            this.txtcustomerid.ReadOnly = true;
            this.txtcustomerid.Size = new System.Drawing.Size(312, 27);
            this.txtcustomerid.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(29, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 21);
            this.label3.TabIndex = 841;
            this.label3.Text = "CUSTOMER NAME :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(126, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 840;
            this.label4.Text = "AREA :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(97, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 21);
            this.label8.TabIndex = 839;
            this.label8.Text = "ADDRESS :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(61, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 21);
            this.label9.TabIndex = 838;
            this.label9.Text = "CUSTOMER ID :";
            // 
            // txtchitamount
            // 
            this.txtchitamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtchitamount.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchitamount.Location = new System.Drawing.Point(660, 286);
            this.txtchitamount.Name = "txtchitamount";
            this.txtchitamount.Size = new System.Drawing.Size(312, 27);
            this.txtchitamount.TabIndex = 8;
            this.txtchitamount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // txtchittype
            // 
            this.txtchittype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtchittype.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchittype.Location = new System.Drawing.Point(660, 253);
            this.txtchittype.Name = "txtchittype";
            this.txtchittype.ReadOnly = true;
            this.txtchittype.Size = new System.Drawing.Size(312, 27);
            this.txtchittype.TabIndex = 7;
            this.txtchittype.Text = "MONTHLY";
            this.txtchittype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // txtmobileno
            // 
            this.txtmobileno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtmobileno.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmobileno.Location = new System.Drawing.Point(660, 220);
            this.txtmobileno.Name = "txtmobileno";
            this.txtmobileno.Size = new System.Drawing.Size(312, 27);
            this.txtmobileno.TabIndex = 6;
            this.txtmobileno.TextChanged += new System.EventHandler(this.txtmobileno_TextChanged);
            this.txtmobileno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // txtpincode
            // 
            this.txtpincode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpincode.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpincode.Location = new System.Drawing.Point(660, 187);
            this.txtpincode.Name = "txtpincode";
            this.txtpincode.Size = new System.Drawing.Size(312, 27);
            this.txtpincode.TabIndex = 5;
            this.txtpincode.TextChanged += new System.EventHandler(this.txtpincode_TextChanged);
            this.txtpincode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(545, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 833;
            this.label2.Text = "MOBLIE NO :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(523, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 21);
            this.label7.TabIndex = 832;
            this.label7.Text = "CHIT AMOUNT :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(560, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 831;
            this.label6.Text = "CHIT TYPE :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(563, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 830;
            this.label5.Text = "PINCODE :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnnew);
            this.flowLayoutPanel1.Controls.Add(this.btnsave);
            this.flowLayoutPanel1.Controls.Add(this.btnedit);
            this.flowLayoutPanel1.Controls.Add(this.btndelete);
            this.flowLayoutPanel1.Controls.Add(this.btnview);
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(383, 606);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(515, 61);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnnew.FlatAppearance.BorderSize = 0;
            this.btnnew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnnew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnnew.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnnew.ForeColor = System.Drawing.Color.White;
            this.btnnew.Location = new System.Drawing.Point(8, 8);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(95, 45);
            this.btnnew.TabIndex = 10;
            this.btnnew.Text = "F1 &New";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnsave.FlatAppearance.BorderSize = 0;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(109, 8);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(95, 45);
            this.btnsave.TabIndex = 9;
            this.btnsave.Text = "F2 &Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnedit.FlatAppearance.BorderSize = 0;
            this.btnedit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnedit.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Location = new System.Drawing.Point(210, 8);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(95, 45);
            this.btnedit.TabIndex = 11;
            this.btnedit.Text = "F3 &Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btndelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Location = new System.Drawing.Point(311, 8);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(95, 45);
            this.btndelete.TabIndex = 12;
            this.btndelete.Text = "F4 &Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnview.FlatAppearance.BorderSize = 0;
            this.btnview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnview.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnview.ForeColor = System.Drawing.Color.White;
            this.btnview.Location = new System.Drawing.Point(412, 8);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(95, 45);
            this.btnview.TabIndex = 13;
            this.btnview.Text = "F5 &View";
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // customerdbBindingSource
            // 
            this.customerdbBindingSource.DataMember = "Customer_db";
            this.customerdbBindingSource.DataSource = this.settings_dbDataSet;
            // 
            // settings_dbDataSet
            // 
            this.settings_dbDataSet.DataSetName = "Settings_dbDataSet";
            this.settings_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customer_dbTableAdapter
            // 
            this.customer_dbTableAdapter.ClearBeforeFill = true;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_id", true));
            this.lblid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblid.Location = new System.Drawing.Point(12, 526);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(41, 13);
            this.lblid.TabIndex = 704;
            this.lblid.Text = "label11";
            // 
            // lblmobileno
            // 
            this.lblmobileno.AutoSize = true;
            this.lblmobileno.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_mobile_no", true));
            this.lblmobileno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblmobileno.Location = new System.Drawing.Point(12, 640);
            this.lblmobileno.Name = "lblmobileno";
            this.lblmobileno.Size = new System.Drawing.Size(41, 13);
            this.lblmobileno.TabIndex = 703;
            this.lblmobileno.Text = "label13";
            // 
            // lblpincode
            // 
            this.lblpincode.AutoSize = true;
            this.lblpincode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_pincode", true));
            this.lblpincode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblpincode.Location = new System.Drawing.Point(12, 627);
            this.lblpincode.Name = "lblpincode";
            this.lblpincode.Size = new System.Drawing.Size(41, 13);
            this.lblpincode.TabIndex = 702;
            this.lblpincode.Text = "label12";
            // 
            // lblarea
            // 
            this.lblarea.AutoSize = true;
            this.lblarea.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_area", true));
            this.lblarea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblarea.Location = new System.Drawing.Point(12, 614);
            this.lblarea.Name = "lblarea";
            this.lblarea.Size = new System.Drawing.Size(41, 13);
            this.lblarea.TabIndex = 701;
            this.lblarea.Text = "label11";
            // 
            // lblchitamount
            // 
            this.lblchitamount.AutoSize = true;
            this.lblchitamount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_chit_amount", true));
            this.lblchitamount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblchitamount.Location = new System.Drawing.Point(12, 665);
            this.lblchitamount.Name = "lblchitamount";
            this.lblchitamount.Size = new System.Drawing.Size(41, 13);
            this.lblchitamount.TabIndex = 700;
            this.lblchitamount.Text = "label12";
            // 
            // lblchittype
            // 
            this.lblchittype.AutoSize = true;
            this.lblchittype.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_chit_type", true));
            this.lblchittype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblchittype.Location = new System.Drawing.Point(12, 652);
            this.lblchittype.Name = "lblchittype";
            this.lblchittype.Size = new System.Drawing.Size(41, 13);
            this.lblchittype.TabIndex = 699;
            this.lblchittype.Text = "label11";
            // 
            // lbldelete
            // 
            this.lbldelete.AutoSize = true;
            this.lbldelete.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_delete", true));
            this.lbldelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lbldelete.Location = new System.Drawing.Point(12, 565);
            this.lbldelete.Name = "lbldelete";
            this.lbldelete.Size = new System.Drawing.Size(41, 13);
            this.lbldelete.TabIndex = 698;
            this.lbldelete.Text = "label13";
            // 
            // lbledit
            // 
            this.lbledit.AutoSize = true;
            this.lbledit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_edit", true));
            this.lbledit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lbledit.Location = new System.Drawing.Point(12, 552);
            this.lbledit.Name = "lbledit";
            this.lbledit.Size = new System.Drawing.Size(41, 13);
            this.lbledit.TabIndex = 697;
            this.lbledit.Text = "label12";
            // 
            // lblsave
            // 
            this.lblsave.AutoSize = true;
            this.lblsave.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_save", true));
            this.lblsave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblsave.Location = new System.Drawing.Point(12, 539);
            this.lblsave.Name = "lblsave";
            this.lblsave.Size = new System.Drawing.Size(41, 13);
            this.lblsave.TabIndex = 696;
            this.lblsave.Text = "label11";
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_address", true));
            this.lbladdress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lbladdress.Location = new System.Drawing.Point(12, 603);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(41, 13);
            this.lbladdress.TabIndex = 695;
            this.lbladdress.Text = "label13";
            // 
            // lblcustomername
            // 
            this.lblcustomername.AutoSize = true;
            this.lblcustomername.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_name", true));
            this.lblcustomername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblcustomername.Location = new System.Drawing.Point(12, 590);
            this.lblcustomername.Name = "lblcustomername";
            this.lblcustomername.Size = new System.Drawing.Size(41, 13);
            this.lblcustomername.TabIndex = 694;
            this.lblcustomername.Text = "label12";
            // 
            // lblcustomerid
            // 
            this.lblcustomerid.AutoSize = true;
            this.lblcustomerid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerdbBindingSource, "f_customer_master_id", true));
            this.lblcustomerid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblcustomerid.Location = new System.Drawing.Point(12, 577);
            this.lblcustomerid.Name = "lblcustomerid";
            this.lblcustomerid.Size = new System.Drawing.Size(41, 13);
            this.lblcustomerid.TabIndex = 693;
            this.lblcustomerid.Text = "label11";
            // 
            // FRM_CUSTOMER_MASTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.lblmobileno);
            this.Controls.Add(this.lblpincode);
            this.Controls.Add(this.lblarea);
            this.Controls.Add(this.lblchitamount);
            this.Controls.Add(this.lblchittype);
            this.Controls.Add(this.lbldelete);
            this.Controls.Add(this.lbledit);
            this.Controls.Add(this.lblsave);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.lblcustomername);
            this.Controls.Add(this.lblcustomerid);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.grpcustomer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FRM_CUSTOMER_MASTER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_CUSTOMER_MASTER";
            this.Load += new System.EventHandler(this.FRM_CUSTOMER_MASTER_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_CUSTOMER_MASTER_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclose)).EndInit();
            this.grpcustomer.ResumeLayout(false);
            this.grpcustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_view)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerdbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings_dbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picminimize;
        private System.Windows.Forms.PictureBox piclose;
        private System.Windows.Forms.GroupBox grpcustomer;
        private System.Windows.Forms.DataGridView dgw_view;
        private System.Windows.Forms.TextBox txtarea;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtcustomername;
        private System.Windows.Forms.TextBox txtcustomerid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtchitamount;
        private System.Windows.Forms.TextBox txtchittype;
        private System.Windows.Forms.TextBox txtmobileno;
        private System.Windows.Forms.TextBox txtpincode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.BindingSource customerdbBindingSource;
        private Settings_dbDataSet settings_dbDataSet;
        private Settings_dbDataSetTableAdapters.Customer_dbTableAdapter customer_dbTableAdapter;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Label lblmobileno;
        private System.Windows.Forms.Label lblpincode;
        private System.Windows.Forms.Label lblarea;
        private System.Windows.Forms.Label lblchitamount;
        private System.Windows.Forms.Label lblchittype;
        private System.Windows.Forms.Label lbldelete;
        private System.Windows.Forms.Label lbledit;
        private System.Windows.Forms.Label lblsave;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.Label lblcustomername;
        private System.Windows.Forms.Label lblcustomerid;
    }
}