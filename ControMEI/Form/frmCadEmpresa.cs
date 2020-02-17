using ControMEI.files.Class;
using ControMEI.files.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControMEI
{
    public partial class frmCadEmpresa : Form
    {
        

        public frmCadEmpresa()
        {
            InitializeComponent();            
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {            
            Empresa empresa = new Empresa(
                mskCNPJ.Text,
                txtRazaoSocial.Text,
                mskCEP.Text,
                txtEndereco.Text,
                mskNumber.Text,
                txtComplemento.Text,
                txtBairro.Text,
                mskTelefone.Text,
                txtCidade.Text,
                txtEstado.Text,
                txtEmail.Text
                );
            if (Util.validarEmpresa(empresa))
            {
                MessageBox.Show("vou salvar no BD");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !(e.KeyChar == '.') && !(e.KeyChar == '_') && !(e.KeyChar == '@') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mskCNPJ_Leave(object sender, EventArgs e)
        {

        }
    }
}
