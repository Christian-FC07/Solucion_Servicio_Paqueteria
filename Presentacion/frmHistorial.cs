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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Diagnostics;

namespace Presentacion
{
    public partial class frmHistorial : Form
    {
        private List<Pedido> pedidos;
        private List<Paquete> paquetes;
        private Usuario usuarioActivo;
        private List<Historial> historiales;

        public frmHistorial()
        {
            Usuario usuario = new Usuario();
            usuario.Correo = ConfiguracionGlobal.CorreoUsuarioActivo;
            usuarioActivo = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);
            InitializeComponent();
            CargarCombo();
            CargarHistorialPedidos();
        }

        public void CargarCombo()
        {
            pedidos = UsuarioLN.ConsultarPedidosPorUsuario(usuarioActivo);
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
                List<Historial> historialesFiltrados = historiales.FindAll(h => h.IdPedido == selectedPedido.Id);
                dgvHistorial.DataSource = historialesFiltrados;
                dgvHistorial.Refresh();
            }
            else
            {
                dgvHistorial.DataSource = historiales;
                dgvHistorial.Refresh();
            }
        }

        private void CargarHistorialPedidos()
        {
            historiales = UsuarioLN.ConsultarHistorialesPorUsuario(usuarioActivo);

            dgvHistorial.DataSource = historiales;
            dgvHistorial.Refresh();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoFiltro = txtBuscar.Text.ToLower();
            List<Historial> datosFiltrados = historiales
                .Where(h => h.GetType().GetProperties()
                    .Any(p => p.GetValue(h)?.ToString().ToLower().Contains(textoFiltro) ?? false))
                .ToList();

            dgvHistorial.DataSource = datosFiltrados;
            dgvHistorial.Refresh();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para exportar", "Consulta de Historial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog dialogoguardar = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = "ExportarDatosPDF"
            };

            if (dialogoguardar.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string ruta = dialogoguardar.FileName;

            try
            {
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }

                PdfPTable pdftable = new PdfPTable(dgvHistorial.Columns.Count)
                {
                    DefaultCell = { Padding = 3, BorderWidth = 2, HorizontalAlignment = Element.ALIGN_CENTER },
                    WidthPercentage = 100,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };

                foreach (DataGridViewColumn columna in dgvHistorial.Columns)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText));
                    pdftable.AddCell(celda);
                }

                foreach (DataGridViewRow row in dgvHistorial.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdftable.AddCell(cell.Value?.ToString() ?? string.Empty);
                    }
                }

                using (FileStream stream = new FileStream(ruta, FileMode.Create))
                using (Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f))
                {
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdftable);
                }

                MessageBox.Show("Exportacion a PDF satisfactoria", "Consulta de Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!String.IsNullOrEmpty(ruta))
                {
                    Process.Start(ruta);
                }
            }
            catch (IOException exIO)
            {
                MessageBox.Show(Constantes.AccionError, "Consultas Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al exportar el archivo: " + ex.Message, "Consultas Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Paquete ObtenerPaquete(int id)
        {
            return paquetes.Find(x => x.Id == id);
        }
    }
}
