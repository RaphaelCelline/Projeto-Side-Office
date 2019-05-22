using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SideOffice.Infra.CrossCutting.Identity.Models.UserViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Campo 'Name' é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        public string Name      { get; set; }
        [Required(ErrorMessage = "Campo 'Last_name' é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        public string Last_name { get; set; }
        [Required(ErrorMessage = "Campo 'Email' é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um E-mail válido.")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres.")]
        public string Email     { get; set; }
        [Required(ErrorMessage = "Campo 'Document' é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        public string Document  { get; set; }
        [Required(ErrorMessage = "Campo 'Country_code' é obrigatório.")]
        [MaxLength(3, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(3, ErrorMessage = "Minimo de {0} caracteres.")]  
        public string Country_code { get; set; }
        [Required(ErrorMessage = "Campo 'Password' é obrigatório.")]
        [MaxLength(32, ErrorMessage = "Máximo de {0} caracteres.")]
        public string Password     { get; set; }
    }
}
