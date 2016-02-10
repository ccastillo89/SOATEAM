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
    public interface IServicioService
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<ServicioEN> ListarServicios();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        ServicioEN ObtenerServicio(int codigo);

    }
}
