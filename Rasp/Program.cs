using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Расписание
{
    class Program
    {
        static void Main(string[] args)
        {
            Maker maker = new Maker();
            maker.makeShedule();
            maker.GetShedule();
            maker.display();
        }
    }
}
