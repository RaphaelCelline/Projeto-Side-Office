using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SideOffice.Infra.CrossCutting.Identity.Models.RoomViewModel
{
    public class RoomViewModel
    {
        [Key]
        public Guid Room_id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Lugares")]
        public int Seats { get; set; }

        [Required]
        [DisplayName("m²")]
        [ScaffoldColumn(false)]
        public float Square_meters { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Valor hora")]
        public decimal Hour_price { get; set; }

        [Required]
        [DisplayName("Wifi")]
        public bool Has_wifi { get; set; }

        [Required]
        [DisplayName("Rede")]
        public bool Has_ethernet { get; set; }

        [Required]
        [DisplayName("Tv")]
        public bool Has_tv { get; set; }

        [Required]
        [DisplayName("WebCam")]
        public bool Has_webcam { get; set; }

        [Required]
        [DisplayName("Ar Condicionado")]
        public bool Has_air_conditioning { get; set; }

        [DisplayName("status")]
        public string Status { get; set; } = "A";

        // Relação 1pN - Um usuário pode ter Varios alugueis
        public virtual IEnumerable<Rent> Rents { get; set; }
    }
}
