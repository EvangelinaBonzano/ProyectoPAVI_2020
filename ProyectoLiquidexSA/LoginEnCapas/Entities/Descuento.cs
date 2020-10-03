using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    public class Descuento
    {
        private int id_descuento;
        private string n_descuento;
        private int monto;
        private bool borrado;

        public int Id_descuento { get => id_descuento; set => id_descuento = value; }
        public string N_descuento { get => n_descuento; set => n_descuento = value; }
        public int Monto { get => monto; set => monto = value; }
        public bool Borrado { get => borrado; set => borrado = value; }


        //public override string ToString()
        //{
            
        //}
    }


}
