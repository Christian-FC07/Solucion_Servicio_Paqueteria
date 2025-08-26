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
using Utilitarios;

namespace Presentacion
{
    public partial class frmMantenimientoPaquetes : Form
    {
        public Paquete paqueteSeleccionado = new Paquete();
        public List<Paquete> paquetes;
        public Usuario usuarioActivo;

        public frmMantenimientoPaquetes()
        {
            Usuario usuario = new Usuario();
            usuario.Correo = ConfiguracionGlobal.CorreoUsuarioActivo;
            usuarioActivo = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);
            InitializeComponent();
            CargarPaquetes();
        }

        private void CargarPaquetes()
        {
            paquetes = UsuarioLN.ConsultarPaquetesPorUsuario(usuarioActivo);

            dgvPaquetes.DataSource = null;
            dgvPaquetes.Rows.Clear();
            dgvPaquetes.Columns.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Dueño", typeof(string));
            dt.Columns.Add("Codigo", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Valor", typeof(double));
            dt.Columns.Add("Peso", typeof(double));

            foreach (var p in paquetes)
            {
                DataRow row = dt.NewRow();
                row["Id"] = p.Id;
                row["Dueño"] = usuarioActivo.NombreCompleto;
                row["Codigo"] = p.Codigo;
                row["Descripcion"] = p.Descripcion;
                row["Valor"] = p.Valor;
                row["Peso"] = p.Peso;
                dt.Rows.Add(row);
            }

            dgvPaquetes.DataSource = dt;
            dgvPaquetes.Refresh();
        }

        private void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            numValor.Value = 0.00M;
            numPeso.Value = 0.00M;
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

            Paquete paquete = new Paquete();
            paquete.IdUsuario = usuarioActivo.Id;
            paquete.Codigo = txtCodigo.Text;
            paquete.Descripcion = txtDescripcion.Text;
            paquete.Valor = (double)numValor.Value;
            paquete.Peso = (double)numPeso.Value;

            if (UsuarioLN.Agregar(paquete))
            {
                MessageBox.Show("Paquete agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarPaquetes();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (SiCamposVacios())
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            paqueteSeleccionado.IdUsuario = usuarioActivo.Id;
            paqueteSeleccionado.Codigo = txtCodigo.Text;
            paqueteSeleccionado.Descripcion = txtDescripcion.Text;
            paqueteSeleccionado.Valor = (double)numValor.Value;
            paqueteSeleccionado.Peso = (double)numPeso.Value;

            if (UsuarioLN.Modificar(paqueteSeleccionado))
            {
                MessageBox.Show("Paquete modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarPaquetes();
            }
            else
            {
                MessageBox.Show("No se pudo modificar el paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (SiCamposVacios())
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsuarioLN.Eliminar(paqueteSeleccionado))
            {
                MessageBox.Show("Paquete eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                CargarPaquetes();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool SiCamposVacios()
        {
            string codigo = txtCodigo.Text;
            string descripcion = txtDescripcion.Text;
            decimal valor = numValor.Value;
            decimal peso = numPeso.Value;

            return codigo.Equals(string.Empty) || descripcion.Equals(string.Empty) || valor == 0.00M || peso == 0.00M;
        }

        private void dgvPaquetes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodigo.Text = dgvPaquetes.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDescripcion.Text = dgvPaquetes.Rows[e.RowIndex].Cells[3].Value.ToString();
                numValor.Text = dgvPaquetes.Rows[e.RowIndex].Cells[4].Value.ToString();
                numPeso.Text = dgvPaquetes.Rows[e.RowIndex].Cells[5].Value.ToString();

                int id = Convert.ToInt32(dgvPaquetes.Rows[e.RowIndex].Cells[0].Value);
                paqueteSeleccionado = ObtenerPaquete(id);
            }
            catch
            {
            }
        }

        private Paquete ObtenerPaquete(int id)
        {
            return paquetes.Find(x => x.Id == id);
        }
    }
}
