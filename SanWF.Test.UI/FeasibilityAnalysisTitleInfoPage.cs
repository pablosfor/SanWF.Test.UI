using OpenQA.Selenium;
using System.Threading;

public class FeasibilityAnalysisTitleInfoPage
{
    private IWebDriver driver;

    string titulo;

    public FeasibilityAnalysisTitleInfoPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public FeasibilityAnalysisTitleInfoPage WithTitulo(string titulo)
    {
        this.titulo = titulo;

        return this;
    }

    public void Add()
    {
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_btnAgregarTitulo")).Click();
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_txtTitulo")).Clear();
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_txtTitulo")).SendKeys(this.titulo);
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_chkNvoAutor")).Click();
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_txtNvoAutor")).SendKeys("Nuevo autor de prueba");
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_mypMesAnio_dateInput")).SendKeys("marzo de 2013");
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_cmbSello_Arrow")).Click();
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_cmbSello_Input")).SendKeys("AGUILAR");
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_cmbSello_Input")).SendKeys(Keys.Enter);
        Thread.Sleep(1000);
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_chkNvaColeccion")).Click();
        Thread.Sleep(1000);
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_txtNvaColeccion")).SendKeys("Nueva colección de prueba");
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_btnAceptarTitulo")).Click();
    }
}