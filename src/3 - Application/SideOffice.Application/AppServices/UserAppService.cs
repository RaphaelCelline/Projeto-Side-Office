using SideOffice.Application.Interfaces;
using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Application.AppServices
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
        }

        public IEnumerable<User> GetAllPendentMailUsers()
        {
            return _userService.GetAllPendentMailUsers();
        }
        public IEnumerable<User> GetAllPendentMailUsers(IEnumerable<User> Users)
        {
            return _userService.GetAllPendentMailUsers(Users);
        }
    }
}
