using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UPC.SisTictecks.EL
{
    [DataContract]
    public class UsuarioEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingrese Nombres", AllowEmptyStrings = false)]
        public string Nombres { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingrese Apellidos", AllowEmptyStrings = false)]
        public string Apellidos { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingrese Usuario", AllowEmptyStrings = false)]
        public string Usuario { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingrese Contraseña", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass{ get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingrese DNI", AllowEmptyStrings = false)]
        public string Dni { get; set; }
        [DataMember]
        public PerfilEN Perfil { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingrese Teléfono", AllowEmptyStrings = false)]        
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        [DataMember]        
        [Required(ErrorMessage = "Ingrese Correo", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Ingrese correctamente el correo")]
        public string Correo { get; set; }
        [DataMember]
        public Login login { get; set; }
    }
}
