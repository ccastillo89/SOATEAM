using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPC.SisTictecks.EL;
using System.ServiceModel;

namespace UPC.SisTictecks.TestWS
{
    [TestClass]
    public class ParametrosTest
    {
        [TestMethod]
        public void ListarServiciosTest()
        {
            ParametrosWS.ParametrosServiceClient _proxy = new ParametrosWS.ParametrosServiceClient();
            List<ServicioEN> lista = null;
            int cantidad;
            try
            {
                lista = _proxy.ListarServicios();
                cantidad = lista.Count;
                Assert.AreEqual(1, cantidad);
            }
            catch (FaultException<RepetidoException> fe)
            {
                //Assert.AreEqual(1, fe.Detail.Codigo);
                Assert.AreEqual("No se encontraron datos", fe.Detail.Mensaje);
                Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void ListarTalleresTest()
        {
            ParametrosWS.ParametrosServiceClient _proxy = new ParametrosWS.ParametrosServiceClient();
            List<TallerEN> lista = null;
            int cantidad;
            try
            {
                lista = _proxy.ListarTalleres();
                cantidad = lista.Count;
                Assert.AreEqual(3, cantidad);
            }
            catch (FaultException<RepetidoException> fe)
            {
                //Assert.AreEqual(1, fe.Detail.Codigo);
                Assert.AreEqual("No se encontraron datos", fe.Detail.Mensaje);
                Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
