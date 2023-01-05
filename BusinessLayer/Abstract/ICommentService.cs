using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll(Expression<Func<Comment, bool>> filter = null);
        Comment Get(Expression<Func<Comment, bool>> filter);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
