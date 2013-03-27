using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

public class FeasibilityAnalysisTitleInfoPage
{
    private IWebDriver driver;

    private string title;
    private string newAuthor;
    private string monthYear;
    private string seal;
    private string collection;

    public FeasibilityAnalysisTitleInfoPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public FeasibilityAnalysisTitleInfoPage WithTitle(string title)
    {
        this.title = title;

        return this;
    }

    public FeasibilityAnalysisTitleInfoPage WithNewAuthor(string newAuthor)
    {
        this.newAuthor = newAuthor;

        return this;
    }

    public FeasibilityAnalysisTitleInfoPage WithMonthYear(string monthYear)
    {
        this.monthYear = monthYear;

        return this;
    }

    public FeasibilityAnalysisTitleInfoPage WithSeal(string seal)
    {
        this.seal = seal;

        return this;
    }

    public FeasibilityAnalysisTitleInfoPage WithCollection(string collection)
    {
        this.collection = collection;

        return this;
    }

    public void Add()
    {
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_btnAgregarTitulo")).Click();

        var txtTitle = this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_txtTitulo"));
        txtTitle.Clear();
        txtTitle.SendKeys(this.title);

        if (string.IsNullOrEmpty(this.newAuthor))
        {
            this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_chkNvoAutor")).Click();
            this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_txtNvoAutor")).SendKeys(this.newAuthor);
        }

        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_mypMesAnio_dateInput")).SendKeys(this.monthYear);

        //TODO: Find out the way to select an item from a Telerik combobox using WebDriver -> http://www.telerik.com/community/forums/aspnet/combobox/select-value-in-telerik-combo-box.aspx
        var cmbSeal = this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_cmbSello_Input"));
        cmbSeal.SendKeys(this.seal[0].ToString());
        cmbSeal.Submit();
        this.Sleep();

        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_chkNvaColeccion")).Click();
        this.Sleep();
        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_txtNvaColeccion")).SendKeys(this.collection);

        this.driver.FindElement(By.Id("ctl00_MainContent_ctrlDatosDetalle_rpbDatosTitulo_i0_ctrlDatosTitulo_btnAceptarTitulo")).Click();
    }

    private void Sleep()
    {
        Thread.Sleep(1000);
    }
}