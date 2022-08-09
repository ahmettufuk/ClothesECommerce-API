using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductDetails>> GetProductsDetails();
        IDataResult<List<Product>> GetProductsById(int id);
        IDataResult<List<Product>> GetProductByName(string productName);
        IDataResult<List<Product>> GetProductByCategory(int id);
        IDataResult<List<Product>> GetProductByBrand(int id);
        IDataResult<List<Product>> GetProductByColour(int id);

        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}
