using ArrayObjetos.Datos;
using ArrayObjetos.Entidades;

namespace ArrayObjetos.Windows
{
    public partial class frmPrincipal : Form
    {
        private RepositorioDeObjetos repo;
        private List<Objeto> lista;
        int intValor;
        bool filterOn = false;
        public frmPrincipal()
        {
            InitializeComponent();
            repo = new RepositorioDeObjetos();
            ActualizarCantidadRegistros();
        }

        private void ActualizarCantidadRegistros()
        {
            if (intValor > 0)
            {
                txtCantidad.Text = repo.GetCantidad(intValor).ToString();
            }
            else
            {
                txtCantidad.Text = repo.GetCantidad().ToString();

            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmObjeto frm = new frmObjeto() { Text = "Agregar Objeto" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Objeto objeto = frm.GetObjeto();
            if (!repo.Existe(objeto))
            {
                repo.Agregar(objeto);
                txtCantidad.Text = repo.GetCantidad().ToString();
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, objeto);
                AgregarFila(r);


                MessageBox.Show("Registro agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registro existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Objeto objeto)
        {
            r.Cells[colRadio.Index].Value = objeto.GetLado();
            r.Cells[colBorde.Index].Value = objeto.TipoDeBorde;
            r.Cells[colRelleno.Index].Value = objeto.ColorRelleno;
            r.Cells[colArea.Index].Value = objeto.GetArea();
            r.Cells[colVolumen.Index].Value = objeto.GetVolumen();
            r.Tag = objeto;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("¿Desea borrar la esfera?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Objeto objeto = filaSeleccionada.Tag as Objeto;
            repo.Borrar(objeto);
            txtCantidad.Text = repo.GetCantidad().ToString();
            QuitarFila(filaSeleccionada);
            MessageBox.Show("Esfera borrada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Objeto objeto = (Objeto)filaSeleccionada.Tag;
            int ladoAnterior = objeto.GetLado();
            frmObjeto frm = new frmObjeto() { Text = "Editar Esfera" };
            frm.SetObjeto(objeto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            objeto = frm.GetObjeto();
            repo.Editar(ladoAnterior, objeto);
            SetearFila(filaSeleccionada, objeto);
            MessageBox.Show("Esfera editada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (repo.GetCantidad() > 0)
            {
                lista = repo.GetLista();
                MostrarDatosEnGrilla();
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var objeto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, objeto);
                AgregarFila(r);
            }
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            if (!filterOn)
            {


                var stringValor = Microsoft.VisualBasic.Interaction.InputBox("ingrese el valor para filtrar",
                 "filtrar por mayor!",
                 "0", 400, 400);
                if (!int.TryParse(stringValor, out intValor))
                {
                    return;
                }
                if (intValor <= 0)
                {
                    return;
                }
                lista = repo.Filtrar(intValor);
                tsbFiltrar.BackColor = Color.Blue;
                filterOn = true;
                MostrarDatosEnGrilla();
                ActualizarCantidadRegistros();
            }
            else
            {
                MessageBox.Show("Filtro ya aplicado");


            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            intValor = 0;
            filterOn = false;
            tsbFiltrar.BackColor = SystemColors.Control;
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCantidadRegistros();
        }
    }
}
