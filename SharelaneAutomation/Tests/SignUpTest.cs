using System;
using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    [TestFixture]

    public class SignUpTest : BaseTest
    {
        [Test]
        public void SU1_SignUp_ValidData_FillInOnlyRequiredFields()
        {
            //Var
            string zipCode = "44444";
            string firstName = "Tomas";
            string email = "testemail@gmail.com";
            string password = "2508";
            string confirmPassword = "2508";
            string expectedConfirmationMessage = "Account is created!";

            //Action
            SignUpPage.SignUp(zipCode, firstName, email: email, password: password, confirmPassword: confirmPassword);

            //Assert
            Assert.That(SignUpPage.GetConfirmationMessage(), Is.EqualTo(expectedConfirmationMessage));
        }

        [Test]
        public void SU2_SignUp_ValidData_FillInAllFields()
        {
            //Var
            string zipCode = "22222";
            string firstName = "Miranda";
            string lastName = "Torryl";
            string email = "testemail@gmail.com";
            string password = "2508";
            string confirmPassword = "2508";
            string expectedConfirmationMessage = "Account is created!";

            //Action
            SignUpPage.SignUp(zipCode, firstName, lastName, email, password, confirmPassword);

            //Assert
            Assert.That(SignUpPage.GetConfirmationMessage(), Is.EqualTo(expectedConfirmationMessage));
        }
    }
}

