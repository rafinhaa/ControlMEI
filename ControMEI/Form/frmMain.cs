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
        Empresa empresa;

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
                empresa = empresas.ElementAt(0);
                menuStrip1.Enabled = true;                
            }else if (total_empresas > 1)
            {
                //carregar menu para listar empresas
                menuStrip1.Enabled = true;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {   
            System.Windows.Forms.Application.Exit();
        }
        public void updateEmpresaList()
        {
            empresas = empresaDAO.SelectAll();
            checkEmpresasInDataBase();
        }
    }
}
