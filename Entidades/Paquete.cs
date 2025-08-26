using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete
    {
        public int Id {  get; set; }
        public int IdUsuario { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }
        public double Peso { get; set; }

        public Paquete()
        {
            Id = 0;
            IdUsuario = 0;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            Valor = 0.0;
            Peso = 0.0;
        }

    }
}
