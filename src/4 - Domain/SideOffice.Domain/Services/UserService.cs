using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces.Repositories;
using SideOffice.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SideOffice.Domain.Services
{
    public class UserService : ServiceBase<User>,  IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAllPendentMailUsers()
        {
            return _userRepository.GetAll().Where(c => c.NeedCofirmEmail(c));
        }
        public IEnumerable<User> GetAllPendentMailUsers(IEnumerable<User> Users)
        {
            return Users.Where(c => c.NeedCofirmEmail(c));
        }
    }
}
