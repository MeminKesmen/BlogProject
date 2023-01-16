using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {


        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);

                addedEntity.State = EntityState.Added;//Ekleme işlemi yapılacağını bildirdik. 

                context.SaveChanges();//İşlemleri gerçekleştir.
            }

        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }

        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>().SingleOrDefault(filter);
            }

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filter boş mu     EVET ise bütün datayı döndür           HAYIR ise filtreyi uygula 
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }

        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity);

                updatedEntity.State = EntityState.Modified;

                context.SaveChanges();
            }
        }
        public int Count(Expression<Func<TEntity, bool>> filter=null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                 ? context.Set<TEntity>().Count()
                 : context.Set<TEntity>().Where(filter).Count();
            }

        }
        //public List<TEntity> GetAllWithInclude(Expression<Func<TEntity, bool>> filter = null,params Expression<Func<TEntity, object>>[] includes)
        //{
        //    using (TContext context = new TContext())
        //    {
        //        var query = filter == null ? context.Set<TEntity>() : context.Set<TEntity>().Where(filter);
        //        foreach (var item in includes)
        //        {
        //            query = query.Include(item);
        //        }
        //        return query.ToList();
        //    }

        //}
    }
}
