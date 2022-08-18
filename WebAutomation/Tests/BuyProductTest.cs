using System;
using WebAutomation.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAutomation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebAutomation.DTO;
using WebAutomation.Utils;
using System.Linq;
using NLog;


namespace WebAutomation.Tests
{
    [TestClass]
    public class BuyProductTest : SetupBase
    {

        public static Logger logger;

        [TestMethod]
        public void BuyOneProduct()
        {
            try
            {                
                logger = LogManager.GetCurrentClassLogger();                
                logger.Info("Starting the Test.");

                //In the Home Page 
                logger.Info("Home Page --> Accessing the Home Page.");
                HomePage homePage = new HomePage(SetupBase.SeleniumWebDriver);                
                Assert.IsTrue(homePage.IsHome());
                
                logger.Info("Search product typing: dress.");
                SearchProductPage search = homePage.SearchProduct("dress");
                string searchProductText = search.GetProductTextSearchPage();

                //In the Search Page
                logger.Info("Search Page --> Select the first product and add the product in the cart.");
                PopUpProductPage popupProduct = search.SelectAndAddFirstProduct();

                //In the Popup - Verify if the product displayed in the popup is the same that is in the search page  
                logger.Info("Pop Up Page --> Verify if the product was successfully added.");
                Assert.IsTrue(popupProduct.IsPopupEnabled(),"Pop up Page is not enabled");
                string popupProductText = popupProduct.GetProductPopupPage();
                string productAddedText = popupProduct.GetProductAdded();

                logger.Info("Product Description on Pop up Page: {0}.", popupProductText);
                logger.Info("Product message on Pop up Page: {0}.", productAddedText);
                Assert.AreEqual("Product successfully added to your shopping cart", productAddedText);
                Assert.IsTrue(searchProductText.Contains(popupProductText));

                logger.Info("Clicking in the Proceed to Checkout.");
                SummaryPage summaryPage = popupProduct.ClickProceedCheckout();

                //In the SummaryPage -
                string numberProducts = summaryPage.GetNumberOfProducts();
                logger.Info("Summmary Page --> Getting number of products added: {0}.", numberProducts);
                Assert.AreEqual("1 Product", numberProducts);

                string totalProductSummaryPage = summaryPage.GetTotalProduct();
                string totalPriceSummaryPage = summaryPage.GetTotalPriceProduct();
                string summaryProductText = summaryPage.GetProductSummaryPage(0);
                logger.Info("Product Description on Summary Page: {0}.", summaryProductText);
                Assert.AreEqual(popupProductText, summaryProductText);   

                logger.Info("Clicking in the Proceed to Checkout.");
                LoginPage loginPage = summaryPage.ClickButtonCheckout();

                //In the LoginPage                 
                logger.Info("Login Page --> Validate if the  label Create an Account is displayed correctly.");
                string createAccountText = loginPage.GetCreataAccountText();
                Assert.AreEqual("CREATE AN ACCOUNT", createAccountText);

                logger.Info("Creating an account user data.");
                User user = CreateUserData();
                SignInPage signInPage = loginPage.CreateAccount(user.Email);

                //In the Sign In                
                logger.Info("Sign In --> Fill the registration Form.");
                AdressPage adressPage = signInPage.FillRegistrationForm(user);

                //In the Address Page - 
                logger.Info("Address Page --> Validate if the correct address is displayed.");
                string address = adressPage.GetAddressText();
                string country = adressPage.GetCountryText();
                string cityState = adressPage.GetCityStatePostalCodeText();                
                
                string fullAddress = user.Adress.AddressLineOne + " " + user.Adress.AddressLineTwo;
                string fullLocation = user.Adress.City + ", " + user.Adress.State.First().Value + " " + user.Adress.PostalCode;

                logger.Info("Full Address: {0}.", address);
                logger.Info("Country: {0}.", country);
                logger.Info("Full Location: {0}.", cityState);

                Assert.AreEqual(fullAddress, address);
                Assert.AreEqual(fullLocation, cityState);
                Assert.AreEqual(user.Adress.Country.First().Value, country);

                logger.Info("Clicking in the Proceed to Checkout.");
                ShippingPage shippingPage = adressPage.ClickProceedToCheckout();

                logger.Info("Shipping Page --> Clicking to accept the terms.");
                shippingPage.CickTermsOfServiceCheckBox();

                logger.Info("Clicking in the Proceed to Checkout.");
                PaymentPage paymentPage = shippingPage.ClickProceedToCheckout();

                //In the Payment Page - 
                logger.Info("Payment Page --> Validate the product price.");                
                string totalProductPaymentPage = paymentPage.GetTotalProduct();
                string totalShippingPaymentPage = paymentPage.GetTotalShipping();
                string totalPricePaymentePage = paymentPage.GetTotalPrice();
                logger.Info("Total Product: {0}.", totalProductPaymentPage);
                logger.Info("Total Shipping: {0}.", totalPricePaymentePage);
                logger.Info("Total Price: {0}.", totalPricePaymentePage);

                Assert.AreEqual(totalProductSummaryPage, totalProductPaymentPage);
                Assert.AreEqual("$2.00", totalShippingPaymentPage);
                Assert.AreEqual(totalPriceSummaryPage, totalPricePaymentePage);

                logger.Info("Clicking in Bank Payment method.");
                paymentPage.ClickPaymentBank();

                string totalAmountPaymentPage = paymentPage.GetTotalAmount();
                Assert.AreEqual(totalPricePaymentePage, totalAmountPaymentPage);

                logger.Info("Clicking in Confirm Order.");
                paymentPage.ClickConfirmOrder();

                logger.Info("Validate if the order was finalized with success.");
                Assert.IsTrue(paymentPage.IsDisplayedOrderFinalized());

                string orderFinalized = paymentPage.GetOrderFinalizedText();
                Assert.AreEqual("Your order on My Store is complete.", orderFinalized);

                string priceOrderFinalized = paymentPage.GetPriceOrderFinalized();
                Assert.AreEqual(totalPricePaymentePage, priceOrderFinalized);

                logger.Info("Clicking in Logout and Back to Home.");
                loginPage = paymentPage.ClickLogout();
                homePage = loginPage.ClickBackHome();
                Assert.IsTrue(homePage.IsHome());
                logger.Info("**** TEST PASSED ****");


                LogManager.Shutdown();
            }            
            catch (Exception e)
            {
                logger.Error("Error Message" + e.Message);                
                logger.Error("**** TEST FAILED ****");
                throw new Exception(e.Message);                
            }
}


        /// <summary>
        /// This method is used to create the user data. Here I just added the values hardcode, but we can read this data from txt files or a spreadsheet
        /// </summary>
        /// <returns></returns>
        private User CreateUserData()
        {
            User user = new User();

            user.GenderTitle = "Mister";
            user.FirstName = "John";
            user.LastName = "Doe";
            user.Email = "JohnDoe"+ Helpers.GenerateRandomString(3)+"@gmail.com";
            user.Password = "12345";
            user.DateOfBirthDay = "10";
            user.DateOfBirthMonth = "5";
            user.DateOfBirthYear = "1980";

            user.Adress.Company = "Company Co.";            
            user.Adress.AddressLastName = "DBServer";
            user.Adress.AddressLineOne = "234 Street";
            user.Adress.AddressLineTwo = "234 Avenue";
            user.Adress.City = "Los Angeles";            
            user.Adress.State.Add("5", "California");
            user.Adress.PostalCode = "12534";
            user.Adress.Country.Add("21", "United States");
            
            user.Phone.MobilePhone = "322143254";
            user.Adress.AddressAlias = "TecnoPuc";
            
            return user;
        }

    }
}
