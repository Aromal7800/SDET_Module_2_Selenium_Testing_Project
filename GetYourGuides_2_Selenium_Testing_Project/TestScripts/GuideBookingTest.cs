using BunnyCart.Utilities;
using GetYourGuides_2_Selenium_Testing_Project.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SDET_Module_2_Selenium_Testing_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Serilog;

namespace GetYourGuides_2_Selenium_Testing_Project.TestScripts
{
    internal class GuideBookingTest:CoreCodes
    {
        [Test]
        [Order(1)]
        [Category("E2E")]
        public void BookAGuide()
        {
            String currdir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyymmdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            GetYourGuideHomePage GetYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            GetYourGuide.ProfileBtn = fluentWait.Until(driv => { return GetYourGuide.ProfileBtn.Displayed ? GetYourGuide.ProfileBtn : null; });
            
             if (GetYourGuide.ProfileBtn != null)
             {
                 GetYourGuide.ClickProfile();
             }

             GetYourGuide.LogInOrSignUpBtn = fluentWait.Until(driv =>
             {
                 return GetYourGuide.LogInOrSignUpBtn.Displayed ? GetYourGuide.LogInOrSignUpBtn : null;
             });
             if (GetYourGuide.LogInOrSignUpBtn != null)
             {
                 GetYourGuide.ClickSignUpOrLogInBtn();
             }
            
            
            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "BookGuide";

            List<GetYourGuide> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? logInEmail = excelData?.LogInEmail;
                string? logInPassword = excelData?.LogInPassword;
                string? search = excelData?.Search;
                string? adultCount = excelData?.AdultCount;
                string? mobileNumber = excelData?.MobileNumber;
                string? text = excelData?.Text;

                GetYourGuide.ProfileEmailTextBar = fluentWait.Until(driv =>
                {
                    return GetYourGuide.ProfileEmailTextBar.Displayed ? GetYourGuide.ProfileEmailTextBar : null;
                });
                if (GetYourGuide.ProfileEmailTextBar != null)
                {
                    GetYourGuide.EnterEmail(logInEmail);
                }
                GetYourGuide.SubmitEmailBtn = fluentWait.Until(driv =>
                {
                    return GetYourGuide.SubmitEmailBtn.Displayed ? GetYourGuide.SubmitEmailBtn : null;
                });
                if (GetYourGuide.SubmitEmailBtn != null)
                {
                    GetYourGuide.SubmitEmail();
                }
                GetYourGuide.PasswordBar = fluentWait.Until(driv =>
                {
                    return GetYourGuide.PasswordBar.Displayed ? GetYourGuide.PasswordBar : null;
                });
                if (GetYourGuide.PasswordBar != null)
                {
                    //  Console.WriteLine(password);
                    GetYourGuide.EnterPassword(logInPassword);
                }

               
                    GetYourGuide.ClickRememberMeCheckBox();
               
               
              
                    GetYourGuide.ClickLogIn();

                GetYourGuide.SearchBox = fluentWait.Until(driv =>
                {
                    return GetYourGuide.SearchBox.Displayed ? GetYourGuide.SearchBox : null;
                });
                if (GetYourGuide.SearchBox != null)
                {
                   
                }
                var searchResultPg = GetYourGuide.SearchItem(search);
                
                searchResultPg.FilterToursbtn = fluentWait.Until(driv =>
                {
                    return searchResultPg.FilterToursbtn.Displayed ? searchResultPg.FilterToursbtn : null;
                });
                if (searchResultPg.FilterToursbtn != null)
                {

                    ScrollIntoView(driver, searchResultPg.FilterToursbtn);
                    searchResultPg.ClickFilter();

                }

                searchResultPg.SelectTiming = fluentWait.Until(driv =>
                {
                    return searchResultPg.SelectTiming.Displayed ? searchResultPg.SelectTiming : null;
                });
                if (searchResultPg.SelectTiming != null)
                {

                    ScrollIntoView(driver, searchResultPg.SelectTiming);
                    searchResultPg.ClickSelectTiming();

                }

                searchResultPg.GuideTour = fluentWait.Until(driv =>
                {
                    return searchResultPg.GuideTour.Displayed ? searchResultPg.GuideTour : null;
                });
                if (searchResultPg.GuideTour != null)
                {

                    ScrollIntoView(driver, searchResultPg.GuideTour);
                    searchResultPg.ClickGuideTour();

                }

                searchResultPg.LocalActivity = fluentWait.Until(driv =>
                {
                    return searchResultPg.LocalActivity.Displayed ? searchResultPg.LocalActivity : null;
                });
                if (searchResultPg.LocalActivity != null)
                {

                    ScrollIntoView(driver, searchResultPg.LocalActivity);
                    searchResultPg.ClickLocalActivity();

                }                         
                    ScrollIntoView(driver, searchResultPg.SubmitFilterTours);
                    searchResultPg.ClickSubmit();

                searchResultPg.SelectTour = fluentWait.Until(driv =>
                {
                    return searchResultPg.SelectTour.Displayed ? searchResultPg.SelectTour : null;
                });
                if (searchResultPg.SelectTour != null)
                {

                    ScrollIntoView(driver, searchResultPg.SelectTour);
                }
              //  Thread.Sleep(3000);
                var selectedProductpg = searchResultPg.SelectTourPage();
                // ScrollIntoView(driver, searchResultPg.SelectTour);
               // Thread.Sleep(3000);
                selectedProductpg.AdultBtn = fluentWait.Until(driv =>
                {
                    return selectedProductpg.AdultBtn.Displayed ? selectedProductpg.AdultBtn : null;
                });
                if (selectedProductpg.AdultBtn != null)
                {
                    ScrollIntoView(driver, selectedProductpg.AdultBtn);
                    selectedProductpg.ClickAdultBtn();

                }
                selectedProductpg.AdultCount = fluentWait.Until(driv =>
                {
                    return selectedProductpg.AdultCount.Displayed ? selectedProductpg.AdultCount : null;
                });
                if (selectedProductpg.AdultCount != null)
                {

                    selectedProductpg.EnterAdultCount(adultCount);

                }


                selectedProductpg.SelectDateBtn = fluentWait.Until(driv =>
                {
                    return selectedProductpg.SelectDateBtn.Displayed ? selectedProductpg.SelectDateBtn : null;
                });
                if (selectedProductpg.SelectDateBtn != null)
                {
                    ScrollIntoView(driver, selectedProductpg.SelectDateBtn);
                    selectedProductpg.ClickSelectDate();

                }
                selectedProductpg.NextMonthBtn = fluentWait.Until(driv =>
                {
                    return selectedProductpg.NextMonthBtn.Displayed ? selectedProductpg.NextMonthBtn : null;
                });
                if (selectedProductpg.NextMonthBtn != null)
                {
                    ScrollIntoView(driver, selectedProductpg.NextMonthBtn);
                    selectedProductpg.ClickNextMonth();

                }
                selectedProductpg.DateBtn = fluentWait.Until(driv =>
                {
                    return selectedProductpg.DateBtn.Displayed ? selectedProductpg.DateBtn : null;
                });
                if (selectedProductpg.DateBtn != null)
                {
                    ScrollIntoView(driver, selectedProductpg.DateBtn);
                    selectedProductpg.SelectDate();

                }
                selectedProductpg.CheckAvailabilityBtn = fluentWait.Until(driv =>
                {
                    return selectedProductpg.CheckAvailabilityBtn.Displayed ? selectedProductpg.CheckAvailabilityBtn : null;
                });
                if (selectedProductpg.CheckAvailabilityBtn != null)
                {
                    ScrollIntoView(driver, selectedProductpg.CheckAvailabilityBtn);
                    selectedProductpg.ClickCheckAvailability();

                }
                selectedProductpg.BookNowBtn = fluentWait.Until(driv =>
                {
                    return selectedProductpg.BookNowBtn.Displayed ? selectedProductpg.BookNowBtn : null;
                });
                if (selectedProductpg.BookNowBtn != null)
                {
                    ScrollIntoView(driver, selectedProductpg.BookNowBtn);
                }
                var ShoppingCart = selectedProductpg.ClickBookNow();
                
                while (driver.Url.Contains("https://www.getyourguide.com/checkout/activity"))
                {

                    ShoppingCart.PickUpLocation = fluentWait.Until(driv =>
                    {
                        return ShoppingCart.PickUpLocation.Displayed ? ShoppingCart.PickUpLocation : null;
                    });
                    if (ShoppingCart.PickUpLocation != null)
                    {
                        ScrollIntoView(driver, ShoppingCart.PickUpLocation);
                        ShoppingCart.ClickDoNotPickUp();
                    }
                }
                ShoppingCart.GoToCheckOut = fluentWait.Until(driv =>
                {
                    return ShoppingCart.GoToCheckOut.Displayed ? ShoppingCart.GoToCheckOut : null;
                });
                if (ShoppingCart.GoToCheckOut != null)
                {
                    ScrollIntoView(driver, ShoppingCart.GoToCheckOut);
                }
               var checkOutPage= ShoppingCart.ClickCheckOutBtn();

                checkOutPage.CheckOutPhone = fluentWait.Until(driv =>
                {
                    return checkOutPage.CheckOutPhone.Displayed ? checkOutPage.CheckOutPhone : null;
                });
                if (checkOutPage.CheckOutPhone != null)
                {
                    ScrollIntoView(driver, checkOutPage.CheckOutPhone);

                    checkOutPage.CheckOutNumber(mobileNumber);
                }
                

                checkOutPage.EnterTextArea = fluentWait.Until(driv =>
                {
                    return checkOutPage.EnterTextArea.Displayed ? checkOutPage.EnterTextArea : null;
                });
                if (checkOutPage.EnterTextArea != null)
                {
                    ScrollIntoView(driver, checkOutPage.EnterTextArea);

                    checkOutPage.SentText(text);
                }

               
             
                ScrollIntoView(driver, checkOutPage.NextPaymentDetailsBtn);   
                
                TakeScreenShot();

                try
                {
                    Assert.True(driver.Url.Contains("personal"));
                    LogTestResult("Booking Test - Pass", "Booking Test success");
               
                }
                catch (AssertionException ex)
                {

                    LogTestResult("Booking Test - Fail", "Booking Test failed");
                }

                var paymentsPage= checkOutPage.ClickNextPaymentDetails();

               
            }
        }
    }
}
