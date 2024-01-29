using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace WpfApp1.Database.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> Create(TEntity item);
        Task<TEntity> FindById(Guid id);
        Task<IEnumerable<TEntity>> Get();
        Task<int> Remove(TEntity item);
        Task<int> Update(TEntity item);
    }
}
