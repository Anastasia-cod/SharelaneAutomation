using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
    public class LoginPage : BasePage
    {
        By EmailInputLocator = By.XPath("//*[@name='email']");
        By PasswordInputLocator = By.XPath("//*[@name='password']");
        By LoginButtonLocator = By.XPath("(//input)[5]");
        By ErrorMessageLocator = By.ClassName("error_message");

        public LoginPage(WebDriver driver) : base(driver)
        {
        }

        public void SetUserEmail(string email)
        {
            Driver.FindElement(EmailInputLocator).SendKeys(email);
        }

        public void SetUserPassword(string password)
        {
            Driver.FindElement(PasswordInputLocator).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(LoginButtonLocator).Click();
        }

        public void Login(string email = "", string password = "")
        {
            Driver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
            SetUserEmail(email);
            SetUserPassword(password);
            ClickLoginButton();
        }

        public string GetErrorMessage()
        {
            Assert.That(Driver.FindElement(ErrorMessageLocator).Displayed);

            return Driver.FindElement(ErrorMessageLocator).Text;
        }
    }
}

