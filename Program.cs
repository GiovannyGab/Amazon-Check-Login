using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Program
{

    //Criando a referencia pro crhome browser
    IWebDriver driver = new ChromeDriver();


    [SetUp]
    public void Initialize()
    {
        
        //Indo para a pagina da Google
        driver.Navigate().GoToUrl("https://www.amazon.com.br");
    }

    [Test]
    public void ExecuteTest()
    {
        try
        {
            //fazendo o browser ficar em fullscreen
            driver.Manage().Window.Maximize();

            IWebElement singIn = driver.FindElement(By.Id("nav-link-accountList"));

            


            singIn.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            //tela de  login

            IWebElement emailInput = driver.FindElement(By.Id("ap_email"));
            emailInput.SendKeys("fulanoemail@gmel.com");

            IWebElement buttonContinue = driver.FindElement(By.Id("continue"));
            buttonContinue.Click();

            IWebElement ErrorMessage = driver.FindElement(By.ClassName("a-alert-heading"));

            string ActualErrorText = ErrorMessage.Text;
            string ExpectedErrorText = "Houve um problema";

            Assert.That(ActualErrorText, Is.EqualTo(ExpectedErrorText));
            

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
    }
    [TearDown]
    public void CloseProgram()
    {
        //fechando a tela
        //driver.Quit();
    }

   
}




