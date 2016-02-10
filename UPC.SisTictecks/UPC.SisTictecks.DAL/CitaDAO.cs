using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.SisTictecks.EL;
using NHibernate;
using NHibernate.Criterion;

namespace UPC.SisTictecks.DAL
{
    public class CitaDAO : BaseDAO<CitaEN, int>
    {

        enum EstadosCita : int { 
            Pendiente = 1,
            Realizado = 2,
            Cancelado = 3
        }

        public ICollection<CitaEN> ListarCitasPendientesDeAtencion(int codigoUsuario)
        {
            IList<CitaEN> lista = null;

            UsuarioEN usuario = new UsuarioEN() { Codigo = codigoUsuario };

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                lista = session
                    .CreateCriteria(typeof(CitaEN))
                    .Add(Restrictions.Eq("Usuario", usuario))
                    .Add(Restrictions.Eq("Estado", (int)EstadosCita.Pendiente))
                    .List<CitaEN>();
            }
            return lista;
        }

        public ICollection<CitaEN> ListarHistorialDeCitas(int codigoUsuario)
        {
            IList<CitaEN> lista = null;

            UsuarioEN usuario = new UsuarioEN() { Codigo = codigoUsuario };

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                lista = session
                    .CreateCriteria(typeof(CitaEN))
                    .Add(Restrictions.Eq("Usuario", usuario))
                    .Add(Restrictions.Gt("Estado", (int)EstadosCita.Realizado))
                    .List<CitaEN>();
            }
            return lista;
        }
        
        public bool ValidarFechaHoraCitaXTaller(string fecha, DateTime horaIni, DateTime horaFin,
                                        int codigoTaller, int codigoUsuario)
        {
            int cantidad = 0;
            bool resultado = false;

            UsuarioEN usuario = new UsuarioEN() { Codigo = codigoUsuario };
            TallerEN taller = new TallerEN() { Codigo = codigoTaller };

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidad = session
                    .CreateCriteria(typeof(CitaEN))
                    .Add(Restrictions.Eq("Usuario", usuario))
                    .Add(Restrictions.Eq("Taller", taller))
                    .Add(Restrictions.Eq("Fecha", fecha))
                    .Add(Restrictions.Ge("HoraInicio", horaIni))
                    .Add(Restrictions.Le("HoraInicio", horaIni))
                    .Add(Restrictions.Ge("HoraFin", horaFin))
                    .Add(Restrictions.Le("HoraFin", horaFin))
                    .List<CitaEN>().Count;
            }

            if (cantidad == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }
    }
}
