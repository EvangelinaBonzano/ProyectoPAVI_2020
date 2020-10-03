using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.Entities;
using ProyectoLiquidexSA.DataAccessLayer;

namespace ProyectoLiquidexSA.BusinessLayer
{
    public class EstadoService
    {
        private EstadoDao oEstadoDao;
        public EstadoService()
        {
            oEstadoDao = new EstadoDao();
        }
        public IList<Estado> ObtenerTodos()
        {
            return oEstadoDao.GetAll();
        }

    }
}
