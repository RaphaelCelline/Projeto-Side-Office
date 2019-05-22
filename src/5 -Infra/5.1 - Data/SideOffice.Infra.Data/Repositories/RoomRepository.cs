using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces;
using SideOffice.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Infra.Data.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
    }
}
