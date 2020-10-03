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
    public class DescuentoDao
    {
        public IList<Descuento> GetAll()
        {
            List<Descuento> listadoDescuento = new List<Descuento>();

            var strSql = " SELECT * FROM Descuentos " +
                         " WHERE borrado=0 ";

            //var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);
            DataManager dm = new DataManager();
            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);


            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoDescuento.Add(ObjectMapping(row));
            }

            return listadoDescuento;
        }

     


        public Descuento GetDescuentoSinParametros(string nDescuento)
        {
            //Construimos la consulta sql para buscar el descuento en la base de datos.
            String strSql = string.Concat(" SELECT * FROM Descuentos d ",
                                              "  WHERE d.borrado=0 ");

            
            strSql += " AND d.n_descuento=" + "'" + nDescuento + "'";

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


        public IList<Descuento> GetByFiltersConParametros(Dictionary<string, object> parametros)
        {

            List<Descuento> lst = new List<Descuento>();
            String strSql = string.Concat(" SELECT * FROM Descuentos d ",
                                              "  WHERE d.borrado=0 ");


            if (parametros.ContainsKey("id_descuento"))
                strSql += " AND (id_descuento = @id_descuento) ";


            if (parametros.ContainsKey("n_descuento"))
                strSql += " AND (d.n_descuento LIKE '%' + @n_descuento + '%') ";

            //var resultado = DBHelper.GetDBHelper().ConsultaSQLConParametros(strSql, parametros);
            DataManager dm = new DataManager();
            dm.Open();
            var resultado = dm.ConsultaSQLConParametros(strSql, parametros);

            foreach (DataRow row in resultado.Rows)
                lst.Add(ObjectMapping(row));

            return lst;
        }


        public IList<Descuento> GetByFiltersSinParametros(String condiciones)
        {

            List<Descuento> lstDescuento = new List<Descuento>();
            String strSql = string.Concat(" SELECT * FROM Descuentos d ",
                                              "  WHERE d.borrado=0 ");
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
                lstDescuento.Add(ObjectMapping(row));

            return lstDescuento;
        }

        internal bool Create(Descuento oDescuento)
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

                string str_sql = "INSERT INTO Descuentos (n_descuento, monto, borrado)" +
                            " VALUES (" +
                            
                            "'" + oDescuento.N_descuento + "'" + "," +
                            "'" + oDescuento.Monto + "'" + "," + "0)";


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

        internal bool Update(Descuento oDescuento)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE Descuentos " +
                             "SET monto= " + "'" + oDescuento.Monto + "'" +
                             " WHERE id_descuento=" + oDescuento.Id_descuento +
                             " AND  n_descuento='" + oDescuento.N_descuento + "'" +
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


        internal bool Delete(Descuento oDescuento)
        {
            //SIN PARAMETROS
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();
                string str_sql = "UPDATE Descuentos " +
                             "SET borrado= 1" +
                             " WHERE n_descuento='" + oDescuento.N_descuento + "'" +
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

        private Descuento ObjectMapping(DataRow row)
        {
            Descuento oDescuento = new Descuento
            {
                Id_descuento = Convert.ToInt32(row["id_descuento"].ToString()),
                N_descuento = row["n_descuento"].ToString(),
                Monto = Convert.ToInt32(row["monto"].ToString()),
                Borrado = Convert.ToBoolean(row["borrado"].ToString())

            };

            return oDescuento;
        }
    }
}
  