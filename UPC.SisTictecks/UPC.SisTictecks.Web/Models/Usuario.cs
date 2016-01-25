using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UPC.SisTictecks.Web.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Ingrese Usuario", AllowEmptyStrings = false)]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required(ErrorMessage = "Ingrese Contraseña", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }
        public bool Activo { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }

        [Display(Name = "Mantener session activa")]
        public bool Recordarme { get; set; }
    }
}