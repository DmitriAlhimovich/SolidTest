using System;
using System.Collections.Generic;
using System.Text;

namespace SolidTest.Controlls.Adders
{  
        interface IAdderGroup
        {
            void AddGroup(Group group, Repository repository);

        }

        class AdderGroup : IAdderGroup
        {
            public void AddGroup(Group group, Repository repository)
            {
                repository.Groups.Add(group);
            }
        }
    
}
