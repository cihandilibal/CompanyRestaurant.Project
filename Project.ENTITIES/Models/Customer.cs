using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Customer : BaseEntity
    {
        public string CustomerName {get;set;}
        public string CustomerLastName { get; set; }
        public int MobileNo { get; set; }
       
}
}

