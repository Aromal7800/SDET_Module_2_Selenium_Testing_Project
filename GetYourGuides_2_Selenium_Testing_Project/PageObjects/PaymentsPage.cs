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
        public IWebElement CardHolderName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@maxlength ='24']")]
        public IWebElement AccNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder ='MM/YY']")]
        public IWebElement ExpiaryDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder ='3 digits']")]
        public IWebElement CVVNumber { get; set; }

        public void EnterCVV(string cvv)
        {
            CVVNumber.SendKeys(cvv);
        }
        public void EnterExpiaryDate(string date)
        {
            ExpiaryDate.SendKeys(date);
        }

        public void EnterAccNumber(string AccNo)
        {
            AccNumber.SendKeys(AccNo);
        }



    }
}
