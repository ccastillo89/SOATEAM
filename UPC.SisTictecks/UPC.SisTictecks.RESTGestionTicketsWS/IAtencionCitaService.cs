using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;
using System.ServiceModel.Web;

namespace UPC.SisTictecks.RESTGestionTicketsWS
{
    [ServiceContract]
    public interface IAtencionCitaService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Citas", ResponseFormat = WebMessageFormat.Json)]
        List<CitaEN> ListarCitas();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Citas/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        CitaEN ObtenerCita(string codigo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Citas", ResponseFormat = WebMessageFormat.Json)]
        CitaEN DarAltaCita(CitaEN citaEN);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Citas", ResponseFormat = WebMessageFormat.Json)]
        CitaEN DarBajaCita(CitaEN citaEN);

    }
}
