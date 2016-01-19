using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UPC.SisTictecks.EL
{
    public class PerfilEN
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Perfil")]
        public string Descripcion { get; set; }
    }
}
