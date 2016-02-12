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

        private CitaDAO citaDAO = null;

        private CitaDAO CitaDAO
        {
            get
            {
                if (citaDAO == null)
                    citaDAO = new CitaDAO();

                return citaDAO;
            }
        }

        public CitaEN CrearCita(CitaEN citaCrear)
        {
            string codigoNroCita = GenerarCodigoCitaNuevo();
            citaCrear.NroCita = codigoNroCita;

            //Obtener hora de termino calculada
            ServicioService proxy = new ServicioService();
            ServicioEN servicioAsociado = null;
            servicioAsociado = proxy.ObtenerServicio(citaCrear.Servicio.Codigo);

            int anio = Convert.ToInt32(citaCrear.Fecha.Substring(6, 4));
            int mes = Convert.ToInt32(citaCrear.Fecha.Substring(3, 2));
            int dia = Convert.ToInt32(citaCrear.Fecha.Substring(0, 2));
            int hhInicio;
            int hhFinal; int mmFinal = 0; int ssFinal = 0;
            DateTime horaFinal;
            DateTime fechaCita = Convert.ToDateTime(citaCrear.Fecha);

            hhInicio = citaCrear.HoraInicio.Hour;
            hhFinal = hhInicio + servicioAsociado.TiempoEstimado;

            horaFinal = new DateTime(anio, mes, dia, hhFinal, mmFinal, ssFinal);
            citaCrear.HoraFin = horaFinal;

            //Estado
            citaCrear.Estado = 1; //Pendiente

            if (fechaCita.Date < DateTime.Now.Date)
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 1,
                    Mensaje = "La fecha seleccionada de la cita es incorrecta."
                },
                new FaultReason("Validación de negocio"));
            }

            if (citaCrear.HoraInicio <= DateTime.Now.AddHours(1))
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 2,
                    Mensaje = "Las citas de servicios son registradas con 1 hora de anticipacion, por favor elija otro horario disponible."
                },
                new FaultReason("Validación de negocio"));
            }

            //validar si el horario ya no esta disponible
            bool bEstaDisponibleHorario = false;
            bEstaDisponibleHorario = ValidarFechaHoraCitaXTaller( citaCrear.Fecha, 
                                                                  citaCrear.HoraInicio,
                                                                  citaCrear.HoraFin,
                                                                  citaCrear.Taller.Codigo, citaCrear.Usuario.Codigo);

            if (bEstaDisponibleHorario)
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 3,
                    Mensaje = "La fecha y hora seleccionada no esta disponible."
                },
                new FaultReason("Validación de negocio"));
            }

            return CitaDAO.Crear(citaCrear);
        }

        public CitaEN ObtenerCita(int codigo)
        {
            return CitaDAO.Obtener(codigo);
        }

        public CitaEN ModificarCita(CitaEN citaModificar)
        {
            CitaEN citaExistente = CitaDAO.Obtener(citaModificar.Codigo);
            return CitaDAO.Modificar(citaModificar);
        }

        public bool EliminarCita(int codigo)
        {
            CitaEN citaExistente = CitaDAO.Obtener(codigo);
            bool ejecuto = false;
            if (citaExistente != null)
            {
                CitaDAO.Eliminar(citaExistente);
                ejecuto = true;
            }
            else
                ejecuto = false;

            return ejecuto;
        }

        public bool ValidarFechaHoraCitaXTaller(string fecha, DateTime horaIni, DateTime horaFin, int idTaller, int idUsuario)
        {
            return CitaDAO.ValidarFechaHoraCitaXTaller(fecha, horaIni, horaFin, idTaller, idUsuario);
        }

        public List<CitaEN> ListarCitas()
        {
            return CitaDAO.ListarTodos().ToList();
        }

        public List<CitaEN> ListarCitasPendientesDeAtencion(string codigoUsuario)
        {
            var codUsuario = Convert.ToInt32(codigoUsuario);
            return CitaDAO.ListarCitasPendientesDeAtencion(codUsuario).ToList();
        }

        public List<CitaEN> ListarHistorialDeCitas(string codigoUsuario)
        {
            var codUsuario = Convert.ToInt32(codigoUsuario);
            return CitaDAO.ListarHistorialDeCitas(codUsuario).ToList();
        }

        private string GenerarCodigoCitaNuevo()
        {
            string cadena = "R" + DateTime.Now.ToString("yyyyMMddHHmmssffff");
            return cadena.Substring(0, 17);
        }

        public CitaEN DarAltaCita(CitaEN citaAlta)
        {
            DateTime fecha = Convert.ToDateTime(citaAlta.Fecha);
            if (DateTime.Now.Date < fecha.Date)
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 1,
                    Mensaje = "No es posible el alta. La fecha de cita es posterior a la fecha actual."
                },
                new FaultReason("Validación de negocio"));
            }

            if (DateTime.Now.Date > fecha.Date.AddDays(1))
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 2,
                    Mensaje = "No es posible el alta, debido a que ya se ha vencido el tiempo maximo de alta de cita (01 dias)."
                },
                new FaultReason("Validación de negocio"));
            }

            citaAlta.Estado = 2; //Realizado
            return CitaDAO.Modificar(citaAlta);
        }

        public CitaEN DarBajaCita(CitaEN citaBaja)
        {
            citaBaja.Estado = 3; //Cancelado
            return CitaDAO.Modificar(citaBaja);
        }

    }
}
