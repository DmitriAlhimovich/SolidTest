using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.Reporter
{

        class TeachersInfo : IReport
        {
            public object GetReport(Repository repository)
            {
                StringBuilder stringBuilder = new StringBuilder("Список всех учителей");

                foreach (var teacher in repository.Teachers)
                {
                    stringBuilder.Append($"\nИмя: {teacher.FullName} Группа: {teacher.TeachrsGroup} Категория: {teacher.Category}\n");
                 
                }
                return stringBuilder.ToString();
            }
        }



       
    
}
