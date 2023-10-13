
namespace SS_SOFTWARE_CHIT
{
    partial class FRM_REMINDER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_REMINDER));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picminimize = new System.Windows.Forms.PictureBox();
            this.piclose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclose)).BeginInit();
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
            this.panel1.TabIndex = 7;
            // 
            // picminimize
            // 
            this.picminimize.Image = ((System.Drawing.Image)(resources.GetObject("picminimize.Image")));
            this.picminimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picminimize.Location = new System.Drawing.Point(48, 5);
            this.picminimize.MaximumSize = new System.Drawing.Size(30, 30);
            this.picminimize.MinimumSize = new System.Drawing.Size(30, 30);
            this.picminimize.Name = "picminimize";
            this.picminimize.Size = new System.Drawing.Size(30, 30);
            this.picminimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picminimize.TabIndex = 59;
            this.picminimize.TabStop = false;
            // 
            // piclose
            // 
            this.piclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.piclose.Image = ((System.Drawing.Image)(resources.GetObject("piclose.Image")));
            this.piclose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.piclose.Location = new System.Drawing.Point(12, 5);
            this.piclose.MaximumSize = new System.Drawing.Size(30, 30);
            this.piclose.MinimumSize = new System.Drawing.Size(30, 30);
            this.piclose.Name = "piclose";
            this.piclose.Size = new System.Drawing.Size(30, 30);
            this.piclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piclose.TabIndex = 58;
            this.piclose.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Std Book", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(589, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 69;
            this.label1.Text = "REMINDER";
            // 
            // FRM_REMINDER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_REMINDER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SS SOFTWARE";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piclose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picminimize;
        private System.Windows.Forms.PictureBox piclose;
        private System.Windows.Forms.Label label1;
    }
}