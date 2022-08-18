using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAutomation.TestBase
{
    [TestClass]
    public class SetupBase
    {
        public static IWebDriver SeleniumWebDriver { get; set; }
        

        [TestInitialize]
        public void InitializeTestWebDriver()
        {            
            if (SeleniumWebDriver == null)
            {
                var configValue = Enum.Parse(typeof(Browser), ConfigurationManager.AppSettings["WebDriver"]);

                switch (configValue)
                {
                    case Browser.Chrome:
                        SeleniumWebDriver = new ChromeDriver();
                        break;

                    case Browser.Firefox:
                        SeleniumWebDriver = new FirefoxDriver();
                        break;

                    case Browser.IE:
                        SeleniumWebDriver = new InternetExplorerDriver();
                        break;

                    default:
                        SeleniumWebDriver = null;
                        break;
                }                                
            }

            SeleniumWebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Host"]);
            SeleniumWebDriver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Cleanup()
        {                        
            if (SeleniumWebDriver != null)
            {
                SeleniumWebDriver.Close();
                SeleniumWebDriver.Quit();
            }
        }
    }
}
