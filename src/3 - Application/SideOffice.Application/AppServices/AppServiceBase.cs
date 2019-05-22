using SideOffice.Application.Interfaces;
using SideOffice.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Application.AppServices
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }
        public void Dispose()
        {
            _serviceBase.Dispose();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }
        public TEntity GetById(Guid id)
        {
            return _serviceBase.GetById(id);
        }
        public void Remove(Guid id)
        {
            _serviceBase.Remove(id);
        }
        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }
    }
}
