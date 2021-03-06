using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectTest.PageObjects;
using System;
using System.Linq;
using System.Threading;

namespace ProjectTest.Tests
{
    public class GoogleTests
    {
        private IWebDriver driver;

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
            var GoogleSearch = new GoogleSearchPageObject(driver);
            GoogleSearch
                .SignIn()
                .TryLogin(VariablesForTests.email);
            Thread.Sleep(1000);
            var GoogleAuth = new GoogleAutorizationPageObject(driver);
            string actualErrorText = GoogleAuth.GetErrorMessage();
            Assert.AreEqual(VariablesForTests.expectedErrorText, actualErrorText, "Text is incorrect");
        }

        [Test]
        public void OpenLink()
        {
            var GoogleSearch = new GoogleSearchPageObject(driver);
            GoogleSearch
                .Search(VariablesForTests.searchQuery);
            string linkName = GoogleSearch.GetLinkName(VariablesForTests.linkNum);
            GoogleSearch
                .OpenLink(VariablesForTests.linkNum);
            Assert.AreEqual(linkName, GoogleSearch.GetTabName(), "Tab name is incorrect");
            //StringAssert.Contains(linkName, GoogleSearch.GetTabName(), "Link name is incorrect");            
        }

        [Test]
        public void OpenNextSearchTab()
        {
            var GoogleSearch = new GoogleSearchPageObject(driver);
            GoogleSearch
                .Search(VariablesForTests.searchQuery);
            GoogleSearch.OpenNextTab(VariablesForTests.tabNum);
            int currentTab = GoogleSearch.GetCurrentTabNum();
            Assert.AreEqual(VariablesForTests.tabNum+2, currentTab, "Tab number is not correct"); //+2 cause we counting from zero + first search tab is not counting
        }

        [Test]
        public void OpenLinkedSearches()
        {
            //??????? ? ????? ???????? ???? ?? ???????? ????????
            var GoogleSearch = new GoogleSearchPageObject(driver);
            GoogleSearch
                .Search(VariablesForTests.searchQuery);
            string expectedQueueName = GoogleSearch.GetRelatedSearchName(VariablesForTests.relatedSearchesNum);
            GoogleSearch.OpenRelatedSearchLink(VariablesForTests.relatedSearchesNum);
            
            StringAssert.Contains(expectedQueueName.ToLower(), GoogleSearch.GetSearchQueueText().ToLower(), "Link name is incorrect");
           
        }


        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(600);
            driver.Quit();
        }
    }
}  