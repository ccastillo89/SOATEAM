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
    public class TalleresTest
    {
        [TestMethod]
        public void ListarTalleresTest()
        {
            TalleresWS.TallerServiceClient _proxy = new TalleresWS.TallerServiceClient();
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
