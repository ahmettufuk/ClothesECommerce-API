using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        [SecuredOperation("SysAdmin,Admin")]

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrdersListed);
        }
        [SecuredOperation("SysAdmin,Admin")]

        public IDataResult<List<Order>> GetOrdersByUserId(int userId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll().Where(p => p.User.Id == userId).ToList(),
                Messages.OrdersListedByUserId);
        }
        [SecuredOperation("SysAdmin,Admin")]

        public IDataResult<List<Order>> GetOrdersByProduct(Product product)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll().Where(p => p.Products == product).ToList(),
                Messages.OrdersListedByProduct);
        }
        [SecuredOperation("SysAdmin")]

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrdersAdded);
        }
        [SecuredOperation("SysAdmin")]

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrdersUpdated);   
        }
        [SecuredOperation("SysAdmin")]

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrdersDeleted);
        }
    }
}
