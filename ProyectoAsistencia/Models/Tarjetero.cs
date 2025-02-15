using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class Tarjetero
    {
        [PrimaryKey, AutoIncrement]
        public int IdTarjetero { get; set; }
        public int NumeroEnTarjetero { get; set; }
        public string EstadoNumero { get; set; }
        public string RangoPertenencia { get; set; } //Hace relacion a si el rango corresponde a un empleado o visitante
        public string EmpresaAsociada { get; set; } //Hace relacion a la empresa a la que se le asocio el numero
        public string LocacionAsociada { get; set; } //Hace relacion a la Locacion donde se despliega el tarjetero

    }
}
