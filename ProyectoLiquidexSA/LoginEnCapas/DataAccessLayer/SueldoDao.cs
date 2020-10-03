using ProyectoLiquidexSA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoLiquidexSA.DataAccessLayer
{
    class SueldoDao
    {
        internal bool Create(Sueldos sueldo)
        {
            DataManager dm = new DataManager();
            try
            {
                dm.Open();
                dm.BeginTransaction();

                string sql = string.Concat("INSERT INTO Sueldos ",
                                            "           (id_usuario   ",
                                            "           ,fecha         ",
                                            "           ,sueldo_bruto       ",
                                            "           ,borrado)      ",
                                            "     VALUES                 ",
                                            "           (@id_usuario   ",
                                            "           ,@fecha          ",
                                            "           ,@sueldo_bruto      ",
                                            "           ,@borrado)       ");


                var parametros = new Dictionary<string, object>();
                parametros.Add("id_usuario", sueldo.Usuario.IdUsuario);
                parametros.Add("fecha", sueldo.Fecha);
                parametros.Add("sueldo_bruto", sueldo.Sueldo_bruto);
                parametros.Add("borrado", false);
                dm.EjecutarSQLConParametros(sql, parametros);


                foreach (var itemSueldo in sueldo.SueldoAsignaciones)
                {
                    string sqlDetalle = string.Concat(" INSERT INTO SueldoAsignaciones ",
                                                        "           (id_usuario          ",
                                                        "           ,fecha          ",
                                                        "           ,id_asignacion      ",
                                                         "          ,monto      ",
                                                        "           ,cantidad             ",
                                                        "           ,borrado)             ",
                                                        "     VALUES                        ",
                                                        "           (@id_usuario           ",
                                                        "           ,@fecha           ",
                                                        "           ,@id_asignacion      ",
                                                        "           ,@monto     ",
                                                        "           ,@cantidad              ",
                                                        "           ,@borrado)               ");

                    var paramDetalle = new Dictionary<string, object>();
                    paramDetalle.Add("id_usuario", sueldo.Usuario.IdUsuario);
                    paramDetalle.Add("fecha", itemSueldo.Fecha);
                    paramDetalle.Add("id_asignacion", itemSueldo.Id_asignacion);
                    paramDetalle.Add("monto", itemSueldo.Monto);
                    paramDetalle.Add("cantidad", itemSueldo.Cantidad);
                    paramDetalle.Add("borrado", false);

                    dm.EjecutarSQLConParametros(sqlDetalle, paramDetalle);
                }

                foreach (var itemSueldo in sueldo.SueldoDescuentos)
                {
                    string sqlDetalle = string.Concat(" INSERT INTO SueldoDescuentos ",
                                                        "           (id_usuario          ",
                                                        "           ,fecha          ",
                                                        "           ,id_descuento      ",
                                                         "          ,cantidad      ",
                                                        "           ,monto             ",
                                                        "           ,borrado)             ",
                                                        "     VALUES                        ",
                                                        "           (@id_usuario           ",
                                                        "           ,@fecha           ",
                                                        "           ,@id_descuento      ",
                                                        "           ,@cantidad     ",
                                                        "           ,@monto              ",
                                                        "           ,@borrado)               ");

                    var paramDetalle = new Dictionary<string, object>();
                    paramDetalle.Add("id_usuario", sueldo.Usuario.IdUsuario);
                    paramDetalle.Add("fecha", itemSueldo.Fecha);
                    paramDetalle.Add("id_descuento", itemSueldo.Id_descuento);
                    paramDetalle.Add("cantidad", itemSueldo.Cantidad);
                    paramDetalle.Add("monto", itemSueldo.Monto);
                    paramDetalle.Add("borrado", false);

                    dm.EjecutarSQLConParametros(sqlDetalle, paramDetalle);
                }



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
    }
}

