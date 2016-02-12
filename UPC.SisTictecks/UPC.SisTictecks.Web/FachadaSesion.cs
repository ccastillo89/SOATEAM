using System;
using System.Collections.Generic;
using System.Linq;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.Helpers;
using System.Web;

namespace UPC.SisTictecks.Web
{
    public static class FachadaSesion
    {
        /// <summary>
        /// Usuario actual.
        /// </summary>
        public static UsuarioEN Usuario
        {
            get
            {
                return Obtener<UsuarioEN>("entrada");
            }
            set { Asignar("entrada", value); }
        }

        public static bool EsAdministrador()
        {
            List<UsuarioEN> listaUser = new List<UsuarioEN>();
            listaUser.Add(new UsuarioEN { login = Usuario.login, Perfil = new PerfilEN { Codigo = Usuario.Perfil.Codigo } });

            return listaUser.Any(x => x.Perfil.Codigo == (int)ePerfiles.Administradores);
        }

        private static void Asignar(string key, object value)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                HttpContext.Current.Session.Add(key, value);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        private static T Obtener<T>(string key)
        {
            var x = new HttpContextWrapper(HttpContext.Current);
            var y = x.Session[key];

            return (T)HttpContext.Current.Session[key];
        }

        private static bool Existe(string key)
        {
            bool retval = HttpContext.Current.Session[key] != null;

            return retval;
        }

    }
}