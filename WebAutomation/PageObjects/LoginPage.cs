using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace WebAutomation.PageObjects
{
    public class LoginPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor
        public LoginPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }

        #endregion Constructor

        #region Mapping Elements

        private IWebElement CreateAccountLabel
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@id='create-account_form']//h3"));
            }
        }

        private IWebElement EmailTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("email_create"));
            }
        }

        private IWebElement ButtonCreateAccount
        {
            get
            {
                return _webDriver.FindElement(By.Id("SubmitCreate"));
            }
        }

        private IWebElement LogoPage
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@class='logo img-responsive']"));
            }
        }

        #endregion Mapping Elements

        #region Mapping Events

        public string GetCreataAccountText()
        {
            return CreateAccountLabel.Text;
        }

        public SignInPage CreateAccount(string emailValue)
        {
            EmailTextBox.SendKeys(emailValue);
            ButtonCreateAccount.Click();

            return new SignInPage(_webDriver);
        }

        public HomePage ClickBackHome()
        {
            LogoPage.Click();

            return new HomePage(_webDriver);
        }

        #endregion Mapping Events
    }
}
