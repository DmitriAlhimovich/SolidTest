using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Models
{
    class Subject
    {
        private static List<int> listOfExistingIds = new List<int>();/// <summary>
        /// для рандомных не повторяющихся номеров
        /// </summary>

        public string NameOfSubject { get; set; }
        public int Id { get; }

        public Subject()
        {
            int randId;
            do
            {
                randId = new Random().Next(0, 20);
            }
            while (listOfExistingIds.Contains(randId));

            this.Id = randId;
            Subject.listOfExistingIds.Add(randId);        

        }
    }
}
