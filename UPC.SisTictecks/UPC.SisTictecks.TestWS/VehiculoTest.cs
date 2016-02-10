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
        public void RegistraVehiculoTest()
        {
            VehiculoEN vehiculoCreado = null;
            MarcaEN marcaAsociada = null;
            ModeloEN modeloAsociado = null;
            ColorEN colorAsociado = null;
            UsuarioEN usuarioAsociado = null;
            VehiculoWS.VehiculoServiceClient _proxy = new VehiculoWS.VehiculoServiceClient();

            marcaAsociada = new MarcaEN()
            {
                Codigo = 1
            };

            modeloAsociado = new ModeloEN()
            {
                Codigo = 1
            };

            colorAsociado = new ColorEN()
            {
                Codigo = 1
            };

            usuarioAsociado = new UsuarioEN()
            {
                Codigo = 2
            };


            VehiculoEN vehiculoACrear = new VehiculoEN()
            {
                Anio = 2015,
                Color = colorAsociado,
                Descripcion = "Auto convertible",
                Kilometros = 5000,
                Marca = marcaAsociada,
                Modelo = modeloAsociado,
                Usuario = usuarioAsociado,
                Placa = "XYZ-456"
            };

            try
            {
                vehiculoCreado = _proxy.CrearVehiculo(vehiculoACrear);
                Assert.AreNotEqual(null, vehiculoCreado);
            }
            catch (FaultException<RepetidoException> fe)
            {
                if (fe.Detail.Codigo == 1)
                {
                    Assert.AreEqual(1, fe.Detail.Codigo);
                    Assert.AreEqual("La placa ya ha sido registrada", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [TestMethod]
        public void EditarVehiculoTest()
        {
            VehiculoEN vehiculoEditado = null;
            ModeloEN modeloAsociado = null;
            ColorEN colorAsociado = null;
            VehiculoWS.VehiculoServiceClient _proxy = new VehiculoWS.VehiculoServiceClient();

            modeloAsociado = new ModeloEN()
            {
                Codigo = 2
            };

            colorAsociado = new ColorEN()
            {
                Codigo = 3
            };


            int codigoVehiculo = 2;
            VehiculoEN vehiculoAEditar = _proxy.ObtenerVehiculo(codigoVehiculo);

            vehiculoAEditar.Modelo = modeloAsociado;
            vehiculoAEditar.Color = colorAsociado;
            vehiculoAEditar.Anio = 2013;
            vehiculoAEditar.Placa = "XYZ-123";

            try
            {
                vehiculoEditado = _proxy.ModificarVehiculo(vehiculoAEditar);
                Assert.AreNotEqual(null, vehiculoEditado);
            }
            catch (FaultException<RepetidoException> fe)
            {
                if (fe.Detail.Codigo == 1)
                {
                    Assert.AreEqual(1, fe.Detail.Codigo);
                    Assert.AreEqual("La placa ya ha sido registrada", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void EliminarVehiculoTest() 
        {
            bool vehiculoEliminado = false;
            VehiculoWS.VehiculoServiceClient _proxy = new VehiculoWS.VehiculoServiceClient();
            int codigo = 2;

            try
            {
                vehiculoEliminado = _proxy.EliminarVehiculo(codigo);
                Assert.IsTrue(vehiculoEliminado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            List<MarcaEN> lista = null;
            int cantidad;
            try
            {
                lista = _proxy.ListarMarcas();
                cantidad = lista.Count;
                Assert.AreEqual(28, cantidad);
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
