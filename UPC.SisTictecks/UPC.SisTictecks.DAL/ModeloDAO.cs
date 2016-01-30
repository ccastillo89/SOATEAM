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
    public class ModeloDAO : BaseDAO<ModeloEN, int>
    {
        public IList<ModeloEN> ListarModelosXMarca(MarcaEN marca)
        {
            IList<ModeloEN> listaModelos = null;
            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                listaModelos = session
                    .CreateCriteria(typeof(ModeloEN))
                    .Add(Restrictions.Eq("Marca", marca))
                    .List<ModeloEN>();
            }

            return listaModelos;
        }


    }
}
