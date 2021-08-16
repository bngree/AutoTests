using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace ProjectTest
{
    public class Tests
    {
        private IWebDriver driver;

        //TryToLoginGoogle
        private readonly By _signInButton = By.XPath("//a[text()='Войти']");
        private readonly By _signInContinueButton = By.XPath("//span[text()='Далее']");
        private readonly By _signInEmailLabel = By.XPath("//input[@id='identifierId']");
        private readonly By _errorMessageSpan = By.XPath("//h1[@id='headingText']/span");

        private const string _email = "zaraznaya.pochta@gmail.com";
        private const string expectedErrorText = "Не удалось войти в аккаунт";

        //OpenFirstLink
        //private readonly By _searchField = By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input");
        private readonly By _searchField = By.CssSelector(".gLFyf.gsfi");



        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void TryToLoginGoogle()
        {
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();



            var email = driver.FindElement(_signInEmailLabel);
            email.SendKeys(_email);

            var signInContinue = driver.FindElement(_signInContinueButton);
            signInContinue.Click();

            Thread.Sleep(600);
            var actualErrorText = driver.FindElement(_errorMessageSpan).Text;
            Assert.AreEqual(expectedErrorText, actualErrorText, "Text is incorrect");

            

            //Assert.Pass();
        } 

       [Test]
       public void OpenFirstLink()
        {
            var searchField = driver.FindElement(_searchField);
            searchField.SendKeys("some test data" + Keys.Enter);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(600);
            //driver.Quit();
        }
    }
}  