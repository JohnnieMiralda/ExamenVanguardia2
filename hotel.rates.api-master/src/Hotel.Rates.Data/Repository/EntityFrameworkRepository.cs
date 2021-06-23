using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repository
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly InventoryContext _context;
       public EntityFrameworkRepository(InventoryContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(TKey key)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(key));
        }

        public IReadOnlyList<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
