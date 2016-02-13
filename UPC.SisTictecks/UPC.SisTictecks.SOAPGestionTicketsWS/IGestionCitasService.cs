using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;

namespace UPC.SisTictecks.SOAPGestionTicketsWS
{
    [ServiceContract]
    public interface IGestionCitasService
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        CitaEN CrearCita(CitaEN citaCrear);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        CitaEN ObtenerCita(int codigo);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        CitaEN ModificarCita(CitaEN citaModificar);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        bool EliminarCita(int codigo);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<CitaEN> ListarCitas();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        bool ValidarFechaHoraCitaXTaller(string fecha, DateTime horaIni, DateTime horaFin,
                                        int idTaller, int idUsuario);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<CitaEN> ListarCitasPendientesDeAtencion(string codigoUsuario);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<CitaEN> ListarHistorialDeCitas(string codigoUsuario);
    }
}
