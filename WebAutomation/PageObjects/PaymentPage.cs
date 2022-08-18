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
    public class PaymentPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor

        public PaymentPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }

        #endregion Constructor

        #region Mapping Elements

        private IWebElement PaymentBank
        {
            get
            {
                return _webDriver.FindElement(By.ClassName("bankwire"));
            }
        }

        private IWebElement PaymentCheck
        {
            get
            {
                return _webDriver.FindElement(By.ClassName("cheque"));
            }
        }

        private IWebElement TotalProductValue
        {
            get
            {
                return _webDriver.FindElement(By.Id("total_product"));
            }
        }

        private IWebElement TotalShippingValue
        {
            get
            {
                return _webDriver.FindElement(By.Id("total_shipping"));
            }
        }

        private IWebElement TotalPriceValue
        {
            get
            {
                return _webDriver.FindElement(By.Id("total_price_container"));
            }
        }

        private IWebElement TotalAmountValue
        {
            get
            {
                return _webDriver.FindElement(By.Id("amount"));
            }
        }

        private IWebElement ButtonConfirmOrder
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//p[@id='cart_navigation']/button"));
            }            
        }

        private IWebElement OrderFinalizedLabel
        {
            get
            {
                return _webDriver.FindElement(By.ClassName("cheque-indent"));
            }
        }

        private IWebElement PriceOrderFinalized
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@class='price']"));
            }

        }

        private IWebElement ButtonLogout
        {
            get
            {
                return _webDriver.FindElement(By.ClassName("logout"));
            }

        }

        #endregion Mapping Elements

        #region Mapping Events

        public void ClickPaymentBank()
        {
            PaymentBank.Click();
        }

        public void ClickPaymentCheck()
        {
            PaymentCheck.Click();
        }

        public void ClickConfirmOrder()
        {
            ButtonConfirmOrder.Click();
        }

        public LoginPage ClickLogout()
        {
            ButtonLogout.Click();
            return new LoginPage(_webDriver);
        }
        
        public string GetTotalProduct()
        {
            return TotalProductValue.Text;
        }

        public string GetTotalShipping()
        {
            return TotalShippingValue.Text;
        }
         
        public string GetTotalPrice()
        {
            return TotalPriceValue.Text;
        }

        public string GetTotalAmount()
        {
            return TotalAmountValue.Text;
        }

        public string GetOrderFinalizedText()
        {
            return OrderFinalizedLabel.Text;
        }

        public bool IsDisplayedOrderFinalized()
        {
            return OrderFinalizedLabel.Displayed;
        }

        public string GetPriceOrderFinalized()
        {
            return PriceOrderFinalized.Text;
        }

        #endregion Mapping Events
    }
}
