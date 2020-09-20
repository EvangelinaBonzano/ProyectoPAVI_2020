using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoLiquidexSA.Entities
{
    public class Perfil
    {
        private int id_perfil;
        private string nombre;
        private bool borrado;

        public int IdPerfil { get => id_perfil; set => id_perfil = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Borrado { get => borrado; set => borrado = value; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
