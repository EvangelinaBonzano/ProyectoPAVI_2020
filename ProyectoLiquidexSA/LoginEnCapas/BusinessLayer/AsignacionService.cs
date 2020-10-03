using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.Entities;
using ProyectoLiquidexSA.DataAccessLayer;

namespace ProyectoLiquidexSA.BusinessLayer
{
    public class AsignacionService
    {
        private AsignacionDao oAsignacionDao;
        public AsignacionService()
        {
            oAsignacionDao = new AsignacionDao();
        }
        public IList<Asignacion> ObtenerTodos()
        {
            return oAsignacionDao.GetAll();
        }

        internal bool CrearAsignacion(Asignacion oAsignacion)
        {
            return oAsignacionDao.Create(oAsignacion);
        }

        internal bool ActualizarAsignacion(Asignacion oAsignacionSelected)
        {
            return oAsignacionDao.Update(oAsignacionSelected);
        }
        internal bool BorrarAsignacion(Asignacion oAsignacionSelected)
        {
            return oAsignacionDao.Delete(oAsignacionSelected);
        }
        //internal bool ModificarEstadoAsistencia(AsistenciaUsuarios oAsistenciaUsuarioSelected)
        //{
        //    //throw new NotImplementedException();
        //    return oAsistenciaDao.Update(oAsistenciaUsuarioSelected);
        //}

        internal object ObtenerAsignacion(string nombreAsignacion)
        {
            //CON PARAMETROS
            //return oAsistenciaDao.GetAsistenciaConParametros(idUsuario, fecha);

            //SIN PARAMETROS
            return oAsignacionDao.GetAsignacionSinParametros(nombreAsignacion);
        }

        internal IList<Asignacion> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oAsignacionDao.GetByFiltersSinParametros(condiciones);
        }

        internal IList<Asignacion> ConsultarConFiltrosConParametros(Dictionary<string, object> filtros)
        {
            return oAsignacionDao.GetByFiltersConParametros(filtros);
        }
    }
        
}
