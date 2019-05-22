using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Domain.Entities
{
    public class Room
    {
        public Guid     Room_id { get; set; }
        public string   Name { get; set; }
        public string   Description { get; set; }
        public int      Seats { get; set; }
        public float    Square_meters { get; set; }
        public decimal  Hour_price { get; set; }
        public bool     Has_wifi { get; set; }
        public bool     Has_ethernet { get; set; }
        public bool     Has_tv { get; set; }
        public bool     Has_webcam { get; set; }
        public bool     Has_air_conditioning { get; set; }
        public string   Status { get; set; }

        // Relação 1pN - Um usuário pode ter Varios alugueis
        public virtual IEnumerable<Rent> Rents { get; set; }
    }
}
