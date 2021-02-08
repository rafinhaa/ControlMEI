using ControMEI.files.Class;
using ControMEI.files.DAO;
using ControMEI.files.Util;
using System;
using System.Linq;
using System.Windows.Forms;


namespace ControMEI
{
    public partial class frmCadEmpresa : Form
    {
        EmpresaDAO empresaDAO = new EmpresaDAO();
        public bool firstUse;
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
                MessageBox.Show(empresaDAO.Insert(empresa));
                ((frmMain)this.MdiParent).updateEmpresaList();
                this.limpaCampos();
                if (firstUse)
                {
                    this.Dispose();
                }                
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

        private void frmCadEmpresa_Load(object sender, EventArgs e)
        {

        }
        private void limpaCampos()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
            }
        }
    }
}
