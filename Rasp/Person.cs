using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Person
    {
        private string name;
        public string GetName() { return name; }

        private string adress;
        public string GetAdress() { return adress; }

        public Person(string _Name, string _Adress)
        {
            name = _Name;
            adress = _Adress;
        }

        public virtual void display(){
            Console.WriteLine("ФИО: " + name);
            Console.WriteLine("  Адрес:\t" + adress);
        }

    }
}
