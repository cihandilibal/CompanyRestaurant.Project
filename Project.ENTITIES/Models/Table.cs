﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Table: BaseEntity
    {
        public int TableNo { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
