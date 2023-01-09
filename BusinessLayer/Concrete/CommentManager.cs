using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
           _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public Comment Get(Expression<Func<Comment, bool>> filter)
        {
            return _commentDal.Get(filter);
        }

        public List<Comment> GetAll(Expression<Func<Comment, bool>> filter = null)
        {
            return  _commentDal.GetAll(filter);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
