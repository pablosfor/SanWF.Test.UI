using OpenQA.Selenium;
using System.Threading;

namespace SanWF.Test.UI
{
    public class FeasibilityAnalysisPage
    {
        private IWebDriver driver;
        private string baseURL;

        public FeasibilityAnalysisPage(IWebDriver driver, string baseURL)
        {
            this.driver = driver;
            this.baseURL = baseURL;
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.baseURL + "/wfafacti/Default.aspx");
        }

        public FeasibilityAnalysisTitleInfoPage AgregarTitulo()
        {
            return new FeasibilityAnalysisTitleInfoPage(driver);
        }

        public void Aceptar()
        {
            Thread.Sleep(1000);
            this.driver.FindElement(By.Id("ctl00_MainContent_btnAceptar")).Click();
        }
    }
}
