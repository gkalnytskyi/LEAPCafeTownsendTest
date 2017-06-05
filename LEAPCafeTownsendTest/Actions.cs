using System;

using LeapCafeTownsendTest.Pages;
using LeapCafeTownsendTest.People;

namespace LeapCafeTownsendTest
{
    class Actions
    {
        readonly AutomationFramework _Framework;

        public Actions(AutomationFramework af)
        {
            if (af == null)
                throw new ArgumentNullException("af");

            _Framework = af;
        }

        public EmployeeListPage LoginAsLuke()
        {
            var loginPage = _Framework.GetLoginPage();
            var luke = Person.LukeSkywalker;
            return loginPage.LoginAs(luke.UserName, luke.Password);
        }
    }
}
