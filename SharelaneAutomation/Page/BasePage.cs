using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
    public abstract class BasePage
    {
        public WebDriver ChromeDriver { get; set; }

        public BasePage(WebDriver driver)
        {
            ChromeDriver = driver;
        }
    }
}

