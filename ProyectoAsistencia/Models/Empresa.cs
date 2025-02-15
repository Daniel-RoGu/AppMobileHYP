using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class Empresa
    {
        [PrimaryKey, AutoIncrement]
        public int idEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string NITEmpresa { get; set; }
        public string LogoEmpresa { get; set; }
        public string EstadoEmpresa { get; set; }
    }
}
