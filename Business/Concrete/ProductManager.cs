using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<ProductDetails>> GetProductsDetails()
        {
            return new SuccessDataResult<List<ProductDetails>>(_productDal.GetProductDetails(), Messages.ProductListed);
        }

        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Product>> GetProductsById(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().Where(p => p.Id == id).ToList(),
                Messages.ProductListedById);
        }

        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Product>> GetProductByName(string productName)
        {
            return new SuccessDataResult<List<Product>>(
                _productDal.GetAll().Where(p => p.ProductName == productName).ToList(), Messages.ProductListedByName);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Product>> GetProductByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id),
                Messages.ProductsListedByCategory);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Product>> GetProductByBrand(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.BrandId == id),
                Messages.ProductsListedByBrand);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Product>> GetProductByColour(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ColourId == id),
                Messages.ProductsListedByColour);
        }

        [SecuredOperation("SysAdmin,Admin")]
        [ValidationAspects(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [SecuredOperation("SysAdmin,Admin")]
        [ValidationAspects(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [SecuredOperation("SysAdmin,Admin")]
        [ValidationAspects(typeof(ProductValidator))]
        public IResult Delete(Product product)
        {
            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
