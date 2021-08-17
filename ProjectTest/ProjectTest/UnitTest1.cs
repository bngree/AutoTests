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
        public readonly By _signInButton = By.CssSelector(".gb_3.gb_4.gb_9d.gb_3c");//'Login' button
        public readonly By _signInContinueButton = By.CssSelector(".VfPpkd-vQzf8d");//'Continue' button
        public readonly By _signInEmailLabel = By.XPath("//input[@id='identifierId']");
        public readonly By _errorMessageSpan = By.XPath("//h1[@id='headingText']/span");

        public const string _email = "zaraznaya.pochta@gmail.com";
        public const string _expectedErrorText = "Не удалось войти в аккаунт";

        //OpenFirstLink
        public readonly By _searchField = By.CssSelector(".gLFyf.gsfi");
        public readonly By _tabLink = By.CssSelector(".LC20lb.DKV0Md");

        //OpenSecondSearchTab



        //OpenLinkedSearches


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
            Assert.AreEqual(_expectedErrorText, actualErrorText, "Text is incorrect");
        }

        [Test]
        public void OpenFirstLink()
        {
            var searchField = driver.FindElement(_searchField);
            searchField.SendKeys("some test data" + Keys.Enter);

            var tabLink = driver.FindElements(_tabLink).ElementAt(7);// 1-first, 5-second, 6-third ....
            Actions actions = new Actions(driver); //move to needed element
            actions.MoveToElement(tabLink);
            actions.Perform();
            var linkName = tabLink.Text;

            tabLink.Click();

            Assert.AreEqual(linkName, driver.Title, "Tab name is incorrect");

        }

        [Test]
        public void OpenSecondSearchTab()
        {
            //открыть любую  2+ вкладку гугл поиска
        }

        [Test]
        public void OpenLinkedSearches()
        {
            //открыть в конце страницы один из подобных запросов
        }


        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(600);
            //driver.Quit();
        }
    }
}  