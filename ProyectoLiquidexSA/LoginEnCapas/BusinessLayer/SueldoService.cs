using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.DataAccessLayer;
using ProyectoLiquidexSA.Entities;

namespace ProyectoLiquidexSA.BusinessLayer
{
    class SueldoService
    {
        private SueldoDao oSueldoDao;
        public SueldoService()
        {
            oSueldoDao = new SueldoDao();
        }

        internal bool Crear(Sueldos sueldo)
        {
            return oSueldoDao.Create(sueldo);
        }

        internal bool ValidarDatos(Sueldos sueldo)
        {
            if (sueldo.SueldoAsignaciones.Count == 0)
            {
                throw new Exception("Debe ingresar al menos un item de sueldo.");
            }

            return true;
        }
    }
}
