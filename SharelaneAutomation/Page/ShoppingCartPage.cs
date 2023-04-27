using System;
using OpenQA.Selenium;

namespace SharelaneAutomation.Page
{
	public class ShoppingCartPage : BasePage
	{
        By ShoppingCartLinkLocator = By.XPath("//a[@href='./shopping_cart.py']");
        By QuantityInputLocator = By.Name("q");
        By UpdateButtonLocator = By.XPath("//input[@value='Update']");
        By PriceUsdLocator = By.XPath("//tr[2]/td[4]");
        By DiscountPercentLocator = By.XPath("//td[5]/p/b");
        By DiscountUsdLocator = By.XPath("//tr[2]/td[6]");
        By TotalUsdLocator = By.XPath("//tr[2]/td[7]");
        By ProceedToCheckoutButtonLocator = By.XPath("//input[@value='Proceed to Checkout']");

        public ShoppingCartPage(WebDriver driver) : base(driver)
        {
        }

        public void ClickShoppingCartLink()
        {
            ChromeDriver.FindElement(ShoppingCartLinkLocator).Click();
        }

        public void SetQuantity(int quantity)
        {
            ChromeDriver.FindElement(QuantityInputLocator).Clear();
            ChromeDriver.FindElement(QuantityInputLocator).SendKeys(Convert.ToString(quantity));
        }

        public void ClickUpdateButton()
        {
            ChromeDriver.FindElement(UpdateButtonLocator).Click();
        }

        public string GetPriseUsdValue()
        {
            return ChromeDriver.FindElement(PriceUsdLocator).Text.Replace(".", ",");
        }

        public string GetDiscountPercentValue()
        {
            return ChromeDriver.FindElement(DiscountPercentLocator).Text;
        }

        public string GetDiscountUsdValue()
        {
            return ChromeDriver.FindElement(DiscountUsdLocator).Text.Replace(".", ",");
        }

        public string GetDTotalUsdValue()
        {
            return ChromeDriver.FindElement(TotalUsdLocator).Text.Replace(".", ",");
        }

        public void AddBookToShoppingCart(string bookName, int quantity)
        {
            new MainPage(ChromeDriver).SearchBook(bookName);
            new BookInfoPage(ChromeDriver).ClickAddToCardButton();
            ClickShoppingCartLink();
            SetQuantity(quantity);
            ClickUpdateButton();
        }

    }
}

