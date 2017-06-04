using System;

namespace LeapCafeTownsendTest.People
{
    class Person
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public Person(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public static Person LukeSkywalker => new Person("Luke", "Skywalker");
    }
}
