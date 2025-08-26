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
    public partial class frmGenerarPedido : Form
    {
        private ComboBox cmbSucursales;
        private TextBox txtUbicacionEntrega;

        private Usuario usuarioActivo;
        private List<Paquete> paquetes;

        private List<Pedido> pedidos;

        private Pedido pedidoSeleccionado = null;

        public frmGenerarPedido()
        {
            Usuario usuario = new Usuario();
            usuario.Correo = ConfiguracionGlobal.CorreoUsuarioActivo;
            usuarioActivo = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);
            InitializeComponent();
            CargarCombo();
            CargarPedidos();
        }

        public void CargarCombo()
        {
            paquetes = UsuarioLN.ConsultarPaquetesPorUsuario(usuarioActivo);

            Paquete paquete = new Paquete();
            paquete.Descripcion = "Seleccione un paquete";

            paquetes.Add(paquete);
            cmbPaquetes.DataSource = paquetes;
            cmbPaquetes.DisplayMember = "Descripcion";
            cmbPaquetes.ValueMember = "Descripcion";
            cmbPaquetes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaquetes.Refresh();
            cmbPaquetes.SelectedIndex = paquetes.Count - 1;
        }

        public void CargarPedidos()
        {
            pedidos = UsuarioLN.ConsultarPedidosPorUsuario(usuarioActivo);

            dgvPedidos.DataSource = null;
            dgvPedidos.Rows.Clear();
            dgvPedidos.Columns.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Descripcion Paquete", typeof(string));
            dt.Columns.Add("Fecha Creación", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Ubicación Recogida", typeof(string));
            dt.Columns.Add("Tipo Entrega", typeof(string));
            dt.Columns.Add("Ubicación Entrega", typeof(string));
            dt.Columns.Add("Pagado", typeof(string));

            foreach (var p in pedidos)
            {
                DataRow row = dt.NewRow();
                row["Id"] = p.Id;
                row["Descripcion Paquete"] = ObtenerPaquete(p.IdPaquete).Descripcion;
                row["Fecha Creación"] = p.FechaCreacion.ToString("dd/MM/yyyy");
                row["Estado"] = p.Estado;
                row["Ubicación Recogida"] = p.UbicacionRecogida;
                row["Tipo Entrega"] = p.TipoEntrega;
                row["Ubicación Entrega"] = p.UbicacionEntrega;
                row["Pagado"] = p.Pagado ? "Si" : "No";
                dt.Rows.Add(row);
            }

            dgvPedidos.DataSource = dt;
            dgvPedidos.Refresh();
        }

        private void cbEntregaSucursal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEntregaSucursal.Checked)
            {
                cbEntregaDomicilio.Checked = false;
                GenerarComboBoxSucursales();
                EliminarTextBoxDireccionDomicilio();
            }
            else
            {
                EliminarComboBoxSucursales();
            }
        }

        private void cbEntregaDomicilio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEntregaDomicilio.Checked)
            {
                cbEntregaSucursal.Checked = false;
                GenerarTextBoxDireccionDomicilio();
                EliminarComboBoxSucursales();
            }
            else
            {
                EliminarTextBoxDireccionDomicilio();
            }
        }

        private void GenerarComboBoxSucursales()
        {
            if (cmbSucursales == null)
            {
                cmbSucursales = new ComboBox
                {
                    Location = new System.Drawing.Point(cbEntregaSucursal.Location.X, cbEntregaSucursal.Location.Y + cbEntregaSucursal.Height + 10),
                    Width = 500
                };

                List<string> sucursales = new List<string> {
                    "Sucursal Acosta - 50 metros norte del Parque Monseñor Sanabria, frente a CoopeAlianza.",
                    "Sucursal Alajuelita - De la iglesia Católica 25 metros al sur",
                    "Sucursal Aserrí - Costado norte del Parque en el Centro Comercial Corazón de Jesús 2 piso",
                    "Sucursal Barrio Mexico - De la esquina noreste del parque 50 metros norte y de 25 metros este",
                    "Sucursal Calle Blancos - 25 metros este, 75 metros norte y de 25 metros este, de la Iglesia de ladrillos.",
                    "Sucursal Centro Colon - Centro Colón, Costado este del edificio Centro Colón",
                    "Sucursal Ciudad Colon - Costado norte de la Casa Cural",
                    "Sucursal Coronado - 200 metros norte y de 50 metros oeste de la Iglesia Católica",
                    "Sucursal Correo Central - Central Frente Club Unión",
                    "Sucursal Curridabat - 300 metros oeste de la esquina suroeste de Iglesia Católica.",
                    "Sucursal Desamparados - 100 metros sur de la Estación de Bomberos.",
                    "Sucursal Escazu - 50 metros norte del Centro Comercial Plaza Real",
                    "Sucursal Guadalupe - 100 metros oeste de la Iglesia Católica.",
                    "Sucursal Hatillo - Hatillo 6, Centro Comercial Hatillo.",
                    "Sucursal La Y Griega - Frente Centro Comercial del Sur",
                    "Sucursal La Corte - Edificio Corte Suprema de Justicia",
                    "Sucursal León Cortés - Contiguo a la Guardia Civil",
                    "Sucursal Moravia - Costado oeste del Parque",
                    "Sucursal Pavas - Pavas en Centro Comercial Plaza Rohrmoser, locales 43 y 44",
                    "Sucursal Pérez Zeledón - Contiguo a Megasuper",
                    "Sucursal Puriscal - 150 metros oeste del Parque Central",
                    "Sucursal Sabanilla - Costado oeste del Parque",
                    "Sucursal San Marcos De Tarrazú - Contiguo a la Municipalidad",
                    "Sucursal San Pedro Montes De Oca - De la Iglesia católica, 150 metros al sur",
                    "Sucursal San Sebastián - De la Iglesia católica, 400 metros norte",
                    "Sucursal Santa Ana - Contiguo a la Municipalidad",
                    "Sucursal Tibas - 50 metros al sur del salón Parroquial",
                    "Sucursal Zapote - De la Iglesia de Zapote 200 metros al Sur",
                    "Seleccione una sucursal"
                };
                cmbSucursales.DataSource = sucursales;
                cmbSucursales.DropDownStyle = ComboBoxStyle.DropDownList;
                this.Controls.Add(cmbSucursales);
                cmbSucursales.Refresh();
                cmbSucursales.SelectedIndex = sucursales.Count - 1;
            }
        }

        private void EliminarComboBoxSucursales()
        {
            if (cmbSucursales != null)
            {
                this.Controls.Remove(cmbSucursales);
                cmbSucursales.Dispose();
                cmbSucursales = null;
            }
        }

        private void GenerarTextBoxDireccionDomicilio()
        {
            if (txtUbicacionEntrega == null)
            {
                txtUbicacionEntrega = new TextBox
                {
                    Location = new System.Drawing.Point(cbEntregaDomicilio.Location.X, cbEntregaDomicilio.Location.Y + cbEntregaDomicilio.Height + 10),
                    Width = 250,
                    Height = 60,
                    Multiline = true
                };
                this.Controls.Add(txtUbicacionEntrega);
            }
        }

        private void EliminarTextBoxDireccionDomicilio()
        {
            if (txtUbicacionEntrega != null)
            {
                this.Controls.Remove(txtUbicacionEntrega);
                txtUbicacionEntrega.Dispose();
                txtUbicacionEntrega = null;
            }
        }

        private void Limpiar()
        {
            cmbPaquetes.SelectedIndex = paquetes.Count - 1;

            txtUbicacionRecogida.Text = string.Empty;

            cbEntregaSucursal.Checked = false;
            cbEntregaDomicilio.Checked = false;

            if (cmbSucursales != null)
            {
                cmbSucursales.SelectedIndex = cmbSucursales.Items.Count - 1;
            }

            if (txtUbicacionEntrega != null)
            {
                txtUbicacionEntrega.Text = string.Empty;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            Pedido pedido = new Pedido();
            pedido.IdPaquete = paquetes[cmbPaquetes.SelectedIndex].Id;
            pedido.IdUsuario = usuarioActivo.Id;
            pedido.Estado = "Pedido generado";
            pedido.UbicacionRecogida = txtUbicacionRecogida.Text;
            pedido.TipoEntrega = cbEntregaSucursal.Checked ? "Sucursal" : "Domicilio";
            pedido.UbicacionEntrega = cbEntregaSucursal.Checked ? cmbSucursales.SelectedValue.ToString() : txtUbicacionEntrega.Text;

            if (UsuarioLN.Agregar(pedido))
            {
                MessageBox.Show("Pedido agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo agregar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Limpiar();
            CargarCombo();
            CargarPedidos();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            pedidoSeleccionado.IdPaquete = paquetes[cmbPaquetes.SelectedIndex].Id;
            pedidoSeleccionado.IdUsuario = usuarioActivo.Id;
            pedidoSeleccionado.Estado = "Pedido generado";
            pedidoSeleccionado.UbicacionRecogida = txtUbicacionRecogida.Text;
            pedidoSeleccionado.TipoEntrega = cbEntregaSucursal.Checked ? "Sucursal" : "Domicilio";
            pedidoSeleccionado.UbicacionEntrega = cbEntregaSucursal.Checked ? cmbSucursales.SelectedValue.ToString() : txtUbicacionEntrega.Text;

            if (UsuarioLN.Modificar(pedidoSeleccionado))
            {
                string descripcionPaquete = paquetes[cmbPaquetes.SelectedIndex].Descripcion;
                Historial historial = new Historial();
                historial.IdPedido = pedidoSeleccionado.Id;
                historial.Accion = $"Pedido modificado por: {usuarioActivo.NombreCompleto}. " +
                                   $"Paquete: {descripcionPaquete}, " +
                                   $"Recogida: {pedidoSeleccionado.UbicacionRecogida}, " +
                                   $"Entrega: {pedidoSeleccionado.TipoEntrega} - {pedidoSeleccionado.UbicacionEntrega}";
                UsuarioLN.Agregar(historial);

                MessageBox.Show("Pedido modificado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo modificar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Limpiar();
            CargarCombo();
            CargarPedidos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            pedidoSeleccionado.IdPaquete = paquetes[cmbPaquetes.SelectedIndex].Id;
            if (UsuarioLN.Eliminar(pedidoSeleccionado))
            {
                MessageBox.Show("Pedido eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Limpiar();
            CargarCombo();
            CargarPedidos();
        }

        private bool ValidarDatos()
        {
            if (cmbPaquetes.SelectedValue.ToString() == "Seleccione un paquete")
            {
                MessageBox.Show("Debe seleccionar un paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUbicacionRecogida.Text))
            {
                MessageBox.Show("Debe ingresar una ubicación de recogida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!cbEntregaSucursal.Checked && !cbEntregaDomicilio.Checked)
            {
                MessageBox.Show("Debe seleccionar una opción de entrega.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbEntregaSucursal.Checked)
            {
                if (cmbSucursales == null || cmbSucursales.SelectedValue.ToString() == "Seleccione una sucursal")
                {
                    MessageBox.Show("Debe seleccionar una sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (cbEntregaDomicilio.Checked)
            {
                if (txtUbicacionEntrega == null || string.IsNullOrWhiteSpace(txtUbicacionEntrega.Text))
                {
                    MessageBox.Show("Debe ingresar una dirección de domicilio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtUbicacionRecogida.Text = dgvPedidos.Rows[e.RowIndex].Cells["Ubicación Recogida"].Value.ToString();

                string tipoEntrega = dgvPedidos.Rows[e.RowIndex].Cells["Tipo Entrega"].Value.ToString();
                cbEntregaDomicilio.Checked = tipoEntrega == "Domicilio";
                cbEntregaSucursal.Checked = tipoEntrega == "Sucursal";

                if (tipoEntrega == "Sucursal")
                {
                    string ubicacionEntrega = dgvPedidos.Rows[e.RowIndex].Cells["Ubicación Entrega"].Value.ToString();
                    cmbSucursales.SelectedIndex = cmbSucursales.Items.IndexOf(ubicacionEntrega);
                }
                else if (tipoEntrega == "Domicilio")
                {
                    txtUbicacionEntrega.Text = dgvPedidos.Rows[e.RowIndex].Cells["Ubicación Entrega"].Value.ToString();
                }

                int id = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells[0].Value);
                pedidoSeleccionado = ObtenerPedido(id);
                cmbPaquetes.SelectedIndex = paquetes.FindIndex(p => p.Id == pedidoSeleccionado.IdPaquete);
            }
            catch
            {
            }
        }

        private Pedido ObtenerPedido(int id)
        {
            return pedidos.Find(x => x.Id == id);
        }
        private Paquete ObtenerPaquete(int id)
        {
            return paquetes.Find(x => x.Id == id);
        }
    }
}
