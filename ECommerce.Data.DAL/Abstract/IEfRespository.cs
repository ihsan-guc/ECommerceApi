using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data.DAL.Abstract
{
    public interface IEfRespository<TEntity>
    {
        IEnumerable<TEntity> GetList();
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        TEntity GetById(int Id);
        void Commit();
        IQueryable<TEntity> GetQueryable();

    }
}
