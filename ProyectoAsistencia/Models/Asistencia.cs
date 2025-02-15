using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class Asistencia
    {
        [PrimaryKey, AutoIncrement]
        public int IdAsistencia { get; set; }
        public string FechaSincronizacion { get; set; }
        public string FechaAsistencia { get; set; }
        public string EstadoAsistencia { get; set; }
        
    }
}
