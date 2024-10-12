using IC_TurnUpWeb.Pages;
using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace IC_TurnUpWebTesting_SpecFlow.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : ComWebDriver
    {
        TMPage tmPageObj = new TMPage();

        ////li[contains(@class, \"dropdown\")]/a[contains(text(),\"Administration \")]
        private readonly By administrationXpath = By.XPath("//li[contains(@class, \"dropdown\")]/a[contains(text(),\"Administration \")]");
        private readonly By tMXPath = By.XPath("//li/a[contains(text(),\"Time & Materials\")]");

        //private readonly By tMXPath = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        //private readonly By administrationXpath = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");

        [BeforeScenario]
        public void Setup()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
        }

        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            //Login
            loginPageObj.LoginAction(driver);
            
        }

        [Given(@"I navigate to Time and Material page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            //Navigate to TmPage
            homePageObj.NavigateToPage(driver, administrationXpath, tMXPath);
        }

        [When(@"I create a time record")]
        public void WhenICreateATimeRecord()
        {
            tmPageObj.CreateNewRecord(driver);
        }

        [Then(@"the time record should be created successfully")]
        public void ThenTheTimeRecordShouldBeCreatedSuccessfully()
        {

            Assert.That(tmPageObj.GetTextValue(driver, "code").Equals("IC_123"), "Record failed to create!");
            Assert.That(tmPageObj.GetTextValue(driver, "desc").Equals("myTesting1!"), "Record failed to create!");
            Assert.That(tmPageObj.GetTextValue(driver, "price").Contains("199"), "Record failed to create!");
        }

        [When(@"I update the '([^']*)', '([^']*)' and '([^']*)' on an existing Time records")]
        public void WhenIUpdateTheAndOnAnExistingTimeRecords(string code, string description, string price)
        {
            tmPageObj.EditRecord(driver, code, description, price);
        }

        [Then(@"the time record should be updated successfully with '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheTimeRecordShouldBeUpdatedSuccessfullyWithAnd(string code, string description, string price)
        {
            Assert.That(tmPageObj.GetTextValue(driver, "code").Equals(code), "Record failed to create!");
            Assert.That(tmPageObj.GetTextValue(driver, "desc").Equals(description), "Record failed to create!");
            Assert.That(tmPageObj.GetTextValue(driver, "price").Contains(price), "Record failed to create!");
        }

        [Given(@"I delete and existing Time/Metrial record")]
        public void GivenIDeleteAndExistingTimeMetrialRecord()
        {
            tmPageObj.DeleteRecord(driver);
        }

        [Then(@"the record should be deleted sucessfully")]
        public void ThenTheRecordShouldBeDeletedSucessfully()
        {
            throw new PendingStepException();
        }


        [AfterScenario]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
