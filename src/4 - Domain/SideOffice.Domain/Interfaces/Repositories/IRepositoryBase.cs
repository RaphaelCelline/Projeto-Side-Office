using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        // CRUD
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        void Dispose();
    }
}
