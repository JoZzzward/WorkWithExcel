using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Lecturer: Person
    {
        private string courses;
        public string getCourses() { return courses; }

        public Lecturer(string aName, string aAdress, string phone, string courses)
            : base(aName, aAdress)
        {
            this.courses = courses;
        }


        public override void display()
        {
            Console.Write("Информация о преподавателе:\n");
            base.display();
            Console.WriteLine("  Курсы:\n" + courses);
        }  

    }
}
