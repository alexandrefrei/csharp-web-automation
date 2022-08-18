using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebAutomation.PageObjects
{
    public class PopUpProductPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor

        public PopUpProductPage(IWebDriver driver)
        {
            _webDriver = driver;            
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            
        }

        #endregion Constructor

        #region Mapping Elements

        private IWebElement ProductText
        {
            get
            {
                return _webDriver.FindElement(By.Id("layer_cart_product_title"));
            }
        }

        private IWebElement ProductAddedText
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//div[@class='clearfix']//div[contains(@class,'layer_cart_product')]//h2"));
            }
        }

        private IWebElement ButtonCheckout
        {
            get
            {
                return _webDriver.FindElement(By.LinkText("Proceed to checkout"));
            }
        }

        private IWebElement PopupPage
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//div[@id='layer_cart']//div[@class='clearfix']"));
            }
        }

        #endregion Mapping Elements

        #region Mapping Events

        public string GetProductPopupPage()
        {
            return ProductText.Text;
        }

        public string GetProductAdded()
        {
            
            return ProductAddedText.Text;
        }

        public bool IsPopupEnabled()
        {
            Thread.Sleep(1000);
            return PopupPage.Displayed;
        }

        public SummaryPage ClickProceedCheckout()
        {

            ButtonCheckout.Click();

            return new SummaryPage(_webDriver);
        }

        #endregion Mapping Events
    }
}
