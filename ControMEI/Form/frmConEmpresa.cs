using ControMEI.files.Class;
using ControMEI.files.DAO;
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
    public partial class frmConEmpresa : Form
    {
        Empresa empresa;
        EmpresaDAO empresaDAO = new EmpresaDAO();

        public frmConEmpresa(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
        }

        private void btnSalvarOuAtualizar_Click(object sender, EventArgs e)
        {
            empresa.Cnpj = mskCNPJ.Text;
            empresa.RazaoSocial = txtRazaoSocial.Text;
            empresa.Cep = mskCEP.Text;
            empresa.Endereco = txtEndereco.Text;
            empresa.Numero = mskNumber.Text;
            empresa.Complemento = txtComplemento.Text;
            empresa.Bairro = txtBairro.Text;
            mskTelefone.Text = empresa.Telefone;
            empresa.Cidade = txtCidade.Text;
            empresa.Estado = txtEstado.Text;
            empresa.Email  = txtEmail.Text;
            if (Util.validarEmpresa(empresa))
            {
                if (empresaDAO.Update(empresa))
                {
                    MessageBox.Show("Atualização efetuada com sucesso!");
                    if (((frmMain)this.MdiParent).updateEmpresaSelected(empresa))
                    {
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel efetuar a atualização");
                }
                             
            }
        }

        private void frmConEmpresa_Load(object sender, EventArgs e)
        {
            mskCNPJ.Text = empresa.Cnpj;
            txtRazaoSocial.Text = empresa.RazaoSocial;
            mskCEP.Text = empresa.Cep;
            txtEndereco.Text = empresa.Endereco;
            mskNumber.Text = empresa.Numero;
            txtComplemento.Text = empresa.Complemento;
            txtBairro.Text = empresa.Bairro;
            mskTelefone.Text = empresa.Telefone;
            txtCidade.Text = empresa.Cidade;
            txtEstado.Text = empresa.Estado;
            txtEmail.Text = empresa.Email;
        }
    }
}
