using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class OrderDetailManager:BaseManager<OrderDetail>, IOrderDetailManager
    {
        readonly IOrderDetailRepository _odRep;
        public OrderDetailManager(IOrderDetailRepository odRep): base(odRep)
        {
            _odRep = odRep;
        }

        public decimal PriceOfOrder()
        {
            decimal totalprice = 0;
            List<OrderDetail> orderDetails = _odRep.GetActives();
            foreach (OrderDetail item in orderDetails)
            {
                totalprice += item.Quantity * item.UnitPrice;
            }
            return totalprice;
        }
       
    }
}
