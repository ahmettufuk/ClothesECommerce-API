using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFrameWork;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfProductDal : EfEntityRepositoryBase<Product,ClothesECommerceDbContext> , IProductDal
    {
        public List<ProductDetails> GetProductDetails()
        {
            using (ClothesECommerceDbContext context = new())
            {
                var result = from product in context.Products
                    join brand in context.Brands on product.BrandId equals brand.Id
                    join colour in context.Colours on product.ColourId equals colour.Id
                    join category in context.Categories on product.CategoryId equals category.Id
                    join size in context.Sizes on product.SizeId equals size.Id
                    select new ProductDetails()
                    {
                        Id = product.Id,
                        CategoryName = category.CategoryName,
                        BrandName = brand.BrandName,
                        ColourName = colour.ColourName,
                        SizeName = size.SizeName,
                        ProductName = product.ProductName,
                        UnitInStock = product.UnitInStock,
                        UnitPrice = product.UnitPrice,
                        Description = product.Description
                        
                    };

                return result.ToList();
            }
        }
    }
}
