using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class TipoDocumento
    {
        [PrimaryKey, AutoIncrement]
        public int IdTipoDocumento { get; set; }
        public string _tipoDocumento { get; set; }
        public string EstadoTipoDocumento { get; set; }
    }
}
