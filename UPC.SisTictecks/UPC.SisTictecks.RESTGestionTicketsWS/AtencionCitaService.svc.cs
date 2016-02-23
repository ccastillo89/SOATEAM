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
    public class AtencionCitaService : IAtencionCitaService
    {
        private CitaDAO atiendeCitaDao = new CitaDAO();

        public List<CitaEN> ListarCitas()
        {
            return atiendeCitaDao.ListarCitasPendientesDeAltas().ToList();
        }

        public CitaEN ObtenerCita(string codigo)
        {
            int iCodigoCita = Convert.ToInt32(codigo);
            return atiendeCitaDao.Obtener(iCodigoCita);
        }

        public CitaEN DarAltaCita(CitaEN citaEN)
        {
            CitaEN citaAlta = null;
            CitaEN citaDarAlta = null;
            int iCodigoCita = Convert.ToInt32(citaEN.Codigo);
            try
            {
                citaAlta = atiendeCitaDao.Obtener(iCodigoCita);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.InternalServerError);
            }

            DateTime fecha = Convert.ToDateTime(citaAlta.Fecha);

            if (DateTime.Now.Date < fecha.Date)
            {
                throw new WebFaultException<string>("No es posible el alta. La fecha de cita es posterior a la fecha actual. Se debe dar alta el mismo dia de la cita.", HttpStatusCode.InternalServerError);
            }

            if (DateTime.Now.Date > fecha.Date.AddDays(1))
            {
                throw new WebFaultException<string>("No es posible el alta, debido a que ya se ha vencido el tiempo maximo de alta de cita (01 dias).", HttpStatusCode.InternalServerError);
            }

            try
            {
                citaAlta.Estado = 2;
                citaDarAlta = atiendeCitaDao.Modificar(citaAlta);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.InternalServerError);
            }

            return citaDarAlta;
        }

        public CitaEN DarBajaCita(CitaEN citaEN)
        {
            CitaEN citaDarBaja = null;
            CitaEN citaDarBaja2 = null;
            try
            {
                int iCodigoCita = Convert.ToInt32(citaEN.Codigo);
                citaDarBaja = atiendeCitaDao.Obtener(iCodigoCita);

                citaDarBaja.Estado = 3;
                citaDarBaja2 = atiendeCitaDao.Modificar(citaDarBaja);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.InternalServerError);
            }

            return citaDarBaja2;
        }
    }
}
