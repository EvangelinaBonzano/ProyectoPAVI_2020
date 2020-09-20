using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ProyectoLiquidexSA.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoLiquidexSA.DataAccessLayer
{
    public class UsuarioDao
    {
        public IList<Usuario> GetAll()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();

            String strSql = string.Concat(" SELECT id_usuario, ",
            "        usuario, ",
            "        u.borrado as borrado, ",
            "        email, ",
            "        estado, ",
            "        password, ",
            "        p.id_perfil, ",
            "        p.nombre as perfil",
            "   FROM Usuarios u",
            "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil WHERE u.borrado=0 ");

            var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            //DataManager dm = new DataManager();
            //var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuarios.Add(ObjectMapping(row));
            }

            return listadoUsuarios;
        }
        public Usuario GetUserConParametros(string nombreUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        email, ",
                                          "        estado, ",
                                          "        password, ",
                                          "        p.id_perfil, ",
                                          "        p.nombre as perfil",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                          "  WHERE u.usuario =  @usuario AND u.borrado=0 ");

            var parametros = new Dictionary<string, object>();
            parametros.Add("usuario", nombreUsuario);
            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            //var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);
            DataManager dm = new DataManager();
            dm.Open();
            var resultado = dm.ConsultaSQLConParametros(strSql, parametros);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }


        public Usuario GetUserSinParametros(string nombreUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_usuario, ",
                                          "        usuario, ",
                                          "        u.borrado as borrado, ",
                                          "        email, ",
                                          "        estado, ",
                                          "        password, ",
                                          "        p.id_perfil, ",
                                          "        p.nombre as perfil ",
                                          "   FROM Usuarios u",
                                          "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                          "  WHERE u.borrado =0 ");

            strSql +=" AND usuario="+"'"+nombreUsuario+"'";


            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            // var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            DataManager dm = new DataManager();
            dm.Open();
            var resultado = dm.ConsultaSQL(strSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return ObjectMapping(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Usuario> GetByFiltersConParametros(Dictionary<string, object> parametros)
        {
                        
            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, ",
                                              "        usuario, ",
                                              "        u.borrado as borrado, ",
                                              "        email, ",
                                              "        estado, ",
                                              "        password, ",
                                              "        p.id_perfil, ",
                                              "        p.nombre as perfil ",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                              "  WHERE u.borrado = 0 AND u.estado = 'S'");


            if (parametros.ContainsKey("idPerfil"))
            strSql += " AND (u.id_perfil = @idPerfil) ";


            if (parametros.ContainsKey("usuario"))
            strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            //var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);
            DataManager dm = new DataManager();
            dm.Open();
            var resultado = dm.ConsultaSQLConParametros(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }


        public IList<Usuario> GetByFiltersSinParametros(String condiciones)
        {

            List<Usuario> lst = new List<Usuario>();
            String strSql = string.Concat(" SELECT id_usuario, ",
                                              "        usuario, ",
                                              "        u.borrado as borrado, ",
                                              "        email, ",
                                              "        estado, ",
                                              "        password, ",
                                              "        p.id_perfil, ",
                                              "        p.nombre as perfil ",
                                              "   FROM Usuarios u",
                                              "  INNER JOIN Perfiles p ON u.id_perfil= p.id_perfil ",
                                              "  WHERE u.borrado =0 AND u.estado = 'S'");
            //agrego condiciones
            strSql += condiciones;


            // if (parametros.ContainsKey("idPerfil"))
            //   strSql += " AND (u.id_perfil = @idPerfil) ";


            // if (parametros.ContainsKey("usuario"))
            //    strSql += " AND (u.usuario LIKE '%' + @usuario + '%') ";

            //var resultado = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            DataManager dm = new DataManager();
            dm.Open();
            var resultado = dm.ConsultaSQL(strSql);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }

        internal bool Create(Usuario oUsuario)
        {
            //CON PARAMETROS
            //string str_sql = "     INSERT INTO Usuarios (usuario, password, email, id_perfil, estado, borrado)" +
            //                 "     VALUES (@usuario, @password, @email, @id_perfil, 'S', 0)";

            // var parametros = new Dictionary<string, object>();
            //parametros.Add("usuario", oUsuario.NombreUsuario);
            //parametros.Add("password", oUsuario.Password);
            //parametros.Add("email", oUsuario.Email);
            //parametros.Add("id_perfil", oUsuario.Perfil.IdPerfil);

            // Si una fila es afectada por la inserción retorna TRUE. Caso contrario FALSE
            //con parametros
            //return (DBHelper.GetDBHelper().EjecutarSQLConParametros(str_sql, parametros) == 1);

            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                //SIN PARAMETROS

                string str_sql = "INSERT INTO Usuarios (usuario, password, email, estado, id_perfil, borrado)" +
                            " VALUES (" + 
                            "'" + oUsuario.NombreUsuario + "'" +","+
                            "'" + oUsuario.Password + "'" +"," +
                            "'" + oUsuario.Email + "'" + "," +
                            "'" + oUsuario.Estado+ "'" + "," +
                            oUsuario.Perfil.IdPerfil +  ",0)";


                //return (DBHelper.GetDBHelper().EjecutarSQL(str_sql)==1);
                dm.EjecutarSQL(str_sql);
                dm.Commit();
            }
           
            catch (Exception ex)
            {
                dm.Rollback();
                throw ex;
            }
            finally
            {
                // Cierra la conexión 
                dm.Close();
            }
            return true;
        }

        internal bool Update(Usuario oUsuario)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE Usuarios " +
                             "SET usuario=" + "'" + oUsuario.NombreUsuario + "'" + "," +
                             " password=" + "'" + oUsuario.Password + "'" + "," +
                             " email=" + "'" + oUsuario.Email + "'" + "," +
                             " estado=" + "'" + oUsuario.Estado + "'" + "," +
                             " id_perfil=" + oUsuario.Perfil.IdPerfil +
                             " WHERE id_usuario=" + oUsuario.IdUsuario + " AND  borrado=0";

            //return (DBHelper.GetDBHelper().EjecutarSQL(str_sql)==1);
            dm.EjecutarSQL(str_sql);
            dm.Commit();
        }
           
            catch (Exception ex)
            {
                dm.Rollback();
                throw ex;
            }
            finally
            {
                // Cierra la conexión 
                dm.Close();
            }
            return true;
        }
        

        internal bool Delete(Usuario oUsuario)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE Usuarios " +
                             "SET borrado=1" +
                             " WHERE id_usuario=" + oUsuario.IdUsuario + " AND  borrado=0";

                //return (DBHelper.GetDBHelper().EjecutarSQL(str_sql) == 1);
                dm.EjecutarSQL(str_sql);
                dm.Commit();
            }

            catch (Exception ex)
            {
                dm.Rollback();
                throw ex;
            }
            finally
            {
                // Cierra la conexión 
                dm.Close();
            }
            return true;
        }

        private Usuario ObjectMapping(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                Borrado = Convert.ToBoolean(row["borrado"].ToString()),
                NombreUsuario = row["usuario"].ToString(),
                Email = row["email"].ToString(),
                Estado = row["estado"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,
                Perfil = new Perfil() {
                    IdPerfil = Convert.ToInt32(row["id_perfil"].ToString()),
                    Nombre = row["perfil"].ToString(),
                }                
            };

            return oUsuario;
        }
        
}

}

