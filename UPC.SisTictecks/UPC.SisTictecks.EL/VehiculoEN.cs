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
    public class VehiculoEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        [Display(Name = "Vehículo")]
        public string Descripcion { get; set; }
        [DataMember]
        public string Placa { get; set; }
        [DataMember]
        public int Kilometros { get; set; }
        [DataMember]
        [Display(Name = "Año")]
        public int Anio { get; set; }
        [DataMember]
        public MarcaEN Marca { get; set; }
        [DataMember]
        public ModeloEN Modelo { get; set; }
        [DataMember]
        public ColorEN Color { get; set; }
        [DataMember]
        public UsuarioEN Usuario { get; set; }
    }
}
