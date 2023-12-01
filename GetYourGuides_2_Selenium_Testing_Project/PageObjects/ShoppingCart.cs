using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourGuides_2_Selenium_Testing_Project.PageObjects
{
    internal class ShoppingCart
    {
        IWebDriver driver;
        public ShoppingCart(IWebDriver driver) 
        {
            this.driver=driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //button[@data-test-id='checkout-button']


        [FindsBy(How = How.XPath, Using = "//label[contains(@for,'booking_pickup_location-0-later')]")]
        public IWebElement PickUpLocation {  get; set; }
        [FindsBy(How=How.XPath,Using = "//button[@data-test-id='checkout-next-button']")]
        public IWebElement GoToCheckOut { get; set; }

       public CheckOutPage ClickCheckOutBtn()
        {
            GoToCheckOut.Click();
           // List<string> Windows = driver.WindowHandles.ToList();
            //driver.SwitchTo().Window(Windows[1]);
            return new CheckOutPage(driver);
        }

        public void ClickDoNotPickUp()
        {
            PickUpLocation.Click();
        }
        //input[@data-test-id='billing-fullname']
    }
}
