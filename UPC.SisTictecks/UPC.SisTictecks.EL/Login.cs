using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UPC.SisTictecks.EL
{
    [DataContract]
    public class Login
    {
        [DataMember]
        [Required(ErrorMessage = "Ingrese Usuario", AllowEmptyStrings = false)]
        public string Usuario { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Ingrese Contraseña", AllowEmptyStrings = false)]
        public string Clave { get; set; }
    }
}
