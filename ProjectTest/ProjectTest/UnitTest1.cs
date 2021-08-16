using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
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
        private readonly By _searchField = By.CssSelector(".gLFyf.gsfi");
        private readonly By _secondLink = By.CssSelector(".LC20lb.DKV0Md");



        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
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

            Thread.Sleep(1000);
            var actualErrorText = driver.FindElement(_errorMessageSpan).Text;
            Assert.AreEqual(expectedErrorText, actualErrorText, "Text is incorrect");
        }

        [Test]
        public void OpenFirstLink()
        {
            var searchField = driver.FindElement(_searchField);
            searchField.SendKeys("some test data" + Keys.Enter);

            var secondLink = driver.FindElements(_secondLink).ElementAt(5);// 1-first, 5-second, 6-third ....
            Actions actions = new Actions(driver); //move to needed element
            actions.MoveToElement(secondLink);
            actions.Perform();
            var linkName = secondLink.Text;

            secondLink.Click();

            Assert.AreEqual(linkName, driver.Title, "Tab name is incorrect");

        }

        [Test]
        public void Test3()
        {
            //открыть любую  2+ вкладку гугл поиска
        }

        [Test]
        public void Test4()
        {
            //открыть в конце страницы один из подобных запросов
        }


        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(600);
            driver.Quit();
        }
    }
}  