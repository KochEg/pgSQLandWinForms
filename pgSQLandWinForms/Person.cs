using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgSQLandWinForms
{
    public class Person
    {
        int _id;
        string _name;
        string _surname;
        string _patronymic;
        int _age;

        Person() { }
        public Person(string name, string surname, string patronymic, int age)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _age = age;
        }

        public Person(int id, string name, string surname, string patronymic, int age)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _age = age;
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Имя { get { return _name; } set { _name = value; } }
        public string Фамилия { get { return _surname; } set { _surname = value; } }
        public string Отчество { get { return _patronymic; } set { _patronymic = value; } } 
        public int Возраст { get { return _age;} set { _age = value; } }
    }
}
