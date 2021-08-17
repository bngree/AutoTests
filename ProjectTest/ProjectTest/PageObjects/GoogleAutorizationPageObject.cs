using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectTest.PageObjects
{
    class GoogleAutorizationPageObject
    {
        private IWebDriver _webDriver;

        public readonly By _signInEmailLabel = By.XPath("//input[@id='identifierId']");
        public readonly By _signInContinueButton = By.CssSelector(".VfPpkd-vQzf8d");//'Continue' button
        public readonly By _errorMessageSpan = By.XPath("//h1[@id='headingText']/span");

        public GoogleAutorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public GoogleAutorizationPageObject TryLogin (string email)
        {
            _webDriver.FindElement(_signInEmailLabel).SendKeys(email);
            _webDriver.FindElement(_signInContinueButton).Click();
            return new GoogleAutorizationPageObject(_webDriver);
        }

        public string GetErrorMessage()
        {
            string errorMessage = _webDriver.FindElement(_errorMessageSpan).Text;
            return errorMessage;
        }
    }
}
