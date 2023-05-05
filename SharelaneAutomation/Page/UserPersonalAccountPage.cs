using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SharelaneAutomation.Page
{
    public class UserPersonalAccountPage : BasePage
    {
        By LogoutLinkLocator = By.XPath("//a[text()='Logout']");

        public UserPersonalAccountPage(WebDriver driver) : base(driver)
        {
            Assert.IsTrue(CheckLogoutLink());
        }

        public bool CheckLogoutLink()
        {
            return Driver.FindElement(LogoutLinkLocator).Displayed;
        }
    }
}

