using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.DAL;
using System.ServiceModel.Web;
using System.Net;

namespace UPC.SisTictecks.RESTGestionTicketsWS
{
    public class AprobacionCitaService : IAprobacionCitaService
    {
        private CitaDAO altasDao = new CitaDAO();

        public List<CitaEN> ListarCitas()
        {
            return altasDao.ListarCitasPendientesDeAltas().ToList();
        }

        public CitaEN ObtenerCita(string codigo)
        {
            int iCodigoCita = Convert.ToInt32(codigo);
            return altasDao.Obtener(iCodigoCita);
        }

        public CitaEN DarAltaCita(CitaEN citaAlta)
        {
            DateTime fecha = Convert.ToDateTime(citaAlta.Fecha);
            if (DateTime.Now.Date < fecha.Date)
            {
                throw new WebFaultException<string>("No es posible el alta. La fecha de cita es posterior a la fecha actual.", HttpStatusCode.InternalServerError);
            }

            if (DateTime.Now.Date > fecha.Date.AddDays(1))
            {
                throw new WebFaultException<string>("No es posible el alta, debido a que ya se ha vencido el tiempo maximo de alta de cita (01 dias).", HttpStatusCode.InternalServerError);
            }

            citaAlta.Estado = 2;
            return altasDao.Modificar(citaAlta);
        }


    }
}
