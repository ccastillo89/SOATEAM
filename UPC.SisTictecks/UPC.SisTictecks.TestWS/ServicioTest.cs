using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPC.SisTictecks.EL;
using System.ServiceModel;
using System.Collections.Generic;

namespace UPC.SisTictecks.TestWS
{
    [TestClass]
    public class ServicioTest
    {
        [TestMethod]
        public void CrearServicio()
        {

            ServiciosWS.ServiciosClient _proxy = new ServiciosWS.ServiciosClient();
            ServicioEN servicioCreado;
            string descripcion = "Servicio de lavado de auto";
            decimal valor = 201;
            bool estado = true;
            int tiempo = 1;
            int idCreado;

            try
            {
                servicioCreado = _proxy.CrearServicio(descripcion, valor, estado, tiempo);
                idCreado = servicioCreado.Codigo;
                //Assert.Equals(0, idCreado);
            }
            catch (FaultException<RepetidoException> fe)
            {

                Assert.AreEqual(1, fe.Detail.Codigo);
                Assert.AreEqual("El valor de servicio debe ser menor o igual a 200", fe.Detail.Mensaje);
                Assert.AreEqual("Validacion de negocio", fe.Reason.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void Eliminar()
        {
            try
            {
                ServiciosWS.ServiciosClient _proxy = new ServiciosWS.ServiciosClient();
                int codigo = 2;
                _proxy.EliminarServicio(codigo);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
                throw ex;
            }
        }

        [TestMethod]
        public void Listar()
        {
            try
            {
                int cantidad = 0;
                ServiciosWS.ServiciosClient _proxy = new ServiciosWS.ServiciosClient();
                List<ServicioEN> ListaServicio;

                ListaServicio = _proxy.ListarServicios();
                cantidad = ListaServicio.Count;
                Assert.AreNotEqual(1,cantidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
