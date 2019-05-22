using SideOffice.Application.Interfaces;
using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Application.AppServices
{
    public class RoomAppService : AppServiceBase<Room>, IRoomAppService
    {
        private readonly IRoomService _roomService;        
        public RoomAppService(IRoomService roomService)
            : base(roomService)
        {
            _roomService = roomService;
        }
    }
}
