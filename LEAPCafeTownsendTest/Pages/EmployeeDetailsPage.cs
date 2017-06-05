using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using LeapCafeTownsendTest.People;

namespace LeapCafeTownsendTest.Pages
{
    class EmployeeDetailsPage : AbstractPage
    {
        const string FIRST_NAME_CSS = "input[ng-model='selectedEmployee.firstName']";
        const string LAST_NAME_CSS = "input[ng-model='selectedEmployee.lastName']";
        const string START_DATE_CSS = "input[ng-model='selectedEmployee.startDate']";
        const string EMAIL_CSS = "input[ng-model='selectedEmployee.email']";

        const string CANCEL_CSS = "a.bCancel";
        const string BACK_CSS = "a.bBack";
        const string CREATE_XPATH = "//button[@type='submit' and text()='Add']";
        const string UPDATE_XPATH = "//button[@type='submit' and text() ='Update']";
        const string DELETE_CSS = "p.main-button";

        [FindsBy(How = How.CssSelector, Using = FIRST_NAME_CSS)]
        IWebElement FirstName;
        [FindsBy(How = How.CssSelector, Using = LAST_NAME_CSS)]
        IWebElement LastName;
        [FindsBy(How = How.CssSelector, Using = START_DATE_CSS)]
        IWebElement _StartDate;
        [FindsBy(How = How.CssSelector, Using = EMAIL_CSS)]
        IWebElement Email;

        IWebElement AddButton { get { return _Driver.FindElement(By.XPath(CREATE_XPATH)); } }
        IWebElement UpdateButton { get { return _Driver.FindElement(By.XPath(UPDATE_XPATH)); } }
        IWebElement DeleteButton { get { return _Driver.FindElement(By.CssSelector(DELETE_CSS)); } }

        IWebElement CancelButton { get { return _Driver.FindElement(By.CssSelector(CANCEL_CSS)); } }
        IWebElement BackButton { get { return _Driver.FindElement(By.CssSelector(BACK_CSS)); } }

        public EmployeeDetailsPage(IWebDriver driver) : base(driver) { }

        public EmployeeDetailsPage SetFirstName(string firstName)
        {
            FirstName.Clear();
            FirstName.SendKeys(firstName);
            return this;
        }

        public EmployeeDetailsPage SetLastName(string lastName)
        {
            LastName.Clear();
            LastName.SendKeys(lastName);
            return this;
        }

        public EmployeeDetailsPage SetStartDate(DateTime date)
        {
            _StartDate.Clear();
            _StartDate.SendKeys(date.ToString("yyyy-MM-dd"));
            return this;
        }

        public EmployeeDetailsPage SetEmail(string validEmail)
        {
            Email.Clear();
            Email.SendKeys(validEmail);
            return this;
        }

        public EmployeeListPage ClickAddEmployee()
        {
            AddButton.Click();
            return PageFactory.InitElements<EmployeeListPage>(_Driver);
        }

        public EmployeeListPage ClickUpdateEmployee()
        {
            UpdateButton.Click();
            return PageFactory.InitElements<EmployeeListPage>(_Driver);
        }

        public EmployeeListPage ClickDeleteEmployee()
        {
            DeleteButton.Click();
            return PageFactory.InitElements<EmployeeListPage>(_Driver);
        }

        public EmployeeListPage ClickBack()
        {
            BackButton.Click();
            return PageFactory.InitElements<EmployeeListPage>(_Driver);
        }

        public EmployeeListPage ClickCancel()
        {
            CancelButton.Click();
            return PageFactory.InitElements<EmployeeListPage>(_Driver);
        }

        public EmployeeListPage AddEmployee(Employee employee)
        {
            SetFirstName(employee.FirstName);
            SetLastName(employee.LastName);
            SetStartDate(employee.StartDate);
            SetEmail(employee.Email);

            return ClickAddEmployee();
        }
    }
}
