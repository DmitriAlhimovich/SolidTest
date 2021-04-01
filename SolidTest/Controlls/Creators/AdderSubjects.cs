using SolidTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.Adders
{
    interface IAdderSubjects
    {
        void AddSubjects(Subject subject, Repository repository);

    }


    class AdderSubjects : IAdderSubjects
    {
        public void AddSubjects(Subject subject, Repository repository)
        {
            repository.Subjects.Add(subject);
        }
    }
}
