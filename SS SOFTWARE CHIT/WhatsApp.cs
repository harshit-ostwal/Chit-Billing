using CrystalDecisions.CrystalReports.Engine;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    public class WhatsApp
    {
        public IWebDriver driver;
        public ChromeDriverService service = ChromeDriverService.CreateDefaultService();
        public ChromeOptions options = new ChromeOptions();
        public string Url = "https://web.whatsapp.com"; 

        public WhatsApp()
        {
            InitializeDriver();
        }

        public void InitializeDriver()
        {
            try
            {
                service.HideCommandPromptWindow = true;
                options.AddArguments("--window-position=0,0","user-data-dir=" + Application.StartupPath + "\\WHATSAPP DATA\\Google\\Chrome\\User Data");
                driver = new ChromeDriver(service, options);
            }
            catch (Exception)
            {

            }
        }

        public async void Load()
        {
            try
            {
                await Task.Run(() => driver.Navigate().GoToUrl(Url));
            }
            catch (Exception)
            {

            }
        }

        public async void Logout()
        {
            await Task.Run(() =>
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    if (wait.Until(driver => driver.PageSource.Contains("Use WhatsApp on your computer")) == false)
                    {
                        wait.Until(driver => driver.FindElement(By.XPath("// div[@title='Menu']"))).Click();
                        wait.Until(driver => driver.FindElement(By.XPath("// div[@aria-label='Log out']"))).Click();
                        wait.Until(driver => driver.FindElement(By.XPath("// button[@class='emrlamx0 aiput80m h1a80dm5 sta02ykp g0rxnol2 l7jjieqr hnx8ox4h f8jlpxt4 l1l4so3b le5p0ye3 m2gb0jvt rfxpxord gwd8mfxi mnh9o63b qmy7ya1v dcuuyf4k swfxs4et bgr8sfoe a6r886iw fx1ldmn8 orxa12fk bkifpc9x rpz5dbxo bn27j4ou oixtjehm hjo1mxmu snayiamo szmswy5k']"))).Click();
                        MessageBox.Show("LOGOUT SUCCESSFULLY DONE!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load();
                    }
                    else
                    {
                        MessageBox.Show("NOT CONNECTED TO WHATSAPP?", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {

                }
            });
        }

        public async void CaptureAndDisplayQrCode(PictureBox pictureBox)
        {
            try
            {
                IWebElement divElement = driver.FindElement(By.XPath("//div[@class='_2I5ox']"));
                var location = divElement.Location;
                var size = divElement.Size;
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                using (MemoryStream stream = new MemoryStream(screenshot.AsByteArray))
                using (Bitmap fullScreenshot = new Bitmap(stream))
                {
                    Rectangle croppedImage = new Rectangle(location, size);
                    using (Bitmap croppedScreenshot = fullScreenshot.Clone(croppedImage, fullScreenshot.PixelFormat))
                    {
                        int desiredX = 0;
                        int desiredY = 0;

                        Bitmap finalImage = new Bitmap(pictureBox.Width, pictureBox.Height);
                        using (Graphics graphics = Graphics.FromImage(finalImage))
                        {
                            await Task.Run(() => graphics.DrawImage(croppedScreenshot, desiredX, desiredY, croppedScreenshot.Width, croppedScreenshot.Height));
                            await Task.Run(() => pictureBox.Image = finalImage);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

    }
}