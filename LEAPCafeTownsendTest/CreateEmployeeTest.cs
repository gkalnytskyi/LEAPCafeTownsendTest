using System;
using NUnit.Framework;
using FluentAssertions;

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


        class Employee
        {
            public string FirstName;
            public string LastName;
            public DateTime StartDate;
            public string Email;

            public string FullName { get { return FirstName + " " + LastName; } }

            public static Employee GetNewEmployeeEntry()
            {
                string firstName = "John";
                string lastName = "Smith";

                Guid guid = Guid.NewGuid();

                var str_guid = guid.ToString().Split('-');
                firstName = String.Join(" ", firstName,
                    String.Join("-", str_guid[0], str_guid[1], str_guid[2]));
                lastName = String.Join(" ", lastName,
                    String.Join("-", str_guid[3], str_guid[4]));

                var date = DateTime.Now;

                var email = String.Join(".", firstName, lastName) + "@example.com";
                email = email.Replace(' ', '.');

                return new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    StartDate = date,
                    Email = email
                };
            }
        }
    }
}
