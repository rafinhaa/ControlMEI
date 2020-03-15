using ControMEI.files.Class;
using ControMEI.files.DAO;
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
    public partial class frmSelecionarEmpresa : Form
    {


        public frmSelecionarEmpresa()
        {
            InitializeComponent();
            //BD.CriarBancoSQLite();
            //EmpresaDAO empresaDAO = new EmpresaDAO();
            //List<Empresa> aa = empresaDAO.SelectAll();
            //if (aa.Count() != 1)
            //{
            //}
            //else
            //{
            //
            //}
        }

        private void frmSelecionarEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
            this.Close();
        }
    }
}