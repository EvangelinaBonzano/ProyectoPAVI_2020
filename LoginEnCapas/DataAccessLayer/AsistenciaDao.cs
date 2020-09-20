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
using ProyectoLiquidexSA.BusinessLayer;


namespace ProyectoLiquidexSA.DataAccessLayer
{
    public class AsistenciaDao
    {
        public IList<AsistenciaUsuarios> GetAll()
        {
            List<AsistenciaUsuarios> listadoAsistencia = new List<AsistenciaUsuarios>();

            String strSql = string.Concat(" SELECT a.id_usuario, ",
                                          "        a.fecha, ",
                                          "        a.borrado as borrado, ",
                                          "        a.hora_ingreso, ",
                                          "        a.hora_salida, ",
                                          "        a.comentario, ",
                                          "        e.id_estado_asistencia, ",
                                          "        u.usuario, ",
                                          "        e.n_estados_asistencia ",
                                          "   FROM AsistenciaUsuarios a",
                                          "  INNER JOIN EstadosAsistencia e ON (a.id_estado_asistencia=e.id_estado_asistencia) ",
                                          "  INNER JOIN Usuarios u ON (a.id_usuario=u.id_usuario) WHERE a.borrado=0 ");

            //var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            DataManager dm = new DataManager();
            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoAsistencia.Add(ObjectMapping(row));
            }
            return listadoAsistencia;
        }
        //public AsistenciaUsuarios GetAsistenciaConParametros(int idUsuario, DateTime fecha)
        //{
        //    //Construimos la consulta sql para buscar el usuario en la base de datos.
        //    String strSql = string.Concat(" SELECT a.id_usuario, ",
        //                                  "        a.fecha, ",
        //                                  "        a.borrado as borrado, ",
        //                                  "        a.hora_ingreso, ",
        //                                  "        a.hora_salida, ",
        //                                  "        a.comentario, ",
        //                                  "        e.id_estado_asistencia, ",
        //                                  "        u.usuario, ",
        //                                  "        e.n_estados_asistencia ",
        //                                  "   FROM AsistenciaUsuarios a",
        //                                  "  INNER JOIN EstadosAsistencia e ON (a.id_estado_asistencia=e.id_estado_asistencia) ",
        //                                  "  INNER JOIN Usuarios u ON (a.id_usuario=u.id_usuario) ",
        //                                  "  WHERE a.id_usuario =  @id_usuario AND a.fecha= @fecha AND a.borrado=0 ");

        //    var parametros = new Dictionary<string, object>();
        //    parametros.Add("id_usuario", idUsuario);
        //    parametros.Add("fecha", fecha);
        //    //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
        //    //var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);
        //    DataManager dm = new DataManager();
        //    dm.Open();
        //    var resultado = dm.ConsultaSQLConParametros(strSql, parametros);

        //    // Validamos que el resultado tenga al menos una fila.
        //    if (resultado.Rows.Count > 0)
        //    {
        //        return ObjectMapping(resultado.Rows[0]);
        //    }

