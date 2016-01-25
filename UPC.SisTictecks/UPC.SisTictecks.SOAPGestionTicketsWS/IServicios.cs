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
    public interface IServicios
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        ServicioEN CrearServicio(string descripcion, decimal valor, bool estado, int tiempoEstimadoHH);
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        ServicioEN ObtenerServicio(int codigo);
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        ServicioEN ModificarServicio(int codigo, string descripcion, decimal valor, bool estado, int tiempoEstimadoHH);
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        void EliminarServicio(int codigo);
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<ServicioEN> ListarServicios();
    }
}
