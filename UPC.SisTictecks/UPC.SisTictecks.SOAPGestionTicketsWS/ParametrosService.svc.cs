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

    public class ParametrosService : IParametrosService
    {

        #region "Servicios"

        private ServicioDAO servicioDAO = null;
        private ServicioDAO ServicioDAO
        {
            get
            {
                if (servicioDAO == null)
                    servicioDAO = new ServicioDAO();

                return servicioDAO;
            }
        }

        public List<ServicioEN> ListarServicios()
        {
            return ServicioDAO.ListarTodos().ToList();
        }

        public ServicioEN ObtenerServicio(int codigo)
        {
            return ServicioDAO.Obtener(codigo);
        }

        #endregion

        #region "Taller"

        private TallerDAO tallerDAO = null;
        private TallerDAO TallerDAO
        {
            get
            {
                if (tallerDAO == null)
                    tallerDAO = new TallerDAO();

                return tallerDAO;
            }
        }

        public List<TallerEN> ListarTalleres()
        {
            return TallerDAO.ListarTodos().ToList();
        }

        public TallerEN ObtenerTaller(int codigo)
        {
            return TallerDAO.Obtener(codigo);
        }

        #endregion


    }
}
