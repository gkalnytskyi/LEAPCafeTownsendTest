using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace LeapCafeTownsendTest.Pages
{
    class LoginPage : AbstractPage
    {
        const string LOGIN_FORM_ID = "#login-form";
        const string USER_NAME_CSS = LOGIN_FORM_ID + " input[ng-model='user.name']";
        const string USER_PASSWORD_CSS = LOGIN_FORM_ID + " input[ng-model='user.password']";
        const string SUBMIT_CSS = LOGIN_FORM_ID + " button[type='submit']";

        [FindsBy(How = How.CssSelector, Using = USER_NAME_CSS)]
        IWebElement _Login;
        [FindsBy(How = How.CssSelector, Using = USER_PASSWORD_CSS)]
        IWebElement _Password;
        [FindsBy(How = How.CssSelector, Using = SUBMIT_CSS)]
        IWebElement _Submit;

        public LoginPage(IWebDriver driver) : base(driver) { }

        public LoginPage TypeUserName(string username)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            _Login.Clear();
            _Login.SendKeys(username);
            return this;
        }

        public LoginPage TypeUserPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            _Password.Clear();
            _Password.SendKeys(password);
            return this;
        }

        public EmployeesPage SubmitLogin()
        {
            _Submit.Click();
            return PageFactory.InitElements<EmployeesPage>(_Driver);
        }

        public LoginPage SubmitLoginExpectingFailure()
        {
            _Submit.Click();
            return PageFactory.InitElements<LoginPage>(_Driver);
        }

        public EmployeesPage LoginAs(string username, string password)
        {
            TypeUserName(username);
            TypeUserPassword(password);

            return SubmitLogin();
        }
    }
}
