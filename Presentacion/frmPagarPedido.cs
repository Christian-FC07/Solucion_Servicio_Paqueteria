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
    public partial class frmPagarPedido : Form
    {

        private Usuario usuarioActivo;
        private List<Pedido> pedidos;
        private List<Paquete> paquetes;
        private Label lblDesglosePago;
        public frmPagarPedido()
        {
            Usuario usuario = new Usuario();
            usuario.Correo = ConfiguracionGlobal.CorreoUsuarioActivo;
            usuarioActivo = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);
            InitializeComponent();
            CargarCombo();
        }

        public void CargarCombo()
        {
            pedidos = UsuarioLN.ConsultarPedidosPorUsuario(usuarioActivo).Where(p => p.Pagado == false).ToList();
            paquetes = UsuarioLN.ConsultarPaquetesPorUsuario(usuarioActivo);

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
        }

        private void cmbPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedValue.ToString() != "Seleccione un pedido")
            {
                Pedido selectedPedido = pedidos[cmbPedidos.SelectedIndex];
                CrearDesgloseDePago();
                MostrarDesglosePago(selectedPedido);
            }
            else
            {
                if (lblDesglosePago != null)
                {
                    this.Controls.Remove(lblDesglosePago);
                    lblDesglosePago = null;
                }
            }
        }

        private void CrearDesgloseDePago()
        {
            lblDesglosePago = new Label
            {
                Width = 260,
                Height = 200,
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 10),
                Location = new Point(cmbPedidos.Location.X, cmbPedidos.Location.Y + cmbPedidos.Height + 10)
            };
            this.Controls.Add(lblDesglosePago);
        }

        private void MostrarDesglosePago(Pedido pedido)
        {
            Paquete paquete = ObtenerPaquete(pedido.IdPaquete);
            Random random = new Random();
            double costoAduanas = random.Next(5000, 10000) + (paquete.Valor * 0.2) + (paquete.Peso * 0.1);
            double costoEnvio = paquete.Peso * 2300;
            double costoSeguro = paquete.Valor * 0.3;
            double costoTotal = costoAduanas + costoEnvio + costoSeguro;

            string desglosePago = $"Desglose de pago del pedido:{Environment.NewLine}" +
                                  $"Peso del paquete: {paquete.Peso} kg{Environment.NewLine}" +
                                  $"Valor del paquete: ₡{paquete.Valor:F2}{Environment.NewLine}" +
                                  $"Costo de aduanas: ₡{costoAduanas:F2}{Environment.NewLine}" +
                                  $"Costo de envío: ₡{costoEnvio:F2}{Environment.NewLine}" +
                                  $"Costo de seguro: ₡{costoSeguro:F2}{Environment.NewLine}" +
                                  $"Costo total: ₡{costoTotal:F2}{Environment.NewLine}{Environment.NewLine}" +
                                  $"Formulas:{Environment.NewLine}" +
                                  $"Costo de aduanas: Random(5000, 10000) + Valor * 0.2 + Peso * 0.1{Environment.NewLine}" +
                                  $"Costo de envío: Peso * 2300{Environment.NewLine}" +
                                  $"Costo de seguro: Valor * 0.3";

            lblDesglosePago.Text = desglosePago;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (cmbPedidos.SelectedValue.ToString() == "Seleccione un pedido")
            {
                MessageBox.Show("Por favor, seleccione un pedido antes de proceder con el pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Pedido pedidoSeleccionado = pedidos[cmbPedidos.SelectedIndex];
            if (UsuarioLN.PagarPedido(pedidoSeleccionado))
            {
                Historial historial = new Historial();
                historial.IdPedido = pedidoSeleccionado.Id;
                historial.Accion = "El usuario: " + usuarioActivo.NombreCompleto + " ha pagado el pedido.";
                UsuarioLN.Agregar(historial);
                MessageBox.Show("Pedido pagado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo pagar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private Paquete ObtenerPaquete(int id)
        {
            return paquetes.Find(x => x.Id == id);
        }
    }
}
