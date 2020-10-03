using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    public class SueldoDescuentos
    {
        private int id_usuario;
        private DateTime fecha;
        
        private int cantidad;
        private double monto;
        private bool borrado;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Descuento Descuento { get; set; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Monto { get => monto; set => monto = value; }
        public bool Borrado { get => borrado; set => borrado = value; }

        public Usuario Usuario { get; set; }

        public int Id_descuento
        {
            get
            {
                return Descuento.Id_descuento;
            }
        }
        
        public string N_descuento
        {
            get 
            {
                return Descuento.N_descuento;
            }
        }

        public Double Importe
        {
            get
            {
                return Cantidad * Monto;
            }
        }

    }

}
