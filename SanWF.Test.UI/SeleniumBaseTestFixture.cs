using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace SanWF.Test.UI
{
    [TestFixture]
    public abstract class SeleniumBaseTestFixture
    {
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        protected IWebDriver driver;
        protected string baseURL;
        protected string feasibilityAnalysisOrderCreator;

        [TestFixtureSetUp]
        public void SetupTest()
        {
            SetConfigFileAtRuntime(@"C:\SanWF.Test.UI.config");
            this.baseURL = ConfigurationManager.AppSettings["baseURL"];
            this.feasibilityAnalysisOrderCreator = ConfigurationManager.AppSettings["feasibilityAnalysisOrderCreator"];

            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            verificationErrors = new StringBuilder();
        }

        [TestFixtureTearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        /// <summary>
        /// Sets the config file at runtime.
        /// </summary>
        /// <param name="configFilePath"></param>
        protected static void SetConfigFileAtRuntime(string configFilePath)
        {
            string runtimeconfigfile;

            if (configFilePath.Length == 0)
            {
                Console.WriteLine("Please specify a config file to read from ");
                Console.Write("> "); // prompt
                runtimeconfigfile = Console.ReadLine();
            }
            else
            {
                runtimeconfigfile = configFilePath;
            }

            // Specify config settings at runtime.
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //Similarly you can apply for other sections like SMTP/System.Net/System.Web etc..
            //But you have to set the File Path for each of these
            config.AppSettings.File = runtimeconfigfile;

            //This doesn't actually going to overwrite you Exe App.Config file.
            //Just refreshing the content in the memory.
            config.Save(ConfigurationSaveMode.Modified);

            //Refreshing Config Section
            ConfigurationManager.RefreshSection("appSettings");
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alert.Text;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        protected bool IsTextPresent(string text)
        {
            return this.IsTextPresent(this.driver, text);
        }

        protected bool IsTextNotPresent(IWebDriver driver, string text)
        {
            return !this.IsTextPresent(driver, text);
        }

        protected bool IsTextPresent(IWebDriver driver, string text)
        {
            try
            {
                driver.FindElement(By.XPath("//*[contains(.,'" + text + "')]"));

                return true;
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return false;
            }
        }

        protected bool IsTextPresentWithWait(IWebDriver driver, string text)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.XPath("//*[contains(.,'" + text + "')]")));

                return true;
            }
            catch (OpenQA.Selenium.WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
