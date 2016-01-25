using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.SisTictecks.DAL
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=SERVER7\\SQLEXPRESS;Initial Catalog=DSD_AUTOSVC;;user id=sa;password=Sredes;Integrated Security=False;";
        }

    }
}
