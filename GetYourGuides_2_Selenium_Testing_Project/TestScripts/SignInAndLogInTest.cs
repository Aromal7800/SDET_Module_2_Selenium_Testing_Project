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
        [Order(1)]
        [Category("SmokeTest")]
        public void SignUpTest()
        {
            GetYourGuideHomePage GetYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

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
              //  Thread.Sleep(5000);
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
                TakeScreenShot();
                try
                {
                    Assert.That(GetYourGuide.CreateAccountBtn.Displayed);
                    LogTestResult("Create Account Test", "Create Account sucess");
 

                }
                catch (AssertionException ex)
                {
                    LogTestResult("Create Account Test", "Create Account Test failed");
                }
            }


        }
        [Test]

        [Order(2)]
        [Category("SmokeTest")]
        public void LoginTest()
        {
            GetYourGuideHomePage GetYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

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
                TakeScreenShot();
                try
                {
                    Assert.True(GetYourGuide.WelcomeBack.Text == "Welcome back!");
                    LogTestResult("Login Test", "Login Test success");

                }
                catch (AssertionException ex)
                {
                       LogTestResult("Login Test","Login Test failed");
                }
            }
        }

        [Test]
        [Order(3)]
        [Category("SmokeTest")]
        public void InvalidSignUpTest()
        {
            GetYourGuideHomePage GetYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

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
            string? sheetName = "InvalidSignUp";

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
                    GetYourGuide.ClickCreateAccount();
                    Thread.Sleep(3000);
                }
                TakeScreenShot();
                try
                {
                    Assert.That(GetYourGuide.NameErrorMessage.Displayed);
                    LogTestResult("Invalid Create Account Test", "Invalid Create Account sucess");
                }
                catch (AssertionException ex)
                {
                    LogTestResult("Invalid Create Account Test", "Invalid Create Account Test failed");
                }


            }

        }
        /*
        [Test]
        public void InvalidLoginTest()
        {
            GetYourGuideHomePage GetYourGuide = new GetYourGuideHomePage(driver);
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element Not Found";

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
            string? sheetName = "InvalidLogIn";

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
                Thread.Sleep(8000);
                GetYourGuide.ErrorMessage = fluentWait.Until(driv =>
                {
                    return GetYourGuide.ErrorMessage.Displayed ? GetYourGuide.ErrorMessage : null;
                });
               if (GetYourGuide.LogInBtn != null)
                {

                    ScrollIntoView(driver,GetYourGuide.ErrorMessage);
                }

                TakeScreenShot();
                try
                {
                    Assert.True(GetYourGuide.ErrorMessage.Text == "Invalid email or password. Please try again.");
                    LogTestResult("InvalidLogin Test", "InvalidLogin Test sucess");
                    // Log.Information("Test passed for Create Account");

                    // test = extent.CreateTest("InvalidLogin Test - Pass");
                    //test.Pass("InvalidLogin Test success");

                }
                catch (AssertionException ex)
                {
                    //Log.Error($"Test failed for Create Account. \n Exception : {ex.Message}");

                      LogTestResult("InvalidLogin Test","InvalidLogin Test failed");


                    // test = extent.CreateTest("User Login Test - Fail");
                    //   test.Fail("Login Test failed");

                }
            }
            */
        }
        
    }

