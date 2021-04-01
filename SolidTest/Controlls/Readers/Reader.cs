using System;
using System.Collections.Generic;
using System.Text;
using SolidTest.Controlls.Reporter;

namespace SolidTest.Controlls
{
    class Reader
    {
        private readonly Repository repository;       

        public Reader(Repository repository)
        {
            this.repository = repository;
            
        }

        public object ShowInfo(IReport report)
        {
            return report.GetReport(repository);
        }

    }
}
