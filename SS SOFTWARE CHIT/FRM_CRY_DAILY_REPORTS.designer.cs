﻿
namespace SS_SOFTWARE_CHIT
{
    partial class FRM_CRY_DAILY_REPORTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_CRY_DAILY_REPORTS));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.View_Report = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CRY_DAILY_REPORTS1 = new SS_SOFTWARE_CHIT.CRY_DAILY_REPORTS();
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
            this.View_Report.ReportSource = this.CRY_DAILY_REPORTS1;
            this.View_Report.ShowCloseButton = false;
            this.View_Report.ShowCopyButton = false;
            this.View_Report.ShowExportButton = false;
            this.View_Report.ShowGotoPageButton = false;
            this.View_Report.ShowGroupTreeButton = false;
            this.View_Report.ShowLogo = false;
            this.View_Report.ShowPageNavigateButtons = false;
            this.View_Report.ShowParameterPanelButton = false;
            this.View_Report.ShowPrintButton = false;
            this.View_Report.ShowRefreshButton = false;
            this.View_Report.ShowTextSearchButton = false;
            this.View_Report.ShowZoomButton = false;
            this.View_Report.Size = new System.Drawing.Size(1904, 1041);
            this.View_Report.TabIndex = 7;
            this.View_Report.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FRM_CRY_DAILY_REPORTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.View_Report);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_CRY_DAILY_REPORTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SS SOFTWARE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_CRY_DAILY_REPORTS_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public CrystalDecisions.Windows.Forms.CrystalReportViewer View_Report;
        private CRY_DAILY_REPORTS CRY_DAILY_REPORTS1;
    }
}