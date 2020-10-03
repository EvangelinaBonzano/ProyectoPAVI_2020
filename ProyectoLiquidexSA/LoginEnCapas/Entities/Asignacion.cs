using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    public class Asignacion
    {
        private int id_asignacion;
        private string n_asignacion;
        private double monto;
        private bool borrado;

        public int Id_asignacion { get => id_asignacion; set => id_asignacion = value; }
        public string N_asignacion { get => n_asignacion; set => n_asignacion = value; }
        public double Monto { get => monto; set => monto = value; }
        public bool Borrado { get => borrado; set => borrado = value; }

        public override string ToString()
        {
            return N_asignacion;
        }
    }
}
