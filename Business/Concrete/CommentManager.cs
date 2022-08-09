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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]
        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(),Messages.CommentListed);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IDataResult<List<Comment>> GetCommentsByUserId(int userId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll().Where(p => p.UserId == userId).ToList(),
                Messages.CommentListed);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
        [SecuredOperation("SysAdmin,Admin,Customer")]

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }
    }
}
