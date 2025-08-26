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
    public partial class frmActualizarContrasena : Form
    {
        public frmActualizarContrasena()
        {
            InitializeComponent();
        }

        private void btnModificarContrasena_Click(object sender, EventArgs e)
        {
            string contrasenaAntigua = txtContrasenaAntigua.Text;
            string contrasenaNueva = txtContrasenaNueva.Text;
            string confirmarContrasena = txtConfirmarContrasena.Text;

            
            if (string.IsNullOrEmpty(contrasenaAntigua)
                || string.IsNullOrEmpty(contrasenaNueva)
                || string.IsNullOrEmpty(confirmarContrasena))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Usuario usuario = new Usuario();
            usuario.Correo = ConfiguracionGlobal.CorreoUsuarioActivo;
            
            Usuario usuarioObtenido = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);

            
            if (usuarioObtenido == null || contrasenaAntigua != usuarioObtenido.Contraseña)
            {
                MessageBox.Show("La contraseña antigua no es correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (contrasenaNueva != confirmarContrasena)
            {
                MessageBox.Show("La nueva contraseña y la confirmación no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            usuarioObtenido.Contraseña = contrasenaNueva;
            usuarioObtenido.ContraseñaTemporal = false;
            usuarioObtenido.FechaExpiracionContraseña = DateTime.Now.AddHours(3);
            UsuarioLN.Modificar(usuarioObtenido);

            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
            this.Hide();
        }
    }
}
