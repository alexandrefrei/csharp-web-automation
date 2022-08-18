using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;


namespace WebAutomation.PageObjects
{
    public class SummaryPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor

        public SummaryPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }

        #endregion Constructor

        #region Mapping Elements

        private IWebElement NumberOfProducts
        {
            get
            {
                return _webDriver.FindElement(By.Id("summary_products_quantity"));
            }
        }

        private IReadOnlyList<IWebElement> ListProducts
        {
            get
            {
                return _webDriver.FindElements(By.XPath("//td[@class='cart_description']//p[@class='product-name']"));
            }
        }

        private IWebElement ButtonCheckout
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//a[@class='button btn btn-default standard-checkout button-medium']"));
            }
        }

        private IWebElement TotalProductValue
        {
            get
            {
                return _webDriver.FindElement(By.Id("total_product"));
            }
        }

        private IWebElement TotalPriceValue
        {
            get
            {
                return _webDriver.FindElement(By.Id("total_price"));
            }
        }

        #endregion Mapping Elements

        #region Mapping Events

        public LoginPage ClickButtonCheckout()
        {
            ButtonCheckout.Click();

            return new LoginPage(_webDriver);
        }
        
        public string GetNumberOfProducts()
        {
            return NumberOfProducts.Text;
        }

        public string GetProductSummaryPage(int index)
        {
            return ListProducts[index].Text;
        }

        public string GetTotalProduct()
        {
            return TotalProductValue.Text;
        }

        public string GetTotalPriceProduct()
        {
            return TotalPriceValue.Text;
        }

        #endregion Mapping Events
    }
}
