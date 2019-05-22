using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Application.Interfaces
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        IEnumerable<User> GetAllPendentMailUsers();
        IEnumerable<User> GetAllPendentMailUsers(IEnumerable<User> Users);
    }
}
