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

        public bool CrearAsistencia(AsistenciaUsuarios oAsistenciaUsuario)
        {
            return oAsistenciaDao.Create(oAsistenciaUsuario);
        }

        public bool ActualizarAsistencia(AsistenciaUsuarios oAsistenciaUsuariosSelected)
        {
            return oAsistenciaDao.Update(oAsistenciaUsuariosSelected);
        }
        public bool BorrarAsistencia(AsistenciaUsuarios oAsistenciaUsuarioSelected)
        {
            return oAsistenciaDao.Delete(oAsistenciaUsuarioSelected);
        }
        public bool ModificarEstadoAsistencia(AsistenciaUsuarios oAsistenciaUsuarioSelected)
        {
            //throw new NotImplementedException();
            return oAsistenciaDao.Update(oAsistenciaUsuarioSelected);
        }

        public object ObtenerAsistencia(string asistencia)
        {
              //CON PARAMETROS
             return oAsistenciaDao.GetAsistenciaConParametros(asistencia);

           //SIN PARAMETROS
           //return oUsuarioDao.GetUserSinParametros(usuario);
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


