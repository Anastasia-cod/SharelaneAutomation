using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
    public class LoginPage : BasePage
    {
        By EmailInputLocator = By.XPath("//*[@name='email']");
        By PasswordInputLocator = By.XPath("//*[@name='password']");
        By LoginButtonLocator = By.XPath("(//input)[5]");

        public LoginPage(WebDriver driver) : base(driver)
        {
        }

        public void SetUserEmail(string email)
        {
            ChromeDriver.FindElement(EmailInputLocator).SendKeys(email);
        }

        public void SetUserPassword(string password)
        {
            ChromeDriver.FindElement(PasswordInputLocator).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            ChromeDriver.FindElement(LoginButtonLocator).Click();
        }

        public void Login(string email = "", string password = "")
        {
            ChromeDriver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
            SetUserEmail(email);
            SetUserPassword(password);
            ClickLoginButton();
        }
    }
}

