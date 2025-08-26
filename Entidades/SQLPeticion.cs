using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SQLPeticion
    {
        public string Peticion { get; set; }
        public List<SqlParameter> ListaParametros { get; set; }

        public SQLPeticion()
        {
            Peticion = string.Empty;
            ListaParametros = new List<SqlParameter>();
        }
    }
}
