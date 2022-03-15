using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Расписание
{
    class Maker
    {
        Random rnd = new Random();
        int couplesMAX = 4;

        List<Lecturer> listLect;
        bool[] busyLecturer;

        List<int> listAud;

        bool[] audClose;

        List<Group> groupCount;
        Lecturer lec;

        string[,] shed;
        string[] shedule = new string[12];

        public Maker()
        {
            listLect = new List<Lecturer>();
            listAud = new List<int>();
            groupCount = new List<Group>();
        }

        public void GetShedule()
        {
            int rows = 5;
            int cols = 6;

            Excel.Application ExcelApp = new Excel.Application();
            string pathToExcel = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\MainShedule.xlsx";

            Workbook wb = ExcelApp.Workbooks.Open($@"{pathToExcel}");
            Worksheet ws = ExcelApp.Worksheets[1];

            string pathToTxt = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\allInfo.txt";
            string[] lines = File.ReadAllLines($@"{pathToTxt}");

            if (ExcelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }
            ws.Cells.ColumnWidth = 18;
            ws.Cells.RowHeight = 30;
            ws.Cells.WrapText = true;
            string[] daysOfWeek = new string[6]
            {
                "Понедельник",
                "Вторник",
                "Среда",
                "Четверг",
                "Пятница",
                "Cуббота"
            };
            int k = 0;
            Random r = new Random();
            for (int i = 1; i <= rows; i++)
                for (int j = 1; j <= cols; j++)
                    if (i == 1)
                        ws.Cells[i, j].Value2 = daysOfWeek[j - 1];
                    else
                        ws.Cells[i, j].Value2 = $"{lines[r.Next(0, 17)]}";
            wb.Save();
            wb.SaveAs();
            ExcelApp.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(ExcelApp);
        }

        void addLect(Lecturer lect) => listLect.Add(lect);

        void addAud(int n) => listAud.Add(n);

        void addGroup(Group gr) => groupCount.Add(gr);

        static bool found(string s, string[] ss)
        {
            for (int i = 0; i < ss.Length; i++)
                if (ss[i].Equals(s))
                    return true;
            return false;
        }


        public void makeShedule()
        {
            // Добавление преподавателей в список
            lec = new Lecturer("Самойлов", "-", "-", "ООП лекция");
            addLect(lec);
            lec = new Lecturer("Самойлов", "-", "-", "ООП");
            addLect(lec);
            lec = new Lecturer("Тарасов", "-", "-", "КГ лекция");
            addLect(lec);
            lec = new Lecturer("Стрельникова", "-", "-", "Английский");
            addLect(lec);
            lec = new Lecturer("Беломытцева", "-", "-", "ТФКП лекция");
            addLect(lec);
            lec = new Lecturer("Решетова", "-", "-", "ТФКП");
            addLect(lec);
            lec = new Lecturer("Кургалин", "-", "-", "ДМ лекция");
            addLect(lec);
            lec = new Lecturer("Малыхин", "-", "-", "УД");
            addLect(lec);
            lec = new Lecturer("Толстобров", "-", "-", "УД лекция");
            addLect(lec);
            lec = new Lecturer("Черницын", "-", "-", "КГ");
            addLect(lec);
            lec = new Lecturer("Атанов", "-", "-", "Диффуры");
            addLect(lec);
            lec = new Lecturer("Стукалова", "-", "-", "ДМ");
            addLect(lec);
            lec = new Lecturer("Каверина", "-", "-", "Диффуры лекция");
            addLect(lec);
            lec = new Lecturer("Попова", "-", "-", "ТеорВер лекция");
            addLect(lec);
            lec = new Lecturer("Попова", "-", "-", "Теорвер");
            addLect(lec);
            lec = new Lecturer("Вяткина", "-", "-", "Филосовия лекция");
            addLect(lec);
            lec = new Lecturer("Вяткина", "-", "-", "Философия");
            addLect(lec);

            // Заполнение списка аудиторий
            listAud.Add(380);
            listAud.Add(297);
            listAud.Add(292);
            listAud.Add(383);
            listAud.Add(381);
            listAud.Add(497);
            listAud.Add(498);
            listAud.Add(383);
            listAud.Add(385);
            listAud.Add(384);
            listAud.Add(382);
            listAud.Add(295);

            // Заполнение списка групп

            Group group;

            group = new Group(1);
            group.FillTheme("ООП КГ Английский ТФКП ДМ Диффуры Теорвер УД Философия");
            groupCount.Add(group);

            group = new Group(2);
            group.FillTheme("ООП КГ Английский ТФКП ДМ Диффуры Теорвер УД Философия");
            groupCount.Add(group);

            group = new Group(3);
            group.FillTheme("ООП КГ Английский ТФКП ДМ Диффуры Теорвер УД Философия");
            groupCount.Add(group);


            int len = listLect.Count;
            busyLecturer = new bool[len];
            for (int i = 0; i < len; i++)
                busyLecturer[i] = false;
            int groupNumber = groupCount.Count;

            string[] theme = groupCount[0].GetTheme();
            int numTheme = theme.Length;
            shed = new string[couplesMAX, groupNumber];

            bool[] activeItem = new bool[numTheme];
            for (int i = 0; i < numTheme; i++)
                activeItem[i] = false;

            int numLec = listLect.Count;
            int numAud = listAud.Count;

            // Используемые предметы
            bool[,] totalActiveItem = new bool[numTheme, groupNumber];

            for (int i = 0; i < numTheme; i++)
                for (int j = 0; j < groupNumber; j++)
                    totalActiveItem[i, j] = false;
            audClose = new bool[numAud];


            int temp;
            //      СОСТАВЛЕНИЕ РАСПИСАНИЯ


            // Составление списка пар
            for (int i = 0; i < couplesMAX; i++)
            {

                for (int k = 0; k < numTheme; k++)
                    activeItem[k] = false;

                for (int k = 0; k < numLec; k++)
                    busyLecturer[k] = false;

                for (int k = 0; k < numAud; k++)
                    audClose[k] = false;

                for (int j = 0; j < groupNumber; j++)
                {
                    do temp = rnd.Next(numTheme);
                    while (activeItem[temp] || totalActiveItem[temp, j]);

                    totalActiveItem[temp, j] = true;
                    activeItem[temp] = true;

                    string res = theme[temp];

                    bool isLecturer = false;

                    for (int k = 0; k < numLec; k++)
                        if (!busyLecturer[k] && (string.Compare(res, listLect[k].getCourses()) == 0))
                        {
                            isLecturer = true;
                            temp = k;
                            break;
                        }

                    if (isLecturer)
                    {
                        res += " " + listLect[temp].GetName();
                        busyLecturer[temp] = true;
                    }
                    else res = "свободная пара";

                    do temp = rnd.Next(numAud);
                    while (audClose[temp]);

                    audClose[temp] = true;

                    shed[i, j] = res + " " + listAud[temp] + " ";
                }
            } 

        }
        //составление расписания
        public void display()
        {
            for (int i = 0; i < couplesMAX; i++)
            {
                for (int j = 0; j < groupCount.Count; j++)
                {
                    Console.Write(shed[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}