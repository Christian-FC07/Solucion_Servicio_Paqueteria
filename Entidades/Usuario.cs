using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public int IntentosFallidos { get; set; }
        public DateTime? BloqueadoHasta { get; set; }
        public DateTime FechaExpiracionContraseña { get; set; }
        public bool ContraseñaTemporal { get; set; }

        public string Rol { get; set; }

        public Usuario()
        {
            Id = 0;
            Correo = string.Empty;
            Contraseña = string.Empty;
            NombreCompleto = string.Empty;
            Telefono = string.Empty;
            IntentosFallidos = 0;
            BloqueadoHasta = null;
            FechaExpiracionContraseña = DateTime.Now.AddHours(3);
            ContraseñaTemporal = false;
            Rol = "cliente";
        }
    }
}