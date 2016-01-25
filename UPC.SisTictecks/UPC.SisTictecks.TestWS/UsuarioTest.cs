using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPC.SisTictecks.EL;
using System.ServiceModel;
using System.Collections.Generic;

namespace UPC.SisTictecks.TestWS
{
    [TestClass]
    public class UsuarioTest
    {

        [TestMethod]
        public void CrearUsuario()
        {

            UsuarioWS.UsuariosClient _proxy = new UsuarioWS.UsuariosClient();
            UsuarioEN usuarioCreado;

            PerfilEN perfil = new PerfilEN(){
                  Codigo = 1
            };

            UsuarioEN usuarioNuevo = new UsuarioEN()
            {
                Nombres = "Carlos",
                Apellidos = "Castillo Calderon",
                Usuario = "ccastillo",
                Pass = "123",
                Estado = true,
                Correo = "ccas@gmail.com",
                Telefono = "991440830",
                Perfil = perfil
            };

            string user;

            try
            {
                usuarioCreado = _proxy.CrearUsuario(usuarioNuevo);
                user = usuarioCreado.Usuario;
                Assert.AreEqual("ccastillo", user);
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
                UsuarioWS.UsuariosClient _proxy = new UsuarioWS.UsuariosClient();
                int codigo =6;
                bool respuesta = false;
                respuesta = _proxy.EliminarUsuario(codigo);
                Assert.IsTrue(respuesta);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
                throw ex;
            }
        }



    }
}
