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
    public class AsignacionDao
    {
        public IList<Asignacion> GetAll()
        {
            List<Asignacion> listadoAsignaciones = new List<Asignacion>();

            String strSql = string.Concat(" SELECT id_asignacion, ",
                                            "        n_asignacion, ",
                                            "        borrado as borrado, ",
                                            "        monto ",
                                            " FROM Asignaciones",
                                            " WHERE borrado=0 ");

            //var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            DataManager dm = new DataManager();
            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoAsignaciones.Add(ObjectMapping(row));
            }

            return listadoAsignaciones;
        }

        public Asignacion GetAsignacionSinParametros(string nombreAsignacion)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String strSql = string.Concat(" SELECT id_asignacion, ",
                                          "        n_asignacion, ",
                                          "        borrado as borrado, ",
                                          "        monto ",
                                          "   FROM Asignaciones",
                                          "  WHERE borrado =0 ");

            strSql += " AND n_asignacion=" + "'" + nombreAsignacion + "'";


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
        public IList<Asignacion> GetByFiltersConParametros(Dictionary<string, object> parametros)
        {

            List<Asignacion> lst = new List<Asignacion>();
            String strSql = string.Concat(" SELECT id_asignacion, ",
                                              "        n_asignacion, ",
                                              "        borrado as borrado, ",
                                              "        monto ",
                                              "   FROM Asignaciones",
                                              "  WHERE borrado = 0 ");


            if(parametros.ContainsKey("id_asignacion"))
                strSql += " AND (id_asignacion = @id_asignacion) ";

            //var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);
            DataManager dm = new DataManager();
            dm.Open();
            var resultado = dm.ConsultaSQLConParametros(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }


        public IList<Asignacion> GetByFiltersSinParametros(String condiciones)
        {

            List<Asignacion> lst = new List<Asignacion>();
            String strSql = string.Concat(" SELECT id_asignacion, ",
                                              "        n_asignacion, ",
                                              "        borrado as borrado, ",
                                              "        monto ",
                                              "   FROM Asignaciones",
                                              "  WHERE borrado =0 ");
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

        internal bool Create(Asignacion oAsignacion)
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

                string str_sql = "INSERT INTO Asignaciones (n_asignacion, monto, borrado)" +
                            " VALUES (" +
                            "'" + oAsignacion.N_asignacion + "'" + "," 
                            + oAsignacion.Monto + ",0)";


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

        internal bool Update(Asignacion oAsignacion)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE Asignaciones " +
                             "SET n_asignacion=" + "'" + oAsignacion.N_asignacion + "'" + "," +
                             " monto=" + oAsignacion.Monto +
                             " WHERE id_asignacion=" + oAsignacion.Id_asignacion + " AND  borrado=0";

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


        internal bool Delete(Asignacion oAsignacion)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE Asignaciones " +
                             "SET borrado=1" +
                             " WHERE id_asignacion=" + oAsignacion.Id_asignacion + " AND  borrado=0";

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

        private Asignacion ObjectMapping(DataRow row)
        {
            Asignacion oAsignacion = new Asignacion
            {
                Id_asignacion = Convert.ToInt32(row["id_asignacion"].ToString()),
                Borrado = Convert.ToBoolean(row["borrado"].ToString()),
                N_asignacion = row["n_asignacion"].ToString(),
                Monto = Convert.ToDouble(row["monto"]),       
            };

            return oAsignacion;
        }

    }
}
