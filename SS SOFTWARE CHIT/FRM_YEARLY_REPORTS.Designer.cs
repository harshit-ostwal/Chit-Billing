
namespace SS_SOFTWARE_CHIT
{
    partial class FRM_YEARLY_REPORTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_YEARLY_REPORTS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picminimize = new System.Windows.Forms.PictureBox();
            this.piclose = new System.Windows.Forms.PictureBox();
            this.company_dbTableAdapter = new SS_SOFTWARE_CHIT.MainDataSetTableAdapters.Company_dbTableAdapter();
            this.mainDataSet = new SS_SOFTWARE_CHIT.MainDataSet();
            this.lblusername = new System.Windows.Forms.Label();
            this.companydbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnclear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txttype = new System.Windows.Forms.ComboBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.dgw_view = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblbalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblamount = new System.Windows.Forms.Label();
            this.btnmail = new System.Windows.Forms.Button();
            this.pnlmail = new System.Windows.Forms.Panel();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnmailsender = new System.Windows.Forms.Button();
            this.pnlamount = new System.Windows.Forms.Panel();
            this.pnldate = new System.Windows.Forms.Panel();
            this.txttodate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnload = new System.Windows.Forms.Button();
            this.txtfromdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.pnllbldate = new System.Windows.Forms.Panel();
            this.pnldgw = new System.Windows.Forms.Panel();
            this.pnlbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnpdf = new System.Windows.Forms.Button();
            this.btnexcel = new System.Windows.Forms.Button();
            this.btnwhatsapp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companydbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_view)).BeginInit();
            this.pnlmail.SuspendLayout();
            this.pnlamount.SuspendLayout();
            this.pnldate.SuspendLayout();
            this.pnlfilter.SuspendLayout();
            this.pnllbldate.SuspendLayout();
            this.pnldgw.SuspendLayout();
            this.pnlbuttons.SuspendLayout();
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
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Std Book", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(563, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 71;
            this.label1.Text = "YEARLY REPORTS";
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
            // company_dbTableAdapter
            // 
            this.company_dbTableAdapter.ClearBeforeFill = true;
            // 
            // mainDataSet
            // 
            this.mainDataSet.DataSetName = "MainDataSet";
            this.mainDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.companydbBindingSource, "f_company_name", true));
            this.lblusername.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.lblusername.Location = new System.Drawing.Point(12, 692);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(0, 21);
            this.lblusername.TabIndex = 926;
            // 
            // companydbBindingSource
            // 
            this.companydbBindingSource.DataMember = "Company_db";
            this.companydbBindingSource.DataSource = this.mainDataSet;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnclear.FlatAppearance.BorderSize = 0;
            this.btnclear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnclear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnclear.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(718, 17);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(95, 45);
            this.btnclear.TabIndex = 13;
            this.btnclear.Text = "&Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(444, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 917;
            this.label3.Text = "TYPE :";
            // 
            // txttype
            // 
            this.txttype.AutoCompleteCustomSource.AddRange(new string[] {
            "CASH",
            "ONLINE"});
            this.txttype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txttype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txttype.Font = new System.Drawing.Font("Futura Bk", 11.25F);
            this.txttype.FormattingEnabled = true;
            this.txttype.Items.AddRange(new object[] {
            "CASH",
            "ONLINE"});
            this.txttype.Location = new System.Drawing.Point(518, 26);
            this.txttype.MaxDropDownItems = 2;
            this.txttype.Name = "txttype";
            this.txttype.Size = new System.Drawing.Size(172, 28);
            this.txttype.TabIndex = 12;
            this.txttype.SelectedIndexChanged += new System.EventHandler(this.txttype_SelectedIndexChanged);
            // 
            // lbldate
            // 
            this.lbldate.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.Black;
            this.lbldate.Location = new System.Drawing.Point(0, 10);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(1256, 21);
            this.lbldate.TabIndex = 903;
            this.lbldate.Text = "DATE :";
            this.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgw_view
            // 
            this.dgw_view.AllowUserToAddRows = false;
            this.dgw_view.AllowUserToDeleteRows = false;
            this.dgw_view.AllowUserToResizeColumns = false;
            this.dgw_view.AllowUserToResizeRows = false;
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
            this.dgw_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw_view.EnableHeadersVisualStyles = false;
            this.dgw_view.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.dgw_view.Location = new System.Drawing.Point(0, 0);
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
            this.dgw_view.Size = new System.Drawing.Size(1256, 288);
            this.dgw_view.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(557, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 919;
            this.label2.Text = "GRAND BALANCE";
            // 
            // lblbalance
            // 
            this.lblbalance.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbalance.ForeColor = System.Drawing.Color.Black;
            this.lblbalance.Location = new System.Drawing.Point(0, 93);
            this.lblbalance.Name = "lblbalance";
            this.lblbalance.Size = new System.Drawing.Size(1256, 21);
            this.lblbalance.TabIndex = 917;
            this.lblbalance.Text = "₹";
            this.lblbalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(557, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 21);
            this.label4.TabIndex = 916;
            this.label4.Text = "GRAND AMOUNT";
            // 
            // lblamount
            // 
            this.lblamount.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblamount.ForeColor = System.Drawing.Color.Black;
            this.lblamount.Location = new System.Drawing.Point(0, 38);
            this.lblamount.Name = "lblamount";
            this.lblamount.Size = new System.Drawing.Size(1256, 21);
            this.lblamount.TabIndex = 915;
            this.lblamount.Text = "₹";
            this.lblamount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnmail
            // 
            this.btnmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnmail.FlatAppearance.BorderSize = 0;
            this.btnmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnmail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnmail.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnmail.ForeColor = System.Drawing.Color.White;
            this.btnmail.Location = new System.Drawing.Point(532, 8);
            this.btnmail.Name = "btnmail";
            this.btnmail.Size = new System.Drawing.Size(125, 45);
            this.btnmail.TabIndex = 8;
            this.btnmail.Text = "&Email";
            this.btnmail.UseVisualStyleBackColor = false;
            this.btnmail.Click += new System.EventHandler(this.btnmail_Click);
            // 
            // pnlmail
            // 
            this.pnlmail.Controls.Add(this.txtemail);
            this.pnlmail.Controls.Add(this.label5);
            this.pnlmail.Controls.Add(this.btnmailsender);
            this.pnlmail.Location = new System.Drawing.Point(316, 260);
            this.pnlmail.Name = "pnlmail";
            this.pnlmail.Size = new System.Drawing.Size(657, 178);
            this.pnlmail.TabIndex = 925;
            this.pnlmail.Visible = false;
            // 
            // txtemail
            // 
            this.txtemail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtemail.Font = new System.Drawing.Font("Futura Bk", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(195, 50);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(353, 27);
            this.txtemail.TabIndex = 9;
            this.txtemail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            this.txtemail.Leave += new System.EventHandler(this.txtemail_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(108, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 891;
            this.label5.Text = "EMAIL ID :";
            // 
            // btnmailsender
            // 
            this.btnmailsender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnmailsender.FlatAppearance.BorderSize = 0;
            this.btnmailsender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnmailsender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnmailsender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnmailsender.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnmailsender.ForeColor = System.Drawing.Color.White;
            this.btnmailsender.Location = new System.Drawing.Point(195, 83);
            this.btnmailsender.Name = "btnmailsender";
            this.btnmailsender.Size = new System.Drawing.Size(164, 45);
            this.btnmailsender.TabIndex = 10;
            this.btnmailsender.Text = "&SEND EMAIL";
            this.btnmailsender.UseVisualStyleBackColor = false;
            this.btnmailsender.Click += new System.EventHandler(this.btnmailsender_Click);
            this.btnmailsender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // pnlamount
            // 
            this.pnlamount.Controls.Add(this.label2);
            this.pnlamount.Controls.Add(this.lblbalance);
            this.pnlamount.Controls.Add(this.label4);
            this.pnlamount.Controls.Add(this.lblamount);
            this.pnlamount.Location = new System.Drawing.Point(12, 521);
            this.pnlamount.Name = "pnlamount";
            this.pnlamount.Size = new System.Drawing.Size(1256, 126);
            this.pnlamount.TabIndex = 923;
            this.pnlamount.Visible = false;
            // 
            // pnldate
            // 
            this.pnldate.Controls.Add(this.txttodate);
            this.pnldate.Controls.Add(this.label7);
            this.pnldate.Controls.Add(this.btnload);
            this.pnldate.Controls.Add(this.txtfromdate);
            this.pnldate.Controls.Add(this.label6);
            this.pnldate.Location = new System.Drawing.Point(428, 263);
            this.pnldate.Name = "pnldate";
            this.pnldate.Size = new System.Drawing.Size(436, 167);
            this.pnldate.TabIndex = 919;
            // 
            // txttodate
            // 
            this.txttodate.CustomFormat = "dd/MM/yyyy";
            this.txttodate.Font = new System.Drawing.Font("Futura Bk", 11.25F);
            this.txttodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txttodate.Location = new System.Drawing.Point(193, 61);
            this.txttodate.Name = "txttodate";
            this.txttodate.Size = new System.Drawing.Size(164, 27);
            this.txttodate.TabIndex = 2;
            this.txttodate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(79, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 21);
            this.label7.TabIndex = 893;
            this.label7.Text = "TO DATE :";
            // 
            // btnload
            // 
            this.btnload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnload.FlatAppearance.BorderSize = 0;
            this.btnload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnload.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnload.ForeColor = System.Drawing.Color.White;
            this.btnload.Location = new System.Drawing.Point(193, 94);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(164, 45);
            this.btnload.TabIndex = 3;
            this.btnload.Text = "&LOAD";
            this.btnload.UseVisualStyleBackColor = false;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            this.btnload.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // txtfromdate
            // 
            this.txtfromdate.CustomFormat = "dd/MM/yyyy";
            this.txtfromdate.Font = new System.Drawing.Font("Futura Bk", 11.25F);
            this.txtfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfromdate.Location = new System.Drawing.Point(193, 28);
            this.txtfromdate.Name = "txtfromdate";
            this.txtfromdate.Size = new System.Drawing.Size(164, 27);
            this.txtfromdate.TabIndex = 1;
            this.txtfromdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_Only);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Std Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(79, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 21);
            this.label6.TabIndex = 890;
            this.label6.Text = "FROM DATE :";
            // 
            // pnlfilter
            // 
            this.pnlfilter.Controls.Add(this.btnclear);
            this.pnlfilter.Controls.Add(this.label3);
            this.pnlfilter.Controls.Add(this.txttype);
            this.pnlfilter.Location = new System.Drawing.Point(12, 93);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(1256, 78);
            this.pnlfilter.TabIndex = 920;
            this.pnlfilter.Visible = false;
            // 
            // pnllbldate
            // 
            this.pnllbldate.Controls.Add(this.lbldate);
            this.pnllbldate.Location = new System.Drawing.Point(12, 46);
            this.pnllbldate.Name = "pnllbldate";
            this.pnllbldate.Size = new System.Drawing.Size(1256, 41);
            this.pnllbldate.TabIndex = 921;
            this.pnllbldate.Visible = false;
            // 
            // pnldgw
            // 
            this.pnldgw.Controls.Add(this.dgw_view);
            this.pnldgw.Location = new System.Drawing.Point(12, 227);
            this.pnldgw.Name = "pnldgw";
            this.pnldgw.Size = new System.Drawing.Size(1256, 288);
            this.pnldgw.TabIndex = 922;
            this.pnldgw.Visible = false;
            // 
            // pnlbuttons
            // 
            this.pnlbuttons.Controls.Add(this.btnprint);
            this.pnlbuttons.Controls.Add(this.btnpdf);
            this.pnlbuttons.Controls.Add(this.btnexcel);
            this.pnlbuttons.Controls.Add(this.btnwhatsapp);
            this.pnlbuttons.Controls.Add(this.btnmail);
            this.pnlbuttons.ForeColor = System.Drawing.Color.White;
            this.pnlbuttons.Location = new System.Drawing.Point(308, 650);
            this.pnlbuttons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlbuttons.Name = "pnlbuttons";
            this.pnlbuttons.Padding = new System.Windows.Forms.Padding(5);
            this.pnlbuttons.Size = new System.Drawing.Size(665, 61);
            this.pnlbuttons.TabIndex = 924;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnprint.FlatAppearance.BorderSize = 0;
            this.btnprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Location = new System.Drawing.Point(8, 8);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(125, 45);
            this.btnprint.TabIndex = 4;
            this.btnprint.Text = "&Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnpdf
            // 
            this.btnpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnpdf.FlatAppearance.BorderSize = 0;
            this.btnpdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnpdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnpdf.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnpdf.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnpdf.ForeColor = System.Drawing.Color.White;
            this.btnpdf.Location = new System.Drawing.Point(139, 8);
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(125, 45);
            this.btnpdf.TabIndex = 5;
            this.btnpdf.Text = "&Export To PDF";
            this.btnpdf.UseVisualStyleBackColor = false;
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // btnexcel
            // 
            this.btnexcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnexcel.FlatAppearance.BorderSize = 0;
            this.btnexcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnexcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnexcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnexcel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnexcel.ForeColor = System.Drawing.Color.White;
            this.btnexcel.Location = new System.Drawing.Point(270, 8);
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(125, 45);
            this.btnexcel.TabIndex = 6;
            this.btnexcel.Text = "&Export To Excel";
            this.btnexcel.UseVisualStyleBackColor = false;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // btnwhatsapp
            // 
            this.btnwhatsapp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(92)))));
            this.btnwhatsapp.FlatAppearance.BorderSize = 0;
            this.btnwhatsapp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnwhatsapp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnwhatsapp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnwhatsapp.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnwhatsapp.ForeColor = System.Drawing.Color.White;
            this.btnwhatsapp.Location = new System.Drawing.Point(401, 8);
            this.btnwhatsapp.Name = "btnwhatsapp";
            this.btnwhatsapp.Size = new System.Drawing.Size(125, 45);
            this.btnwhatsapp.TabIndex = 7;
            this.btnwhatsapp.Text = "&Whatsapp";
            this.btnwhatsapp.UseVisualStyleBackColor = false;
            // 
            // FRM_YEARLY_REPORTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlmail);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.pnlamount);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.pnllbldate);
            this.Controls.Add(this.pnldgw);
            this.Controls.Add(this.pnlbuttons);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnldate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FRM_YEARLY_REPORTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SS SOFTWARE";
            this.Load += new System.EventHandler(this.FRM_YEARLY_REPORTS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_YEARLY_REPORTS_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companydbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_view)).EndInit();
            this.pnlmail.ResumeLayout(false);
            this.pnlmail.PerformLayout();
            this.pnlamount.ResumeLayout(false);
            this.pnlamount.PerformLayout();
            this.pnldate.ResumeLayout(false);
            this.pnldate.PerformLayout();
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.pnllbldate.ResumeLayout(false);
            this.pnldgw.ResumeLayout(false);
            this.pnlbuttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picminimize;
        private System.Windows.Forms.PictureBox piclose;
        private MainDataSetTableAdapters.Company_dbTableAdapter company_dbTableAdapter;
        private MainDataSet mainDataSet;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.BindingSource companydbBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlmail;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnmailsender;
        private System.Windows.Forms.Panel pnlamount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblbalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblamount;
        private System.Windows.Forms.Panel pnldate;
        private System.Windows.Forms.DateTimePicker txttodate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.DateTimePicker txtfromdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txttype;
        private System.Windows.Forms.Panel pnllbldate;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Panel pnldgw;
        private System.Windows.Forms.DataGridView dgw_view;
        private System.Windows.Forms.FlowLayoutPanel pnlbuttons;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnpdf;
        private System.Windows.Forms.Button btnexcel;
        private System.Windows.Forms.Button btnwhatsapp;
        private System.Windows.Forms.Button btnmail;
        private System.Windows.Forms.Label label1;
    }
}