using System;
using System.Collections.Generic;
using System.Text;
using SolidTest.Controlls.Adders;
using SolidTest.Models;

namespace SolidTest.Controlls
{
    abstract class PublisherCreator
    {
        public abstract Dictionary<string, KeyValuePair<string, Action<object>>> DictionaryOfHandlers { get; set; }
        public abstract event Action<object> AddGroupEvent;
        public abstract event Action<object> AddStudentEvent;
        public abstract event Action<object> AddSubjectEvent;
        public abstract event Action<object> AddTeacherEvent;
    }

    class Creator : PublisherCreator
    {
        private readonly Repository repository;
        private readonly IAdderStudent adderStudent;
        private readonly IAdderGroup adderGroup;
        private readonly IAdderTeacher adderTeacher;
        private readonly IAdderSubjects adderSubjects;


        public override Dictionary<string, KeyValuePair<string, Action<object>>> DictionaryOfHandlers { get; set; }
        public override event Action<object> AddGroupEvent;
        public override event Action<object> AddStudentEvent;
        public override event Action<object> AddSubjectEvent;
        public override event Action<object> AddTeacherEvent;

        public Creator(Repository repository, IAdderStudent adderStudent, IAdderGroup adderGroup, IAdderTeacher adderTeacher, IAdderSubjects adderSubjects)
        {
            this.repository = repository;
            this.adderStudent = adderStudent;
            this.adderGroup = adderGroup;
            this.adderTeacher = adderTeacher;
            this.adderSubjects = adderSubjects;
            this.DictionaryOfHandlers = new Dictionary<string, KeyValuePair<string, Action<object>>>();         
        }


        public void CreateStudent(string firstName, string lastName)
        {
            adderStudent.AddStudent(new Student { FirstName = firstName, LastName = lastName, Marks = new Dictionary<Subject, int>(), StudentsGroup = new Group() }, this.repository);

            if (this.AddStudentEvent != null)
            {
                this.AddStudentEvent.Invoke($"Студент {firstName} {lastName} создан");

            }

        }

        public void CreateTeacher(string firstName, string lastName, int? category)
        {
            adderTeacher.AddTeacher(new Teacher {FirstName = firstName, LastName = lastName, Category = category }, this.repository);

            if (this.AddTeacherEvent != null)
            {
                this.AddTeacherEvent.Invoke($"Учитель {firstName} {lastName} категория:{category} создан");

            }
        }

        public void CreateGroup(string nameOfGroup)
        {
            adderGroup.AddGroup(new Group {NameOfGroup = nameOfGroup, StudentsInGroup = new List<Student>(), TeacherInGroup = new Teacher() }, this.repository);

            if (this.AddGroupEvent != null)
            {
                this.AddGroupEvent.Invoke($"Группа {nameOfGroup} создана");
            }
           
        }

        public void CreateSubjects(string subject)
        {
            adderSubjects.AddSubjects(new Subject { NameOfSubject = subject }, this.repository);

            if (this.AddSubjectEvent != null)
            {
                this.AddSubjectEvent.Invoke($"Предмет {subject} создан");

            }
        }

    }
}
