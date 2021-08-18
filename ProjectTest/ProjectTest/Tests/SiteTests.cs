using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using ProjectTest.PageObjects;
using System;
using System.Linq;
using System.Threading;

namespace ProjectTest.Tests
{
    public class SiteTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://facebook.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void Test1()
        {

        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(600);
            driver.Quit();
        }
    }
}
