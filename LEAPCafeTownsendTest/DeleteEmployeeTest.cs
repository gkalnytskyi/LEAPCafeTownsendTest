using System;
using NUnit.Framework;
using FluentAssertions;

using LeapCafeTownsendTest.People;

namespace LeapCafeTownsendTest
{
    [TestFixture]
    public class DeleteEmployeeTest
    {
        AutomationFramework _Framework;
        Actions _Actions;

        [SetUp]
        public void Setup()
        {
            _Framework = AutomationFramework.Init();
            _Actions = new Actions(_Framework);
        }

        [TearDown]
        public void TearDown()
        {
            _Framework.TearDown();
        }

        [Test, Ignore("Exposes the issue in Chrome 58, that deleted entry " +
            "is not removed from the list until it is scrolled")]
        public void EmployeeRemovedFromTheListAfterDelete()
        {
            // Arrange
            var employee = Employee.GetNewEmployeeEntry();
            var employeeListPage = _Actions.LoginAsLukeAndCreateEmployee(employee);

            // Act
            employeeListPage.SelectEmployee(employee.FullName);
            employeeListPage = employeeListPage.DeleteEmployee(true);

            // Assert
            employeeListPage.EmployeeListContainsEmployee(employee.FullName).Should().BeFalse();
        }

        [Test]
        public void EmployeeRemovedFromTheListAfterDeleteOnEditPage()
        {
            // Arrange
            var employee = Employee.GetNewEmployeeEntry();
            var employeeListPage = _Actions.LoginAsLukeAndCreateEmployee(employee);

            // Act
            employeeListPage.SelectEmployee(employee.FullName);
            var employee_details = employeeListPage.EditEmployee();

            employeeListPage = employee_details.ClickDeleteEmployee(true);

            // Assert
            employeeListPage.EmployeeListContainsEmployee(employee.FullName).Should().BeFalse();
        }
    }
}
