using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace ProjectTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _signInButton = By.XPath("//a[text()='Войти']");
        private readonly By _signInContinueButton = By.XPath("//span[text()='Далее']");
        private readonly By _signInEmailLabel = By.XPath("//input[@id='identifierId']");
        private readonly By _errorMessageSpan = By.XPath("//h1[@id='headingText']/span");


        private const string _email = "zaraznaya.pochta@gmail.com";
        private const string expectedErrorText = "Не удалось войти в аккаунт";


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://google.com");
        }

        [Test]
        public void TryToLogin()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();


            Thread.Sleep(400);
            var email = driver.FindElement(_signInEmailLabel);
            email.SendKeys(_email);

            Thread.Sleep(400);
            var signInContinue = driver.FindElement(_signInContinueButton);
            signInContinue.Click();

            Thread.Sleep(600);
            var actualErrorText = driver.FindElement(_errorMessageSpan).Text;
            Assert.AreEqual(expectedErrorText, actualErrorText, "Text is incorrect");

            

            //Assert.Pass();
        }

       [Test]
       public void Test2()
        {
            driver.Navigate().GoToUrl("https://google.com");
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(600);
            driver.Quit();
        }
    }
}