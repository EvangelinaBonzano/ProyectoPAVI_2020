using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    public class Usuario
    {
        private int id_usuario;
        private int id_perfil;
        private string usuario;
        private string password;
        private string email;
        private string estado;
        private bool borrado;

        public Perfil Perfil { get; set; }
        public int IdUsuario { get => id_usuario; set => id_usuario = value; }
        public string NombreUsuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Estado { get => estado; set => estado = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        public int Id_perfil { get => id_perfil; set => id_perfil = value; }

        public override string ToString()
        {
            return NombreUsuario;
            
        }
    }
}
