using GetYourGuides_2_Selenium_Testing_Project.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDET_Module_2_Selenium_Testing_Project;
using Serilog;
using BunnyCart.Utilities;
using NUnit.Framework;

namespace GetYourGuides_2_Selenium_Testing_Project.TestScripts
{
    internal class WishListTest : CoreCodes
    {
        [Test]
        [Order(1)]
        [Category("E2E")]
        public void AddToWishList()
        {
            String currdir = Directory.GetParent(@"../../../").FullName;
            LogInfo();
            GetYourGuideHomePage GetYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1000);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";
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

            // string currdir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "WishList";

            List<GetYourGuide> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? logInEmail = excelData?.LogInEmail;
                string? logInPassword = excelData?.LogInPassword;
                string? wishListName = excelData?.WishListName; 

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
                Thread.Sleep(3000);

                GetYourGuide.SelectSports = fluentWait.Until(driv =>
                {
                    return GetYourGuide.SelectSports.Displayed ? GetYourGuide.SelectSports : null;
                });
                if (GetYourGuide.SelectSports != null)
                {
                    ScrollIntoView(driver, GetYourGuide.SelectSports);
                }
                Thread.Sleep(3000);

                GetYourGuide.ClickSelectSports();
                
                ScrollIntoView(driver, GetYourGuide.FristDisplayedSport);
                var selectedProduct = GetYourGuide.ClickFristDisplayedSport();
                Thread.Sleep(3000);

                selectedProduct.ClickWishListBtn();
                Thread.Sleep(3000);

                selectedProduct.CLickCreateWishList();
                Thread.Sleep(5000);
                selectedProduct.AddNewWishListName = fluentWait.Until(driv =>
                {
                    return selectedProduct.AddNewWishListName.Displayed ? selectedProduct.AddNewWishListName : null;
                });
                if (selectedProduct.AddNewWishListName != null)
                {
                    ScrollIntoView(driver, selectedProduct.AddNewWishListName);
                    selectedProduct.EnterNewWishListName(wishListName);
                }
               selectedProduct.ClickSubmitWishList();

                selectedProduct.NavWishListBtn = fluentWait.Until(driv =>
                {
                    return selectedProduct.NavWishListBtn.Displayed ? selectedProduct.NavWishListBtn : null;
                });

                Thread.Sleep(3000);
                var wishListPg = selectedProduct.ClickNavWishListBtn();
                TakeScreenShot();
                try
                {
                    Assert.True(wishListPg.CheckIfWishListCreated(wishListName));
                    LogTestResult("WishList Test - Pass", "WishList Test success");
                }
                catch (AssertionException ex)
                {
                    LogTestResult("WishList Test", "WishList Test failed");
                }
            }
        }
    }
    }

