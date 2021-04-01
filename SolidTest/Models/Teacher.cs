using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest
{
    class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
        public int? Category { get; set; }
        public Group TeachrsGroup { get; set; }

    }
}
