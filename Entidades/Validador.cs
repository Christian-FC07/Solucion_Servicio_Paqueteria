using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Validador
    {
        public string Valor { get; set; }
        public string Patron { get; set; }

       // Constructor

        public Validador()
        {
            Valor = string.Empty;
            Patron = string.Empty;
        }
    }
}
