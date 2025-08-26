using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Historial
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }

        public Historial()
        {
            Id = 0;
            IdPedido = 0;
            Fecha = DateTime.Now;
            Accion = string.Empty;
        }
    }
}
