using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Student: Person
    {
        private int course;
        public int GetCourse() { return course; }

        private int group;
        public int GetGroup() { return group; }

        public Student(string _Name, string _Adress, int _Course, int _Group)
                     : base(_Name, _Adress)
        {
            this.course = _Course;
            this.group = _Group;
        }

        public override void display()
        {
            Console.WriteLine("Информация о студенте: ");
            base.display();
            Console.Write("  Курс\t" + course);
            Console.WriteLine("  Группа\t" + group);
        }



    }
}
