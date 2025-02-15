using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class Hora
    {
        [PrimaryKey, AutoIncrement]
        public int IdHora { get; set; }
        public string HoraLlegada { get; set; }
        public string HoraSalida { get; set; }
        public string EstadoHora { get; set; }
        public string AsistenciaRelacionada { get; set; } // foranea del modelo Asistencia - fecha asociada
        public string UsuarioRelacionado { get; set; } // foranea del modelo Usuario

    }
}
