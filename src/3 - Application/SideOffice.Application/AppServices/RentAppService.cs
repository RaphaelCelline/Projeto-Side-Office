using SideOffice.Application.Interfaces;
using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Application.AppServices
{
    public class RentAppService : AppServiceBase<Rent>, IRentAppService
    {
        private readonly IRentService _rentService;
        public RentAppService(IRentService rentService)
            : base(rentService)
        {
            _rentService = rentService;
        }

        public bool CanRentOffice(DateTime start_datetime, DateTime end_datetime, Guid room_id)
        {
            return _rentService.CanRentOffice(start_datetime, end_datetime, room_id);
        }

        public IEnumerable<Rent> GetAllWhitReferences()
        {
            return _rentService.GetAllWhitReferences();
        }
        public IEnumerable<Rent> GetByDateTime(DateTime start_datetime, DateTime end_datetime)
        {
            return _rentService.GetByDateTime(start_datetime, end_datetime);
        }
        public IEnumerable<Rent> GetByRoomId(Guid room_id)
        {
            return _rentService.GetByRoomId(room_id);
        }
        public IEnumerable<Rent> GetByUserId(Guid user_id)
        {
            return _rentService.GetByUserId(user_id);
        }
        public IEnumerable<Rent> GetByUserIdAndRoomId(Guid user_id, Guid room_id)
        {
            return _rentService.GetByUserIdAndRoomId(user_id, room_id);
        }
        public bool IsRented(DateTime start_datetime, DateTime end_datetime, Guid room_id)
        {
            return _rentService.IsRented(start_datetime, end_datetime, room_id);
        }
    }
}
