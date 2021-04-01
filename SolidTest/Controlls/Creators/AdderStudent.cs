using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.Adders
{
    interface IAdderStudent
    {
        void AddStudent(Student student, Repository studentRepository);

    }

    class AdderStudent : IAdderStudent
    {
        public void AddStudent(Student student, Repository studentRepository)
        {
            studentRepository.Students.Add(student);
        }
    }


}
