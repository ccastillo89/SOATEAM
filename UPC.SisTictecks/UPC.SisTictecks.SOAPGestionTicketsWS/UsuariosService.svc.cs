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
    public class Usuarios : IUsuariosService
    {
        private UsuarioDAO usuarioDAO = null;

        private UsuarioDAO UsuarioDAO
        {
            get
            {
                if (usuarioDAO == null)
                    usuarioDAO = new UsuarioDAO();

                return usuarioDAO;
            }
        }

        public UsuarioEN CrearUsuario(UsuarioEN usuarioCrear)
        {
            int cantidadAdm = 0;
            bool existeNombreUsuario = false;
            bool existeCorreo = false;
            bool existeDNI = false;

            if (usuarioCrear.Perfil.Codigo == 1)
            {
                cantidadAdm = usuarioDAO.ValidarCantidadAdministradores();

                if (cantidadAdm == 3)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 1,
                        Mensaje = "El máximo numero de administradores permitidos es 3"
                    },
                    new FaultReason("Validación de negocio"));                    
                }
            }

            if (usuarioCrear.Usuario != null)
            {
                existeNombreUsuario = usuarioDAO.ValidarNombreDeUsuario(usuarioCrear.Usuario.ToUpper());

                if (existeNombreUsuario)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 2,
                        Mensaje = "El nombre de usuario, ya esta siendo usado."
                    },
                    new FaultReason("Validación de negocio"));   
                }
            }

            if (usuarioCrear.Correo != null)
            {
                existeCorreo = usuarioDAO.ValidarCorreoExistente(usuarioCrear.Correo);

                if (existeCorreo)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 3,
                        Mensaje = "El correo electronico ya ha sido registrado."
                    },
                   new FaultReason("Validación de negocio"));  
                }
            }

            if (usuarioCrear.Dni != null)
            {
                existeDNI = usuarioDAO.ValidarDniExistente(usuarioCrear.Dni);

                if (existeDNI)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 4,
                        Mensaje = "El número de DNI ya ha sido registrado."
                    },
                   new FaultReason("Validación de negocio"));
                }
            }

            return UsuarioDAO.Crear(usuarioCrear);
        }

        public UsuarioEN ObtenerUsuario(int codigo)
        {
            return UsuarioDAO.Obtener(codigo);
        }

        public UsuarioEN ModificarUsuario(UsuarioEN usuarioModificar)
        {
            UsuarioEN usuarioExistente = UsuarioDAO.Obtener(usuarioModificar.Codigo);

            int cantidadAdm = 0;
            bool existeNombreUsuario = false;
            bool existeCorreo = false;
            bool existeDNI = false;

            if (usuarioModificar.Perfil.Codigo == 1 && usuarioModificar.Perfil.Codigo != usuarioExistente.Perfil.Codigo)
            {
                cantidadAdm = usuarioDAO.ValidarCantidadAdministradores();

                if (cantidadAdm == 3)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 1,
                        Mensaje = "El máximo numero de administradores permitidos es 3"
                    },
                    new FaultReason("Validación de negocio"));
                }
            }

            if (usuarioModificar.Usuario != null && usuarioModificar.Usuario != usuarioExistente.Usuario)
            {
                existeNombreUsuario = usuarioDAO.ValidarNombreDeUsuario(usuarioModificar.Usuario.ToUpper());

                if (existeNombreUsuario)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 2,
                        Mensaje = "El nombre de usuario, ya esta siendo usado."
                    },
                    new FaultReason("Validación de negocio"));
                }
            }

            if (usuarioModificar.Correo != null && usuarioModificar.Correo.ToUpper() != usuarioExistente.Correo.ToUpper())
            {
                existeCorreo = usuarioDAO.ValidarCorreoExistente(usuarioModificar.Correo);

                if (existeCorreo)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 3,
                        Mensaje = "El correo electronico ya ha sido registrado."
                    },
                   new FaultReason("Validación de negocio"));
                }
            }

            if (usuarioModificar.Dni != null && usuarioModificar.Dni != usuarioExistente.Dni)
            {
                existeDNI = usuarioDAO.ValidarDniExistente(usuarioModificar.Dni);

                if (existeDNI)
                {
                    throw new FaultException<RepetidoException>(new RepetidoException()
                    {
                        Codigo = 4,
                        Mensaje = "El número de DNI ya ha sido registrado."
                    },
                   new FaultReason("Validación de negocio"));
                }
            }

            return UsuarioDAO.Modificar(usuarioModificar);
        }

        public bool EliminarUsuario(int codigo)
        {
            UsuarioEN usuarioExistente = UsuarioDAO.Obtener(codigo);
            bool ejecuto =false;
            if (usuarioExistente != null)
            {
                UsuarioDAO.Eliminar(usuarioExistente);
                ejecuto = true;
            }
            else
                ejecuto = false;

            return ejecuto;
        }

        public List<UsuarioEN> ListarUsuarios()
        {
            return UsuarioDAO.ListarTodos().ToList();
        }

        public bool ValidarNombreDeUsuarioExistente(string usuario)
        {
            return usuarioDAO.ValidarNombreDeUsuario(usuario);
        }

        public bool ValidarCorreoExistente(string correo)
        {
            return usuarioDAO.ValidarCorreoExistente(correo);
        }

    }
}
