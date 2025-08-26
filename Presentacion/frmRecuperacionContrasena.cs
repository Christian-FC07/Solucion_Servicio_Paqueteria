using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Utilitarios;

namespace Presentacion
{
    public partial class frmRecuperacionContrasena : Form
    {
        public frmRecuperacionContrasena()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmInicioSesion frmInicioSesion = new frmInicioSesion();
            frmInicioSesion.Show();
            this.Hide();
        }

        private void btnRecuperarContrasena_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("El correo no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Usuario usuario = new Usuario();
            usuario.Correo = txtCorreo.Text;

            Usuario usuarioObtenido = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);

            if (usuarioObtenido == null)
            {
                MessageBox.Show("El correo ingresado no está registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            string contrasena = GeneradorContrasena.GenerarContrasena();
            
            usuarioObtenido.Contraseña = contrasena;
            usuarioObtenido.ContraseñaTemporal = true;
            UsuarioLN.Modificar(usuarioObtenido);
          
            EnviadorCorreo.EnviarCorreoRecuperarContrasena(usuarioObtenido.Correo, contrasena);

            MessageBox.Show("Se ha enviado un correo con la nueva contraseña", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmInicioSesion frmInicioSesion = new frmInicioSesion();
            frmInicioSesion.Show();
            this.Hide();
        }
    }
}
