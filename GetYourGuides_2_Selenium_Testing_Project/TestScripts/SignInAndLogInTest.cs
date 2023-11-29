using BunnyCart.Utilities;
using GetYourGuides_2_Selenium_Testing_Project.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SDET_Module_2_Selenium_Testing_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GetYourGuides_2_Selenium_Testing_Project.TestScripts
{

    internal class SignInAndLogInTest : CoreCodes
    {
        [Test]
        public void SignUpTest()
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
            Thread.Sleep(4000);
            string currdir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "SignUp";

            List<GetYourGuide> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? fullName = excelData?.FullName;
                string? email = excelData?.Email;
                string? password = excelData?.Password;

                GetYourGuide.ProfileEmailTextBar = fluentWait.Until(driv =>
                {
                    return GetYourGuide.ProfileEmailTextBar.Displayed ? GetYourGuide.ProfileEmailTextBar : null;
                });
                if (GetYourGuide.ProfileEmailTextBar != null)
                {
                    GetYourGuide.EnterEmail(email);
                }
                GetYourGuide.SubmitEmailBtn = fluentWait.Until(driv =>
                {
                    return GetYourGuide.SubmitEmailBtn.Displayed ? GetYourGuide.SubmitEmailBtn : null;
                });
                if (GetYourGuide.SubmitEmailBtn != null)
                {
                    GetYourGuide.SubmitEmail();
                }
                Thread.Sleep(4000);

                GetYourGuide.FullNameBar = fluentWait.Until(driv =>
                {
                    return GetYourGuide.FullNameBar.Displayed ? GetYourGuide.FullNameBar : null;
                });
                if (GetYourGuide.FullNameBar != null)
                {
                    GetYourGuide.EnterFullName(fullName);
                }

                GetYourGuide.PasswordBar = fluentWait.Until(driv =>
                {
                    return GetYourGuide.PasswordBar.Displayed ? GetYourGuide.PasswordBar : null;
                });
                if (GetYourGuide.PasswordBar != null)
                {
                    Console.WriteLine(password);
                    GetYourGuide.EnterPassword(password);
                }
                Thread.Sleep(5000);
                GetYourGuide.SentEmailsCheckBox = fluentWait.Until(driv =>
                {
                    return GetYourGuide.SentEmailsCheckBox.Displayed ? GetYourGuide.SentEmailsCheckBox : null;
                });
                if (GetYourGuide.SentEmailsCheckBox != null)
                {
                    GetYourGuide.ClickSentEmailsCheckBox();
                }

                GetYourGuide.CreateAccountBtn = fluentWait.Until(driv =>
                {
                    return GetYourGuide.CreateAccountBtn.Displayed ? GetYourGuide.CreateAccountBtn : null;
                });
                if (GetYourGuide.CreateAccountBtn != null)
                {
                    // GetYourGuide.ClickCreateAccount();
                }
                try
                {
                    Assert.That(GetYourGuide.CreateAccountBtn.Displayed);
                    //  LogTestResult("Create Account Link Test","Create Account Link sucess");
                    // Log.Information("Test passed for Create Account");

                    test = extent.CreateTest("Create Account Test - Pass");
                    test.Pass("Create Account success");
                    Console.WriteLine("ERCP");
                }
                catch (AssertionException ex)
                {
                    //Log.Error($"Test failed for Create Account. \n Exception : {ex.Message}");

                    //   LogTestResult("Create Account Link Test","Create Account Link failed");


                    test = extent.CreateTest("Create Account Link Test - Fail");
                    test.Fail("Create Account Link failed");
                    Console.WriteLine("ERCF");
                }
            }


        }
        [Test]
        public void LoginTest()
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
            string? sheetName = "LogIn";

            List<GetYourGuide> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? logInEmail = excelData?.LogInEmail;
                string? logInPassword = excelData?.LogInPassword;

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

                try
                {
                    Assert.True(GetYourGuide.WelcomeBack.Text == "Welcome back!");
                    //  LogTestResult("Create Account Link Test","Create Account Link sucess");
                    // Log.Information("Test passed for Create Account");

                    test = extent.CreateTest("User Login Test - Pass");
                    test.Pass("Login Test success");
                    // Console.WriteLine("ERCP");
                }
                catch (AssertionException ex)
                {
                    //Log.Error($"Test failed for Create Account. \n Exception : {ex.Message}");

                    //   LogTestResult("Create Account Link Test","Create Account Link failed");


                    test = extent.CreateTest("User Login Test - Fail");
                    test.Fail("Login Test failed");
                    // Console.WriteLine("ERCF");
                }
            }
        }
      
    }
}
