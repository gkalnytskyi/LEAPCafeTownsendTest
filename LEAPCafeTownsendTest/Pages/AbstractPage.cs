using System;
using OpenQA.Selenium;

namespace LeapCafeTownsendTest.Pages
{
    class AbstractPage
    {
        protected readonly IWebDriver _Driver;

        public AbstractPage(IWebDriver driver)
        {
            if (driver == null)
                throw new ArgumentNullException("driver");

            _Driver = driver;
        }
    }
}
