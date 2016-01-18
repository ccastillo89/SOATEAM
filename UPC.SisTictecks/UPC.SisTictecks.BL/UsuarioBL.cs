using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.SisTictecks.DAL;
using UPC.SisTictecks.EL;

namespace UPC.SisTictecks.BL
{
    public class UsuarioBL
    {
        private Usuario usuarioDAL = new Usuario();

        public List<UsuarioEN> Listar()
        {
            return usuarioDAL.Listar();
        }
        public UsuarioEN Obtener(int id)
        {
            return usuarioDAL.Obtener(id);
        }

        public bool Actualizar(UsuarioEN usuario)
        {
            return usuarioDAL.Actualizar(usuario);
        }

        public bool Registrar(UsuarioEN usuario)
        {
            return usuarioDAL.Registrar(usuario);
        }

        public bool Eliminar(int id)
        {
            return usuarioDAL.Eliminar(id);
        }

        public bool Login(string user, string pass)
        {
            return usuarioDAL.Login(user, pass);
        }

    }
}
