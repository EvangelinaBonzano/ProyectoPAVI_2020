using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLiquidexSA.Entities;
using ProyectoLiquidexSA.DataAccessLayer;

namespace ProyectoLiquidexSA.BusinessLayer
{
    public class PerfilService
    {
        private PerfilDao oPerfilDao;
        public PerfilService()
        {
            oPerfilDao = new PerfilDao();
        }
        public IList<Perfil> ObtenerTodos()
        {
            return oPerfilDao.GetAll();
        }        
    }
}
