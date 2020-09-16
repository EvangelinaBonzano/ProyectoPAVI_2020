using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    public class EstadosAsistencia
    {
        private int id_estado_asistencia;
        private string n_estados_asistencia;
        private bool borrado;

        public int Id_estado_asistencia { get => id_estado_asistencia; set => id_estado_asistencia = value; }
        public string N_estados_asistencia { get => n_estados_asistencia; set => n_estados_asistencia = value; }
        public bool Borrado { get => borrado; set => borrado = value; }

        public override string ToString()
        {
            return N_estados_asistencia; 
        }
    }
}
