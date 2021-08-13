using NUnit.Framework;
using OpenQA.Selenium;

namespace ProjectTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _signInButton = By.XPath("//a[text()='Войти']");
        private readonly By _signInContinueButton = By.XPath("//span[text()='Далее']");

        private readonly By _signInEmailLabel = By.XPath("//input[@id='identifierId']");


        private const string _email = "zaraznaya.pochta@gmail.com";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://google.com");
        }

        [Test]
        public void Test1()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();


            var email = driver.FindElement(_signInEmailLabel);
            email.SendKeys(_email);

            var signInContinue = driver.FindElement(_signInContinueButton);
            signInContinue.Click();
            //Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}