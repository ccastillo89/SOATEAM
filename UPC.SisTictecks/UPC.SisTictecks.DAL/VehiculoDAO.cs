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
    public class VehiculoDAO : BaseDAO<VehiculoEN, int>
    {
        public ICollection<VehiculoEN> ListarVehiculosPorUsuario(string codigoUsuario)
        {
            IList<VehiculoEN> lista = null;
            UsuarioEN usuario = new UsuarioEN() { Codigo = Convert.ToInt32(codigoUsuario)};

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                lista = session
                    .CreateCriteria(typeof(VehiculoEN))
                    .Add(Restrictions.Eq("Usuario", usuario))
                    .List<VehiculoEN>();
            }
            return lista;
        }

        public bool ValidarPlacaExistente(string strPlaca)
        {
            int cantidad = 0;
            bool resultado = false;

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidad = session
                    .CreateCriteria(typeof(VehiculoEN))
                    .Add(Restrictions.Eq("Placa", strPlaca.ToUpper()))
                    .List<VehiculoEN>().Count;
            }

            if (cantidad == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }

        public bool ValidarKMMenorAnterior(int kilometros, int IdVehiculo)
        {
            int cantidad = 0;
            bool resultado = false;

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidad = session
                    .CreateCriteria(typeof(VehiculoEN))
                    .Add(Restrictions.Le("KM", kilometros))
                    .Add(Restrictions.Eq("Codigo", IdVehiculo))
                    .List<VehiculoEN>().Count;
            }

            if (cantidad == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }

    }
}
