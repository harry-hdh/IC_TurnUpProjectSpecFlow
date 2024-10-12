using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IC_TurnUpWeb.Pages
{
    public class HomePage
    {
        
        
        public void NavigateToPage(IWebDriver driver, By locator, By? dropDownItemLocator = null)
        {
            //1.Navigate to Time and Material Page
            //1a. Click Administraton
            
            CustomMethods.Click(driver, locator);

            if (dropDownItemLocator != null)
            {
                Wait.WaitToBeClickable(driver, dropDownItemLocator, 1);

                //1b. Click Time and Material
                try
                {
                    CustomMethods.Click(driver, dropDownItemLocator);

                }
                catch (Exception ex)
                {
                    Assert.Fail($"Fail to find Time & material Option - {ex.Message}");
                }
            }
            
        }
    }
}
