using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebAutomation.DTO;

namespace WebAutomation.PageObjects
{
    public class ShippingPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor

        public ShippingPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        #endregion Constructor

        #region Mapping Elements
        private IWebElement TermsOfServiceCheckBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("cgv"));
            }
        }

        private IWebElement ButtonProceedCheckout
        {
            get
            {
                return _webDriver.FindElement(By.Name("processCarrier"));
            }
        }

        #endregion Mapping Elements

        #region Mapping Events

        public void CickTermsOfServiceCheckBox()
        {
            TermsOfServiceCheckBox.Click();
        }

        public PaymentPage ClickProceedToCheckout()
        {
            ButtonProceedCheckout.Click();

            return new PaymentPage(_webDriver);
        }

        #endregion Mapping Events
    }
}
