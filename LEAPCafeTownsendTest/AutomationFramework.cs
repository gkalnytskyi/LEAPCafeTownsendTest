using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

using LeapCafeTownsendTest.Pages;

namespace LeapCafeTownsendTest
{
    // Using ChromeDriver to reduce complexity
    sealed class AutomationFramework : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        private AutomationFramework()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-default-apps");
            chromeOptions.AddArgument("--disable-infobars");
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);

            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 0, 10);
        }

        public static AutomationFramework Init()
        {
            var af = new AutomationFramework();
            af.Driver.Navigate().GoToUrl("https://cafetownsend-angular-rails.herokuapp.com/login");
            return af;
        }

        public LoginPage GetLoginPage()
        {
            return PageFactory.InitElements<LoginPage>(Driver);
        }

        public void TearDown()
        {
            Dispose();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Driver != null)
                    {
                        Driver.Close();
                        Driver.Quit();
                        Driver.Dispose();
                        Driver = null;
                    }
                }

                GC.SuppressFinalize(this);

                disposedValue = true;
            }
        }

        ~AutomationFramework()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
