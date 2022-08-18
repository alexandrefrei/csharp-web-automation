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
    public class AdressPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor

        public AdressPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }

        #endregion Constructor

        #region Mapping Elements

        private IWebElement FirstLastNameText
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@id='address_delivery']//li[@class='address_firstname address_lastname']"));
            }
        }
       
        private IWebElement AddressLineText
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@id='address_delivery']//li[@class='address_address1 address_address2']"));
            }
        }

        private IWebElement CityStatePostalCodeText
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@id='address_delivery']//li[@class='address_city address_state_name address_postcode']"));
            }
        }

        private IWebElement CountryText
        {
            get
            {
                return _webDriver.FindElement(By.XPath("//*[@id='address_delivery']//li[@class='address_country_name']"));
            }
        }       

        private IWebElement ButtonProceedCheckout
        {
            get
            {
                return _webDriver.FindElement(By.Name("processAddress"));
            }
        }

        #endregion Mapping Elements

        #region Mapping Events

        public string GetFirstLastNameText()
        {
            return FirstLastNameText.Text;
        }        

        public string GetAddressText()
        {
            return AddressLineText.Text;
        }

        public string GetCityStatePostalCodeText()
        {
            return CityStatePostalCodeText.Text;
        }

        public string GetCountryText()
        {
            return CountryText.Text;
        }        
        
        public ShippingPage ClickProceedToCheckout()
        {
            ButtonProceedCheckout.Click();

            return new ShippingPage(_webDriver);
        }

        #endregion Mapping Events

    }


}
