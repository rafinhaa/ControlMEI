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
    public partial class frmRelMensal : Form
    {
        public frmRelMensal()
        {
            InitializeComponent();
        }

        private void frmRelMensal_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'ControlMEI_DS.Empresa'. Você pode movê-la ou removê-la conforme necessário.
            this.EmpresaTableAdapter.Fill(this.ControlMEI_DS.Empresa);

            this.reportViewer1.RefreshReport();
        }
    }
}
