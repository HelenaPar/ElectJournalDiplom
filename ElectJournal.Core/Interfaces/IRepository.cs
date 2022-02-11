using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Get(int id);
        TEntity Get(ISpecification<TEntity> specification);
        IList<TEntity> List();
        IList<TEntity> List(ISpecification<TEntity> specification);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
