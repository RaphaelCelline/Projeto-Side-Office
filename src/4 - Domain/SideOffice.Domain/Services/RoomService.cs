using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces.Repositories;
using SideOffice.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Domain.Services
{
    public class RoomService : ServiceBase<Room>, IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
            : base(roomRepository)
        {
            _roomRepository = roomRepository;
        }
    }
}
