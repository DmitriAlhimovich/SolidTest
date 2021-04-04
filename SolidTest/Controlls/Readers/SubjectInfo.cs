using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.Reporter
{
    class SubjectInfo : IReport
    {
        public object GetReport(Repository repository)
        {
            StringBuilder stringBuilder = new StringBuilder("Список всех предметов");

            foreach (var subject in repository.Subjects)
            {
                stringBuilder.Append($"\nID предмета: {subject.Id}\tНазвание предмета : {subject.NameOfSubject}\n");

            }
            return stringBuilder.ToString();
        }
    }
}
