using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UPC.SisTictecks.EL
{
    [DataContract]
    public class UsuarioEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Pass{ get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        public PerfilEN Perfil { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Correo { get; set; }
    }
}
