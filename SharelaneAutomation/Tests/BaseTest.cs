using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    public class BaseTest
    {
        public WebDriver Driver { get; set; }
        public LoginPage LoginPage { get; set; }
        public SignUpPage SignUpPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            string browser = TestContext.Parameters.Get("Browser");

            switch (browser)
            {
                case "headless":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless");
                    Driver = new ChromeDriver(options);
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }

            Driver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            LoginPage = new LoginPage(Driver);
            SignUpPage = new SignUpPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

