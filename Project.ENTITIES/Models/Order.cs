using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Order:BaseEntity
    {  
        public int TableNo { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal PriceOfOrder { get; set; }

        //Relational Properties
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
       

    }
}
