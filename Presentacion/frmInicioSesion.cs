using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Utilitarios;

namespace Presentacion
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            Usuario usuario = new Usuario();
            usuario.Correo = txtUsuario.Text;

            Usuario usuarioObtenido = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);

            if (!ValidarUsuario(usuarioObtenido))
            {
                return;
            }

            usuarioObtenido.BloqueadoHasta = null;
            usuarioObtenido.IntentosFallidos = 0;
            UsuarioLN.Modificar(usuarioObtenido);

            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("El correo y la contraseña no pueden estar vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!EsCorreoValido(txtUsuario.Text))
            {
                MessageBox.Show("El formato del correo no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool EsCorreoValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtUsuario.Text != usuario.Correo || txtContraseña.Text != usuario.Contraseña)
            {
                ManejarIntentoFallido(usuario);
                return false;
            }

            if (usuario.BloqueadoHasta.HasValue && usuario.BloqueadoHasta.Value > DateTime.Now)
            {
                MessageBox.Show("Su cuenta está bloqueada por exceso de intentos fallidos, inténtelo de nuevo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ConfiguracionGlobal.CorreoUsuarioActivo = usuario.Correo;

            if (usuario.FechaExpiracionContraseña < DateTime.Now)
            {
                MessageBox.Show("Por favor renueve su contraseña que expiró", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmActualizarContrasena frmActualizarContrasena = new frmActualizarContrasena();
                frmActualizarContrasena.Show();
                this.Hide();
                return false;
            }

            if (usuario.ContraseñaTemporal)
            {
                usuario.BloqueadoHasta = null;
                usuario.IntentosFallidos = 0;
                UsuarioLN.Modificar(usuario);

                MessageBox.Show("Tienes una contraseña temporal, por favor crea una nueva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmActualizarContrasena frmActualizarContrasena = new frmActualizarContrasena();
                frmActualizarContrasena.Show();
                this.Hide();
                return false;
            }

            return true;
        }

        private void ManejarIntentoFallido(Usuario usuario)
        {
            usuario.IntentosFallidos++;
            if (usuario.IntentosFallidos >= 3)
            {
                usuario.BloqueadoHasta = DateTime.Now.AddHours(3);
                MessageBox.Show("Su cuenta está bloqueada por exceso de intentos fallidos, inténtelo de nuevo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UsuarioLN.Modificar(usuario);
        }

        private void recuperarContrasenaLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperacionContrasena frmRecuperacionContrasena = new frmRecuperacionContrasena();
            frmRecuperacionContrasena.Show();
            this.Hide();
        }

        private void btnRegistrarme_Click(object sender, EventArgs e)
        {
            frmRegistro frmRegistro = new frmRegistro();
            frmRegistro.Show();
            this.Hide();
        }
    }
}
