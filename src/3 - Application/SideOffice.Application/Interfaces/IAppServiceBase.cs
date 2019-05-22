using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
        void Dispose();
    }
}
