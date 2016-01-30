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
    public class UsuariosTest
    {
        [TestMethod]
        public void ListarUsuariosTest()
        {
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();
            List<UsuarioEN> lista = null;
            int cantidad;

            try
            {
                lista = _proxy.ListarUsuarios();
                cantidad = lista.Count;
                Assert.AreEqual(2, cantidad);
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
        public void CrearUsuarioTest()
        {
            UsuarioEN usuarioCreado = null;
            PerfilEN perfilAsignado = null;
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();

            perfilAsignado = new PerfilEN(){
                Codigo = 2
            };

            UsuarioEN UsuarioCrear = new UsuarioEN(){
                Nombres = "Ivan",
                Apellidos = "Juarez",
                Telefono = "989989897",
                Correo = "pasivo1@gmail.com",
                Usuario = "CHIVANES",
                Pass = "123",
                Dni = "45791113",
                Estado = true,
                Perfil = perfilAsignado
            };

            try
            {
                usuarioCreado = _proxy.CrearUsuario(UsuarioCrear);
                Assert.AreNotEqual(null, usuarioCreado);
            }
            catch (FaultException<RepetidoException> fe)
            {
                if (fe.Detail.Codigo == 1) 
                {
                    Assert.AreEqual(1, fe.Detail.Codigo);
                    Assert.AreEqual("El máximo numero de administradores permitidos es 3", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
                else if(fe.Detail.Codigo == 2)
                {
                    Assert.AreEqual(2, fe.Detail.Codigo);
                    Assert.AreEqual("El nombre de usuario, ya esta siendo usado.", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
                else if(fe.Detail.Codigo == 3)
                {
                    Assert.AreEqual(3, fe.Detail.Codigo);
                    Assert.AreEqual("El correo electronico ya ha sido registrado.", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
                else if (fe.Detail.Codigo == 4)
                {
                    Assert.AreEqual(4, fe.Detail.Codigo);
                    Assert.AreEqual("El número de DNI ya ha sido registrado.", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [TestMethod]
        public void ObtenerUsuarioTest()
        {
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();
            UsuarioEN usuario = null;
            int codigo = 2;

            try
            {
                usuario = _proxy.ObtenerUsuario(codigo);
                Assert.AreNotEqual(null, usuario);
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
        public void ModificarUsuarioTest()
        {
            UsuarioEN usuarioModificado = null;
            PerfilEN perfilAsignado = null;
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();

            perfilAsignado = new PerfilEN()
            {
                Codigo = 2
            };

            UsuarioEN UsuarioModificar = new UsuarioEN()
            {
                Codigo = 4,
                Nombres = "Ivan",
                Apellidos = "Juarez",
                Telefono = "989989897",
                Correo = "pasivo1@gmail.com",
                Usuario = "CHIVANES",
                Pass = "12344",
                Dni = "45791113",
                Estado = true,
                Perfil = perfilAsignado
            };

            try
            {
                usuarioModificado = _proxy.ModificarUsuario(UsuarioModificar);
                Assert.AreNotEqual(null, usuarioModificado);
            }
            catch (FaultException<RepetidoException> fe)
            {
                if (fe.Detail.Codigo == 1)
                {
                    Assert.AreEqual(1, fe.Detail.Codigo);
                    Assert.AreEqual("El máximo numero de administradores permitidos es 3", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
                else if (fe.Detail.Codigo == 2)
                {
                    Assert.AreEqual(2, fe.Detail.Codigo);
                    Assert.AreEqual("El nombre de usuario, ya esta siendo usado.", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
                else if (fe.Detail.Codigo == 3)
                {
                    Assert.AreEqual(3, fe.Detail.Codigo);
                    Assert.AreEqual("El correo electronico ya ha sido registrado.", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }
                else if (fe.Detail.Codigo == 4)
                {
                    Assert.AreEqual(4, fe.Detail.Codigo);
                    Assert.AreEqual("El número de DNI ya ha sido registrado.", fe.Detail.Mensaje);
                    Assert.AreEqual("Validación de negocio", fe.Reason.ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        [TestMethod]
        public void EliminarUsuarioTest()
        {
            bool usuarioeliminado = false;
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();
            int codigo = 3;

            try
            {
                usuarioeliminado = _proxy.EliminarUsuario(codigo);
                Assert.IsTrue(usuarioeliminado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void ValidarNombreDeUsuarioExistenteTest()
        {
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();
            string nombreUsuario = "CCAS";
            bool valido = false;

            valido = _proxy.ValidarNombreDeUsuarioExistente(nombreUsuario);
            Assert.IsTrue(valido);
        }

        [TestMethod]
        public void ValidarCorreoExistenteTest()
        {
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();
            string correo = "pasivo1@gmail.com";
            bool valido = false;

            valido = _proxy.ValidarCorreoExistente(correo);
            Assert.IsTrue(valido);
        }

        [TestMethod]
        public void ListarPerfiles()
        {
            GestionUsuariosWS.UsuariosServiceClient _proxy = new GestionUsuariosWS.UsuariosServiceClient();
            List<PerfilEN> lista = null;
            int cantidad;

            try
            {
                lista = _proxy.ListarPerfiles();
                cantidad = lista.Count;
                Assert.AreEqual(2, cantidad);
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
