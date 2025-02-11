using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class ModoEmergencia
    {
        [PrimaryKey, AutoIncrement]
        public int IdHoraModoEmergencia { get; set; }
        public string HoraReporte { get; set; }
        public string EstadoHoraReporte { get; set; }
        public string AsistenciaRelacionada { get; set; } // foranea del modelo Asistencia - fecha asociada
        public string UsuarioRelacionado { get; set; } // foranea del modelo Usuario
        public string NumeroTarjeteroReporte { get; set; }
    }
}
