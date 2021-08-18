using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectTest.PageObjects
{
    class GoogleAutorizationPageObject
    {
        private IWebDriver driver;

        public readonly By signInEmailLabelLocator = By.XPath("//input[@id='identifierId']");
        public readonly By signInContinueButtonLocator = By.CssSelector(".VfPpkd-vQzf8d");//'Continue' button
        public readonly By errorMessageSpanLocator = By.XPath("//h1[@id='headingText']/span");

        public GoogleAutorizationPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public GoogleAutorizationPageObject TryLogin (string email)
        {
            driver.FindElement(signInEmailLabelLocator).SendKeys(email);
            driver.FindElement(signInContinueButtonLocator).Click();
            return new GoogleAutorizationPageObject(driver);
        }

        public string GetErrorMessage()
        {
            string errorMessage = driver.FindElement(errorMessageSpanLocator).Text;
            return errorMessage;
        }
    }
}
