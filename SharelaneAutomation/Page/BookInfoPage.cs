using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
	public class BookInfoPage : BasePage
	{
		By AddToCardButtonLocator = By.XPath("//img[@src='../images/add_to_cart.gif']");

		public BookInfoPage(WebDriver driver) : base(driver)
        {
		}

        public void ClickAddToCardButton()
        {
            ChromeDriver.FindElement(AddToCardButtonLocator).Click();
        }

        public bool CheckForAddToCardButton()
		{
			return ChromeDriver.FindElement(AddToCardButtonLocator).Displayed;
		}
	}
}

