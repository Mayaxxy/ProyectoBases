using System;
using System.Windows.Forms;

using ProyectFinalBD.Entities;
using ProyectFinalBD.Transactions;
using ProyectFinalBD.Reports;
using ProyectFinalBD.Utils;

namespace ProyectFinalBD
{
    public partial class MenuPrincipalForm : Form
    {
        private string usuarioActual;
        private int nivelUsuario;

        public MenuPrincipalForm(string usuario = "admin", int nivel = 1)
        {
            usuarioActual = usuario;
            nivelUsuario = nivel;

            InitializeComponent();
            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            // Ajustar permisos según niveles

            // Nivel 3: solo consultas
            if (nivelUsuario == 3)
            {
                btnClientes.Enabled = false;
                btnProductos.Enabled = false;
                btnVentas.Enabled = false;
                btnReportes.Enabled = false;
            }

            // Nivel 2: no puede abrir usuarios ni bitácora
            if (nivelUsuario == 2)
            {
                // Aquí luego deshabilitas botones si los agregas
            }
        }

        // ==============================
        // MANEJO DE SUBFORMULARIOS
        // ==============================

        private void AbrirFormulario(Form frm)
        {
            panelContenido.Controls.Clear();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(frm);
            frm.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
            => AbrirFormulario(new ClienteListForm());

        private void btnProductos_Click(object sender, EventArgs e)
            => AbrirFormulario(new ProductoListForm());

        private void btnVentas_Click(object sender, EventArgs e)
            => AbrirFormulario(new VentaForm());

        private void btnReportes_Click(object sender, EventArgs e)
            => AbrirFormulario(new ReportVentasMesForm());

        private void btnSalir_Click(object sender, EventArgs e)
            => this.Close();
    }
}