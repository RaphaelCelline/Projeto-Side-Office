using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Domain.Entities
{
    public class Rent
    {
        public Guid Rent_id { get; set; }
        public Guid Room_id { get; set; }
        public Guid User_id { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start_datetime { get; set; }
        public DateTime End_datetime { get; set; }
        public string Status { get; set; }

        //Relação 1p1 - Um Aluguel possui um Usuário
        public virtual User User { get; set; }
        //Relação 1p1 - Um Aluguel possui uma sala
        public virtual Room Room { get; set; }

    }
}
