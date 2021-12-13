using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElectJournal.Infrastrusture.Data.Repository
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly JournalDbContext dbContext;

        public EFRepository(JournalDbContext context)
        {
            dbContext = context;
        }
        public TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public IList<TEntity> Get(ISpecification<TEntity> specification)
        {
            return specification.Apply(dbContext.Set<TEntity>()).AsNoTracking().ToList();
        }

        public IList<TEntity> List()
        {
            return dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public IList<TEntity> List(ISpecification<TEntity> specification)
        {
            return specification.Apply(dbContext.Set<TEntity>()).AsNoTracking().ToList();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            //dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
