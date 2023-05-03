using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
    public abstract class BasePage
    {
        public WebDriver Driver { get; set; }

        public BasePage(WebDriver driver)
        {
            Driver = driver;
        }
    }
}

