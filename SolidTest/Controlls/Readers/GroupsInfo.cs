using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidTest.Controlls.Reporter
{
    class GroupsInfo : IReport
    {
        public object GetReport(Repository repository)
        {
            StringBuilder stringBuilder = new StringBuilder("Список всех групп");

            foreach (var group in repository.Groups)
            {                
                stringBuilder.Append($"\nНомер группы: {group.NameOfGroup} Учитель: {group.TeacherInGroup.FullName} Количество учеников: {group.StudentsInGroup.Count()}\n");            
            }
            return stringBuilder.ToString();
        }
    }
}
