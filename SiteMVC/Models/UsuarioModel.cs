using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMVC.Models
{
    [Table("usuarios")]
    public class UsuarioModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        [EmailAddress(ErrorMessage = "Email digitado não é valido")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo não pode ficar em branco")]
        [Phone(ErrorMessage = "Contato digitado não confere com o padrão telefonico")]
        public string contato { get; set; }
    }
}
