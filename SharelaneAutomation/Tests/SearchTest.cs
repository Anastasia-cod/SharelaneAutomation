using System;
using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    public class SearchTest : BaseTest
    {
        public MainPage MainPage { get; set; }
        public BookInfoPage BookInfoPage { get; set; }

        //[SetUp]
        public void SetUp()
        {
            MainPage = new MainPage(Driver);
            BookInfoPage = new BookInfoPage(Driver);
        }

        //[Test]
        public void TB1_Search_ValidBookName()
        {
            //Var
            string bookName = "Gitanjali";

            //Action
            MainPage.SearchBook(bookName);

            //Assert
            Assert.IsTrue(BookInfoPage.CheckForAddToCardButton());
        }

        //[Test]
        public void TB2_Search_InValidBookName()
        {
            //Var
            string bookName = "Test Test Test";
            var expectedMessage = "Nothing is found :(";

            //Action
            MainPage.SearchBook(bookName);

            //Assert
            Assert.That(expectedMessage, Is.EqualTo(MainPage.GetErrorMessage()));
        }
    }
}

