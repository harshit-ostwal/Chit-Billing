
namespace SS_SOFTWARE_CHIT
{
    partial class FRM_CRY_CUSTOMER_ACTIVITY_REPORT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CRY_CUSTOMER_ACTIVITY_REPORT));
            this.View_Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CRY_CUSTOMER_ACTIVITY_REPORT1 = new SS_SOFTWARE_CHIT.CRY_CUSTOMER_ACTIVITY_REPORT();
            this.SuspendLayout();
            // 
            // View_Report
            // 
            this.View_Report.ActiveViewIndex = 0;
            this.View_Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.View_Report.Cursor = System.Windows.Forms.Cursors.Default;
            this.View_Report.DisplayStatusBar = false;
            this.View_Report.DisplayToolbar = false;
            this.View_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View_Report.Location = new System.Drawing.Point(0, 0);
            this.View_Report.Name = "View_Report";
            this.View_Report.ReportSource = this.CRY_CUSTOMER_ACTIVITY_REPORT1;
            this.View_Report.Size = new System.Drawing.Size(800, 450);
            this.View_Report.TabIndex = 0;
            this.View_Report.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FRM_CRY_CUSTOMER_ACTIVITY_REPORT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.View_Report);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_CRY_CUSTOMER_ACTIVITY_REPORT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SS SOFTWARE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer View_Report;
        private CRY_CUSTOMER_ACTIVITY_REPORT CRY_CUSTOMER_ACTIVITY_REPORT1;
    }
}