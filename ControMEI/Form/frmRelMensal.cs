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

            DataTable dt = new RecebimentoDAO().SelectRelMensal(empresa);
            //reportViewer1.Visible = true;
            //reportViewer1.LocalReport.ReportPath = "..\\..\\RelMensal.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
            Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("cnpj",empresa.Cnpj),
                new Microsoft.Reporting.WinForms.ReportParameter("razaoSocial",empresa.RazaoSocial),
                new Microsoft.Reporting.WinForms.ReportParameter("dataInicio","01/02/2021"),
                new Microsoft.Reporting.WinForms.ReportParameter("dataFim","29/02/2021")
            };
            reportViewer1.LocalReport.SetParameters(rParams);
            this.reportViewer1.RefreshReport();
        }
    }
}
