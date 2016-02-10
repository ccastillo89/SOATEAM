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
    public interface ITallerService
    {

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<TallerEN> ListarTalleres();

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        TallerEN ObtenerTaller(int codigo);

    }
}
