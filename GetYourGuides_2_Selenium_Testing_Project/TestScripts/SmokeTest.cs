using GetYourGuides_2_Selenium_Testing_Project.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDET_Module_2_Selenium_Testing_Project;
using BunnyCart.Utilities;

namespace GetYourGuides_2_Selenium_Testing_Project.TestScripts
{
    internal class SmokeTest : CoreCodes
    {
        [Test]
        [Order(1)]
        [Category("SmokeTest")]
        public void LogoCheck()
        {
            LogInfo();
            GetYourGuideHomePage getYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            getYourGuide.SelectFood = fluentWait.Until(driv =>
            {
                return getYourGuide.SelectFood.Displayed ? getYourGuide.SelectFood : null;
            });
            if (getYourGuide.SelectFood != null)
            {
                ScrollIntoView(driver, getYourGuide.SelectFood);
            }
            getYourGuide.ClickSelectFood();

            var selectedProduct = getYourGuide.ClickSelectFristFood();

            selectedProduct.GoToHomePageLogo = fluentWait.Until(driv =>
            {
                return selectedProduct.GoToHomePageLogo.Displayed ? selectedProduct.GoToHomePageLogo : null;
            });
            if (selectedProduct.GoToHomePageLogo != null)
            {
                ScrollIntoView(driver, selectedProduct.GoToHomePageLogo);
            }
            var homePage = selectedProduct.HomePageLogoClick();
            TakeScreenShot();

            try
            {
                Assert.True(driver.Url == "https://www.getyourguide.com/");
                LogTestResult("Logo click check Test -Pass", "Logo click check Test success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Logo click check Test - Fail", "Logo click check Test failed");

            }

        }
        [Test]
        [Order(2)]
        [Category("SmokeTest")]
        public void ProfileDropdownHoverTest()
        {
            LogInfo();
            GetYourGuideHomePage getYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

           getYourGuide.ProfileBtnDropDownCheck();

            getYourGuide.HiddenProfileDropDown = fluentWait.Until(driv =>
            {
                return getYourGuide.HiddenProfileDropDown.Displayed ? getYourGuide.HiddenProfileDropDown : null;
            });
            if (getYourGuide.HiddenProfileDropDown != null)
            {
                ScrollIntoView(driver, getYourGuide.HiddenProfileDropDown);
            }
            TakeScreenShot();
            try
            {
                Assert.True(getYourGuide.HiddenProfileDropDown.Displayed);
                LogTestResult("profile dropdown hover Test ", "profile dropdown hover Test success");
 
            }
            catch (AssertionException ex)
            {

                LogTestResult("profile dropdown hover Test - Fail", "profile dropdown hover Test failed");
           }
        }

        [Test]
        [Order(3)]
        [Category("SmokeTest")]
        public void CheckAllLinks()
        {
            LogInfo();
            GetYourGuideHomePage getYourGuide = new GetYourGuideHomePage(driver);

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";

            CheckLinkStatus("https://www.getyourguide.com/");

            try
            {
                Assert.That(driver.Url.Contains("https://www.getyourguide.com/"));
                LogTestResult("Check all links Test - Pass", "Check all links Test success");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Check all links Test - Fail", "Check all links Test failed");
            }

        }
    }
}
