using IC_TurnUpWeb.Utilities;
using OpenQA.Selenium;

namespace IC_TurnUpWeb.Pages
{
    public class LoginPage
    {
        private readonly string url = "http://horse.industryconnect.io/";
        private readonly string userName = "hari";
        private readonly string passWord = "123123";

        public void LoginAction(IWebDriver driver)
        {
            //2. Open Turn Up portal
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            //Thread.Sleep(1000);

            //3. Enter Username & Password
            driver.FindElement(By.Name("UserName")).SendKeys(userName);

            driver.FindElement(By.Id("Password")).SendKeys(passWord);

            //4. Click on log in btn
            driver.FindElement(By.CssSelector(".btn")).Click();
            
        }
    }
}
