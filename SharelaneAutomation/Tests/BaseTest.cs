using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    public class BaseTest
    {
        public WebDriver ChromeDriver { get; set; }
        public LoginPage LoginPage { get; set; }
        public SignUpPage SignUpPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage = new LoginPage(ChromeDriver);
            SignUpPage = new SignUpPage(ChromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver.Quit();
        }
    }
}

