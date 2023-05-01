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
            switch ("FireFox")
            {
                case "FireFox":
                    Driver = new FirefoxDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }
                
            Driver = new ChromeDriver();
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

