using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Domain.Interfaces.Services
{
    public interface IRentService : IServiceBase<Rent>
    {
        bool CanRentOffice(DateTime start_datetime, DateTime end_datetime, Guid room_id);
        IEnumerable<Rent> GetAllWhitReferences();
        IEnumerable<Rent> GetByDateTime(DateTime start_datetime, DateTime end_datetime);
        IEnumerable<Rent> GetByUserId(Guid user_id);
        IEnumerable<Rent> GetByRoomId(Guid room_id);
        IEnumerable<Rent> GetByUserIdAndRoomId(Guid user_id, Guid room_id);
        bool IsRented(DateTime start_datetime, DateTime end_datetime, Guid room_id);
    }
}
