using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UPC.SisTictecks.Web.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Perfil")]
        public string Descripcion { get; set; }
    }
}