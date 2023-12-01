using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourGuides_2_Selenium_Testing_Project.PageObjects
{
    internal class SelectedProductPage
    {
        private IWebDriver driver;

        public SelectedProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//input[contains(@title,'Adult x 1') and @class='ba-input__label-text' ]")]
        public IWebElement? AdultBtn { get; set; }
        [FindsBy(How = How.ClassName, Using = "participants-picker__input")]
        public IWebElement? AdultCount { get; set; }

        [FindsBy(How = How.ClassName, Using = "flatpickr-next-month")]
        public IWebElement? NextMonthBtn { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//input[@title=\"Select date\" and @class='ba-input__label-text']")]
        public IWebElement? SelectDateBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@data-date-value='2024-02-20']")]
        public IWebElement? DateBtn { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'gtm-trigger__adp-check-availability-btn')]")]
        public IWebElement? CheckAvailabilityBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='add-to-cart-button' and contains(@class,'c-button c-button--medium c-button--filled-standard gtm-trigger__add-to-cart-btn js-add-to-cart activity-option-cart-wrapper__add-to-cart')][1]")]
        public IWebElement? AddToCart { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='buy-now-button'][1]")]
        public IWebElement? BookNowBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'photo-gallery__wishlist--icon')]\r\n")]
        public IWebElement  ? WishListBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='review-filters-rating-5' and @type='checkbox']")]
        public IWebElement? FIveStarChkBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='review-filters-traveler-couple' and @type='checkbox']")]
        public IWebElement? CoupleChkBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "c-input__field")]
        public IWebElement? ReviewsSearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='new-list-modal']")]
        public IWebElement? CreateWishList { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='list-wishlist-title']")]
        public IWebElement? AddNewWishListName { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='list-wishlist-submit']")]
        public IWebElement? WishListSubmitBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@data-test-id='wishlist-header']")]
        public IWebElement? NavWishListBtn { get; set; }

        public Wishlist ClickNavWishListBtn()
        {
            NavWishListBtn.Click();
            return new Wishlist(driver);
        }
        public void ClickSubmitWishList()
        {
            WishListSubmitBtn.Click();
        }

        public void EnterNewWishListName(string WLName)
        {
            AddNewWishListName.SendKeys(Keys.Control + "a"); // Select all text
            AddNewWishListName.SendKeys(Keys.Delete);
           // AddNewWishListName.Clear();
            AddNewWishListName.SendKeys(WLName);
        }
        public void CLickCreateWishList()
        {
            CreateWishList.Click();
        }
        public void ClickWishListBtn()
        {
            WishListBtn.Click();
        }
       
        public void ClickAdultBtn()
        {

            AdultBtn.Click();
        }
        public void EnterAdultCount(string count)
        {
            AdultCount.Clear();
            AdultCount.SendKeys(count);
        }
        public void ClickSelectDate()
        {
            SelectDateBtn.Click();
        }
        public void ClickNextMonth()
        {
            NextMonthBtn.Click();
        }
        public void SelectDate()
        {
            DateBtn.Click();
        }
        public void ClickCheckAvailability()
        {
            CheckAvailabilityBtn.Click();
        }
        public void AddToWishListBtn()
        {
            WishListBtn.Click();    
        }
        public ShoppingCart ClickBookNow()
        {
            BookNowBtn.Click();
            //List<string> Windows = driver.WindowHandles.ToList();
            //driver.SwitchTo().Window(Windows[1]);
            return new ShoppingCart(driver);
        }
       
    }
}
