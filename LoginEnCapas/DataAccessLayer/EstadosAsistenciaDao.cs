using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.Entities;
using System.Data;

namespace ProyectoLiquidexSA.DataAccessLayer
{
    class EstadosAsistenciaDao
    {
        public IList<EstadosAsistencia> GetAll()
            {
                List<EstadosAsistencia> listadoAsistencia = new List<EstadosAsistencia>();

                var strSql = "SELECT * From EstadosAsistencia";

                var resultadoConsulta = DBHelper.GetDBHelper().ConsultaSQL(strSql);

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    listadoAsistencia.Add(ObjectMapping(row));
                }

                return listadoAsistencia;
            }

            private EstadosAsistencia ObjectMapping(DataRow row)
            {
                EstadosAsistencia oEstadosAsistencia = new EstadosAsistencia
                {
                    Id_estado_asistencia = Convert.ToInt32(row["id_estado_asistencia"].ToString()),
                    N_estados_asistencia = row["n_estados_asistencia"].ToString(),
                    Borrado = Convert.ToBoolean(row["borrado"].ToString()),
                    

                };

                return oEstadosAsistencia;
            }
        }
}
