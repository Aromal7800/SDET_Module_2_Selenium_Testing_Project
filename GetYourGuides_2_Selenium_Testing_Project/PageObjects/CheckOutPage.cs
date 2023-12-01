using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourGuides_2_Selenium_Testing_Project.PageObjects
{
    internal class CheckOutPage
    {
        IWebDriver driver;
        public CheckOutPage(IWebDriver driver)
        { 
        this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver,this);

        }
        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='billing-fullname']")]
        public IWebElement CheckOutName { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='billing-email']")]
        public IWebElement CheckOutEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='billing-phone-nr']")]
        public IWebElement CheckOutPhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='country-form-select']")]
        public IWebElement CountryCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@id,'c-textarea-')]")]
        public IWebElement EnterTextArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'standard billing-form__personal-details__form__save')]")]
       public IWebElement CheckOutSaveBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "loading-button__label")]
        public IWebElement NextPaymentDetailsBtn { get; set; }
      
        public PaymentsPage ClickNextPaymentDetails()
        {
            NextPaymentDetailsBtn.Click();
            return new PaymentsPage(driver);
        }


        public void selectCountry()
        {
            SelectElement selectElement = new SelectElement(CountryCode);
            selectElement.SelectByText("Germany (+49)");
        }
        public void CheckOutNumber(string number)
        {
            CheckOutPhone.SendKeys(number);
        }

        public void SentText(string textInput)
        {
            EnterTextArea.SendKeys(textInput);
        }
        
    }
}
