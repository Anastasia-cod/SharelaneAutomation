using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
    public class SignUpPage : BasePage
    {
        By SignUpLinkLocator = By.XPath("//a[text()='Sign up']");
        By ZipCodeInputLocator = By.Name("zip_code");
        By ContinueButtonLocator = By.XPath("//input[@value='Continue']");
        By FirstNameInputLocator = By.Name("first_name");
        By LastNameInputLocator = By.Name("last_name");
        By EmailLocator = By.Name("email");
        By PasswordLocator = By.Name("password1");
        By ConfirmPasswordLocator = By.Name("password2");
        By RegisterButtonLocator = By.XPath("//input[@value='Register']");
        By ConfirmationMessageLocator = By.CssSelector(".confirmation_message");
        By EmailSignUpUserLocator = By.XPath("//td/b");

        public SignUpPage(WebDriver driver) : base(driver)
        {
        }

        public void ClickSignUpLink()
        {
            ChromeDriver.FindElement(SignUpLinkLocator).Click();
        }

        public void SetZipCode(string zipCode)
        {
            ChromeDriver.FindElement(ZipCodeInputLocator).SendKeys(zipCode);
        }

        public void ClickContinueButton()
        {
            ChromeDriver.FindElement(ContinueButtonLocator).Click();
        }

        public void SetFirstName(string firstName)
        {
            ChromeDriver.FindElement(FirstNameInputLocator).SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            ChromeDriver.FindElement(LastNameInputLocator).SendKeys(lastName);
        }

        public void SetEmail(string email)
        {
            ChromeDriver.FindElement(EmailLocator).SendKeys(email);
        }

        public void SetPassword(string password)
        {
            ChromeDriver.FindElement(PasswordLocator).SendKeys(password);
        }

        public void SetConfirmPassword(string confirmPassword)
        {
            ChromeDriver.FindElement(ConfirmPasswordLocator).SendKeys(confirmPassword);
        }

        public void ClickRegisterButton()
        {
            ChromeDriver.FindElement(RegisterButtonLocator).Click();
        }

        public string GetConfirmationMessage()
        {
            return ChromeDriver.FindElement(ConfirmationMessageLocator).Text;
        }

        public void SignUp (string zipCode = "", string firstName = "", string lastName = "", string email = "", string password = "", string confirmPassword = "")
        {
            ClickSignUpLink();
            SetZipCode(zipCode);
            ClickContinueButton();
            SetFirstName(firstName);
            SetLastName(lastName);
            SetEmail(email);
            SetPassword(password);
            SetConfirmPassword(confirmPassword);
            ClickRegisterButton();
        }

        public string GetEmailSignUpUser_FillInOnlyRequiredFields()
        {
            SignUp("22222", "Tiana",email: "testusercred@gmail.com", password: "1111", confirmPassword: "1111");
            return ChromeDriver.FindElement(EmailSignUpUserLocator).Text;
        }

    }
}

