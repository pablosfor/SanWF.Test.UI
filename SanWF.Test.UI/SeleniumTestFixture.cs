using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace SanWF.Test.UI
{
    [TestFixture]
    public class SeleniumTestFixture : SeleniumBaseTestFixture
    {
        private string baseURL;

        [TestFixtureSetUp]
        public void SeleniumTestFixtureSetupTest()
        {
            SetConfigFileAtRuntime(@"C:\Santillana\Config\desa\SanWF.Test.UI.config");
            this.baseURL = ConfigurationManager.AppSettings["baseURL"];

            driver.Navigate().GoToUrl(this.baseURL + "/wfinbox/Account/LoginNuevo.aspx?ReturnUrl=%2fwfinbox%2fMisTareas.aspx");
            driver.FindElement(By.Id("CPH1_txtNombreUsuarioRad")).Clear();
            driver.FindElement(By.Id("CPH1_txtNombreUsuarioRad")).SendKeys("gzona");
            driver.FindElement(By.Id("CPH1_txtPasswordUsuarioRad")).Clear();
            driver.FindElement(By.Id("CPH1_txtPasswordUsuarioRad")).SendKeys("gzona");
            driver.FindElement(By.Id("ctl00_CPH1_btnAceptarRad_input")).Click();
        }

        [Test]
        public void ClickOnTaskAndVerifyBusinessPanelValue()
        {
            driver.FindElement(By.XPath("//tr[@id='ctl00_CPH1_grdTareas_ctl00__0']/td[5]")).Click();

            Assert.IsTrue(IsTextPresent("$80"));
        }

        [Test]
        public void ClickOnAnotherTaskAndVerifyBusinessPanelValue()
        {
            driver.FindElement(By.XPath("//tr[@id='ctl00_CPH1_grdTareas_ctl00__3']/td[7]")).Click();

            Assert.IsTrue(IsTextPresent("$1.100"));
        }
    }
}