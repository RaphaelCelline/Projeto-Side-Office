using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SideOffice.Infra.CrossCutting.Identity.Models.UserViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid User_id { get; set; }

        [Required(ErrorMessage = "Campo 'Name' é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo 'Last_name' é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        [DisplayName("Sobrenome")]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "Campo 'Email' é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um E-mail válido.")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres.")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo 'Document' é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        [DisplayName("Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Campo 'Country_code' é obrigatório.")]
        [MaxLength(3, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(3, ErrorMessage = "Minimo de {0} caracteres.")]
        [DisplayName("Código País")]
        public string Country_code { get; set; } = "BRA";

        [Required(ErrorMessage = "Campo 'Password' é obrigatório.")]
        [MaxLength(32, ErrorMessage = "Máximo de {0} caracteres.")]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Registration_datetime { get; set; } = DateTime.Parse("1753-01-01");

        [ScaffoldColumn(false)]
        public DateTime Last_login_datetime { get; set; } = DateTime.Parse("1753-01-01");

        [ReadOnly(true)]
        public string Status { get; set; } = "P";
        public virtual IEnumerable<Rent> Rents { get; set; }
    }
}
