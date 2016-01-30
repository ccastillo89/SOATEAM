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
    public class SeguridadTest
    {
        [TestMethod]
        public void AutentificarTest()
        {
            SeguridadWS.SeguridadServiceClient _proxy = new SeguridadWS.SeguridadServiceClient();
            UsuarioEN usuarioLogueado = null;
            string usuario = "ccas";
            string pass = "123";

            try
            {
                usuarioLogueado = _proxy.AutenticarUsuario(usuario, pass);
                Assert.AreNotEqual(null, usuarioLogueado);
            }
            catch (FaultException<RepetidoException> fe)
            {
                //Assert.AreEqual(1, fe.Detail.Codigo);
                Assert.AreEqual("Usuario o password incorrecto", fe.Detail.Mensaje);
                Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
