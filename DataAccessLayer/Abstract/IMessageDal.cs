﻿using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<Message> GetListWithWriter(Expression<Func<Message,bool>> filter=null);
    }
}
