using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.Entities;
using ProyectoLiquidexSA.DataAccessLayer;

namespace ProyectoLiquidexSA.BusinessLayer
{
    class EstadosAsistenciaService
    {
        private EstadosAsistenciaDao oEstadosAsistenciaDao;

        public EstadosAsistenciaService()
        {
            oEstadosAsistenciaDao = new EstadosAsistenciaDao();
        }
        public IList<EstadosAsistencia>ObtenerTodos()
        {
            return oEstadosAsistenciaDao.GetAll();
        }
    }
}