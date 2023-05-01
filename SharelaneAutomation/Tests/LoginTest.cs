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
        [Test]
        public void AR1_Login_ValidCredentianals()
        {
            //Var
            string email = SignUpPage.GetEmailSignUpUser_FillInOnlyRequiredFields();
            string password = "1111";

            //Action
            LoginPage.Login(email, password);
            var userPersonalAccountPage = new UserPersonalAccountPage(Driver);

            //Assert
            Assert.IsTrue(userPersonalAccountPage.CheckLogoutLink());
        }

        [Test]
        public void AR3_Login_InvalidPassword()
        {
            //Var
            string email = SignUpPage.GetEmailSignUpUser_FillInOnlyRequiredFields();
            string password = "11112";
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            LoginPage.Login(email, password);

            var error = Driver.FindElement(By.ClassName("error_message"));

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

            var error = Driver.FindElement(By.ClassName("error_message"));

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
            string email = SignUpPage.GetEmailSignUpUser_FillInOnlyRequiredFields();
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            LoginPage.Login(email);

            var error = Driver.FindElement(By.ClassName("error_message"));

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(error.Text, errorMessage);
                Assert.IsTrue(error.Displayed);
            });
        }
    }
}

