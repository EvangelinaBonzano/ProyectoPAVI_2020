using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    public class SueldoAsignaciones
    {
     
            private int id_usuario;
            private DateTime fecha;
            
            private int cantidad;
            private double monto;
            private bool borrado;

            public int Id_usuario { get => id_usuario; set => id_usuario = value; }
            public DateTime Fecha { get => fecha; set => fecha = value; }
            public Asignacion Asignacion { get; set; }
            public int Cantidad { get => cantidad; set => cantidad = value; }
            public double Monto { get => monto; set => monto = value; }
            public bool Borrado { get => borrado; set => borrado = value; }

            public int Id_asignacion
            {
                get
                {
                    return Asignacion.Id_asignacion;
                }
            }

            public string N_asignacion
            {
                get
                {
                    return Asignacion.N_asignacion;
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


