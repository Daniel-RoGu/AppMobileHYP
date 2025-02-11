using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAsistencia.Models
{
    public class Usuario
    {
        [PrimaryKey]
        public string IdentificacionUsuario { get; set; }
        public string TipoDocumentoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string GeneroUsuario { get; set; }
        public string CargoUsuario { get; set; }
        public string CelularUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string EstadoEmpleado { get; set; }
        public string EPSEmpleado { get; set; }
        public string ARLEmpleado { get; set; }
        public string TipoSangreUsuario { get; set; }
        public string NumeroContactoEmergencia { get; set; }
        public string NombreContactoEmergencia { get; set; }
        public string TipoUsuario { get; set; }
        public string NumeroTarjetero { get; set; }
        public string Pass { get; set; }
        public string Empresa { get; set; }
        public string Locacion { get; set; }

    }
}
