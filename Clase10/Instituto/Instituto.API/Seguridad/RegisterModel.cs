using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Instituto.API.Seguridad
{
    public class RegisterModel
    {
        [Required(ErrorMessage="El nombre de usuario es requerido")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El mail es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="La contraseña es requerida")]
        public string Password { get; set; }
    }
}
