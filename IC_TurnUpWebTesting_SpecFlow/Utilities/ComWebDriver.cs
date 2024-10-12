using IC_TurnUpWeb.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IC_TurnUpWeb.Utilities
{
    public class ComWebDriver
    {
        public static IWebDriver driver;

        public static LoginPage loginPageObj = new LoginPage();
        public static HomePage homePageObj = new HomePage();

    }
}
