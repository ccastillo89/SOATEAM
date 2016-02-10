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
    public class GestionCitasTest
    {
        [TestMethod]
        public void ListaCitasTest()
        {
            GestionCitasWS.GestionCitasServiceClient _proxy = new GestionCitasWS.GestionCitasServiceClient();
            List<CitaEN> lista = null;
            int cantidad;

            try
            {
                lista = _proxy.ListarCitas();
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
        public void ListaCitasPendientesTest()
        {
            GestionCitasWS.GestionCitasServiceClient _proxy = new GestionCitasWS.GestionCitasServiceClient();
            List<CitaEN> lista = null;
            int cantidad;
            string codigoUsuario = "2";
            try
            {
                lista = _proxy.ListarCitasPendientesDeAtencion(codigoUsuario);
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
        public void ListaHistorialCitasTest()
        {
            GestionCitasWS.GestionCitasServiceClient _proxy = new GestionCitasWS.GestionCitasServiceClient();
            List<CitaEN> lista = null;
            int cantidad;
            string codigoUsuario = "2";

            try
            {
                lista = _proxy.ListarHistorialDeCitas(codigoUsuario);
                cantidad = lista.Count;
                Assert.AreEqual(0, cantidad);
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
        public void CrearCitaTest()
        {
            CitaEN citaCreada = null;
            VehiculoEN vehiculoAsignado = null;
            TallerEN tallerAsignado = null;
            UsuarioEN usuarioAsignado = null;
            ServicioEN servicioAsignado = null;

            GestionCitasWS.GestionCitasServiceClient _proxy = new GestionCitasWS.GestionCitasServiceClient();

            tallerAsignado = new TallerEN()
            {
                Codigo = 2
            };

            vehiculoAsignado = new VehiculoEN()
            {
                Codigo = 1
            };

            usuarioAsignado = new UsuarioEN()
            {
                Codigo = 2
            };

            servicioAsignado = new ServicioEN()
            {
                Codigo = 1
            };

            var fecha = "09/02/2016";
            int anio = Convert.ToInt32(fecha.Substring(6, 4));
            int mes = Convert.ToInt32(fecha.Substring(3, 2));
            int dia = Convert.ToInt32(fecha.Substring(0, 2));
            int hh = 9;
            int mm = 0;
            int ss = 0;


            CitaEN citaACrear = new CitaEN()
            {
                Fecha = fecha,
                HoraInicio = new DateTime(anio, mes,dia, hh,mm,ss),
                Observacion = "Pendiente de pago",
                Vehiculo = vehiculoAsignado,
                Taller = tallerAsignado,
                Servicio = servicioAsignado,
                Usuario = usuarioAsignado
            };

            try
            {
                citaCreada = _proxy.CrearCita(citaACrear);
                Assert.AreNotEqual(null, citaCreada);
            }
            catch (FaultException<RepetidoException> fe)
            {
                if (fe.Detail.Codigo == 1)
                {
                    Assert.AreEqual(1, fe.Detail.Codigo);
                    Assert.AreEqual("La fecha y hora seleccionada no esta disponible.", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
