using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IResult Add(UserOperationClaim claim);
        IResult Update(UserOperationClaim claim);
        IResult Delete(UserOperationClaim claim);
    }
}
