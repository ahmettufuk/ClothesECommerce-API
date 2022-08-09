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
    public class ColourManager : IColourService
    {
        private readonly IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(), Messages.ColourListed);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Add(Colour colour)
        {
            _colourDal.Add(colour);
            return new SuccessResult(Messages.ColourAdded);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Delete(Colour colour)
        {
            _colourDal.Delete(colour);
            return new SuccessResult(Messages.ColourDeleted);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Update(Colour colour)
        {
            _colourDal.Update(colour);
            return new SuccessResult(Messages.ColourUpdated);
        }
    }
}
