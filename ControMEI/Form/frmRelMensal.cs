using ControMEI.files.Class;
using ControMEI.files.DAO;
using ControMEI.files.Util;
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
            cmbAno.DataSource = new RecebimentoDAO().SelectYears(empresa);
            cmbAno.DisplayMember = "ano";
            cmbAno.ValueMember = "ano";
            cmbAno.Items.Count.ToString();
            if (cmbAno.Items.Count > 0)
            {
                cmbMes.DataSource = new RecebimentoDAO().SelectMonths(empresa, cmbAno.SelectedValue.ToString());
                cmbMes.DisplayMember = "mes";
                cmbMes.ValueMember = "mes";
            }
            
        }

        private void searchRel(String dtInicio, String dtFim)
        {

            DataTable dt = new RecebimentoDAO().SelectRelMensal(empresa, dtInicio, dtFim);
            //reportViewer1.Visible = true;
            //reportViewer1.LocalReport.ReportPath = "..\\..\\RelMensal.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
            Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("cnpj",empresa.Cnpj),
                new Microsoft.Reporting.WinForms.ReportParameter("razaoSocial",empresa.RazaoSocial),
                new Microsoft.Reporting.WinForms.ReportParameter("dataInicio",Util.formatDateToBr(dtInicio)),
                new Microsoft.Reporting.WinForms.ReportParameter("dataFim",Util.formatDateToBr(dtFim))
            };
            reportViewer1.LocalReport.SetParameters(rParams);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbAno.SelectedItem == null) return;
            cmbMes.DataSource = new RecebimentoDAO().SelectMonths(empresa,cmbAno.SelectedValue.ToString());
            cmbMes.DisplayMember = "mes";
            cmbMes.ValueMember = "mes";

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cmbAno.Items.Count > 0)
            {
                String ano = cmbAno.SelectedValue.ToString();
                String mes = cmbMes.SelectedValue.ToString();
                List<string> data = Util.mountResearch(ano, mes);
                searchRel(data[0], data[1]);
            }
            else
            {
                MessageBox.Show("Você precisa cadastrar sua primeira receita!");
            }
        }
    }
}
