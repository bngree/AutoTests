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
        private IWebDriver _webDriver;

        public readonly By signInButtonLocator = By.CssSelector(".gb_3.gb_4.gb_9d.gb_3c");//'Login' button
        public readonly By searchFieldLocator = By.CssSelector(".gLFyf.gsfi");
        public readonly By tabLinkLocator = By.CssSelector(".LC20lb.DKV0Md");
        public readonly By changeTabLinkLocator = By.CssSelector(".SJajHc.NVbCr");
        public readonly By currentSearchTabLocator = By.CssSelector(".YyVfkd");


        public GoogleSearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GoogleAutorizationPageObject SignIn()
        {
            _webDriver.FindElement(signInButtonLocator).Click();
            return new GoogleAutorizationPageObject(_webDriver);
        }

        public GoogleSearchPageObject Search(string searchQuery)
        {
            _webDriver.FindElement(searchFieldLocator).SendKeys(searchQuery + Keys.Enter);
            return new GoogleSearchPageObject(_webDriver);
        }

        public string GetLinkName(int linkNum)
        {
            return _webDriver.FindElements(tabLinkLocator).ElementAt(linkNum).Text;
        }

        public GoogleSearchPageObject OpenLink(int linkNum)
        {
            var tabLink = _webDriver.FindElements(tabLinkLocator).ElementAt(linkNum);
            Actions actions = new Actions(_webDriver); //move to needed element
            actions.MoveToElement(tabLink);
            actions.Perform();
            tabLink.Click();
            return new GoogleSearchPageObject(_webDriver);
        }

        public string GetTabName()
        {
            return _webDriver.Title;
        }

        public void OpenNextTab(int tabNum)
        {
            var tabChangeLink = _webDriver.FindElements(changeTabLinkLocator).ElementAt(tabNum);
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(tabChangeLink).Perform();
            //actions.Perform();
            tabChangeLink.Click();
        }

        public int  GetCurrentTabNum()
        {
            int currentTabNum = Int32.Parse(_webDriver.FindElement(currentSearchTabLocator).Text);
            return currentTabNum;
        }

    }
}
