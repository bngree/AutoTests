using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTest.PageObjects
{
    class GoogleSearchPageObject
    {
        private IWebDriver driver;

        public readonly By signInButtonLocator = By.CssSelector(".gb_3.gb_4.gb_9d.gb_3c");//'Login' button
        public readonly By searchFieldLocator = By.XPath("//input[@class='gLFyf gsfi']");
        public readonly By tabLinkLocator = By.CssSelector(".LC20lb.DKV0Md");
        public readonly By changeTabLinkLocator = By.CssSelector(".SJajHc.NVbCr");
        public readonly By currentSearchTabLocator = By.CssSelector(".YyVfkd");
        public readonly By relatedSearchesLocator = By.CssSelector(".s75CSd.OhScic.AB4Wff");


        public GoogleSearchPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public GoogleAutorizationPageObject SignIn()
        {
            driver.FindElement(signInButtonLocator).Click();
            return new GoogleAutorizationPageObject(driver);
        }

        public GoogleSearchPageObject Search(string searchQuery)
        {
            driver.FindElement(searchFieldLocator).SendKeys(searchQuery + Keys.Enter);
            return new GoogleSearchPageObject(driver);
        }

        public string GetLinkName(int linkNum)
        {
            return driver.FindElements(tabLinkLocator).ElementAt(linkNum).Text;
        }

        public GoogleSearchPageObject OpenLink(int linkNum)
        {
            var tabLink = driver.FindElements(tabLinkLocator).ElementAt(linkNum);
            Actions actions = new Actions(driver); //move to needed element
            actions.MoveToElement(tabLink).Perform();
            tabLink.Click();
            return new GoogleSearchPageObject(driver);
        }

        public string GetTabName()
        {
            return driver.Title;
        }

        public void OpenNextTab(int tabNum)
        {
            var tabChangeLink = driver.FindElements(changeTabLinkLocator).ElementAt(tabNum);
            Actions actions = new Actions(driver);
            actions.MoveToElement(tabChangeLink).Perform();
            tabChangeLink.Click();
        }

        public int  GetCurrentTabNum()
        {
            int currentTabNum = Int32.Parse(driver.FindElement(currentSearchTabLocator).Text);
            return currentTabNum;
        }

        public void OpenRelatedSearchLink (int relatedSearchLinkNum)
        {
            var relatedSearchLink = driver.FindElements(relatedSearchesLocator).ElementAt(relatedSearchLinkNum);
            Actions actions = new Actions(driver);
            actions.MoveToElement(relatedSearchLink).Perform();
            relatedSearchLink.Click();
        }

        public string GetRelatedSearchName (int relatedSearchLinkNum)
        {
            var relatedSearchLink = driver.FindElements(relatedSearchesLocator).ElementAt(relatedSearchLinkNum);
            return relatedSearchLink.Text;
        }

        public string GetSearchQueueText()
        {
            string searchQueue = driver.FindElement(searchFieldLocator).GetAttribute("value");
            return searchQueue;
        }

    }
}
