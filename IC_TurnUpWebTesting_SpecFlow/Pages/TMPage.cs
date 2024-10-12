using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.Debugger;
using System;
using System.Linq.Expressions;


namespace IC_TurnUpWeb.Pages
{
    public class TMPage
    {
        //locators
        private readonly By createBtnXpath = By.XPath("//*[@id=\"container\"]/p/a");
        private readonly By tMDropDownXpath = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span");
        private readonly By timeXPath = By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]");
        private readonly By priceTxtBoxXpath = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]");
        private readonly By lastPageBtnXpath = By.XPath("//a[contains(@title, 'Go to the last page')]");
        private readonly By descResultXpath = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]");
        private readonly By codeResultXpath = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]");
        private readonly By priceResultXpath = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]");
        private readonly By editBtnXpath = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        //"//*[@id="tmsGrid"]/div[3]/div[2]/table/tbody/tr[8]/td[5]/a[1]"
        private readonly By deleteBtnXpath = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]");

        private readonly By codeTxtBoxID = By.Id("Code");
        private readonly By descTxtBoxID = By.Id("Description");
        private readonly By saveBtnID = By.Id("SaveButton");
        private readonly By priceBoxID = By.Id("Price");

        //Values
        private readonly string codeValue = "IC_123";
        private readonly string descValue = "myTesting1!";
        private readonly string priceValue = "199";
        //private readonly string newCodeValue = "IC_123456";
        //private readonly string newDescValue = "myTesting1!-edited";
        //private readonly string newPriceValue = "100";


        public void CreateNewRecord(IWebDriver driver)
        {

            //1.Click Create
            try
            {
                CustomMethods.Click(driver, createBtnXpath);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Fail to find Create btn - {ex.Message}");
            }
            //Thread.Sleep(2000);

            //2. Select Time from dropdown
            Wait.WaitToBeClickable(driver, tMDropDownXpath, 5);

            CustomMethods.Click(driver, tMDropDownXpath);
            //Thread.Sleep(1000);

            //2a. Select time
            Wait.WaitToBeClickable(driver, timeXPath, 10);

            CustomMethods.Click(driver, timeXPath);

            //4.Enter Code
            CustomMethods.OnlyEnterText(driver, codeTxtBoxID, codeValue);

            //5.Enter Description
            CustomMethods.OnlyEnterText(driver, descTxtBoxID, descValue);

            //6.Enter Price
            CustomMethods.OnlyEnterText(driver, priceTxtBoxXpath, priceValue);

            //7.Click Save
            Wait.WaitToBeClickable(driver, saveBtnID, 1);

            CustomMethods.Submit(driver, saveBtnID);

            //8.Go to the last page
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 2);

            CustomMethods.Click(driver, lastPageBtnXpath);

            //9. Check if record is created or not
            Wait.WaitToBeVisible(driver, descResultXpath, 2);

            //if (recordDescribtion.Text.Contains("myTesting1!"))
            //{
            //    Assert.Pass("Record created successfully!");
            //}
            //else
            //{
            //    Assert.Fail("Record failed to create!");
            //}
        }

        public void EditRecord(IWebDriver driver, string editedCodeValue, string editedDescValue, string editdPriceValue)
        {

            // Go to last page
            Thread.Sleep(1000);
            //Wait.WaitToBeClickable(driver, lastPageBtnXpath, 20);

            CustomMethods.Click(driver, lastPageBtnXpath);

            //1.Find Edit btn and click
            Wait.WaitToBeClickable(driver, editBtnXpath, 10);

            try
            {
                CustomMethods.Click(driver, editBtnXpath);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Fail to find Edit btn - {ex.Message}");
            }
            

            //2. Select dropdown
            Wait.WaitToBeClickable(driver, tMDropDownXpath, 10);

            CustomMethods.Click(driver, tMDropDownXpath);
            //Thread.Sleep(2000);

            //2a. Select time
            Wait.WaitToBeClickable(driver,timeXPath, 10);

            CustomMethods.Click(driver, timeXPath);

            //3.Enter Code
            CustomMethods.ClearEnterText(driver, codeTxtBoxID, editedCodeValue);
            

            //5.Enter Description
            
            CustomMethods.ClearEnterText(driver, descTxtBoxID, editedDescValue);

            //6.Enter Price
            CustomMethods.Click(driver, priceTxtBoxXpath);
            CustomMethods.Clear(driver, priceBoxID);
            CustomMethods.Click(driver, priceTxtBoxXpath);
            CustomMethods.OnlyEnterText(driver, priceBoxID, editdPriceValue);


            //7.Click Save
            //Thread.Sleep(3000);
            Wait.WaitToBeClickable(driver, saveBtnID, 10);
            try
            {
                CustomMethods.Submit(driver, saveBtnID);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Fail to find Save btn - {ex.Message}");
            }

            //Thread.Sleep(3000);
            //8.Go to the last page
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 15);

            CustomMethods.Click(driver, lastPageBtnXpath);

            //Thread.Sleep(3000);
            //9. Check edited record
            Wait.WaitToBeVisible(driver, descResultXpath, 10);

            //IWebElement descRecordEdited = driver.FindElement(descResultXpath);

            //Assert.That(descRecordEdited.Text.Contains(newDescValue), "Record failed to edit!");

        }

        public void DeleteRecord(IWebDriver driver)
        {
            // Go to last page
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);
            //1.Find Delete btn and click

            Wait.WaitToBeClickable(driver, deleteBtnXpath, 5);
            CustomMethods.Click(driver, deleteBtnXpath);
            
            //2. Confirm delete
            Wait.WaitAlertVisible(driver, 5);
            CustomMethods.AcceptAlert(driver);
        }

        public string GetTextValue(IWebDriver driver, string columnName)
        {
            IWebElement result;
            if (columnName == "code")
            {
                result = driver.FindElement(codeResultXpath);
            }
            else if (columnName == "desc")
            {
                result = driver.FindElement(descResultXpath);
            }
            else if (columnName == "price")
            {
                result = driver.FindElement(priceResultXpath);
            }
            else {
                return string.Empty;
            }
            //IWebElement result = driver.FindElement(loactor);
            return result.Text;
        }
    }
}
