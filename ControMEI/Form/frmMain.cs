using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ControMEI.files.Class;
using ControMEI.files.DAO;
using System.Collections.Generic;

namespace ControMEI
{
    public partial class frmMain : Form
    {
        EmpresaDAO empresaDAO = new EmpresaDAO();                                
        private List<Empresa> empresas;
        public Empresa empresa = null;
        private string titleMainForm = "ControlMEI - Gestão para Micro Empreendedor Individual";

        public frmMain()
        {
            InitializeComponent();      
        }
        public frmMain(List<Empresa> empresas)
        {
            InitializeComponent();
            this.empresas = empresas;
        }
        private void OpenForm<T>(T meuFormulario) where T : Form
        {
            if (!Application.OpenForms.OfType<T>().Any())
            {
                meuFormulario.MdiParent = this;
                meuFormulario.Show();
            }
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == meuFormulario.Name)
                {
                    frm.Activate();
                    break;
                }
            }
        }
        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadEmpresa frmCadEmpresa = new frmCadEmpresa();
            OpenForm(frmCadEmpresa);
        }     
        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            frmCadReceita frmCadReceita = new frmCadReceita(empresa);
            OpenForm(frmCadReceita);
        }
        private void receitaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 frmCadReceita = new Form1(empresa);
            OpenForm(frmCadReceita);
        }
        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelEmpresa frmSelEmpresa = new frmSelEmpresa(empresas);
            OpenForm(frmSelEmpresa);
        }
        private void sqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {   
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            System.Windows.Forms.Application.Exit();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            checkEmpresasInDataBase();
        }
        private void checkEmpresasInDataBase()
        {
            int total_empresas = empresas.Count;
            if (total_empresas <= 0)
            {
                frmCadEmpresa frmCadEmpresa = new frmCadEmpresa();
                frmCadEmpresa.firstUse = true;
                OpenForm(frmCadEmpresa);
            }
            else if (total_empresas == 1)
            {
                menuStrip1.Enabled = true;
                empresa = empresas.ElementAt(0);                               
            }else if (total_empresas > 1)
            {
                menuStrip1.Enabled = false;
                frmSelEmpresa frmSelEmpresa = new frmSelEmpresa(empresas);                
                OpenForm(frmSelEmpresa);                
            }
        }        
        public void updateEmpresaList()
        {
            empresas = empresaDAO.SelectAll();
            checkEmpresasInDataBase();
        }
        public bool updateEmpresaSelected(Empresa empresa)
        {
            if(empresa != null)
            {
                this.empresa = empresa;
                menuStrip1.Enabled = true;
                this.Text = titleMainForm + " | Empresa: " + empresa.RazaoSocial + " CNPJ: " + empresa.Cnpj;
                return true;
            }
            else
            {
                return false;
            }            
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void novaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadEmpresa frmCadEmpresa = new frmCadEmpresa();
            OpenForm(frmCadEmpresa);
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void alterarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSelEmpresa frmSelEmpresa = new frmSelEmpresa(empresas);
            OpenForm(frmSelEmpresa);
        }

        private void empresaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmConEmpresa frmConEmpresa = new frmConEmpresa(empresa);
            OpenForm(frmConEmpresa);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frmSobre = new frmSobre();
            OpenForm(frmSobre);
        }

        private void gerarRelatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelMensal frmRelMensal = new frmRelMensal(empresa);
            OpenForm(frmRelMensal);
        }
    }
}
