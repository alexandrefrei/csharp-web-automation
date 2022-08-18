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
    public class SignInPage
    {
        #region Class Variables

        private IWebDriver _webDriver;

        #endregion Class Variables

        #region Constructor

        public SignInPage(IWebDriver driver)
        {
            _webDriver = driver;
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }

        #endregion Constructor

        #region Mapping Elements

        private IReadOnlyCollection<IWebElement> SignInLabels
        {
            get
            {
                return _webDriver.FindElements(By.XPath("//*[@id='account-creation_form']//div[@class='account_creation']//h3"));
            }
        }

        private IWebElement GenderMisterRadioBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("id_gender1"));
            }
        }

        private IWebElement GenderMissRadioBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("id_gender2"));
            }
        }

        private IWebElement FirstNameTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("customer_firstname"));
            }
        }

        private IWebElement LastNameTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("customer_lastname"));
            }
        }

        private IWebElement EmailTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("email"));
            }
        }

        private IWebElement PasswordTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("passwd"));
            }
        }

        private SelectElement DateOfBirthDaysComboBox
        {
            get
            {
                //Another ways to map dropdowns
                //SelectElement selectElement = new SelectElement(_webDriver.FindElement(By.XPath("//div[@id='uniform-days']//select")));
				
				//Select drop down list
                IWebElement listOfDay = _webDriver.FindElement(By.Id("days"));
                //Create Select element object
                SelectElement selectElement = new SelectElement(listOfDay);

                return selectElement;
            }
        }

        private SelectElement DateOfBirthMonthComboBox
        {
            get
            {
                //Select drop down list
                IWebElement listOfDay = _webDriver.FindElement(By.Id("months"));
                //Create Select element object
                SelectElement selectElement = new SelectElement(listOfDay);

                return selectElement;
            }
        }

        private SelectElement DateOfBirthYearComboBox
        {
            get
            {
                //Select drop down list
                IWebElement listOfDay = _webDriver.FindElement(By.Id("years"));
                //Create Select element object
                SelectElement selectElement = new SelectElement(listOfDay);

                return selectElement;
            }
        }

        private IWebElement AddressFirstNameTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("firstname"));
            }
        }

        private IWebElement AddressLastNameTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("lastname"));
            }
        }

        private IWebElement CompanyTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("company"));
            }
        }

        private IWebElement AddressLineOneTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("address1"));
            }
        }

        private IWebElement AddressLineTwoTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("address2"));
            }
        }

        private IWebElement CityTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("city"));
            }
        }

        private SelectElement StateComboBox
        {
            get
            {
                //Select drop down list
                IWebElement listOfDay = _webDriver.FindElement(By.Id("id_state"));
                //Create Select element object
                SelectElement selectElement = new SelectElement(listOfDay);

                return selectElement;
            }
        }

        private IWebElement PostCodeTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("postcode"));
            }
        }

        private SelectElement CountryComboBox
        {
            get
            {
                //Select drop down list
                IWebElement listOfDay = _webDriver.FindElement(By.Id("id_country"));
                //Create Select element object
                SelectElement selectElement = new SelectElement(listOfDay);

                return selectElement;
            }
        }

        private IWebElement MobilePhoneTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("phone_mobile"));
            }
        }

        private IWebElement AddressAliasTextBox
        {
            get
            {
                return _webDriver.FindElement(By.Id("alias"));
            }
        }

        private IWebElement ButtonRegister
        {
            get
            {
                return _webDriver.FindElement(By.Id("submitAccount"));
            }
        }

        #endregion Mapping Elements

        #region Mapping Events

        public AdressPage FillRegistrationForm(User user)
        {
            if (user.GenderTitle == "Mister")
                GenderMisterRadioBox.Click();
            else
                GenderMissRadioBox.Click();

            FirstNameTextBox.SendKeys(user.FirstName);
            LastNameTextBox.SendKeys(user.LastName);
            PasswordTextBox.SendKeys(user.Password);

            DateOfBirthDaysComboBox.SelectByValue(user.DateOfBirthDay);
            DateOfBirthMonthComboBox.SelectByValue(user.DateOfBirthMonth);
            DateOfBirthYearComboBox.SelectByValue(user.DateOfBirthYear);
            CompanyTextBox.SendKeys(user.Adress.Company);
            AddressLineOneTextBox.SendKeys(user.Adress.AddressLineOne);
            AddressLineTwoTextBox.SendKeys(user.Adress.AddressLineTwo);
            CityTextBox.SendKeys(user.Adress.City);
            StateComboBox.SelectByValue(user.Adress.State.First().Key);
            PostCodeTextBox.SendKeys(user.Adress.PostalCode);
            CountryComboBox.SelectByValue(user.Adress.Country.First().Key);
            MobilePhoneTextBox.SendKeys(user.Phone.MobilePhone);
            AddressAliasTextBox.SendKeys(user.Adress.AddressAlias);

            ButtonRegister.Click();

            return new AdressPage(_webDriver);
        }
        #endregion Mapping Events
    }
}
