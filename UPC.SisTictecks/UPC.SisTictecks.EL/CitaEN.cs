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
    public class CitaEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        [Display(Name = "Número Cita")]
        public string NroCita { get; set; }
        [DataMember]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        public string Fecha { get; set; }
        [DataMember]
        [DisplayFormat(DataFormatString = "{0:HH:mm }", ApplyFormatInEditMode = true)]
        [Display(Name = "Hora de Inicio")]
        public DateTime HoraInicio { get; set; }
        [DataMember]
        [DisplayFormat(DataFormatString = "{0:HH:mm }", ApplyFormatInEditMode = true)]
        [Display(Name = "Hora de Fin")]
        public DateTime HoraFin { get; set; }
        [DataMember]
        [Display(Name = "Observación")]
        public string Observacion { get; set; }
        [DataMember]
        public int Estado { get; set; }
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
