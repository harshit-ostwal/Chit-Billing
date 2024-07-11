using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Threading;
using System.Data.OleDb;

namespace SS_SOFTWARE_CHIT
{
    public partial class FRM_FORGOT_PASSWORD : Form
    {
        int seconds = 0;
        string randomCode;
        string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + Application.StartupPath + "/DATABASE/Settings_db.accdb;Jet OLEDB:Database Password = SS9975";
        OleDbCommand cmd = new OleDbCommand();
        WhatsApp app;

        public FRM_FORGOT_PASSWORD(WhatsApp whatsappInitialize)
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

        private void FRM_FORGOT_PASSWORD_Load(object sender, EventArgs e)
        {
            this.company_dbTableAdapter.Fill(this.mainDataSet.Company_db);
            this.login_dbTableAdapter.Fill(this.settings_dbDataSet.Login_db);
            KeyPreview = true;
            seconds = 30;
        }

        private async void btnsendotp_Click(object sender, EventArgs e)
        {
            try
            {
                bool connection = NetworkInterface.GetIsNetworkAvailable();

                if (connection)
                {
                    Cursor = Cursors.WaitCursor;
                    timer1.Start();
                    using (SmtpClient Client = new SmtpClient("smtp.gmail.com"))
                    {
                        Client.Port = 587;
                        Client.EnableSsl = true;
                        Client.Credentials = new NetworkCredential("official.sssoftware@gmail.com", "zhxovvaxvngyacyr");

                        using (MailMessage Message = new MailMessage())
                        {
                            MailAddress FromEmail = new MailAddress("official.sssoftware@gmail.com", "SS SOFTWARE");
                            MailAddress ToEmail = new MailAddress(txtemailid.Text);
                            Message.From = FromEmail;
                            Random rand = new Random();
                            randomCode = (rand.Next(100000, 999999)).ToString();
                            Message.To.Add(ToEmail);
                            Message.Subject = randomCode + " - OTP FOR RESET PASSWORD TO YOUR SS SOFTWARE";
                            string emailBody = @"
  <!DOCTYPE html>
<html>

<head>
    <style>
        body {
            font-family: 'Arial', 'Helvetica', sans-serif;
            margin: 0;
            padding: 0;
            animation: fadeIn 1s ease-in-out;
        }

        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            border-radius: 20px;
            background-color: #ffa600;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .header {
            background-color: #003f5c;
            color: white;
            padding: 1px;
            margin-bottom: 30px;
            margin-top: 20px;
            border-radius: 20px;
            text-transform: capitalize;
            text-align: center;
        }

        .content {
            padding: 20px;
            line-height: 1.5;
            border-radius: 20px;
            color: white;
            background: black;
        }

        .highlight{
            font-weight: 700;
            color: #007acc;
        }

        .title{
            font-weight: 700;
            line-height: 2;
            color: #007acc;
            text-align: center;
        }

        @keyframes fadeIn {
            0% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }
    </style>
</head>

<body>
    <div class='container'>
        <div class='header'>
            <h2>RESET PASSWORD OTP</h2>
        </div>
        <div class='content'>
            <p>Dear " + lbluser.Text + @",</p>
            <p>Here is your OTP to Reset Password to your SS SOFTWARE</p>
            <br>
            <h1 class='title'>" + randomCode + @"</h1>
            <p class='title' style='font-size: 14px; color: gray; line-height:.2;'>This OTP will expire in 10 minutes.</p>
            <br>
            <p><span class='highlight'>Stay Connected:</span></p>
            <p>Got questions, suggestions, or just want to chat? We're here for you. Don't hesitate to reach out; we're
                just a click away.</p>
            <p>Thank you for choosing SS SOFTWARE.We appreciate your trust in our services.</p>
            <p>Best regards,<br>Harshit Jain</p>
        </div>
        <div class='header'>
            <h5>&copy; " + DateTime.Now.Year + @" SS SOFTWARE.All rights reserved.</h5>
        </div>
    </div>
</body>

</html>";

                            Message.Body = emailBody;
                            Message.IsBodyHtml = true;
                            Message.Priority = MailPriority.High;
                            await Client.SendMailAsync(Message);
                        }
                    }
                    timer1.Stop();
                    MessageBox.Show("EMAIL SENT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearall();
                    panel1.Visible = false;
                    panel2.Visible = false;
                    pnlotp.Visible = false;
                    pnlotp.Visible = true;
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }
        private void btnverifyotp_Click(object sender, EventArgs e)
        {
            if (randomCode == txt1.Text + txt2.Text + txt3.Text + txt4.Text + txt5.Text + txt6.Text)
            {
                Thread.Sleep(1000);
                timer1.Stop();
                MessageBox.Show("OTP SUCCESSFULLY VERIFIED!!!","SS SOFTWARE",MessageBoxButtons.OK,MessageBoxIcon.Information);
                panel1.Visible = false;
                panel2.Visible = false;
                pnlotp.Visible = false;
                panel3.Visible = true;
                Clearall();
                SendPass();
            }
            else
            {
                MessageBox.Show("UNSUCCESSFULLY OTP WRONG!!!","SS SOFTWARE",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Clearall();
                txt1.Focus();
            }
        }

        private async void SendPass()
        {
            try
            {
                bool connection = NetworkInterface.GetIsNetworkAvailable();

                if (connection)
                {
                    Cursor = Cursors.WaitCursor;
                    timer1.Start();
                    using (SmtpClient Client = new SmtpClient("smtp.gmail.com"))
                    {
                        Client.Port = 587;
                        Client.EnableSsl = true;
                        Client.Credentials = new NetworkCredential("official.sssoftware@gmail.com", "zhxovvaxvngyacyr");

                        using (MailMessage Message = new MailMessage())
                        {
                            MailAddress FromEmail = new MailAddress("official.sssoftware@gmail.com", "SS SOFTWARE");
                            MailAddress ToEmail = new MailAddress(txtemailid.Text);
                            Message.From = FromEmail;
                            Message.To.Add(ToEmail);
                            Message.Subject = "SS SOFTWARE LOGIN CREDENTIALS";
                            string emailBody = @"
  <!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: 'Arial', 'Helvetica', sans-serif;
            margin: 0;
            padding: 0;
            animation: fadeIn 1s ease-in-out;
        }

        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            border-radius: 20px;
            background-color: #ffa600;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .header {
            background-color: #003f5c;
            color: white;
            padding: 1px;
            margin-bottom: 30px;
            margin-top: 20px;
            border-radius: 20px;
            text-transform: capitalize;
            text-align: center;
        }

        .content {
            padding: 20px;
            line-height: 1.5;
            border-radius: 20px;
            color: white;
            background: black;
        }

        .highlight{
            font-weight: 700;
            color: #007acc;
        }

        .title{
            font-weight: 700;
            line-height: 2;
            color: #007acc;
            text-align: center;
        }

        @keyframes fadeIn {
            0% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }
    </style>
</head>

<body>
    <div class='container'>
        <div class='header'>
            <h2>LOGIN CREDENTIALS</h2>
        </div>
        <div class='content'>
            <p>Dear " + lbluser.Text + @",</p>
            <p>Here is your Login Credentials of SS SOFTWARE</p>
            <br>
            <h1 class='title' style='font-size: 16px; '>
            <span class='title' style='font-size: 16px;color: gray;'>User Name : </span>" + lblusername.Text + @"</h1>
            <h1 class='title' style='font-size: 16px; '>
            <span class='title' style='font-size: 16px;color: gray; '>Password : </span>" + lblpass.Text + @"</h1>
            <p class='title' style='font-size: 14px; color: gray; line-height:1;'>Please Login Using These Details In SS SOFTWARE.</p>
            <br>
            <p><span class='highlight'>Stay Connected:</span></p>
            <p>Got questions, suggestions, or just want to chat? We're here for you. Don't hesitate to reach out; we're
                just a click away.</p>
            <p>Thank you for choosing SS SOFTWARE.We appreciate your trust in our services.</p>
            <p>Best regards,<br>Harshit Jain</p>
        </div>
        <div class='header'>
            <h5>&copy; " + DateTime.Now.Year + @" SS SOFTWARE.All rights reserved.</h5>
        </div>
    </div>
</body>

</html>";

                            Message.Body = emailBody;
                            Message.IsBodyHtml = true;
                            Message.Priority = MailPriority.High;
                            await Client.SendMailAsync(Message);
                        }
                    }
                    timer1.Stop();
                    MessageBox.Show("EMAIL SENT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearall();
                    FRM_LOGIN Login = new FRM_LOGIN(app);
                    Login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void txtemailid_Leave(object sender, EventArgs e)
        {
            string Email_Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtemailid.Text, Email_Pattern) == false)
            {
                errorProvider1.SetError(txtemailid, "Invalid Email Id");
                txtemailid.Focus();
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void Clearall()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt2.Focus();
            txt3.Focus();
            txt4.Focus();
            txt5.Focus();
            txt6.Focus();
            txt1.SelectionLength = 0;
            txt2.SelectionLength = 0;
            txt3.SelectionLength = 0;
            txt4.SelectionLength = 0;
            txt5.SelectionLength = 0;
            txt6.SelectionLength = 0;
            txt1.Focus();
        }

        private void txtotpsingle(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt1.Text + txt2.Text + txt3.Text + txt4.Text + txt5.Text + txt6.Text, "[^0-9]"))
            {
                MessageBox.Show("ONLY NUMBERS !!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clearall();
            }
            SendKeys.Send("{TAB}");
        }

        private void txt6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txt6.Text = "";
                txt6.SelectionLength = 0;
                txt5.Focus();
            }
        }

        private void txt5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txt5.Text = "";
                txt5.SelectionLength = 0;
                txt4.Focus();
            }
        }

