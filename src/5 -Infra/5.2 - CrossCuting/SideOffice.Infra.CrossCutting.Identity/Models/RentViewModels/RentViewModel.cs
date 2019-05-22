using SideOffice.Domain.Entities;
using SideOffice.Infra.CrossCutting.Identity.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SideOffice.Infra.CrossCutting.Identity.Models.RentViewModels
{
    public class RentViewModel
    {
        [Key]
        public Guid Rent_id { get; set; }

        [Required]
        [DisplayName("Sala")]
        public Guid Room_id { get; set; }

        [Required]
        [DisplayName("Usuário")]
        public Guid User_id { get; set; }

        [Required]
        [DisplayName("Titulo")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Inicio")]
        public DateTime Start_datetime { get; set; }

        [Required]
        [DisplayName("Fim")]
        public DateTime End_datetime { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; } = "A";

        //Relação 1p1 - Um Aluguel possui um Usuário
        public virtual UserViewModels.UserViewModel User { get; set; }
        //Relação 1p1 - Um Aluguel possui uma sala
        public virtual RoomViewModel.RoomViewModel Room { get; set; }
    }
}
