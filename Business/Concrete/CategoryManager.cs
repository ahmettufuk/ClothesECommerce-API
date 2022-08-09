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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }
        [SecuredOperation("SysAdmin,Admin")]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
