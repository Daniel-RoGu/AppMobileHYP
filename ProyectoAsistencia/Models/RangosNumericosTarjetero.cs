using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class RangosNumericosTarjetero
    {
        [PrimaryKey, AutoIncrement]
        public int idRangoTarjetero { get; set; }
        public string TipoRangoTarjetero { get; set;}
        public int RangoSuperior { get; set; }
        public int RangoInferior { get; set; }
        public string EstadoRango { get; set; }

    }
}
