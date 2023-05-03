using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
	public class MainPage : BasePage
	{
        By SearchInputLocator = By.Name("keyword");
        By SearchButtonLocator = By.XPath("//input[@value='Search']");
        By NothingFoundMessageLocator = By.CssSelector(".confirmation_message");

        public MainPage(WebDriver driver) : base(driver)
        {
        }

        public void SetBookNameInSearchInput(string bookName)
        {
            Driver.FindElement(SearchInputLocator).SendKeys(bookName);
        }

        public void ClickSearchButton()
        {
            Driver.FindElement(SearchButtonLocator).Click();
        }

        public BookInfoPage SearchBook(string bookName)
        {
            SetBookNameInSearchInput(bookName);
            ClickSearchButton();

            return new BookInfoPage(Driver);
        }

        public string GetErrorMessage()
        {
            return Driver.FindElement(NothingFoundMessageLocator).Text;
        }
    }
}

