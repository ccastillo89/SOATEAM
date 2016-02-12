using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.SisTictecks.EL;
using UPC.SisTictecks.Helpers;
using NHibernate;
using NHibernate.Criterion;

namespace UPC.SisTictecks.DAL
{
    public class CitaDAO : BaseDAO<CitaEN, int>
    {       

        public ICollection<CitaEN> ListarCitasPendientesDeAtencion(int codigoUsuario)
        {
            IList<CitaEN> lista = null;

            UsuarioEN usuario = new UsuarioEN() { Codigo = codigoUsuario };

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                lista = session
                    .CreateCriteria(typeof(CitaEN))
                    .Add(Restrictions.Eq("Usuario", usuario))
                    .Add(Restrictions.Eq("Estado", (int)eEstadosCita.Pendiente))
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
                    .Add(Restrictions.Ge("Estado", (int)eEstadosCita.realizado))
                    .List<CitaEN>();
            }
            return lista;
        }
        
        public bool ValidarFechaHoraCitaXTaller(string fecha, DateTime horaIni, DateTime horaFin,
                                        int codigoTaller, int codigoUsuario)
        {
            int cantidadIni = 0;
            int cantidadFin = 0;
            int iRes = 0;
            bool bResult = false;

            UsuarioEN usuario = new UsuarioEN() { Codigo = codigoUsuario };
            TallerEN taller = new TallerEN() { Codigo = codigoTaller };

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidadIni = session
                        .CreateCriteria(typeof(CitaEN))
                        .Add(Restrictions.Eq("Usuario", usuario))
                        .Add(Restrictions.Eq("Taller", taller))
                        .Add(Restrictions.Eq("Fecha", fecha))
                        .Add(Restrictions.Ge("HoraInicio", horaIni))
                        .Add(Restrictions.Eq("Estado", (int)eEstadosCita.Pendiente))
                        .List<CitaEN>().Count;

                cantidadFin = session
                        .CreateCriteria(typeof(CitaEN))
                        .Add(Restrictions.Eq("Usuario", usuario))
                        .Add(Restrictions.Eq("Taller", taller))
                        .Add(Restrictions.Eq("Fecha", fecha))
                        .Add(Restrictions.Gt("HoraFin", horaIni))
                        .Add(Restrictions.Eq("Estado", (int)eEstadosCita.Pendiente))
                        .List<CitaEN>().Count;
            }

            iRes = cantidadIni + cantidadFin;

            if (iRes == 0)
                bResult = false;
            else
                bResult = true;

            return bResult;
        }

    }
}
