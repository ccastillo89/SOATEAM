﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.SisTictecks.EL;
using NHibernate;
using NHibernate.Criterion;

namespace UPC.SisTictecks.DAL
{
    public class UsuarioDAO : BaseDAO<UsuarioEN, int>
    {

        public UsuarioEN ValidarLogin(string usuario, string password) 
        {
            UsuarioEN oUser = null;
            using (ISession session = NHibernateHelper.ObtenerSesion())
            {

                oUser = session
                    .CreateCriteria(typeof(UsuarioEN))
                    .Add(Restrictions.Eq("Usuario", usuario.ToUpper()))
                    .Add(Restrictions.Eq("Pass", password))
                    .UniqueResult<UsuarioEN>();

            }
            return oUser;
        }

        public int ValidarCantidadAdministradores()
        {
            int cantidad = 0;
            PerfilEN perfilAdmistrador = new PerfilEN() { Codigo = 1, Estado = true};

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {

                cantidad = session
                    .CreateCriteria(typeof(UsuarioEN))
                    .Add(Restrictions.Eq("Perfil", perfilAdmistrador))
                    .List<UsuarioEN>().Count;
            }

            return cantidad;
        }

        public bool ValidarNombreDeUsuario(string usuario)
        {
            int cantidad = 0;
            bool resultado = false;

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidad = session
                    .CreateCriteria(typeof(UsuarioEN))
                    .Add(Restrictions.Eq("Usuario", usuario.ToUpper()))
                    .List<UsuarioEN>().Count;
            }

            if (cantidad == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }

        public bool ValidarCorreoExistente(string correo)
        {
            int cantidad = 0;
            bool resultado = false;

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidad = session
                    .CreateCriteria(typeof(UsuarioEN))
                    .Add(Restrictions.Eq("Correo", correo))
                    .List<UsuarioEN>().Count;
            }

            if (cantidad == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }

        public bool ValidarDniExistente(string dni)
        {
            int cantidad = 0;
            bool resultado = false;

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidad = session
                    .CreateCriteria(typeof(UsuarioEN))
                    .Add(Restrictions.Eq("Dni", dni.ToUpper()))
                    .List<UsuarioEN>().Count;
            }

            if (cantidad == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }

        public bool ValidarUsuarioTipoCliente(int codigoUsuario)
        {
            int cantidad = 0;
            bool resultado = false;

            PerfilEN perfil = new PerfilEN() { Codigo = 2}; //Perfil : Cliente

            using (ISession session = NHibernateHelper.ObtenerSesion())
            {
                cantidad = session
                    .CreateCriteria(typeof(UsuarioEN))
                    .Add(Restrictions.Eq("Codigo", codigoUsuario))
                    .Add(Restrictions.Eq("Perfil", perfil))
                    .List<UsuarioEN>().Count;
            }

            if (cantidad == 0)
                resultado = false;
            else
                resultado = true;

            return resultado;
        }

    }
}
