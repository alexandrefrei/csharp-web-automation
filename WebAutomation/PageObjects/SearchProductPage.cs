using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace WebAutomation.PageObjects
{
    public class SearchProductPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor
        public SearchProductPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        

        }

        #endregion Constructor

        #region Mapping Elements

        private IReadOnlyCollection<IWebElement> ListProducts
        {
            get
            {
                return _webDriver.FindElements(By.XPath("//div[@class='product-container']"));
            }
        }
               
        private IReadOnlyCollection<IWebElement> ButtonAddCart
        {
            get
            {
                return _webDriver.FindElements(By.ClassName("ajax_add_to_cart_button"));
            }
        }
        
        #endregion Mapping Elements

        #region Mapping Events

        public PopUpProductPage SelectAndAddFirstProduct()
        {
            if (ListProducts.Count > 0)
            {                
                ListProducts.ElementAt(0).Click();
                ButtonAddCart.ElementAt(0).Click();
                                
                return new PopUpProductPage(_webDriver);
            }
                
            else
                throw new Exception("There is no Product.");

        }

        public string GetProductTextSearchPage()
        {
            return ListProducts.ElementAt(0).Text;
        }

        public PopUpProductPage SelectProductByIndex(int index)
        {
            if (ListProducts.Count > 0)
            {
                ListProducts.ElementAt(index).Click();
                ButtonAddCart.ElementAt(index).Click();

                return new PopUpProductPage(_webDriver);
            }

            else
                throw new Exception("There is no Product.");
        }


        #endregion Mapping Events
    }
}
