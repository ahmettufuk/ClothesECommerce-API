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
using Entities.DTOs;

namespace Business.Concrete
{
    public class SaleManager : ISaleService
    {
        private ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<SaleDetails>> GetAllSaleDetails()
        {
            var result = _saleDal.GetSaleDetails().Where(p => p.SaleFinishDate > DateTime.Now).ToList();
            return new SuccessDataResult<List<SaleDetails>>(result, Messages.SaleListed);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IDataResult<List<SaleDetails>> GetSaleDetailsByCategory(string name)
        {
            var result = _saleDal.GetSaleDetails().Where(p => p.SaleFinishDate > DateTime.Now && p.CategoryName==name).ToList();
            return new SuccessDataResult<List<SaleDetails>>(result, Messages.SaleListedByCategory);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IDataResult<List<SaleDetails>> GetSaleDetailsByBrand(string name)
        {
            var result = _saleDal.GetSaleDetails().Where(p => p.SaleFinishDate > DateTime.Now && p.BrandName == name).ToList();
            return new SuccessDataResult<List<SaleDetails>>(result, Messages.SaleListedByBrand);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IDataResult<List<SaleDetails>> GetSaleDetailByProduct(string name)
        {
            var result = _saleDal.GetSaleDetails().Where(p => p.SaleFinishDate > DateTime.Now && p.ProductName == name).ToList();
            return new SuccessDataResult<List<SaleDetails>>(result, Messages.SaleListedByProduct);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Add(Sale sale)
        {
            _saleDal.Add(sale);
            return new SuccessResult(Messages.SaleAdded);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Delete(Sale sale)
        {
            _saleDal.Delete(sale);
            return new SuccessResult(Messages.SaleDeleted);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Update(Sale sale)
        {
            _saleDal.Update(sale);
            return new SuccessResult(Messages.SaleUpdated);
        }
    }
}
