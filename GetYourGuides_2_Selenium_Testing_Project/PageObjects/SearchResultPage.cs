using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourGuides_2_Selenium_Testing_Project.PageObjects
{
    internal class SearchResultPage
    {
        private IWebDriver driver;

        public SearchResultPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));    
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//section[contains(@id,'content grid')]//div[1]")]
        public IWebElement? SelectTour { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='trigger-filter-modal']")]
        public IWebElement? FilterToursbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-test-id='filter-modal-apply-btn']")]
        public IWebElement? SubmitFilterTours { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='search-filters-item-input-trigger-timeRanges-12-17']")]
        public IWebElement? SelectTiming { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='search-filters-item-input-trigger-themes-local_culture']")]
        public IWebElement? LocalActivity { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@data-test-id='search-filters-item-input-trigger-activityType-guidedTour']")]
        public IWebElement? GuideTour { get; set; }
        public SelectedProductPage SelectTourPage()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Eement Not Found";
            SelectTour = fluentWait.Until(driv =>
            {

                return SelectTour.Displayed ? SelectTour : null;
            });
            if (SelectTour != null)
            {
                ScrollIntoView(driver, SelectTour);
                SelectTour.Click();
                Thread.Sleep(5000);
                List<string> Windows = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(Windows[1]);
                
                return new SelectedProductPage(driver);
            }
            return new SelectedProductPage(driver);
        }

        public void ClickFilter()
        {
            FilterToursbtn.Click();
        }
        public void ClickSelectTiming()
        {
            SelectTiming.Click();
        }
        public void ClickGuideTour()
        {
            GuideTour.Click();
        }
        public void ClickLocalActivity()
        {
            LocalActivity.Click();
        }
        public void ClickSubmit()
        {
            SubmitFilterTours.Click();
        }
        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

    }
}
