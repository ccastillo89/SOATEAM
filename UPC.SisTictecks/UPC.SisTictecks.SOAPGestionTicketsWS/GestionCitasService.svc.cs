using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.DAL;

namespace UPC.SisTictecks.SOAPGestionTicketsWS
{

    public class GestionCitasService : IGestionCitasService
    {
        public List<CitaEN> ListarCitas()
        {
            List<CitaEN> lista = new List<CitaEN>();
            lista.Add(new CitaEN { Codigo = 1, NroCita = "11111", Fecha = "01/02/2016", HoraInicio = DateTime.Today, HoraFin = DateTime.Today, Observacion = "MMMMMMM", Estado=true});
            lista.Add(new CitaEN { Codigo = 2, NroCita = "2222", Fecha = "01/03/2016", HoraInicio = DateTime.Today, HoraFin = DateTime.Today, Observacion = "PPPPPP", Estado = true });
            lista.Add(new CitaEN { Codigo = 3, NroCita = "3333", Fecha = "01/04/2016", HoraInicio = DateTime.Today, HoraFin = DateTime.Today, Observacion = "AAAAA", Estado = true });
            
            return lista;
        }
    }
}
