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

namespace GetYourGuides_2_Selenium_Testing_Project.TestScripts
{
    internal class SmokeTest : CoreCodes
    {
        [Test]
        public void ProfileDropdownHoverTest()
        {
            String currdir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyymmdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
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

            try
            {
                Assert.True(getYourGuide.HiddenProfileDropDown.Displayed);
                LogTestResult("profile dropdown hover Test ", "profile dropdown hover Test success");
                // Log.Information("Booking Test success");

                test = extent.CreateTest("profile dropdown hover Test - Pass");
                test.Pass("profile dropdown hover Test success");
                // Console.WriteLine("ERCP");
            }
            catch (AssertionException ex)
            {
                //Log.Error($"Test failed for Create Account. \n Exception : {ex.Message}");

                LogTestResult("profile dropdown hover Test - Fail", "profile dropdown hover Test failed");


                test = extent.CreateTest("profile dropdown hover Test - Fail");
                test.Fail("profile dropdown hover Test failed");
                // Console.WriteLine("ERCF");
            }


        }
    }
}