using System;

namespace Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdPaquete { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public string UbicacionRecogida { get; set; }
        public string TipoEntrega { get; set; }
        public string UbicacionEntrega { get; set; }
        public bool Pagado { get; set; }

        public Pedido()
        {
            Id = 0;
            IdPaquete = 0;
            IdUsuario = 0;
            FechaCreacion = DateTime.Now;
            Estado = "Pedido generado";
            UbicacionRecogida = string.Empty;
            TipoEntrega = string.Empty;
            UbicacionEntrega = string.Empty;
            Pagado = false;
        }
    }
}