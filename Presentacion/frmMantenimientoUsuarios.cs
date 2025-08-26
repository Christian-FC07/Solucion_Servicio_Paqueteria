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

namespace Presentacion
{
    public partial class frmMantenimientoUsuarios : Form
    {
        private Usuario usuarioSeleccionado = new Usuario();
        private List<Usuario> usuarios;

        public frmMantenimientoUsuarios()
        {
            InitializeComponent();
            CargaCombo();
            CargarUsuarios();
        }

        private void CargaCombo()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Valor");
            dt.Columns.Add("Nombre");

            dt.Rows.Add("administrador", "Administrador");
            dt.Rows.Add("funcionario", "Funcionario");
            dt.Rows.Add("cliente", "Cliente");

            cmbRol.DataSource = dt;
            cmbRol.DisplayMember = "Nombre";
            cmbRol.ValueMember = "Valor";
            cmbRol.Refresh();
            cmbRol.SelectedIndex = 0;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarUsuarios()
        {
            usuarios = UsuarioLN.ConsultarUsuarios();

            dgvUsuarios.DataSource = usuarios;
            dgvUsuarios.Refresh();
        }

        private void Limpiar()
        {
            txtCorreo.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtNombreCompleto.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cmbRol.SelectedIndex = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (SiCamposVacios())
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarCampos())
            {
                return;
            }

            Usuario usuario = new Usuario();
            usuario.Correo = txtCorreo.Text;
            usuario.Contraseña = txtContrasena.Text;
            usuario.NombreCompleto = txtNombreCompleto.Text;
            usuario.Telefono = txtTelefono.Text;
            usuario.Rol = cmbRol.SelectedValue.ToString();
            
            if (UsuarioLN.Agregar(usuario))
            {
                MessageBox.Show("Usuario agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (SiCamposVacios())
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidarCampos())
            {
                return;
            }

            usuarioSeleccionado.Correo = txtCorreo.Text;
            usuarioSeleccionado.Contraseña = txtContrasena.Text;
            usuarioSeleccionado.NombreCompleto = txtNombreCompleto.Text;
            usuarioSeleccionado.Telefono = txtTelefono.Text;
            usuarioSeleccionado.Rol = cmbRol.SelectedValue.ToString();

            if (UsuarioLN.Modificar(usuarioSeleccionado))
            {
                MessageBox.Show("Usuario modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (SiCamposVacios())
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usuarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            usuarioSeleccionado.Correo = txtCorreo.Text;
            if (UsuarioLN.Eliminar(usuarioSeleccionado))
            {
                MessageBox.Show("Usuario eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool SiCamposVacios()
        {
            string correo = txtCorreo.Text;
            string contrasena = txtContrasena.Text;
            string nombreCompleto = txtNombreCompleto.Text;
            string telefono = txtTelefono.Text;

            return correo.Equals(string.Empty) || contrasena.Equals(string.Empty) || nombreCompleto.Equals(string.Empty) || telefono.Equals(string.Empty);
        }

        public bool ValidarCampos()
        {
            string correo = txtCorreo.Text;
            string nombreCompleto = txtNombreCompleto.Text;
            string telefono = txtTelefono.Text;
            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("El correo no tiene un formato adecuado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!EsNombreCompletoValido(nombreCompleto))
            {
                MessageBox.Show("El nombre completo solo puede contener letras y espacios en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!EsTelefonoValido(telefono))
            {
                MessageBox.Show("El teléfono solo puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool EsNombreCompletoValido(string nombreCompleto)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(nombreCompleto, @"^[a-zA-Z\s]+$");
        }

        private bool EsTelefonoValido(string telefono)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d+$");
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCorreo.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtContrasena.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNombreCompleto.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTelefono.Text = dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbRol.SelectedValue = dgvUsuarios.Rows[e.RowIndex].Cells[9].Value.ToString();

                int id = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value);
                usuarioSeleccionado = ObtenerUsuario(id);
            }
            catch
            {
            }
        }

        private Usuario ObtenerUsuario(int id)
        {
            return usuarios.Find(x => x.Id == id);
        }
    }
}
