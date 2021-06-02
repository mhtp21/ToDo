using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class AssociateManager
    {
        public Associate FindAssocciate(int AssociateId)
        {
            return AssociateData.Associates.FirstOrDefault(i => i.Id == AssociateId);
        }
    }
}
