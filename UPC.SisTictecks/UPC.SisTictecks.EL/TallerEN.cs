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
    public class TallerEN
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        [Display(Name = "Taller")]
        public string Taller { get; set; }
    }
}
