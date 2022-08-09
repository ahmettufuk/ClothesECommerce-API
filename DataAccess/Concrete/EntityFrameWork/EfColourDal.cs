using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfColourDal : EfEntityRepositoryBase<Colour,ClothesECommerceDbContext>,IColourDal
    {
    }
}
