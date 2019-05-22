using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SideOffice.Infra.CrossCutting.Identity.Models.RoomViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public float Square_meters { get; set; }

        [Required]
        public decimal Hour_price { get; set; }

        [Required]
        public bool Has_wifi { get; set; }

        [Required]
        public bool Has_ethernet { get; set; }

        [Required]
        public bool Has_tv { get; set; }

        [Required]
        public bool Has_webcam { get; set; }

        [Required]
        public bool Has_air_conditioning { get; set; }

    }
}
