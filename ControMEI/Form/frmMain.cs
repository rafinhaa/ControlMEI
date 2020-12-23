using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ControMEI.files.DAO;

namespace ControMEI
{
    public partial class frmMain : Form
    {
        EmpresaDAO empresaDAO = new EmpresaDAO();
        int totalEmp = -1;
        Thread t;

        public frmMain()
        {
            InitializeComponent();
            BD.CriarBancoSQLite();
            checkQuantidadeEmpresas();
        }

        private void checkQuantidadeEmpresas()
        {
            t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
        }
        public void ThreadProc()
        {            
            while(totalEmp <= 0)
            {
                totalEmp = empresaDAO.checkEmpresa();
                Thread.Sleep(100);
            }            
            menuStrip1.Invoke((MethodInvoker)delegate {
                menuStrip1.Enabled = true;
            });
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
            frmCadReceita frmCadReceita = new frmCadReceita();
            OpenForm(frmCadReceita);
        }
        private void receitaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 frmCadReceita = new Form1();
            OpenForm(frmCadReceita);
        }

        private void sqliteToolStripMenuItem_Click(object sender, EventArgs e)
        {   
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Abort();
            System.Windows.Forms.Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //menuStrip1.Enabled = false;
            if (totalEmp <= 0)
            {                
                frmCadEmpresa frmCadEmpresa = new frmCadEmpresa();
                OpenForm(frmCadEmpresa);                
            }
            else if (totalEmp > 1)
            {
                //carregar menu para listar empresas
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {            
            t.Abort();
            System.Windows.Forms.Application.Exit();
        }
    }
}
