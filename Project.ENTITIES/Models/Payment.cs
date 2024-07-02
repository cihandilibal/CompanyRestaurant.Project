using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Payment: BaseEntity
    {
        public int TableNo { get; set; }
        public string PaymentType { get; set; }
        public decimal Price { get; set; }
        public  DateTime DateTime { get; set; }
    }
}
