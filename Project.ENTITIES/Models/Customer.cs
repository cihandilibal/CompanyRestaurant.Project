using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Customer : BaseEntity
    {
        public string Name {get;set;}
        public string LastName { get; set; }
        public int MobileNo { get; set; }
       
    }
}

