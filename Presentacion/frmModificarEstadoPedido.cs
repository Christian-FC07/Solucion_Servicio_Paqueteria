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
using Negocio;

namespace Presentacion
{
    public partial class frmModificarEstadoPedido : Form
    {
        private List<Pedido> pedidos;
        private List<Paquete> paquetes;

        public frmModificarEstadoPedido()
        {
            InitializeComponent();
            dgvHistorial.Visible = false;
            CargarCombo();
        }

        public void CargarCombo()
        {
            pedidos = UsuarioLN.ConsultarPedidos();
            paquetes = UsuarioLN.ConsultarPaquetes();

            List<string> informacionCombo = new List<string>();

            foreach (var pedido in pedidos)
            {
                Paquete paquete = ObtenerPaquete(pedido.IdPaquete);
                string descripcion = $"Pedido ID: {pedido.Id} - " +
                                     $"Fecha: {pedido.FechaCreacion.ToShortDateString()} - " +
                                     $"Estado: {pedido.Estado} - " +
                                     $"Paquete: {paquete.Peso}kg, ₡{paquete.Valor:F2}";
                informacionCombo.Add(descripcion);
            }

            informacionCombo.Add("Seleccione un pedido");

            cmbPedidos.SelectedIndexChanged -= cmbPedidos_SelectedIndexChanged;
            cmbPedidos.DataSource = informacionCombo;
            cmbPedidos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPedidos.Refresh();
            cmbPedidos.SelectedIndex = informacionCombo.Count - 1;
            cmbPedidos.SelectedIndexChanged += cmbPedidos_SelectedIndexChanged;

            List<string> estados = new List<string>
            {
                "Seleccione un estado",
                "Pedido generado",
                "Pedido en revision",
                "Pedido en preparación",
                "Pedido en transito",
                "Pedido entregado"
            };

            cmbEstados.DataSource = estados;
            cmbEstados.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstados.Refresh();
        }

        private void cmbPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedValue.ToString() != "Seleccione un pedido")
            {
                Pedido pedidoSeleccionado = pedidos[cmbPedidos.SelectedIndex];
                List<Historial> historialesPedido = UsuarioLN.ConsultarHistorialesPorPedido(pedidoSeleccionado);
                dgvHistorial.Visible = true;
                dgvHistorial.DataSource = historialesPedido;
                dgvHistorial.Refresh();
            }
            else
            {
                dgvHistorial.DataSource = null;
                dgvHistorial.Visible = false;
            }
        }

        private Paquete ObtenerPaquete(int id)
        {
            return paquetes.Find(x => x.Id == id);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedValue.ToString() == "Seleccione un pedido")
            {
                MessageBox.Show("Debe seleccionar un pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbEstados.SelectedValue.ToString() == "Seleccione un estado")
            {
                MessageBox.Show("Debe seleccionar un estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string estado = cmbEstados.SelectedValue.ToString();
            Pedido pedidoSeleccionado = pedidos[cmbPedidos.SelectedIndex];
            pedidoSeleccionado.Estado = estado;

            Historial historial = new Historial
            {
                IdPedido = pedidoSeleccionado.Id,
                Fecha = DateTime.Now,
                Accion = $"Pedido estado modificado a {estado}"
            };

            UsuarioLN.Agregar(historial);

            if (UsuarioLN.Modificar(pedidoSeleccionado))
            {
                MessageBox.Show("Estado del pedido modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("No se pudo modificar el estado del pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarCombo();

            
            List<Historial> historialesPedido = UsuarioLN.ConsultarHistorialesPorPedido(pedidoSeleccionado);
            dgvHistorial.Visible = true;
            dgvHistorial.DataSource = historialesPedido;
            dgvHistorial.Refresh();
        }
    }
}
