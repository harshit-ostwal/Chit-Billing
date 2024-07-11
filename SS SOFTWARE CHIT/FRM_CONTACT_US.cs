using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Threading;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_CONTACT_US : Form
    {
        WhatsApp app;
        public FRM_CONTACT_US(WhatsApp whatsappInitialize)
        {
            InitializeComponent();
            try
            {
                app = whatsappInitialize;
            }
            catch
            {

            }
        }

        private void Enter_Click(object sender, KeyEventArgs e)
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

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("ARE READY TO SEND EMAIL???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool connection = NetworkInterface.GetIsNetworkAvailable();
                    if (connection == true)
                    {
                        MessageBox.Show("CONNECTION SUCCESSFULL!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SmtpClient Client = new SmtpClient()
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = true,
                            Credentials = new NetworkCredential()
                            {
                                UserName = "official.sssoftware@gmail.com",
                                Password = "rmhsnhhwwldxakbp"
                            }
                        };
                        MailAddress FromEmail = new MailAddress("official.sssoftware@gmail.com", "SS SOFTWARE");
                        MailAddress ToEmail = new MailAddress(txtemail.Text);
                        MailMessage Message = new MailMessage()
                        {
                            From = FromEmail,
                            Subject = txtsubject.Text,
                            Body = txtmessage.Text,
                        };
                        Message.To.Add(ToEmail);
                        Client.SendCompleted += Client_SendCompleted;
                        Client.SendMailAsync(Message);
                    }
                    else
                    {
                        MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Clearall();
                }
            }
            catch
            {
                MessageBox.Show("INCORRECT EMAIL ID???,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clearall();
            }
        }

        private void Clearall()
        {
            txtemail.Text = "";
            txtmessage.Text = "";
            txtsubject.Text = "";
            txtemail.Focus();
            txtemail.PlaceholderText = "";
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("UNABLE TO SEND EMAIL???,PLS TRY AGAIN!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clearall();
                return;
            }
            MessageBox.Show("EMAIL SENT SUCCESSFULYL!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clearall();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DO YOU WANT TO CLOSE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FRM_HOME HOME = new FRM_HOME(app);
                HOME.Show();
            }
        }

        private void FRM_CONTACT_US_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
                MessageBox.Show("CONNECTION SUCCESSFULL!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            string Email_Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtemail.Text, Email_Pattern) == false)
            {
                errorProvider1.SetError(txtemail, "Invalid Email Id");
                txtemail.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void FRM_CONTACT_US_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("DO YOU WANT TO CLOSE???", "SS SOFTWARE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Hide();
                    FRM_HOME HOME = new FRM_HOME(app);
                    HOME.Show();
                }
            }
        }

        private void btnsubmit_Click_1(object sender, EventArgs e)
        {

        }
    }
}
