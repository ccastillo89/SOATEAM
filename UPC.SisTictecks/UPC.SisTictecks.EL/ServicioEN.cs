using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UPC.SisTictecks.EL
{
    [DataContract]
    public class ServicioEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal Valor { get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        public int TiempoEstimado { get; set; }
    }
}
