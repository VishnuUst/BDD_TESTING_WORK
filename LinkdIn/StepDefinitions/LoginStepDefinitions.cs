using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkdIn.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        public static IWebDriver? driver;
        private IWebElement? passwordInput;
        

       [BeforeFeature]
        public static void IntializeBrowser()
        {    
            driver = new ChromeDriver();


        }
        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://linkedin.com";
        }

        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [When(@"User will enter username")]
        public void WhenUserWillEnterUsername()
        {
            DefaultWait<IWebDriver?> fluentwait = new DefaultWait<IWebDriver?>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement? emailInput = fluentwait.Until(driv => driv?.FindElement(By.Id("session_key")));
            emailInput?.SendKeys("abc@xyz.com");
        }

        [When(@"User will enter password")]
        public void WhenUserWillEnterPassword()
        {
            DefaultWait<IWebDriver?> fluentwait = new DefaultWait<IWebDriver?>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            passwordInput = fluentwait.Until(driv => driv?.FindElement(By.Id("session_password")));
            passwordInput?.SendKeys("1234");
            Console.WriteLine(passwordInput.GetAttribute("value"));

        }

        [When(@"User will click on login button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);",
                driver?.FindElement(By.XPath("//button[@type='submit']")));
            Thread.Sleep(5000);
            js?.ExecuteScript("arguments[0].click();",
               driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will redirect to Homepage")]
        public void ThenUserWillRedirectToHomepage()
        {
            Assert.That(driver.Title.Contains("Log In")); 
        }
        [Then(@"Error message for password length should be throw")]
        public void ThenErrorMessageForPasswordLengthShouldBeThrow()
        {

            IWebElement? alertPara = driver?.FindElement(By.XPath("//p[@for='session_password']"));
            string?alertText = alertPara?.Text;
            Assert.That(alertText.Contains("password"));
        }
        [When(@"User will click on Show link in the password textbox")]
        public void WhenUserWillClickOnShowLinkInThePasswordTextbox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Show']"));
            showButton.Click();
        }

        [Then(@"the password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click on Hide link in the password textbox")]
        public void WhenUserWillClickOnHideLinkInThePasswordTextbox()
        {
            IWebElement hideButton = driver.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton.Click();
        }

        [Then(@"the password characters should go back to \*")]
        public void ThenThePasswordCharactersShouldGoBackTo()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }

    }
}
