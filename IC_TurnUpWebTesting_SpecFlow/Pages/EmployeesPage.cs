using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.Browser;
using OpenQA.Selenium.Support.UI;


namespace IC_TurnUpWeb.Pages
{
    public class EmployeesPage
    {
        //locators
        private readonly By createBtnXpath = By.XPath("//*[@id=\"container\"]/p/a");
        private readonly By vehicalTxtBoxXpath = By.XPath("//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span/input");
        private readonly By grpDropDownXpath = By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]");
        private readonly By backLinkXpath = By.XPath("//*[@id=\"container\"]/div/a");
        private readonly By lastPageBtnXpath = By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]");
        private readonly By grpIdxXpath = By.XPath("//*[@id=\"groupList_listbox\"]/li[72]");
        private readonly By newGrpIdxXpath = By.XPath("//*[@id=\"groupList_listbox\"]/li[67]");
        private readonly By editBtnXpath = By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]");
        private readonly By uNResultXpath = By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]");
        private readonly By nameResultXpath = By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]");
        private readonly By deleteBtnXpath = By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]");

        private readonly By nameTxtBoxId = By.Id("Name");
        private readonly By uNameTxtBoxId = By.Id("Username");
        private readonly By pwTxtBoxId = By.Id("Password");
        private readonly By rePWTxtBoxId = By.Id("RetypePassword");
        private readonly By isAdminCheckBoxId = By.Id("IsAdmin");
        private readonly By grpListId = By.Id("groupList_listbox");
        private readonly By saveBtnId = By.Id("SaveButton");
        private readonly By editContactBtnId = By.Id("EditContactButton");

        private readonly By fNameTxtBoxId = By.Id("FirstName");
        private readonly By lNameTxtBoxId = By.Id("LastName");
        private readonly By phoneTxtBoxId = By.Id("Phone");
        private readonly By emailTxtBoxId = By.Id("email");
        private readonly By addyTxtBoxId = By.Id("autocomplete");
        private readonly By cityTxtBoxId = By.Id("City");
        private readonly By countryTxtBoxId = By.Id("Country");
        private readonly By saveContactBtnId = By.Id("submitButton");
        private readonly By contractDisplayId = By.Id("ContactDisplay");


        //Values
        private readonly string nameVal = "harry";
        private readonly string uNameVal = "mytest101";
        private readonly string pwVal = "123QWEasd$";
        private readonly string vehicalVal = "car";
        private readonly string newNameVal = "harrynew";
        private readonly string newUNVal = "mytestnew101";
        private readonly string newPWVal = "321QWEasd!";
        private readonly string fNameVal = "fntest";
        private readonly string lNameVal = "lntest";
        private readonly string phoneVal = "0123456789";
        private readonly string emailVal = "test@gmail.com";
        private readonly string addyVal = "123 Street";
        private readonly string cityVal = "Akl";
        private readonly string countryVal = "NZ";

        public void CreateNewEmploye(IWebDriver driver)
        {
            //1.Click Create
            try
            {
                CustomMethods.Click(driver,createBtnXpath);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Fail to find Create btn - {ex.Message}");

            }

            //2.Fill name
            Wait.WaitToBeVisible(driver, nameTxtBoxId, 5);
            CustomMethods.OnlyEnterText(driver, nameTxtBoxId, nameVal);

            //3.Fill username
            CustomMethods.OnlyEnterText(driver, uNameTxtBoxId, uNameVal);

            //4.Fill password
            CustomMethods.OnlyEnterText(driver, pwTxtBoxId, pwVal);

            //5.Fill retype password
            CustomMethods.OnlyEnterText(driver, rePWTxtBoxId, pwVal);

            //6.Tick isadmin box
            CustomMethods.Click(driver, isAdminCheckBoxId);

            //7. Fill Vehical
            CustomMethods.OnlyEnterText(driver, vehicalTxtBoxXpath, vehicalVal);

            //8. Select Group
            CustomMethods.Click(driver, grpDropDownXpath);
            Wait.WaitToBeVisible(driver, grpListId, 5);
            CustomMethods.Click(driver, grpIdxXpath);

            //9. Save create
            CustomMethods.Submit(driver, saveBtnId);
            Thread.Sleep(1000);

            //10. Check if record is created or not
            CustomMethods.Click(driver, backLinkXpath);
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);

            //check Username values
            Wait.WaitToBeVisible(driver, uNResultXpath, 1);
            IWebElement uNameRecord= driver.FindElement(uNResultXpath);
            Assert.That(uNameRecord.Text.Contains(uNameVal), "Record failed to create!");

        }

        public void EditEmployee(IWebDriver driver) 
        {
            //1. Goto last page
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);

            //2. Click Edit btn
            Wait.WaitToBeClickable(driver, editBtnXpath, 5);
            CustomMethods.Click(driver, editBtnXpath);

            //3. Update Name
            Wait.WaitToBeVisible(driver, nameTxtBoxId, 5);
            CustomMethods.ClearEnterText(driver, nameTxtBoxId, newNameVal);

            //4. Update UserName
            CustomMethods.ClearEnterText(driver, uNameTxtBoxId, newUNVal);

            //5. Update Password
            CustomMethods.ClearEnterText(driver, pwTxtBoxId, newPWVal);
            CustomMethods.ClearEnterText(driver, rePWTxtBoxId, newPWVal);

            //6. Untick IsAdmin
            CustomMethods.Click(driver, isAdminCheckBoxId);

            //7. Add another group
            CustomMethods.Click(driver, grpDropDownXpath);
            Wait.WaitToBeVisible(driver, grpListId, 5);
            CustomMethods.Click(driver, newGrpIdxXpath);

            //8. Save Changes
            CustomMethods.Submit(driver, saveBtnId);
            Thread.Sleep(1000);

            //9. Check results
            CustomMethods.Click(driver, backLinkXpath);
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);

            //check Username values
            Wait.WaitToBeVisible(driver, uNResultXpath, 1);
            IWebElement uNameRecord = driver.FindElement(uNResultXpath);
            Assert.That(uNameRecord.Text.Contains(newUNVal), "Record failed to create!");
            //check Name values
            IWebElement nameRecord = driver.FindElement(nameResultXpath);
            Assert.That(nameRecord.Text.Contains(newNameVal), "Record failed to create!");
        }

        public void EditEmployeeContact(IWebDriver driver)
        {
            //1. Goto last page
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);

            //2. Click Edit btn
            Wait.WaitToBeClickable(driver, editBtnXpath, 5);
            CustomMethods.Click(driver, editBtnXpath);

            //3.Click Edit contact btn
            Wait.WaitToBeClickable(driver, editContactBtnId, 5);
            CustomMethods.Click(driver, editContactBtnId);

            //4. Fill First name
            driver.SwitchTo().Frame(0); // switch to pop up
            Wait.WaitToBeVisible(driver, fNameTxtBoxId, 5);
            CustomMethods.ClearEnterText(driver, fNameTxtBoxId, fNameVal);

            //5. Fill last name
            CustomMethods.ClearEnterText(driver, lNameTxtBoxId, lNameVal);

            //6. Fill phone
            CustomMethods.ClearEnterText(driver, phoneTxtBoxId, phoneVal);

            //7. Fill email
            CustomMethods.ClearEnterText(driver, emailTxtBoxId, emailVal);

            //8. Fill address
            CustomMethods.ClearEnterText(driver, addyTxtBoxId, addyVal);

            //9. Fill City
            CustomMethods.ClearEnterText(driver, cityTxtBoxId, cityVal);

            //10. Fill Country
            CustomMethods.ClearEnterText(driver, countryTxtBoxId, countryVal);

            //11. Click Save Contact btn
            CustomMethods.Click(driver, saveContactBtnId);

            //12. Save change
            driver.SwitchTo().DefaultContent(); // switch back to default
            CustomMethods.Submit(driver, saveBtnId);
            Thread.Sleep(2000);

            //13. Back to list
            CustomMethods.Click(driver, backLinkXpath);
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 10);
            CustomMethods.Click(driver, lastPageBtnXpath);

            //14. Click edit btn
            Wait.WaitToBeClickable(driver, editBtnXpath, 5);
            CustomMethods.Click(driver, editBtnXpath);

            //12. Check record is saved or not
            Wait.WaitToBeVisible(driver, contractDisplayId, 10);
            IWebElement contactRecord = driver.FindElement(contractDisplayId);
            Console.WriteLine(contactRecord.Text);

        }

        public void DeleteEmployee(IWebDriver driver) 
        {
            //1. Go to last page
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);
            
            //2.Find Delete btn and click
            Wait.WaitToBeClickable(driver, deleteBtnXpath, 5);
            CustomMethods.Click(driver, deleteBtnXpath);

            //3. Confirm delete
            Wait.WaitAlertVisible(driver, 1);
            CustomMethods.AcceptAlert(driver);
        }
    }
}
