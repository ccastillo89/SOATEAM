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
    public class SeguridadService : ISeguridadService
    {

        private UsuarioDAO usuarioDAO = null;

        private UsuarioDAO UsuarioDAO
        {
            get
            {
                if (usuarioDAO == null)
                    usuarioDAO = new UsuarioDAO();

                return usuarioDAO;
            }
        }

        public UsuarioEN AutenticarUsuario(string usuario, string pass)
        {
            UsuarioEN usuarioLogeado = null;
            bool existeUsuario = false;

            if (usuario != null)
            {
                existeUsuario = UsuarioDAO.ValidarNombreDeUsuario(usuario.ToUpper());

                if (!existeUsuario)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 1,
                        Mensaje = "Usuario o password incorrecto"
                    },
                    new FaultReason("Validación de negocio"));
                }
            }

            usuarioLogeado = UsuarioDAO.ValidarLogin(usuario, pass);

            if (usuarioLogeado == null)
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 2,
                    Mensaje = "Usuario o password incorrecto"
                },
                new FaultReason("Validación de negocio"));
            }

            return usuarioLogeado;
        }
    }
}
