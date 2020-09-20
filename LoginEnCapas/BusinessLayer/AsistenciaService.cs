using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.Entities;
using ProyectoLiquidexSA.DataAccessLayer;


namespace ProyectoLiquidexSA.BusinessLayer
{
    public class AsistenciaService
    {
        private AsistenciaDao oAsistenciaDao;
        public AsistenciaService()
        {
            oAsistenciaDao = new AsistenciaDao();
        }
        public IList<AsistenciaUsuarios> ObtenerTodos()
        {
            return oAsistenciaDao.GetAll();
        }

        internal bool CrearAsistencia(AsistenciaUsuarios oAsistenciaUsuario)
        {
            return oAsistenciaDao.Create(oAsistenciaUsuario);
        }

        internal bool ActualizarAsistencia(AsistenciaUsuarios oAsistenciaUsuariosSelected)
        {
            return oAsistenciaDao.Update(oAsistenciaUsuariosSelected);
        }
        internal bool BorrarAsistencia(AsistenciaUsuarios oAsistenciaUsuarioSelected)
        {
            return oAsistenciaDao.Delete(oAsistenciaUsuarioSelected);
        }
        internal bool ModificarEstadoAsistencia(AsistenciaUsuarios oAsistenciaUsuarioSelected)
        {
            //throw new NotImplementedException();
            return oAsistenciaDao.Update(oAsistenciaUsuarioSelected);
        }

        internal object ObtenerAsistencia(int idUsuario, DateTime fecha)
        {
              //CON PARAMETROS
             //return oAsistenciaDao.GetAsistenciaConParametros(idUsuario, fecha);

           //SIN PARAMETROS
           return oAsistenciaDao.GetAsistenciaSinParametros(idUsuario, fecha);
        }

        internal IList<AsistenciaUsuarios> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oAsistenciaDao.GetByFiltersSinParametros(condiciones);
        }

        internal IList<AsistenciaUsuarios> ConsultarConFiltrosConParametros(Dictionary<string, object> filtros)
        {
            return oAsistenciaDao.GetByFiltersConParametros(filtros);
        }
    }
}


