using OpenQA.Selenium;

namespace LeapCafeTownsendTest.Pages
{
    class EmployeesPage : AbstractPage
    {
        const string EMPLOYEE_LIST_ID = "employee-list";

        const string CREATE_EMPLOYEE_ID = "bAdd";
        const string EDIT_EMPLOYEE_ID = "bEdit";
        const string DELETE_EMPLOYEE_ID = "bDelete";

        public EmployeesPage(IWebDriver driver) : base(driver) { }

        public bool IsEmployeeListPage()
        {
            return (_Driver.FindElement(By.Id(EMPLOYEE_LIST_ID)) != null
                && _Driver.FindElement(By.Id(CREATE_EMPLOYEE_ID)) != null
                && _Driver.FindElement(By.Id(EDIT_EMPLOYEE_ID)) != null
                && _Driver.FindElement(By.Id(DELETE_EMPLOYEE_ID)) != null);
        }
    }    
}
