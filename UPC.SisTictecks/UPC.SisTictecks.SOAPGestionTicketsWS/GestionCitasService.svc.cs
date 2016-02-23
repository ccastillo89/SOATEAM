using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.DAL;
using System.Messaging;
using System.Configuration;

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
            CitaEN citaCreada = null;
            string codigoNroCita = GenerarCodigoCitaNuevo();
            citaCrear.NroCita = codigoNroCita;

            int anio = Convert.ToInt32(citaCrear.Fecha.Substring(6, 4));
            int mes = Convert.ToInt32(citaCrear.Fecha.Substring(3, 2));
            int dia = Convert.ToInt32(citaCrear.Fecha.Substring(0, 2));
            int hhInicio;
            int hhFinal; int mmFinal = 0; int ssFinal = 0;
            DateTime horaFinal;
            DateTime fechaCita = Convert.ToDateTime(citaCrear.Fecha);

            hhInicio = citaCrear.HoraInicio.Hour;

            ServicioEN servicioAsociado = null;
            try
            {
                //Obtener hora de termino calculada
                ServicioService proxy = new ServicioService();
                servicioAsociado = proxy.ObtenerServicio(citaCrear.Servicio.Codigo);
            }
            catch
            {
                servicioAsociado = new ServicioEN() { Codigo = citaCrear.Servicio.Codigo, TiempoEstimado = 3 };
            }

            hhFinal = hhInicio + servicioAsociado.TiempoEstimado;

            horaFinal = new DateTime(anio, mes, dia, hhInicio, mmFinal, ssFinal);
            citaCrear.HoraFin = horaFinal.AddHours(hhFinal);

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


            try
            {

                //validar si el horario ya no esta disponible
                bool bEstaDisponibleHorario = false;
                bEstaDisponibleHorario = ValidarFechaHoraCitaXTaller(citaCrear.Fecha,
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

                string strConectado = ConfigurationManager.AppSettings["ModoDesconectado"];
                if (strConectado.Equals("0"))
                {
                    throw new Exception("Modo Desconectado -  Colas");
                }

                citaCreada = CitaDAO.Crear(citaCrear);
            }
            catch (Exception ex)
            {
                citaCreada = citaCrear;
                string rutacola = @".\private$\ColaCitas";
                if (!MessageQueue.Exists(rutacola))
                {
                    MessageQueue.Create(rutacola);
                }
                MessageQueue cola = new MessageQueue(rutacola);

                Message mensaje = new Message();
                mensaje.Label = "Cola Usuario : " + citaCrear.Usuario.Usuario;
                mensaje.Body = citaCrear;
                cola.Send(mensaje);
            }
            return citaCreada;
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

            List<CitaEN> listaCitas = null;
            try
            {
                string strConectado = ConfigurationManager.AppSettings["ModoDesconectado"];
                if (strConectado.Equals("1"))
                {
                    /******************** Preguntamos si existen Colas en la Bandeja ********************/
                    string rutacola = @".\private$\ColaCitas";
                    if (!MessageQueue.Exists(rutacola)) { MessageQueue.Create(rutacola); }
                    MessageQueue cola = new MessageQueue(rutacola);
                    if (cola.GetAllMessages().Count() > 0)
                    {
                        for (int i = 0; i < cola.GetAllMessages().Count() - 1; i++)
                        {
                            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(CitaEN) });
                            Message mensaje = cola.Receive();
                            CitaEN citaEN = (CitaEN)mensaje.Body;

                            citaEN = CrearCita(citaEN);
                        }
                    }
                    /***********************************************************************************/                    
                }
                
                listaCitas = CitaDAO.ListarTodos().ToList();
            }
            catch (Exception ex)
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 3,
                    Mensaje = ex.Message
                },
               new FaultReason("Error en el sistema"));
            }
            return listaCitas;
        }

        public List<CitaEN> ListarCitasPendientesDeAtencion(string codigoUsuario)
        {
            List<CitaEN> listaCitas = null;
            var codUsuario = Convert.ToInt32(codigoUsuario);
            listaCitas = CitaDAO.ListarCitasPendientesDeAtencion(codUsuario).ToList();

            try
            {
                string strConectado = ConfigurationManager.AppSettings["ModoDesconectado"];
                if (strConectado.Equals("1"))
                {
                    /******************** Preguntamos si existen Colas en la Bandeja ********************/
                    string rutacola = @".\private$\ColaCitas";
                    if (!MessageQueue.Exists(rutacola)) { MessageQueue.Create(rutacola); }
                    MessageQueue cola = new MessageQueue(rutacola);
                    if (cola.GetAllMessages().Count() > 0)
                    {
                        for (int i = 0; i < cola.GetAllMessages().Count(); i++)
                        {
                            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(CitaEN) });
                            Message mensaje = cola.Receive();
                            CitaEN citaEN = (CitaEN)mensaje.Body;

                            citaEN = CrearCita(citaEN);
                        }
                    }
                    /***********************************************************************************/
                }
            }
            catch (Exception ex)
            {
            }

            return listaCitas;
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

    }
}
