﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Duty { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public int OffNumber { get; set; }
    }
}
