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
    public interface IUsuariosService
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        UsuarioEN CrearUsuario(UsuarioEN usuarioCrear);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        UsuarioEN ObtenerUsuario(int codigo);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        UsuarioEN ModificarUsuario(UsuarioEN usuarioModificar);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        bool EliminarUsuario(int codigo);

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        List<UsuarioEN> ListarUsuarios();

        [OperationContract]
        bool ValidarNombreDeUsuarioExistente(string usuario);

        [OperationContract]
        bool ValidarCorreoExistente(string correo);


        #region "Perfiles"

        [OperationContract]
        PerfilEN ObtenerPerfil(int codigo);

        [OperationContract]
        List<PerfilEN> ListarPerfiles();

        #endregion

    }
}
