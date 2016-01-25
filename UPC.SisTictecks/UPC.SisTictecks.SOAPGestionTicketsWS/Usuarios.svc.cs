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
    public class Usuarios : IUsuarios
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

        public UsuarioEN CrearUsuario(UsuarioEN usuarioCrear)
        {
            return UsuarioDAO.Crear(usuarioCrear);
        }

        public UsuarioEN ObtenerUsuario(int codigo)
        {
            return UsuarioDAO.Obtener(codigo);
        }

        public UsuarioEN ModificarUsuario(UsuarioEN usuarioModificar)
        {
            return UsuarioDAO.Modificar(usuarioModificar);
        }

        public bool EliminarUsuario(int codigo)
        {
            UsuarioEN usuarioExistente = UsuarioDAO.Obtener(codigo);
            bool ejecuto =false;
            if (usuarioExistente != null)
            {
                UsuarioDAO.Eliminar(usuarioExistente);
                ejecuto = true;
            }
            else
                ejecuto = false;

            return ejecuto;
        }

        public List<UsuarioEN> ListarUsuarios()
        {
            return UsuarioDAO.ListarTodos().ToList();
        }
    }
}
