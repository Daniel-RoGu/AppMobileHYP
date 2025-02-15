using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class Locacion
    {
        [PrimaryKey, AutoIncrement]
        public int IdLocacion { get; set; }
        public string NombreLocacion { get; set; }
        public string RIG { get; set; }
        public string NombrePozo { get; set; }
        public string EstadoLocacion { get; set; }
    }
}
