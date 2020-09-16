using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLiquidexSA.Entities
{
    public class AsistenciaUsuarios
    {
        private int id_usuario;
        private DateTime fecha;
        private DateTime hora_ingreso;
        private DateTime hora_salida;
        private int id_estado_asistencia;
        private string comentario;
        private bool borrado;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Hora_ingreso { get => hora_ingreso; set => hora_ingreso = value; }
        public DateTime Hora_salida { get => hora_salida; set => hora_salida = value; }
        public int Id_estado_asistencia { get => id_estado_asistencia; set => id_estado_asistencia = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public bool Borrado { get => borrado; set => borrado = value; }
        public Usuario Usuario { get; internal set; }
        public EstadosAsistencia EstadosAsistencia { get; set; }

        public override string ToString()
        {
            return Usuario.NombreUsuario;
        }
    }

    
}
