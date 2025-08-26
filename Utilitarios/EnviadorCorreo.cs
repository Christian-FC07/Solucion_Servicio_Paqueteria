using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace Utilitarios
{
    public class EnviadorCorreo
    {
        public static void EnviarCorreoRecuperarContrasena(string correoUsuario, string contrasenaNueva)
        {
            var correoAplicacion = ConfigurationManager.AppSettings["nombreUsuarioCorreo"].ToString();
            var contrasenaCorreoAplicacion = ConfigurationManager.AppSettings["contrasenaCorreo"].ToString();
            var correo = new MailMessage();
            correo.From = new MailAddress(correoAplicacion);
            correo.To.Add(correoUsuario);
            correo.Subject = "Se hizo una solicitud de recuperación de contraseña";
            correo.Body = "Esta es tu nueva contraseña para que inicies sesión: " + contrasenaNueva;
            correo.IsBodyHtml = false;

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(correoAplicacion, contrasenaCorreoAplicacion);
                smtp.EnableSsl = true;
                smtp.Send(correo);
            }
        }
    }
}
