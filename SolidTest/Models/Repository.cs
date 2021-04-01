using SolidTest.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SolidTest
{
    class Repository
    {
        private static Repository studentRepository;

        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
        public List<Subject> Subjects { get; set; }


        public static Repository RepositoryBuilder
        {
            get 
            { 
                if (Repository.studentRepository == null)
                {
                    Repository.studentRepository = new Repository();
                    return Repository.studentRepository;
                }
                else
                {
                    return Repository.studentRepository;
                }
                
            }
        }
                   
        private Repository()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
            this.Groups = new List<Group>();
            this.Subjects = new List<Subject>();
        } 

    }
}
