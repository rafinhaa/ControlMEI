using ControMEI.files.Class;
using ControMEI.files.DAO;
using Microsoft.Reporting.WinForms;
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
        Empresa empresa;
        public frmRelMensal(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
        }

        private void frmRelMensal_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'ControlMEI_DS.Empresa'. Você pode movê-la ou removê-la conforme necessário.
            //this.EmpresaTableAdapter.Fill(this.ControlMEI_DS.Empresa);
            //this.EmpresaTableAdapter.Fill(new EmpresaDAO().SelectAllDataTable(empresa));

            //this.reportViewer1.RefreshReport();

            DataTable dt = new EmpresaDAO().SelectAllDataTable(empresa);
            reportViewer1.Visible = true;
            //reportViewer1.LocalReport.ReportPath = "..\\..\\RelMensal.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
            this.reportViewer1.RefreshReport();
        }
    }
}
