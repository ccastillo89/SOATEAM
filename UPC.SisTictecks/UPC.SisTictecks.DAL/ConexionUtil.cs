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
            return "Data Source=TOSHIBA\\SQLEXPRESS;Initial Catalog=DSD_AUTOSVC;Integrated Security=True;";
        }

    }
}
