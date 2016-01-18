using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.SisTictecks.EL
{
    public class UsuarioEN
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        
        [Required(ErrorMessage="Ingrese Usuario",AllowEmptyStrings=false)]
        [Display(Name="Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage="Ingrese Contraseña", AllowEmptyStrings=false)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass{ get; set; }
        public bool Activo { get; set; }
        public int PerfilId { get; set; }
        public PerfilEN Perfil { get; set; }

        [Display(Name = "Mantener session activa")]
        public bool Recordarme { get; set; }

        public UsuarioEN()
        {
            Perfil = new PerfilEN();
        }
    }
}
