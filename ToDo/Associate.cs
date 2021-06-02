using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    public class Associate
    {
        public int Id { get; set; }
        public string FullName { get; set; }


        public Associate(int id, string fullName)
        {
            this.Id = id;
            this.FullName = fullName;
        }
    }
}
