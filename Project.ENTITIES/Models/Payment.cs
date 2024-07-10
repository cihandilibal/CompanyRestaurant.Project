using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Payment: BaseEntity
    {
        public int OrderNo { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public  DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        
        

    }
}
