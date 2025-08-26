using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class GeneradorContrasena
    {
        public static string GenerarContrasena()
        {
            string minusculas = "abcdefghijklmnopqrstuvwxyz";
            string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "1234567890";
            string especiales = "!@#$%^&*()_+[]{}|;:,.<>?";

            Random random = new Random();

            char[] contrasena = new char[8];
            contrasena[0] = minusculas[random.Next(minusculas.Length)];
            contrasena[1] = mayusculas[random.Next(mayusculas.Length)];
            contrasena[2] = numeros[random.Next(numeros.Length)];
            contrasena[3] = especiales[random.Next(especiales.Length)];

            string todosCaracteres = minusculas + mayusculas + numeros + especiales;
            for (int i = 4; i < contrasena.Length; i++)
            {
                contrasena[i] = todosCaracteres[random.Next(todosCaracteres.Length)];
            }

            contrasena = contrasena.OrderBy(x => random.Next()).ToArray();

            return new string(contrasena);
        }
    }
}
