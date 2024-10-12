using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TurnUpWeb.Utilities
{
    internal class CustomMethods 
    {
        public static void Click(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void Submit(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Submit();
        }

        public static void Clear(IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Clear();
        }

        public static void ClearEnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).Clear();
            //driver.FindElement(locator).Click();
            driver.FindElement(locator).SendKeys(text);
        }

        public static void OnlyEnterText(IWebDriver driver, By locator, string text)
        {
            driver.FindElement(locator).SendKeys(text);
        }


        public static void AcceptAlert(IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        

    }
}
