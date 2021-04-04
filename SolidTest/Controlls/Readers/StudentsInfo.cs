using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SolidTest.Controlls.Reporter
{
    


    class StudentsInfo : IReport
    {
        public object GetReport(Repository repository)
        {
            StringBuilder stringBuilder = new StringBuilder("Список всех студентов");

            foreach (var student in repository.Students)
            {
                stringBuilder.Append($"\nId:{student.Id}  Имя: {student.FullName} Группа: {student.StudentsGroup.NameOfGroup}\nОценки:\n");

                foreach (var mark in student.Marks)
                {
                    stringBuilder.Append($"{mark.Key.NameOfSubject} {mark.Value}\n");
                }
            }
            return stringBuilder.ToString();        
        }
    }
}
