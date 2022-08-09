using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<Comment>> GetCommentsByUserId(int userId);
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
    }
}
