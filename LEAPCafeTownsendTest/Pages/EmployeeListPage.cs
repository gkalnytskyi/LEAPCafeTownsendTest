﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace LeapCafeTownsendTest.Pages
{
    class EmployeeListPage : AbstractPage
    {
        const string EMPLOYEE_LIST_ID = "employee-list";

        const string CREATE_EMPLOYEE_ID = "bAdd";
        const string EDIT_EMPLOYEE_ID = "bEdit";
        const string DELETE_EMPLOYEE_ID = "bDelete";

        const string GREETING_ID = "greetings";

        [FindsBy(How = How.Id, Using = CREATE_EMPLOYEE_ID)]
        IWebElement AddEmployeeButton;

        [FindsBy(How = How.Id, Using = EDIT_EMPLOYEE_ID)]
        IWebElement EditEmployeeButton;

        [FindsBy(How = How.Id, Using = DELETE_EMPLOYEE_ID)]
        IWebElement DeleteEmployeeButton;

        IWebElement EmployeeList
        {
            get { return _Driver.FindElement(By.Id(EMPLOYEE_LIST_ID)); }
        }

        public EmployeeListPage(IWebDriver driver) : base(driver) { }

        public string GreetingText
        {
            get { return _Driver.FindElement(By.Id(GREETING_ID)).Text; }
        }

        public bool IsEmployeeListPage()
        {
            return (_Driver.FindElement(By.Id(EMPLOYEE_LIST_ID)) != null
                && _Driver.FindElement(By.Id(CREATE_EMPLOYEE_ID)) != null
                && _Driver.FindElement(By.Id(EDIT_EMPLOYEE_ID)) != null
                && _Driver.FindElement(By.Id(DELETE_EMPLOYEE_ID)) != null);
        }

        public EmployeeDetailsPage AddEmployee()
        {
            AddEmployeeButton.Click();
            return PageFactory.InitElements<EmployeeDetailsPage>(_Driver);
        }

        public EmployeeDetailsPage EditEmployee()
        {
            EditEmployeeButton.Click();
            return PageFactory.InitElements<EmployeeDetailsPage>(_Driver);
        }

        public EmployeeListPage DeleteEmployee(bool ack)
        {
            DeleteEmployeeButton.Click();

            IAlert alert = _Driver.SwitchTo().Alert();

            if (ack)
            {
                alert.Accept();
            }
            else
                alert.Dismiss();

            return PageFactory.InitElements<EmployeeListPage>(_Driver);
        }

        public EmployeeListPage SelectEmployee(string fullName)
        {
            var listEntry = EmployeeList.FindElement(
                    By.XPath(string.Format("./li[contains(text(),'{0}')]", fullName)));

            if (listEntry.Text != fullName)
            {
                throw new Exception(String.Format("Employee '{0}' not found.", fullName));
            }

            listEntry.Click();
            return this;
        }

        public bool EmployeeListContainsEmployee(string fullName)
        {
            IWebElement listEntry;
            try
            {
                listEntry = EmployeeList.FindElement(
                    By.XPath(string.Format("./li[contains(text(),'{0}')]", fullName)));
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }

            return listEntry.Text == fullName;
        }
    }    
}
