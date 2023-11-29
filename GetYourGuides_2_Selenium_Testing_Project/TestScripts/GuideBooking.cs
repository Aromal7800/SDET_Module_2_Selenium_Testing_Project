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

namespace GetYourGuides_2_Selenium_Testing_Project.TestScripts
{
    internal class GuideBooking:CoreCodes
    {
        [Test]
        public void BookAGuide()
        {
            GetYourGuideHomePage GetYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
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
            
            string currdir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "BookGuide";

            List<GetYourGuide> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? logInEmail = excelData?.LogInEmail;
                string? logInPassword = excelData?.LogInPassword;
                string? search = excelData?.Search;
                string? adultCount = excelData?.AdultCount;
                
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

                GetYourGuide.RemeberMeCheckBox = fluentWait.Until(driv =>
                {
                    return GetYourGuide.RemeberMeCheckBox.Displayed ? GetYourGuide.RemeberMeCheckBox : null;
                });
                if (GetYourGuide.PasswordBar != null)
                {
                    GetYourGuide.ClickRememberMeCheckBox();
                }
                GetYourGuide.RemeberMeCheckBox = fluentWait.Until(driv =>
                {
                    return GetYourGuide.RemeberMeCheckBox.Displayed ? GetYourGuide.RemeberMeCheckBox : null;
                });
                if (GetYourGuide.PasswordBar != null)
                {
                    GetYourGuide.ClickRememberMeCheckBox();
                }
                GetYourGuide.LogInBtn = fluentWait.Until(driv =>
                {
                    return GetYourGuide.LogInBtn.Displayed ? GetYourGuide.LogInBtn : null;
                });
                if (GetYourGuide.LogInBtn != null)
                {

                    GetYourGuide.ClickLogIn();
                }
                
                Thread.Sleep(4000);
                var searchResultPg = GetYourGuide.SearchItem(search);
                Thread.Sleep(4000);
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
                searchResultPg.SubmitFilterTours = fluentWait.Until(driv =>
                {
                    return searchResultPg.SubmitFilterTours.Displayed ? searchResultPg.SubmitFilterTours : null;
                });
                if (searchResultPg.SubmitFilterTours != null)
                {

                    ScrollIntoView(driver, searchResultPg.SubmitFilterTours);
                    searchResultPg.ClickSubmit();

                }




                Thread.Sleep(5000);

                searchResultPg.SelectTour = fluentWait.Until(driv =>
                {
                    return searchResultPg.SelectTour.Displayed ? searchResultPg.SelectTour : null;
                });
                if (searchResultPg.SelectTour != null)
                {

                    ScrollIntoView(driver, searchResultPg.SelectTour);
                    

                }
                Thread.Sleep(3000);
                var selectedProductpg = searchResultPg.SelectTourPage();
                // ScrollIntoView(driver, searchResultPg.SelectTour);

                Thread.Sleep(3000);

                ScrollIntoView(driver, selectedProductpg.AdultBtn);

                selectedProductpg.AdultBtn = fluentWait.Until(driv =>
                {
                    return selectedProductpg.AdultBtn.Displayed ? selectedProductpg.AdultBtn : null;
                });
                if (selectedProductpg.AdultBtn != null)
                {

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
                Thread.Sleep(3000);

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
                var ShoppingCart= selectedProductpg.ClickBookNow();

/*
                ShoppingCart.PickUpLocation = fluentWait.Until(driv =>
                {
                    return ShoppingCart.PickUpLocation.Displayed ? ShoppingCart.PickUpLocation : null;
                });
                if (ShoppingCart.PickUpLocation != null)
                {
                    ScrollIntoView(driver, ShoppingCart.PickUpLocation);
                    ShoppingCart.ClickDoNotPickUp();

                }

          */     

                ShoppingCart.GoToCheckOut = fluentWait.Until(driv =>
                {
                    return ShoppingCart.GoToCheckOut.Displayed ? ShoppingCart.GoToCheckOut : null;
                });
                if (ShoppingCart.GoToCheckOut != null)
                {
                    ScrollIntoView(driver, ShoppingCart.GoToCheckOut);


                }
                Thread.Sleep(3000);
               var checkOutPage= ShoppingCart.ClickCheckOutBtn();  
            }
        }
    }
}
