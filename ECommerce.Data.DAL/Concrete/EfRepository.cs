using ECommerce.Data.DAL.Abstract;
using ECommerce.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Data.DAL.Concrete
{
    public class EfRepository<TEntity> : IEfRespository<TEntity> where TEntity : BaseEntity<int>
    {
        private DbSet<TEntity> _dbset;
        public DbSet<TEntity> DbSet
        {
            get { return _dbset; }
            set { _dbset = value; }
        }

        private ECommerceContext context;

        public EfRepository(ECommerceContext _context)
        {
            context = _context;
            _dbset = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public TEntity GetById(int Id)
        {
            return DbSet.Where(p => p.Id == Id).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetList()
        {
            return DbSet.ToList();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return DbSet as IQueryable<TEntity>;
        }
    }
}
