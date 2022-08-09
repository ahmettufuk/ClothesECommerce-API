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
    public interface ISaleService
    {
        IDataResult<List<SaleDetails>> GetAllSaleDetails();
        IDataResult<List<SaleDetails>> GetSaleDetailsByCategory(string name);
        IDataResult<List<SaleDetails>> GetSaleDetailsByBrand(string name);
        IDataResult<List<SaleDetails>> GetSaleDetailByProduct(string name);
        IResult Add(Sale sale);
        IResult Delete(Sale sale);
        IResult Update(Sale sale);

    }
}
