using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITCompany.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Problem(string name)
        {
            Name = name;
        }
    }
}
