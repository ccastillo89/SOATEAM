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
    public class Servicios : IServicios
    {
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

        public ServicioEN CrearServicio(string descripcion, decimal valor, bool estado, int tiempoEstimadoHH)
        {

            if (valor > 200)
            {
                throw new FaultException<RepetidoException>(new RepetidoException()
                {
                    Codigo = 1,
                    Mensaje = "El valor de servicio debe ser menor o igual a 200"
                },
                new FaultReason("Validacion de negocio"));
            }

            ServicioEN servicioCrear = new ServicioEN()
            {
                Descripcion = descripcion,
                Valor = valor,
                Estado = estado,
                TiempoEstimado = tiempoEstimadoHH
            };

            return ServicioDAO.Crear(servicioCrear);

        }

        public ServicioEN ObtenerServicio(int codigo)
        {
            return ServicioDAO.Obtener(codigo);
        }

        public ServicioEN ModificarServicio(int codigo, string descripcion, decimal valor, bool estado, int tiempoEstimadoHH)
        {

            ServicioEN servicioModificar = new ServicioEN()
            {
                Codigo = codigo,
                Descripcion = descripcion,
                Valor = valor,
                Estado = estado,
                TiempoEstimado = tiempoEstimadoHH
            };

            return ServicioDAO.Modificar(servicioModificar);

        }

        public void EliminarServicio(int codigo)
        {
            ServicioEN servicioExistente = ServicioDAO.Obtener(codigo);
            ServicioDAO.Eliminar(servicioExistente);
        }

        public List<ServicioEN> ListarServicios()
        {
            return ServicioDAO.ListarTodos().ToList();
        }
    }
}
