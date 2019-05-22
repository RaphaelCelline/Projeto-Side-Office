using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces.Repositories;
using SideOffice.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SideOffice.Domain.Services
{
    public class RentService : ServiceBase<Rent>, IRentService
    {
        private readonly IRentRepository _rentRepository;

        public RentService(IRentRepository rentRepository)
            : base(rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public IEnumerable<Rent> GetAllWhitReferences()
        {
            return _rentRepository.GetAllWhitReferences();
        }

        public IEnumerable<Rent> GetByDateTime(DateTime start_datetime, DateTime end_datetime)
        {
            return _rentRepository.GetByDateTime(start_datetime, end_datetime);
        }

        public IEnumerable<Rent> GetByRoomId(Guid room_id)
        {
            return _rentRepository.GetByRoomId(room_id);
        }

        public IEnumerable<Rent> GetByUserId(Guid user_id)
        {
            return _rentRepository.GetByUserId(user_id);
        }

        public IEnumerable<Rent> GetByUserIdAndRoomId(Guid user_id, Guid room_id)
        {
            return _rentRepository.GetByUserIdAndRoomId(user_id, room_id);
        }

        public bool IsRented(DateTime start_datetime, DateTime end_datetime, Guid room_id)
        {
            return _rentRepository.IsRented(start_datetime, end_datetime, room_id);
        }

        public bool CanRentOffice(DateTime start_datetime, DateTime end_datetime, Guid room_id)
        {
            var offices = _rentRepository.GetByDateTime(start_datetime, end_datetime).Where(p => p.Room_id == room_id);

            if (offices.Count() > 0)
                return false;
            else
                return true;
        }
    }
}
