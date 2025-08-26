using Entidades;
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

namespace Presentacion
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmInicioSesion frmInicioSesion = new frmInicioSesion();
            frmInicioSesion.Show();
            this.Hide();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;
            string nombreCompleto = txtNombreCompleto.Text;
            string telefono = txtTelefono.Text;

            
            if (!TodosLosCamposLlenos(correo, contrasena, nombreCompleto, telefono))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("El correo no tiene un formato adecuado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!EsNombreCompletoValido(nombreCompleto))
            {
                MessageBox.Show("El nombre completo solo puede contener letras y espacios en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!EsTelefonoValido(telefono))
            {
                MessageBox.Show("El teléfono solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            Usuario usuario = new Usuario();
            usuario.Correo = correo;
            usuario.Contraseña = contrasena;
            usuario.NombreCompleto = nombreCompleto;
            usuario.Telefono = telefono;
            usuario.Rol = "cliente";

            if (UsuarioLN.Agregar(usuario))
            {
                MessageBox.Show("Se ha registrado de forma satisfactoria", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmInicioSesion frmInicioSesion = new frmInicioSesion();
                frmInicioSesion.Show();
                this.Hide();
            } else
            {
                MessageBox.Show("Se ha presentado un inconveniente al registrar el usuario, comunicarse con el administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private bool EsNombreCompletoValido(string nombreCompleto)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(nombreCompleto, @"^[a-zA-Z\s]+$");
        }

        private bool EsTelefonoValido(string telefono)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d+$");
        }

        private bool TodosLosCamposLlenos(params string[] campos)
        {
            foreach (var campo in campos)
            {
                if (string.IsNullOrEmpty(campo))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
