using ArrayObjetos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayObjetos.Windows
{
    public partial class frmObjeto : Form
    {
        public frmObjeto()
        {
            InitializeComponent();
        }
        private Objeto objeto;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboColorRelleno();
            CargarDatosComboTipoDeBorde();
            if (objeto != null)
            {
                txtLado.Text = objeto.GetLado().ToString();
                cboColores.SelectedItem = objeto.ColorRelleno;
                cboBorde.SelectedItem = objeto.ColorRelleno;
            }
        }

        private void CargarDatosComboTipoDeBorde()
        {
            var listaBorde = Enum.GetValues(typeof(TipoDeBorde)).Cast<TipoDeBorde>().ToList();
            cboBorde.DataSource = listaBorde;
            cboBorde.SelectedIndex = 0;
        }

        private void CargarDatosComboColorRelleno()
        {
            var listaColores = Enum.GetValues(typeof(ColorRelleno)).Cast<ColorRelleno>().ToList();
            cboColores.DataSource = listaColores;
            cboColores.SelectedIndex = 0;
        }

        public Objeto GetObjeto()
        {
            return objeto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (objeto == null)
                {
                    objeto = new Objeto();

                }
                objeto.SetLado(int.Parse(txtLado.Text));
                objeto.ColorRelleno = (ColorRelleno)cboColores.SelectedItem;
                objeto.TipoDeBorde = (TipoDeBorde)cboBorde.SelectedItem;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtLado.Text, out int lado))
            {
                valido = false;
                errorProvider1.SetError(txtLado, "Numero mal ingresado");
            }
            else if (lado <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLado, "Valor no valido");
            }
            return valido;
        }

        public void SetObjeto(Objeto? objeto)
        {
            this.objeto = objeto;
        }

        private void frmObjeto_Load(object sender, EventArgs e)
        {

        }
    }
}
