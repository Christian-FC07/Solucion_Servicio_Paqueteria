using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entidades;

namespace Utilitarios
{
    public class Validaciones
    {
        public static bool ValidarEspaciosEnBlanco(Validador P_Valor)
        {
            if (String.IsNullOrEmpty(P_Valor.Valor))
                return true;
            else
                return false;
        }

        public static bool ValidarPorExpRegular(Validador P_Valor)
        {
            Regex expresion = new Regex(P_Valor.Patron);
            MatchCollection lstCoincidencias = expresion.Matches(P_Valor.Valor);
            if (lstCoincidencias.Count > 0)
                return true;
            else
                return false;
        }
    }
}
