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
    public partial class frmCadReceita : Form
    {       

        public frmCadReceita()
        {
            InitializeComponent();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Recebimento recebimento = new Recebimento(
                new Empresa(1),
                txtDescrição.Text,
                cmbEmissaoNF.SelectedIndex,
                mskData.Text,
                cmbTipo.SelectedIndex,
                Util.converterStringEmFloat(txtValor.Text)                
                );            
            if (Util.validarRecebimento(recebimento))
            {
                MessageBox.Show("vou salvar no BD");
            }
        }
    }
}
