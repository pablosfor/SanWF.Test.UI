using NUnit.Framework;

namespace SanWF.Test.UI
{
    [TestFixture]
    public class FeasibilityAnalysisOrderTestFixture : SeleniumBaseTestFixture
    {
        [Test]
        public void FeasibilityAnalysisOrderTest()
        {
            var loginPage = new LoginPage(this.driver, this.baseURL);
            loginPage.Navigate();
            loginPage.LoginWith(this.feasibilityAnalysisOrderCreator);

            var feasibilityAnalysisPage = new FeasibilityAnalysisPage(driver, this.baseURL);

            feasibilityAnalysisPage.Navigate();

            feasibilityAnalysisPage.AgregarTitulo().
                WithTitle("Título de prueba").
                WithNewAuthor("Nuevo autor de prueba").
                WithMonthYear("marzo de 2013").
                WithSeal("AGUILAR").
                WithCollection("Nueva colección de prueba").
                Add();

            feasibilityAnalysisPage.Aceptar();

            Assert.IsTrue(this.IsTextPresentWithWait(driver, "Debe ingresar el Formato"));
        }
    }
}