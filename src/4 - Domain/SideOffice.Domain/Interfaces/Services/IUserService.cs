using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        IEnumerable<User> GetAllPendentMailUsers();
        IEnumerable<User> GetAllPendentMailUsers(IEnumerable<User> Users);
    }
}
