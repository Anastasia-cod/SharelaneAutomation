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
            Driver.FindElement(ShoppingCartLinkLocator).Click();
        }

        public void SetQuantity(int quantity)
        {
            Driver.FindElement(QuantityInputLocator).Clear();
            Driver.FindElement(QuantityInputLocator).SendKeys(Convert.ToString(quantity));
        }

        public void ClickUpdateButton()
        {
            Driver.FindElement(UpdateButtonLocator).Click();
        }

        public string GetPriseUsdValue()
        {
            return Driver.FindElement(PriceUsdLocator).Text.Replace(".", ",");
        }

        public string GetDiscountPercentValue()
        {
            return Driver.FindElement(DiscountPercentLocator).Text;
        }

        public string GetDiscountUsdValue()
        {
            return Driver.FindElement(DiscountUsdLocator).Text.Replace(".", ",");
        }

        public string GetDTotalUsdValue()
        {
            return Driver.FindElement(TotalUsdLocator).Text.Replace(".", ",");
        }

        public void AddBookToShoppingCart(string bookName, int quantity)
        {
            new MainPage(Driver).SearchBook(bookName);
            new BookInfoPage(Driver).ClickAddToCardButton();
            ClickShoppingCartLink();
            SetQuantity(quantity);
            ClickUpdateButton();
        }

    }
}

