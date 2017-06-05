using NUnit.Framework;
using FluentAssertions;

using LeapCafeTownsendTest.People;

namespace LeapCafeTownsendTest
{
    [TestFixture]
    public class CreateEmployeeTest
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

        [Test]
        public void EmployeeCanBeAddedToTheSystem()
        {
            // Arrange
            var employee = Employee.GetNewEmployeeEntry();

            var employeesPage = _Actions.LoginAsLuke();

            // Act
            var employeeDetailsPage = employeesPage.AddEmployee();

            employeeDetailsPage.SetFirstName(employee.FirstName).
                SetLastName(employee.LastName).
                SetStartDate(employee.StartDate).
                SetEmail(employee.Email);

            employeesPage = employeeDetailsPage.ClickAddEmployee();

            // Assert
            employeesPage.EmployeeListContainsEmployee(employee.FullName).Should().BeTrue();
        }
    }
}
