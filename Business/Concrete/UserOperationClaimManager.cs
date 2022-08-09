using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        public IResult Add(UserOperationClaim claim)
        {
            _userOperationClaimDal.Add(claim);
            return new SuccessResult();
        }

        public IResult Update(UserOperationClaim claim)
        {
            _userOperationClaimDal.Update(claim);
            return new SuccessResult();
        }

        public IResult Delete(UserOperationClaim claim)
        {
            _userOperationClaimDal.Delete(claim);
            return new SuccessResult();
        }
    }
}
