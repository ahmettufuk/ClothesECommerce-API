using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfSaleDal : EfEntityRepositoryBase<Sale,ClothesECommerceDbContext>,ISaleDal
    {
        public List<SaleDetails> GetSaleDetails()
        {
            using (ClothesECommerceDbContext context = new())
            {
                var result = from sale in context.Sales
                    join brand in context.Brands on sale.BrandId equals brand.Id
                    join category in context.Categories on sale.CategoryId equals category.Id
                    join product in context.Products on sale.ProductId equals product.Id
                    select new SaleDetails()
                    {
                        BrandName = brand.BrandName,
                        CategoryName = category.CategoryName,
                        ProductName = product.ProductName,
                        SaleAmount = sale.SaleAmount,
                        BeforeSaledPrice = product.UnitPrice,
                        SaledPrice = product.UnitPrice * sale.SaleAmount,
                        Description = sale.Description,
                        SaleFinishDate = sale.SaleStartDate
                    };
                return result.ToList();


            }
        }
    }
}
