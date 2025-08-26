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
    public partial class frmMenu : Form
    {
        private Usuario usuarioActivo;

        public frmMenu()
        {
            Usuario usuario = new Usuario();
            usuario.Correo = ConfiguracionGlobal.CorreoUsuarioActivo;
            usuarioActivo = UsuarioLN.ConsultarUsuarioPorCorreo(usuario);
            InitializeComponent();
            ConfigurarMenuSegunRol();
        }

        private void ConfigurarMenuSegunRol()
        {
            switch (usuarioActivo.Rol)
            {
                case "administrador":
                    mantenimientosToolStripMenuItem.Visible = true;
                    procesosToolStripMenuItem.Visible = true;
                    usuariosToolStripMenuItem.Visible = true;
                    modificarEstadoPedidoToolStripMenuItem.Visible = true;
                    break;
                case "funcionario":
                    procesosToolStripMenuItem.Visible = true;
                    modificarEstadoPedidoToolStripMenuItem.Visible = true;
                    break;
                case "cliente":
                    mantenimientosToolStripMenuItem.Visible = true;
                    procesosToolStripMenuItem.Visible = true;
                    historialToolStripMenuItem.Visible = true;

                    paquetesToolStripMenuItem.Visible = true;
                    pedidosToolStripMenuItem.Visible = true;
                    pagarPedidoToolStripMenuItem.Visible = true;
                    verHistorialToolStripMenuItem.Visible = true;
                    break;
                default:
                    MessageBox.Show("Rol desconocido. Acceso denegado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    break;
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracionGlobal.CorreoUsuarioActivo = string.Empty;
            frmInicioSesion frmInicioSesion = new frmInicioSesion();
            frmInicioSesion.Show();
            this.Hide();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoUsuarios frmMantenimientoUsuarios = new frmMantenimientoUsuarios();
            frmMantenimientoUsuarios.Show();
        }

        private void paquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientoPaquetes frmMantenimientoPaquetes = new frmMantenimientoPaquetes();
            frmMantenimientoPaquetes.Show();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerarPedido frmGenerarPedido = new frmGenerarPedido();
            frmGenerarPedido.Show();
        }

        private void pagarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPagarPedido frmPagarPedido = new frmPagarPedido();
            frmPagarPedido.Show();
        }

        private void verHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial frmHistorial = new frmHistorial();
            frmHistorial.Show();
        }

        private void modificarEstadoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarEstadoPedido frmModificarEstadoPedido = new frmModificarEstadoPedido();
            frmModificarEstadoPedido.Show();
        }
    }
}
