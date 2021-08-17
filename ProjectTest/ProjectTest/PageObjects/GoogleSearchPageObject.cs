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

        public readonly By _signInButton = By.CssSelector(".gb_3.gb_4.gb_9d.gb_3c");//'Login' button
        
        public readonly By _searchField = By.CssSelector(".gLFyf.gsfi");
        public readonly By _tabLink = By.CssSelector(".LC20lb.DKV0Md");


        public GoogleSearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GoogleAutorizationPageObject SignIn()
        {
            _webDriver.FindElement(_signInButton).Click();
            return new GoogleAutorizationPageObject(_webDriver);
        }

        public GoogleSearchPageObject Search(string searchQuery)
        {
            _webDriver.FindElement(_searchField).SendKeys(searchQuery + Keys.Enter);
            return new GoogleSearchPageObject(_webDriver);
        }

        public string GetLinkName(int linkNum)
        {
            return _webDriver.FindElements(_tabLink).ElementAt(linkNum).Text;
        }

        public GoogleSearchPageObject OpenLink(int linkNum)
        {
            var tabLink = _webDriver.FindElements(_tabLink).ElementAt(linkNum);
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

    }
}
