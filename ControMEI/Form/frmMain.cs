using System;
using System.Linq;
using System.Windows.Forms;
using ControMEI.files.DAO;

namespace ControMEI
{
    public partial class frmMain : Form
    {         
        public frmMain()
        {
            InitializeComponent();
            BD.CriarBancoSQLite();
            EmpresaDAO empresaDAO = new EmpresaDAO();
            if (empresaDAO.SelectAll().Count() >= 1)
            {
                //frmSelecionarEmpresa frmSelEmpresa = new frmSelecionarEmpresa(empresaDAO);
                //frmSelEmpresa.MdiParent = this;
                //frmSelEmpresa.Show();
                //MessageBox.Show("lol");
            }
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadEmpresa frmCadEmpresa = new frmCadEmpresa();
            frmCadEmpresa.MdiParent = this;
            frmCadEmpresa.Show();
        }

        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            frmCadReceita frmCadReceita = new frmCadReceita();
            frmCadReceita.MdiParent = this;
            frmCadReceita.Show();
        }

        private void receitaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {   
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
