using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_WHATSAPP_SETTINGS : Form
    {

        WhatsApp app;
            
        public FRM_WHATSAPP_SETTINGS(WhatsApp whatsappInitialize)
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

        private async void lbl()
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        WebDriverWait wait = new WebDriverWait(app.driver, TimeSpan.FromSeconds(20));
                        wait.Until(driver => driver.Url.Contains("web.whatsapp.com"));
                        wait.Until(driver => app.driver.PageSource.Contains("Use WhatsApp on your computer"));
                    }
                    catch (Exception)
                    {

                    }
                });

                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    lblstatus.Text = "WHATSAPP NOT AUTHORIZED";
                }
                else
                {
                    lblstatus.Text = "WHATSAPP READY";
                }
            }
            catch (Exception)
            {

            }
        }

        private async Task Initialize()
        {
            lblstatus.Text = "LOADING...";
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    await Task.Run(() => app.Load());
                    lbl();
                    MessageBox.Show("WHATSAPP IS INITIALIZED...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("WHATSAPP IS NOT RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnterminate_Click(object sender, EventArgs e)
        {
            try
            {
                app.driver.Dispose();
                timer2.Stop();
                MessageBox.Show("WHATSAPP IS TERMINATED...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picqrcode.Image = picqrcode.InitialImage;
            }
            catch (Exception)
            {

            }
        }

        private void piclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                FRM_SETTINGS Settings = new FRM_SETTINGS(app);
                Settings.Show();
            }
        }

        private async void btninitialize_Click(object sender, EventArgs e)
        {
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    MessageBox.Show("WHATSAPP IS RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                app.InitializeDriver();
                await Initialize();
                this.Focus();
                timer2.Start();
                lblstatus.Text = "NOT WHATSAPP READY";
            }
        }
        private void QrCode()
        {
            app.CaptureAndDisplayQrCode(picqrcode);
            timer1.Stop();
        }

        private void btnqrcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (app.driver.PageSource.Contains("Use WhatsApp on your computer") == true)
                {
                    if (app.driver.WindowHandles.Count > 0)
                    {
                        timer1.Start();
                    }
                }
                else
                {
                    MessageBox.Show("ALREADY CONNECTED TO WHATSAPP!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                lblstatus.Text = "WHATSAPP NOT READY";
                MessageBox.Show("WHATSAPP IS NOT RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            try
            {
                app.Logout();
                picqrcode.Image = picqrcode.InitialImage;
                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    lblstatus.Text = "WHATSAPP NOT AUTHORIZED";
                }
                else
                {
                    lblstatus.Text = "WHATSAPP READY";
                    picqrcode.Image = picqrcode.InitialImage;
                }
            }
            catch (Exception)
            {
                lblstatus.Text = "WHATSAPP NOT READY";
                MessageBox.Show("WHATSAPP IS NOT RUNNING...", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void picminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FRM_WHATSAPP_SETTINGS_Load(object sender, EventArgs e)
        {
            try
            {
                if (app.driver.WindowHandles.Count > 0)
                {
                    lbl();
                    picqrcode.Image = picqrcode.InitialImage;
                    this.Focus();
                    timer2.Start();
                }
            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            QrCode();
            this.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (app.driver.PageSource.Contains("Use WhatsApp on your computer"))
                {
                    lblstatus.Text = "WHATSAPP NOT AUTHORIZED";
                }
                else
                {
                    lblstatus.Text = "WHATSAPP READY";
                }
            }
            catch (Exception)
            {
                lblstatus.Text = "WHATSAPP NOT READY";
            }
        }

        private void FRM_WHATSAPP_SETTINGS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("DO YOU WANT TO EXIT?", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Hide();
                    FRM_SETTINGS Settings = new FRM_SETTINGS(app);
                    Settings.Show();
                }
            }
        }
    }
}
