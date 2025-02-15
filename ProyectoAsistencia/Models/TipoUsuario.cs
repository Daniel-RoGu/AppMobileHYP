using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class TipoUsuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdTipoUsuario { get; set; }
        public string _TipoUsuario { get; set; }
        public string EstadoTipoUsuario { get; set; }

    }
}
