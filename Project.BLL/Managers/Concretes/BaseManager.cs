using Project.BLL.Managers.Abstracts;
using Project.ENTITIES.CoreIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class BaseManager<T>:IManager<T> where T: class, IEntity 
    {
        public BaseManager()
    }
}
