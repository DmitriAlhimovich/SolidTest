using SolidTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SolidTest.Controlls.Updaters
{
    class StudentException : Exception
    {
        public StudentException(string message, Exception exception): base(message,exception)
        {

        }

        public StudentException(string message): base(message)
        {

        }
    }

    interface IFinderById<out T>// интерфейс поиска элементов по Id
    {
        T FindElement(Repository repository, int id);
    }

    class FinderOfStudent : IFinderById<Student>// класс который ищет студента по ID
    {
        public Student FindElement(Repository repository, int id)
        {
            Student concreteStudent = null;

                var queryOfStudentById = repository.Students.FirstOrDefault(st => st.Id == id);
                concreteStudent = queryOfStudentById;
                if (queryOfStudentById == null)
                    throw new StudentException($"Студет с Id = {id} - не найден!!");// если нет студента с введеным ID бросаем исключение

 
           
            return concreteStudent;

        }
    }
    class FinderOfSubject : IFinderById<Subject> //класс который ищет предмет по ID
    {
        public Subject FindElement(Repository repository, int id)
        {
            Subject concreteSubject;
           
                var queryOfSubjectById = repository.Subjects.FirstOrDefault(st => st.Id == id);
                concreteSubject = queryOfSubjectById;
                if (queryOfSubjectById == null)
                    throw new StudentException($"Предмет с Id = {id} - не найден!!");// если нет предмета с введеным ID бросаем исключение


            return concreteSubject;
        }
    }



    class MarkMaker
    {
        private Repository Repository { get; set; }
        private IFinderById<Student> FinderStudenByID { get; set; }
        private IFinderById<Subject> FinderSubjectByID { get; set; }

        public MarkMaker(Repository repository, IFinderById<Student> studentFinder, IFinderById<Subject> subjectFinder)
        {
            this.Repository = repository;
            this.FinderStudenByID = studentFinder;
            this.FinderSubjectByID = subjectFinder;

        }

        public void Rate(int idStudent, int idSubject, int mark)// Главный метод который выставляет оценки 
        {
            Student student = FinderStudenByID.FindElement(this.Repository, idStudent);
            Subject subject = FinderSubjectByID.FindElement(this.Repository, idSubject);

            this.GradeTheStudent(student,subject, mark );


        }


        private void GradeTheStudent(Student student, Subject subject, int mark)   // поставить оценку ученику
        {

            var queryOfStudent = this.Repository.Students.FirstOrDefault(st => st.Equals(student));

            try
            {
                if (mark < 0 || mark >10)
                {
                    throw new StudentException("Введенная оценка вне диапазона");//  бросаем исключение выходза границы
                }

                queryOfStudent.Marks.Add(subject, mark);//если у ученика нет предмета, то он добавляется в месте с оценкой
            }
            catch (ArgumentException)// если у ученика уже есть предмет, то перезаписывается оценка
            {               
                Console.WriteLine("оценка изменена");// для проверки
                queryOfStudent.Marks[subject] = mark;
            }         

        }
    }



}
