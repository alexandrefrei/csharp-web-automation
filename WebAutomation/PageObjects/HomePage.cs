using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;


namespace WebAutomation.PageObjects
{
    
    public class HomePage
    {
        //The idea is to use two patterns: Page Objects and Page Factory, to show an example using Page Factory pattern
        //The entire is not using the Page Factory pattern, because not support .Net Core. 
        //This is why I define not use this pattern to map the elements.

        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor

        public HomePage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            PageFactory.InitElements(_webDriver, this);

        }

        #endregion Constructor

        #region Mapping Elements

        [FindsBy(How = How.ClassName, Using = "homefeatured")]
        private IWebElement HomePopular;

        //Below are two ways on how to declare the property.
        private IWebElement SearchTextBox => _webDriver.FindElement(By.Id("search_query_top"));
        
        private IWebElement SearchButton
        {
            get
            {
                return _webDriver.FindElement(By.Name("submit_search"));
            }
        }
        
        #endregion mapping Elements

        #region Mapping Events

        public bool IsHome()
        {
            return HomePopular.Displayed;
        }
       
        public SearchProductPage SearchProduct(string value)
        {        
            SearchTextBox.SendKeys(value);
            SearchButton.Click();

            return new SearchProductPage(_webDriver);            
        }
        
        #endregion Mapping Events
    }
}
