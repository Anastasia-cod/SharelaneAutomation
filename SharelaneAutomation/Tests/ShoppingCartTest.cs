using System;
using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    public class ShoppingCartTest : BaseTest
    {
        public MainPage MainPage { get; set; }
        public BookInfoPage BookInfoPage { get; set; }
        public ShoppingCartPage ShoppingCartPage { get; set; }

        [SetUp]
        public void SetUp()
        {
            MainPage = new MainPage(Driver);
            BookInfoPage = new BookInfoPage(Driver);
            ShoppingCartPage = new ShoppingCartPage(Driver);
            string email = SignUpPage.GetEmailSignUpUser_FillInOnlyRequiredFields();
            string password = "1111";
            LoginPage.Login(email, password);
        }

        [TestCase("The Moon and Sixpence", 0, 0)]
        [TestCase("The Moon and Sixpence", 1, 0)]
        [TestCase("The Moon and Sixpence", 19, 0)]
        [TestCase("Great Expectations", 20, 2)]
        [TestCase("Great Expectations", 35, 2)]
        [TestCase("Great Expectations", 49, 2)]
        [TestCase("The Adventures of Tom Sawyer", 50, 3)]
        [TestCase("The Adventures of Tom Sawyer", 78, 3)]
        [TestCase("The Adventures of Tom Sawyer", 99, 3)]
        [TestCase("White Fang", 100, 4)]
        [TestCase("White Fang", 328, 4)]
        [TestCase("White Fang", 499, 4)]
        [TestCase("War and Peace", 500, 5)]
        [TestCase("War and Peace", 801, 5)]
        [TestCase("War and Peace", 999, 5)]
        [TestCase("The Adventures of Huckleberry Finn", 1000, 6)]
        [TestCase("The Adventures of Huckleberry Finn", 2999, 6)]
        [TestCase("The Adventures of Huckleberry Finn", 4999, 6)]
        [TestCase("The Alchemist", 5000, 7)]
        [TestCase("The Alchemist", 8304, 7)]
        [TestCase("The Alchemist", 9999, 7)]
        [TestCase("The Power", 10000, 8)]
        [TestCase("The Power", 1000000, 8)]
        public void _ShoppingCart_CheckCorrectCalculation(string bookName, int quantity, decimal expectedDiscountPercent)
        {

            //Action
            ShoppingCartPage.AddBookToShoppingCart(bookName, quantity);

            decimal actualPriceUsd = Convert.ToDecimal(ShoppingCartPage.GetPriseUsdValue());
            decimal actualDiscountPercent = Convert.ToDecimal(ShoppingCartPage.GetDiscountPercentValue());
            decimal actualDiscountUsdValue = Convert.ToDecimal(ShoppingCartPage.GetDiscountUsdValue());
            decimal actualTotalUsd = Convert.ToDecimal(ShoppingCartPage.GetDTotalUsdValue());

            decimal expectedDiscountUsd = actualPriceUsd * Convert.ToDecimal(quantity) * actualDiscountPercent / 100;
            decimal expectedTotalUsd = actualPriceUsd * Convert.ToDecimal(quantity) - expectedDiscountUsd;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(actualDiscountPercent, Is.EqualTo(expectedDiscountPercent));
                Assert.That(actualDiscountUsdValue, Is.EqualTo(expectedDiscountUsd));
                Assert.That(actualTotalUsd, Is.EqualTo(expectedTotalUsd));
            });
        }
    }
}

