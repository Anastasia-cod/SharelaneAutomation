using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace SharelaneAutomation.Login
{
    [TestFixture]

    public class RegistrationLogin : BaseTest
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
            string login = "brian_rao@840.03.sharelane.com";
            string password = "1111";

            //Action
            ChromeDriver.FindElement(By.XPath("//*[@name='email']")).SendKeys(login);
            ChromeDriver.FindElement(By.XPath("//*[@name='password']")).SendKeys(password);
            ChromeDriver.FindElement(By.XPath("(//input)[5]")).Click();

            //Assert
            var logoutLink = ChromeDriver.FindElement(By.XPath("//a[text()='Logout']"));

            Assert.IsNotNull(logoutLink.Displayed);
        }

        [Test]
        public void AR3_Login_InvalidCredentianals()
        {
            //Var
            string login = "brian_rao@840.03.sharelane.com";
            string password = "11112";
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            ChromeDriver.FindElement(By.XPath("//*[@name='email']")).SendKeys(login);
            ChromeDriver.FindElement(By.XPath("//*[@name='password']")).SendKeys(password);
            ChromeDriver.FindElement(By.XPath("(//input)[5]")).Click();

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

