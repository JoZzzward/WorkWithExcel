using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Расписание
{
    class Course
    {
        int number;
        Group [] group;
    
        public Course(int _number)
        {
            this.number = _number;
        }
    
        public void FillCourse(Group[] gr) => this.group = gr;
    }
}
