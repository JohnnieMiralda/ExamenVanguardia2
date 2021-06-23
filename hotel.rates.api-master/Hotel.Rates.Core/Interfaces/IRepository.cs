using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        void Add(TEntity entity);

        TEntity GetById(TKey key);

        IReadOnlyList<TEntity> GetAll();
    }
}
