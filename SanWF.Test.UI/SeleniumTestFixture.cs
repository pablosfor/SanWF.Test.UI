using NUnit.Framework;
using OpenQA.Selenium;

namespace SanWF.Test.UI
{
    [TestFixture]
    public class SeleniumTestFixture : SeleniumBaseTestFixture
    {
        [TestFixtureSetUp]
        public void SeleniumTestFixtureSetupTest()
        {
            var page = new LoginPage(this.driver, this.baseURL);
            page.Navigate();
            page.LoginWith("gzona");
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