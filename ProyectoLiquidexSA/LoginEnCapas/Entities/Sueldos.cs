using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    class Sueldos
    {
        private int id_usuario;
        private DateTime fecha;
        private double sueldo_bruto;
        private bool borrado;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Sueldo_bruto { get => sueldo_bruto; set => sueldo_bruto = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        public IList<SueldoDescuentos> SueldoDescuentos { get; set; }
        public IList<SueldoAsignaciones> SueldoAsignaciones { get; set; }

        public Usuario Usuario { get; set; }

        
    }
    
}
