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
    public class SizeManager : ISizeService
    {
        private readonly ISizeDal _sizeDal;

        public SizeManager(ISizeDal sizeDal)
        {
            _sizeDal = sizeDal;
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IDataResult<List<Size>> GetAll()
        {
            return new SuccessDataResult<List<Size>>(_sizeDal.GetAll(), Messages.SizeListed);
        }
        [SecuredOperation("SysAdmin,Admin")]

        public IResult Add(Size size)
        {
            _sizeDal.Add(size);
            return new SuccessResult(Messages.SizeAdded);
        }
        [SecuredOperation("SysAdmin,Admin")]

        public IResult Delete(Size size)
        {
            _sizeDal.Delete(size);
            return new SuccessResult(Messages.SizeDeleted);
        }
        [SecuredOperation("SysAdmin,Admin")]

        public IResult Update(Size size)
        {
            _sizeDal.Update(size);
            return new SuccessResult(Messages.SizeUpdated);
        }
    }
}
