using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetOrdersByUserId(int userId);
        IDataResult<List<Order>> GetOrdersByProduct(Product product);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);

    }
}
