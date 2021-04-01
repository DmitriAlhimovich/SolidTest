using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest
{
    class Group
    {
        public string NameOfGroup { get; set; }

        public List<Student> StudentsInGroup { get; set; }

        public Teacher TeacherInGroup { get; set; }
    }
}
