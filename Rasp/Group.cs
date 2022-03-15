using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Group
    {
        List<Student> studs;

        private int number;
        public int GetNumber() { return number; }

        private string[] listTheme;
        public string[] GetTheme() { return listTheme; }


        public Group(int _number)
        {
            this.number = _number;
            studs = new List<Student>();
        }

        public void AddStud(Student st) => studs.Add(st);

        public void FillTheme(string list)
        {
            string[] tmp = list.Split();
            int n = tmp.Length;
            listTheme = new string[n];

            for (int i = 0; i < n; i++)
                listTheme[i] = tmp[i];
        }

        public void display(){
            Console.WriteLine("студенты "+number+" группы");
            foreach (Student stud in studs)
                stud.display();

            Console.WriteLine();
            Console.WriteLine("изучаемые предметы");

            for(int i=0; i<listTheme.Length; i++){
                Console.Write(listTheme[i]+"  ");
            }
            Console.WriteLine();
        }
    }
}
