using SolidTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest
{
    class Student
    {
        public int Id 
        { 
            get
            {
                return this.GetHashCode()%1000;
            }           
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Group StudentsGroup { get; set; }
        public string FullName
        { 
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }

        public Dictionary<Subject, int> Marks { get; set; }

    }
}
