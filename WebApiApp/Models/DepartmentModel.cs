﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentModel() { }
        public DepartmentModel(string name)
        {
            Name = name;
        }
    }
}