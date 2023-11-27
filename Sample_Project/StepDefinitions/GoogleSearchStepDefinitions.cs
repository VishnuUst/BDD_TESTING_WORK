using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Sample_Project.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        public IWebDriver driver;
        [BeforeScenario] public void IntializeBrowser()
        {
            driver = new ChromeDriver();
           
        }
        [AfterScenario] public void CloseBrowser()
        {
            driver?.Close();
        }
        [Given(@"Google home page should be loaded")]
        public void GivenGoogleHomePageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }

        [When(@"Type ""(.*)"" in the search text box")]
        public void WhenTypeInTheSearchTextBox(string searchtext)
        {
            IWebElement searchinput = driver.FindElement(By.Id("APjFqb"));
            searchinput.SendKeys(searchtext);
        }

        [When(@"Click on the Google search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement? googleButton = fluentwait.Until(x =>
            {
                IWebElement? searchBtn = driver.FindElement(By.Name("btnK"));
                return searchBtn.Displayed ? searchBtn : null;
            });
            if(googleButton != null)
            {
                googleButton.Click();
            }
           

        }

        [Then(@"the results should be displayed on the next page with title ""(.*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPage(string title)
        {
            Assert.That(driver.Title, Is.EqualTo(title));
        }
        [When(@"Click on the IMFL button")]
        public void WhenClickOnTheIMFLButton()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            IWebElement? imflB = fluentwait.Until(x =>
            {
                IWebElement? searchBtn = driver.FindElement(By.Name("btnI"));
                return searchBtn.Displayed ? searchBtn : null;
            });
            if (imflB != null)
            {
                imflB.Click();
            }

        }

        [Then(@"the results should be redirected to a new page with title ""(.*)""")]
        public void ThenTheResultsShouldBeRedirectedToANewPageWithTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }

    }
}
