using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    [TestFixture]

    public class LoginTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            ChromeDriver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
        }

        [Test]
        public void AR1_Login_ValidCredentianals()
        {
            //Var
            string email = "linda_holmes@343.06.sharelane.com";
            string password = "1111";

            //Action
            LoginPage.Login(email, password);
            var userPersonalAccountPage = new UserPersonalAccountPage(ChromeDriver);

            //Assert
            Assert.IsTrue(userPersonalAccountPage.CheckLogoutLink());
        }

        [Test]
        public void AR3_Login_InvalidPassword()
        {
            //Var
            string email = "linda_holmes@343.06.sharelane.com";
            string password = "11112";
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            LoginPage.Login(email, password);

            var error = ChromeDriver.FindElement(By.ClassName("error_message"));

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(error.Text, errorMessage);
                Assert.IsTrue(error.Displayed);
            });
        }

        [Test]
        public void AR4_Login_WithoutEmail()
        {
            //Var
            string password = "1111";
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            LoginPage.Login(password: password);

            var error = ChromeDriver.FindElement(By.ClassName("error_message"));

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(error.Text, errorMessage);
                Assert.IsTrue(error.Displayed);
            });
        }

        [Test]
        public void AR5_Login_WithoutPassword()
        {
            //Var
            string email = "linda_holmes@343.06.sharelane.com";
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            LoginPage.Login(email);

            var error = ChromeDriver.FindElement(By.ClassName("error_message"));

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(error.Text, errorMessage);
                Assert.IsTrue(error.Displayed);
            });
        }
    }
}