        private void txt4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txt4.Text = "";
                txt4.SelectionLength = 0;
                txt3.Focus();
            }
        }

        private void txt3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txt3.Text = "";
                txt3.SelectionLength = 0;
                txt2.Focus();
            }
        }

        private void txt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                txt2.Text = "";
                txt2.SelectionLength = 0;
                txt1.Focus();
            }
        }

        private void FRM_FORGOT_PASSWORD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Clearall();
                txtemailid.Text = "";
                txtemailid.Focus();
                txtemailid.SelectionLength = 0;
                FRM_LOGIN Login = new FRM_LOGIN(app);
                Login.Show();
                this.Hide();
            }
        }

        private void txtemailid_KeyDown(object sender, KeyEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = seconds--.ToString();
            if (seconds < 0)
            {
                timer1.Stop();
                lblresendotp.Visible = true;
            }
        }

        private async void lblresendotp_Click(object sender, EventArgs e)
        {
            try
            {
                bool connection = NetworkInterface.GetIsNetworkAvailable();

                if (connection)
                {
                    Cursor = Cursors.WaitCursor;
                    timer1.Start();
                    using (SmtpClient Client = new SmtpClient("smtp.gmail.com"))
                    {
                        Client.Port = 587;
                        Client.EnableSsl = true;
                        Client.Credentials = new NetworkCredential("official.sssoftware@gmail.com", "zhxovvaxvngyacyr");

                        using (MailMessage Message = new MailMessage())
                        {
                            MailAddress FromEmail = new MailAddress("official.sssoftware@gmail.com", "SS SOFTWARE");
                            MailAddress ToEmail = new MailAddress(txtemailid.Text);
                            Message.From = FromEmail;
                            Random rand = new Random();
                            randomCode = (rand.Next(100000, 999999)).ToString();
                            Message.To.Add(ToEmail);
                            Message.Subject = randomCode + " - OTP FOR RESET PASSWORD TO YOUR SS SOFTWARE";
                            string emailBody = @"
  <!DOCTYPE html>
<html>

<head>
    <style>
        body {
            font-family: 'Arial', 'Helvetica', sans-serif;
            margin: 0;
            padding: 0;
            animation: fadeIn 1s ease-in-out;
        }

        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            border-radius: 20px;
            background-color: #ffa600;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .header {
            background-color: #003f5c;
            color: white;
            padding: 1px;
            margin-bottom: 30px;
            margin-top: 20px;
            border-radius: 20px;
            text-transform: capitalize;
            text-align: center;
        }

        .content {
            padding: 20px;
            line-height: 1.5;
            border-radius: 20px;
            color: white;
            background: black;
        }

        .highlight{
            font-weight: 700;
            color: #007acc;
        }

        .title{
            font-weight: 700;
            line-height: 2;
            color: #007acc;
            text-align: center;
        }

        @keyframes fadeIn {
            0% {
                opacity: 0;
            }

            100% {
                opacity: 1;
            }
        }
    </style>
</head>

<body>
    <div class='container'>
        <div class='header'>
            <h2>RESET PASSWORD OTP</h2>
        </div>
        <div class='content'>
            <p>Dear " + lbluser.Text + @",</p>
            <p>Here is your OTP to Reset Password to your SS SOFTWARE</p>
            <br>
            <h1 class='title'>" + randomCode + @"</h1>
            <p class='title' style='font-size: 14px; color: gray; line-height:.2;'>This OTP will expire in 10 minutes.</p>
            <br>
            <p><span class='highlight'>Stay Connected:</span></p>
            <p>Got questions, suggestions, or just want to chat? We're here for you. Don't hesitate to reach out; we're
                just a click away.</p>
            <p>Thank you for choosing SS SOFTWARE.We appreciate your trust in our services.</p>
            <p>Best regards,<br>Harshit Jain</p>
        </div>
        <div class='header'>
            <h5>&copy; " + DateTime.Now.Year + @" SS SOFTWARE.All rights reserved.</h5>
        </div>
    </div>
</body>

</html>";

                            Message.Body = emailBody;
                            Message.IsBodyHtml = true;
                            Message.Priority = MailPriority.High;
                            await Client.SendMailAsync(Message);
                        }
                    }
                    timer1.Stop();
                    lblresendotp.Visible = false;
                    seconds = 30;
                    timer1.Start();
                    MessageBox.Show("EMAIL SENT SUCCESSFULLY!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clearall();
                }
                else
                {
                    MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
