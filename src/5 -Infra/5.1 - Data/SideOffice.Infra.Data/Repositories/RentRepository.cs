using Microsoft.EntityFrameworkCore;
using SideOffice.Domain.Entities;
using SideOffice.Domain.Interfaces;
using SideOffice.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SideOffice.Infra.Data.Repositories
{
    public class RentRepository : RepositoryBase<Rent>, IRentRepository
    {
        public IEnumerable<Rent> GetAllWhitReferences()
        {
            return Db.Rents
                .Include(c => c.Room)
                .Include(c => c.User)
                .ToList();
        }

        public IEnumerable<Rent> GetByDateTime(DateTime start, DateTime end)
        {
            var todos = Db.Rents.ToList();

            var Dentro_periodo = todos.Where(p => 
            (start >= p.Start_datetime && start <= p.End_datetime) ||
            (end   >= p.Start_datetime && end   <= p.End_datetime) ||

            (p.Start_datetime >= start && p.Start_datetime <= end) ||
            (p.End_datetime   >= start && p.End_datetime   <= end));

            return Dentro_periodo;
        }

        public IEnumerable<Rent> GetByRoomId(Guid room_id)
        {
            return Db.Rents.Where(p => p.Room_id == room_id);
        }

        public IEnumerable<Rent> GetByUserId(Guid user_id)
        {
            return Db.Rents.Where(p => p.User_id == user_id);
        }

        public IEnumerable<Rent> GetByUserIdAndRoomId(Guid user_id, Guid room_id)
        {
            return Db.Rents.Where(p => p.User_id == user_id && p.Room_id == room_id);
        }

        public bool IsRented(DateTime start_datetime, DateTime end_datetime, Guid room_id)
        {
            return Db.Rents.Any(p => 
                (p.Start_datetime >= start_datetime &&  p.End_datetime <= end_datetime)
                &&  
                p.Room_id == room_id
                &&
                p.Status == "A");
        }
    }
}