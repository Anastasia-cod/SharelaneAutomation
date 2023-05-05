using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using SharelaneAutomation.Page;
using Core.Utilities;

namespace SharelaneAutomation.Tests
{
    [TestFixture]

    public class LoginTest : BaseTest
    {
        [Test]
        public void AR1_Login_ValidCredentianals()
        {
            //Var
            var standartUser = UserBuilder.StandartUser;

            string email = SignUpPage.GetEmailSignUpUser_FillInOnlyRequiredFields();

            //Action
            LoginPage.Login(email, standartUser.Password);
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

            //Assert
            Assert.AreEqual(LoginPage.GetErrorMessage(), errorMessage);
        }

        [Test]
        public void AR4_Login_WithoutEmail()
        {
            //Var
            string password = "1111";
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            LoginPage.Login(password: password);

            //Assert
            Assert.AreEqual(LoginPage.GetErrorMessage(), errorMessage);
        }

        [Test]
        public void AR5_Login_WithoutPassword()
        {
            //Var
            string email = SignUpPage.GetEmailSignUpUser_FillInOnlyRequiredFields();
            string errorMessage = "Oops, error. Email and/or password don't match our records";

            //Action
            LoginPage.Login(email);

            //Assert
            Assert.AreEqual(LoginPage.GetErrorMessage(), errorMessage);
        }
    }
}

