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
            System.Windows.Forms.Application.Exit();
        }
    }
}
