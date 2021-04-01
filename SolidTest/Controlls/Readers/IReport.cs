using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.Reporter
{
    interface IReport
    {
        object GetReport(Repository studentRepository);
    }
}
