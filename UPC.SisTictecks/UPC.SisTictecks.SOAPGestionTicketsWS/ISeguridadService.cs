﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.SisTictecks.EL;

namespace UPC.SisTictecks.SOAPGestionTicketsWS
{
    [ServiceContract]
    public interface ISeguridadService
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        UsuarioEN AutenticarUsuario(string usuario, string pass);

    }
}
