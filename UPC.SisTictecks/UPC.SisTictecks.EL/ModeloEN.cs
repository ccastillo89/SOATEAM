using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UPC.SisTictecks.EL
{
    [DataContract]
    public class ModeloEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Modelo { get; set; }
        [DataMember]
        public MarcaEN Marca { get; set; }
    }
}
