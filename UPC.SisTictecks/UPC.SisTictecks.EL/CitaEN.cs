using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UPC.SisTictecks.EL
{
    [DataContract]
    public class CitaEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string NroCita { get; set; }
        [DataMember]
        public string Fecha { get; set; }
        [DataMember]
        public DateTime HoraInicio { get; set; }
        [DataMember]
        public DateTime HoraFin { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        public UsuarioEN Usuario { get; set; }
        [DataMember]
        public VehiculoEN Vehiculo { get; set; }
        [DataMember]
        public ServicioEN Servicio { get; set; }
        [DataMember]
        public TallerEN Taller { get; set; }
    }
}
