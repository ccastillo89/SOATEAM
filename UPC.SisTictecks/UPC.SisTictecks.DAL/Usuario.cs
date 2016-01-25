using UPC.SisTictecks.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using UPC.SisTictecks.Helpers;

namespace UPC.SisTictecks.DAL
{
    public class Usuario
    {
     /*
        public List<UsuarioEN> Listar() 
        {
            var usuarios = new List<UsuarioEN>();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cadena"].ToString())) 
                {
                    con.Open();

                    var query = new SqlCommand("SELECT Id,Nombres, Apellidos, Usuario, Activo, PerfilId FROM usuario", con);
                    using (var dr = query.ExecuteReader()) 
                    {
                        while (dr.Read()) 
                        {
                            // Usuario
                            var usuario = new UsuarioEN
                            { 
                                Id = Convert.ToInt32(dr["id"]),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Usuario = dr["Usuario"].ToString(),
                                Activo = Convert.ToBoolean(dr["Activo"]),
                                Perfil = Convert.ToInt32(dr["PerfilId"])
                            };

                            // Agregamos el usuario a la lista genreica
                            usuarios.Add(usuario);
                        }
                    }

                    // Agregamos el Perfil
                    foreach (var u in usuarios) 
                    {
                        query = new SqlCommand("SELECT id, Perfil , activo FROM usuarioPerfil WHERE id = @id", con);
                        query.Parameters.AddWithValue("@id", u.Perfil);

                        using (var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                PerfilEN perfil = new PerfilEN();
                                perfil.Id = Convert.ToInt32(dr["id"]);
                                perfil.Descripcion = dr["Perfil"].ToString();

                                u.Perfil = perfil;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuarios;
        }

        public UsuarioEN Obtener(int id)
        {
            var usuario = new UsuarioEN();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cadena"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT a.id, a.Nombres, a.Apellidos, a.Usuario, a.Password, a.Activo, a.PerfilId, b.Perfil FROM usuario a inner join usuarioPerfil b on a.PerfilID = b.Id WHERE a.id = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows) {
                            usuario.Id = Convert.ToInt32(dr["id"]);
                            usuario.Nombres = dr["Nombres"].ToString();
                            usuario.Apellidos = dr["Apellidos"].ToString();
                            usuario.Usuario = dr["Usuario"].ToString();
                            usuario.Pass = dr["Password"].ToString();
                            usuario.Activo = Convert.ToBoolean(dr["Activo"]);
                            usuario.Perfil = Convert.ToInt32(dr["PerfilId"]);

                            PerfilEN perfil = new PerfilEN();
                            perfil.Id = Convert.ToInt32(dr["PerfilId"]);
                            perfil.Descripcion = dr["Perfil"].ToString();

                            usuario.Perfil = perfil;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuario;
        }

        public bool Actualizar(UsuarioEN usuario)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cadena"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE Usuario SET Nombres = @p0, Apellidos = @p1, PerfilId = @p2, activo = @p3 WHERE id = @p4", con);

                    query.Parameters.AddWithValue("@p0", usuario.Nombres);
                    query.Parameters.AddWithValue("@p1", usuario.Apellidos);
                    query.Parameters.AddWithValue("@p2", usuario.Perfil);
                    query.Parameters.AddWithValue("@p3", usuario.Activo);
                    query.Parameters.AddWithValue("@p4", usuario.Id);

                    int i = query.ExecuteNonQuery();

                    if (i != 1)
	                {
		                respuesta = false;
	                }
                    else
	                {
                        respuesta = true;
	                }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public bool Registrar(UsuarioEN usuario)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cadena"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO Usuario(Nombres, Apellidos, Usuario, Password, Activo, PerfilID) VALUES (@p0, @p1, @p2, @p3, @p4, @p5)", con);

                    query.Parameters.AddWithValue("@p0", usuario.Nombres);
                    query.Parameters.AddWithValue("@p1", usuario.Apellidos);
                    query.Parameters.AddWithValue("@p2", usuario.Usuario);
                    query.Parameters.AddWithValue("@p3", usuario.Pass);
                    query.Parameters.AddWithValue("@p4", usuario.Activo);
                    query.Parameters.AddWithValue("@p5", usuario.Perfil);

                    int i = query.ExecuteNonQuery();

                    if (i != 1)
	                {
		                respuesta = false;
	                }
                    else
	                {
                        respuesta = true;
	                }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cadena"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("DELETE FROM usuario WHERE id = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    int i = query.ExecuteNonQuery();

                    if (i != 1)
	                {
		                respuesta = false;
	                }
                    else
	                {
                        respuesta = true;
	                }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public bool Login(string usuario, string pass)
        {
            bool logueado = false;
            int cntUser = 0;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cadena"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT count(1) FROM usuario WHERE UPPER(usuario) = @user and password = @pass", con);
                    query.Parameters.AddWithValue("@user", usuario.ToUpper());
                    query.Parameters.AddWithValue("@pass", pass); //Encriptar.Encode(pass));
                    
                   //Retornando Valor
                   cntUser =  (Int32)query.ExecuteScalar();

                   if (cntUser == 1)
                   {
                       logueado = true;
                   }
                   else
                   {
                       logueado = false;
                   }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return logueado;
        }
    */
    }
}
