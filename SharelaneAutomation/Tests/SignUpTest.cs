﻿using System;
using OpenQA.Selenium.Chrome;
using SharelaneAutomation.Page;

namespace SharelaneAutomation.Tests
{
    [TestFixture]

    public class SignUpTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            ChromeDriver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/main.py");
        }

        [Test]
        public void SU1_SignUp_ValidData()
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
