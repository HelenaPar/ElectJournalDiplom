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
            //dbContext.Set<TEntity>().Remove(entity);
            dbContext.Entry(entity).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Delete(int id) //самодельный
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            dbContext.Entry(entity).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                dbContext.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public TEntity Get(ISpecification<TEntity> specification)
        {
            return ApplySpecification(dbContext.Set<TEntity>(), specification).FirstOrDefault();
        }

        public IList<TEntity> List()
        {
            return dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public IList<TEntity> List(ISpecification<TEntity> specification)
        {
            return ApplySpecification(dbContext.Set<TEntity>(), specification).ToList();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            //dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
        }

            /*var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    dbContext.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is TEntity)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];
                            }

                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                }
            }*/
        

        private IQueryable<TEntity> ApplySpecification(IQueryable<TEntity> source, ISpecification<TEntity> specification)
        {
            var result = specification.Apply(source);

            foreach (var include in specification.Includes)
            {
                result = result.Include(include);
            }

            return result.AsNoTracking();
        }
    }
}
