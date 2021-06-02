using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public static class AssociateData
    {
        public static List<Associate> Associates;

        static AssociateData() { Associates = StartAssociate(); }

        static List<Associate> StartAssociate()
        {
            return new List<Associate>()
            {
                new Associate(1,"Emre Hatipoğlu"),
                new Associate(2,"Hüseyin Hatipoğlu"),
                new Associate(3,"Elif Hatipoğlu"),
                new Associate(4,"Sedat Hatipoğlu"),
            };
        }
    }
}
