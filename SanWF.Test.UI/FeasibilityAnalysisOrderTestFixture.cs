using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SanWF.Test.UI
{
    [TestFixture]
    public class FeasibilityAnalysisOrderTestFixture : SeleniumBaseTestFixture
    {
        [TestFixtureSetUp]
        public void FeasibilityAnalysisOrderTestFixtureSetupTest()
        {
            var page = new LoginPage(this.driver, this.baseURL);
            page.Navigate();
            page.LoginWith("vnoetinger");
        }

        [Test]
        public void FeasibilityAnalysisOrderTest()
        {
            var page = new FeasibilityAnalysisPage(driver, this.baseURL);

            page.Navigate();

            page.AgregarTitulo().
                WithTitulo("Prueba").
                Add();

            page.Aceptar();

            string expectedAlertText = "procedimiento";

            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//*[contains(.,'" + expectedAlertText + "')]")));
        }
    }
}