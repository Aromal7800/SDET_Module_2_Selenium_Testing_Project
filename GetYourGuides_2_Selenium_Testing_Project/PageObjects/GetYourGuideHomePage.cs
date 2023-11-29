using BunnyCart.Utilities;
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
    internal class GetYourGuideHomePage
    {
        IWebDriver driver;
        public GetYourGuideHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));    
            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How=How.ClassName,Using = "c-input__field")]
        public IWebElement? SearchBox { get; set; }
      
        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'js-navigation-link-wishlist')]")]
        public IWebElement? wishListBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-test-id='header-login-nav']")]
        public IWebElement? ProfileBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@data-test-id='header-login-link']")]
       public IWebElement? LogInOrSignUpBtn { get; set; }

        [FindsBy(How = How.Id, Using = "lookupEmail")]
        public IWebElement? ProfileEmailTextBar { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='submit']")]

        public IWebElement? SubmitEmailBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='fullName']")]
        public IWebElement? FullNameBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='password']")]
        public IWebElement? PasswordBar { get; set; }


        [FindsBy(How = How.Id, Using = "label-checkout-newsletter-opt-in")]
        public IWebElement? SentEmailsCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='signup-submit']")]
        public IWebElement? CreateAccountBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='login-button']")]
        public IWebElement? LogInBtn { get; set; }

        [FindsBy(How = How.Id, Using = "authentication__remember-me--checkbox")]
        public IWebElement? RemeberMeCheckBox { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='submit']")]

        public IWebElement? CartBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "c-modal__title")]

        public IWebElement? WelcomeBack { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Become a supplier')]")]
        public IWebElement? BecomeASupplier { get; set; }
        public SearchResultPage SearchLocation(string? serachItem)
        {
            SearchBox.SendKeys(serachItem);
            SearchBox.SendKeys(Keys.Enter);
            return new SearchResultPage(driver);
        }
        public void ClickProfile()
        {
           ProfileBtn?.Click();
            
        }
        public void ClickSignUpOrLogInBtn()
        {
            LogInOrSignUpBtn?.Click();
        }
        public void EnterEmail(string? email)
        {
            ProfileEmailTextBar?.SendKeys(email);
        }
        public void SubmitEmail()
        {
            SubmitEmailBtn?.Click();
        }
        public void EnterFullName(string? fullName)
        {
            FullNameBar?.SendKeys(fullName);
        }
        public void EnterPassword(string? password)
        {
            PasswordBar?.SendKeys(password);
        }
        public void ClickSentEmailsCheckBox()
        {

            SentEmailsCheckBox?.Click();

        }
        public void ClickCreateAccount()
        {
            CreateAccountBtn?.Click();
        }
    
        public void ClickRememberMeCheckBox()
        {

            RemeberMeCheckBox?.Click();
        }
        public void ClickLogIn()
        {
            LogInBtn?.Click();
        }
        public SearchResultPage SearchItem(string toSearch)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Eement Not Found";
            SearchBox = fluentWait.Until(driv =>
            {
                return SearchBox.Displayed ? SearchBox : null;
            });
            if (SearchBox != null)
            {
                SearchBox.SendKeys(toSearch);
                SearchBox.SendKeys(Keys.Enter);
                return new SearchResultPage(driver);
            }

            return new SearchResultPage(driver);

        }
    }
}
