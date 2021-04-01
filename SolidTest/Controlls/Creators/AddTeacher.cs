using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.Adders
{
    interface IAdderTeacher
    {
        void AddTeacher(Teacher teacher, Repository repository);

    }


    class AdderTeacher : IAdderTeacher
    {
        public void AddTeacher(Teacher teacher, Repository repository)
        {
            repository.Teachers.Add(teacher);
        }
    }
}
