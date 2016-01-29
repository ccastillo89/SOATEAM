using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UPC.SisTictecks.EL
{
    [DataContract]
    public class MarcaEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Marca { get; set; }
    }
}
