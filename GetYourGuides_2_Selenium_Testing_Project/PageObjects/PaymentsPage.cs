using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourGuides_2_Selenium_Testing_Project.PageObjects
{
    internal class PaymentsPage
    {
        IWebDriver driver;
        public PaymentsPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//input[@name ='holderName']")]
        IWebElement CardHolderName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder ='1234 5678 9012 3456']")]
        IWebElement AccNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder ='MM/YY']")]
        IWebElement ExpiaryDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder ='3 digits']")]
        IWebElement CVVNumber { get; set; }






    }
}
