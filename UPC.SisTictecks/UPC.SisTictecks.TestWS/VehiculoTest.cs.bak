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
    public class VehiculoTest
    {

        #region "Vehiculo"

        [TestMethod]
        public void RegistraVehiculo()
        {
        }

        #endregion

        [TestMethod]
        public void ListarColoresTest()
        {
            VehiculoWS.VehiculoServiceClient _proxy = new VehiculoWS.VehiculoServiceClient();
            List<ColorEN> lista = null;
            int cantidad;
            try
            {
                lista = _proxy.ListarColores();
                cantidad = lista.Count;
                Assert.AreEqual(4, cantidad);
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
        public void ListarMoledosXMarca()
        {
            VehiculoWS.VehiculoServiceClient _proxy = new VehiculoWS.VehiculoServiceClient();
            List<ModeloEN> lista = null;
            int cantidad;
            int codigoMarca = 1;

            MarcaEN marca = new MarcaEN() { Codigo = codigoMarca };

            try
            {
                lista = _proxy.ListarModelosXMarca(marca);
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
        public void ListarMarcasTest()
        {
            VehiculoWS.VehiculoServiceClient _proxy = new VehiculoWS.VehiculoServiceClient();
            List<ColorEN> lista = null;
            int cantidad;
            try
            {
                lista = _proxy.ListarColores();
                cantidad = lista.Count;
                Assert.AreEqual(4, cantidad);
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
