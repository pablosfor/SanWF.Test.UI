using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SanWF.Test.UI
{
    class LoginPage
    {
        private IWebDriver driver;
        private string baseURL;

        public LoginPage(OpenQA.Selenium.IWebDriver webDriver, string baseURL)
        {
            this.driver = webDriver;
            this.baseURL = baseURL;
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.baseURL + "/wfinbox/Account/LoginNuevo.aspx");
        }

        public void LoginWith(string username)
        {
            this.driver.FindElement(By.Id("CPH1_txtNombreUsuarioRad")).Clear();
            this.driver.FindElement(By.Id("CPH1_txtNombreUsuarioRad")).SendKeys(username);
            this.driver.FindElement(By.Id("CPH1_txtPasswordUsuarioRad")).Clear();
            this.driver.FindElement(By.Id("CPH1_txtPasswordUsuarioRad")).SendKeys(username);
            this.driver.FindElement(By.Id("ctl00_CPH1_btnAceptarRad_input")).Click();

            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//*[contains(.,'Bienvenido')]")));
        }
    }
}
