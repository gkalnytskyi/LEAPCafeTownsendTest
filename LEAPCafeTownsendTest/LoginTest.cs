using System;
using NUnit.Framework;
using FluentAssertions;

using LeapCafeTownsendTest.People;

namespace LeapCafeTownsendTest
{
    [TestFixture]
    public class LoginTest
    {
        AutomationFramework framework;

        [SetUp]
        public void Setup()
        {
            framework = AutomationFramework.Init();
        }

        [TearDown]
        public void TearDown()
        {
            framework.TearDown();
        }

        [Test]
        public void UserLoginsToAppAndGetsToEmployeesPage()
        {
            var loginPage = framework.GetLoginPage();
            var luke = Person.LukeSkywalker;
            var employeePage = loginPage.LoginAs(luke.UserName, luke.Password);
            employeePage.IsEmployeeListPage().Should().BeTrue();
            employeePage.GreetingText.Should().Be("Hello Luke");
        }
    }
}