        //    return null;
        //}

    
        public AsistenciaUsuarios GetAsistenciaSinParametros(int idUsuario, DateTime fecha)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT a.id_usuario, ",
                                              "        a.fecha, ",
                                              "        a.borrado as borrado, ",
                                              "        a.hora_ingreso, ",
                                              "        a.hora_salida, ",
                                              "        a.comentario, ",
                                              "        e.id_estado_asistencia, ",
                                              "        u.usuario, ",
                                              "        e.n_estados_asistencia ",
                                              "   FROM AsistenciaUsuarios a",
                                              "  INNER JOIN EstadosAsistencia e ON (a.id_estado_asistencia=e.id_estado_asistencia) ",
                                              "  INNER JOIN Usuarios u ON (a.id_usuario=u.id_usuario) ",
                                              "  WHERE a.borrado=0 ");

            strSql += " AND a.id_usuario=" + "'" + idUsuario + "'";
            strSql += " AND a.fecha=" + "'" + fecha.ToString("yyyy-MM-dd") + "'";

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


        public IList<AsistenciaUsuarios> GetByFiltersConParametros(Dictionary<string, object> parametros)
        {

            List<AsistenciaUsuarios> lst = new List<AsistenciaUsuarios>();
            String strSql = string.Concat(" SELECT a.id_usuario, ",
                                          "        a.fecha, ",
                                          "        a.borrado as borrado, ",
                                          "        a.hora_ingreso, ",
                                          "        a.hora_salida, ",
                                          "        a.comentario, ",
                                          "        e.id_estado_asistencia, ",
                                          "        u.usuario, ",
                                          "        e.n_estados_asistencia ",
                                          "   FROM AsistenciaUsuarios a",
                                          "  INNER JOIN EstadosAsistencia e ON (a.id_estado_asistencia=e.id_estado_asistencia) ",
                                          "  INNER JOIN Usuarios u ON (a.id_usuario=u.id_usuario) ",
                                              "  WHERE a.borrado=0 ");


            if (parametros.ContainsKey("id_estado_asistencia"))
                strSql += " AND (a.id_estado_asistencia = @id_estado_asistencia) ";


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


        public IList<AsistenciaUsuarios> GetByFiltersSinParametros(String condiciones)
        {

              List<AsistenciaUsuarios> lstAsistencia = new List<AsistenciaUsuarios>();
              String strSql = string.Concat(" SELECT a.id_usuario, ",
                                          "        a.fecha, ",
                                          "        a.borrado as borrado, ",
                                          "        a.hora_ingreso, ",
                                          "        a.hora_salida, ",
                                          "        a.comentario, ",
                                          "        e.id_estado_asistencia, ",
                                          "        u.usuario, ",
                                          "        e.n_estados_asistencia ",
                                          "   FROM AsistenciaUsuarios a",
                                          "  INNER JOIN EstadosAsistencia e ON (a.id_estado_asistencia=e.id_estado_asistencia) ",
                                          "  INNER JOIN Usuarios u ON (a.id_usuario=u.id_usuario) ",
                                              "  WHERE a.borrado=0 ");
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
                lstAsistencia.Add(ObjectMapping(row));

            return lstAsistencia;
        }

        internal bool Create(AsistenciaUsuarios oAsistenciaUsuarios)
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

                string str_sql = "INSERT INTO AsistenciaUsuarios (id_usuario, fecha, hora_ingreso, hora_salida, id_estado_asistencia,comentario, borrado)" +
                            " VALUES (" +
                            "'" + oAsistenciaUsuarios.Usuario.IdUsuario + "'" + "," +
                            "'" + oAsistenciaUsuarios.Fecha.ToString("yyyy-MM-dd") + "'" + "," +
                            "'" + oAsistenciaUsuarios.Hora_ingreso.ToString("hh:mm:ss") + "'"  + "," +
                            "'" + oAsistenciaUsuarios.Hora_salida.ToString("hh:mm:ss") + "'"  + "," +
                            "'" + oAsistenciaUsuarios.EstadosAsistencia.Id_estado_asistencia + "'" + "," +
                            "'" + oAsistenciaUsuarios.Comentario + "'" + "," + "0)";


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

        internal bool Update(AsistenciaUsuarios oAsistenciaUsuarios)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE AsistenciaUsuarios " +
                             "SET hora_ingreso='" + oAsistenciaUsuarios.Hora_ingreso .ToString("hh:mm:ss")+ "'" + "," +
                             " hora_salida='" + oAsistenciaUsuarios.Hora_salida.ToString("hh:mm:ss") + "'" + "," +
                             " id_estado_asistencia=" + oAsistenciaUsuarios.EstadosAsistencia.Id_estado_asistencia + "," +
                             " comentario = " + "'" + oAsistenciaUsuarios.Comentario + "'" +
                             " WHERE id_usuario=" + oAsistenciaUsuarios.Usuario.IdUsuario +
                             " AND  fecha='" + oAsistenciaUsuarios.Fecha.ToString("yyyy-MM-dd") + "'" + 
                             " AND  borrado=0";

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


        internal bool Delete(AsistenciaUsuarios oAsistenciaUsuarios)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE AsistenciaUsuarios " +
                             " SET borrado=1" +
                             " WHERE id_usuario=" + oAsistenciaUsuarios.Usuario.IdUsuario + 
                             " AND  fecha='" + oAsistenciaUsuarios.Fecha.ToString("yyyy-MM-dd") + "'" +
                             " AND  borrado=0";

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

        private AsistenciaUsuarios ObjectMapping(DataRow row)
        {
            AsistenciaUsuarios oAsistencia = new AsistenciaUsuarios
            {
                Borrado = Convert.ToBoolean(row["borrado"].ToString()),
                Hora_ingreso = Convert.ToDateTime(row["hora_ingreso"].ToString()),
                Fecha = Convert.ToDateTime(row["fecha"]),
                Hora_salida = Convert.ToDateTime(row["hora_salida"].ToString()),
                Comentario = row["comentario"].ToString(),

               Usuario = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                    NombreUsuario = row["usuario"].ToString()
                },

                EstadosAsistencia = new EstadosAsistencia()
                {
                    Id_estado_asistencia = Convert.ToInt32(row["id_estado_asistencia"].ToString()),
                    N_estados_asistencia = row["n_estados_asistencia"].ToString(),
                }
            };

            return oAsistencia;
        }
    }

}