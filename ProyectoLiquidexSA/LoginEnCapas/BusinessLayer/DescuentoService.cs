using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.Entities;
using ProyectoLiquidexSA.DataAccessLayer;

namespace ProyectoLiquidexSA.BusinessLayer
{
    public class DescuentoService
    {
        private DescuentoDao oDescuentoDao;
        public DescuentoService()
        {
            oDescuentoDao = new DescuentoDao();
        }
        public IList<Descuento> ObtenerTodos()
        {
            return oDescuentoDao.GetAll();
        }

        internal bool CrearDescuento(Descuento oDescuento)
        {
            return oDescuentoDao.Create(oDescuento);
        }

        internal bool ActualizarDescuento(Descuento oDescuentoSelected)
        {
            return oDescuentoDao.Update(oDescuentoSelected);
        }
        internal bool BorrarDescuento(Descuento oDescuentoSelected)
        {
            return oDescuentoDao.Delete(oDescuentoSelected);
        }
        internal bool ModificarDescuento(Descuento oDescuentoSelected)
        {
            //throw new NotImplementedException();
            return oDescuentoDao.Update(oDescuentoSelected);
            
        }

        internal object ObtenerDescuento(string nDescuento)
        {
            //CON PARAMETROS
            //return oAsistenciaDao.GetAsistenciaConParametros(idUsuario, fecha);

            //SIN PARAMETROS
            return oDescuentoDao.GetDescuentoSinParametros(nDescuento);
        }

        internal IList<Descuento> ConsultarConFiltrosSinParametros(String condiciones)
        {
            return oDescuentoDao.GetByFiltersSinParametros(condiciones);
        }

        internal IList<Descuento> ConsultarConFiltrosConParametros(Dictionary<string, object> filtros)
        {
            return oDescuentoDao.GetByFiltersConParametros(filtros);
        }
    }
}
