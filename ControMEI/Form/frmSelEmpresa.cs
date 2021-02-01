using ControMEI.files.Class;
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
    public partial class frmSelEmpresa : Form
    {
        private List<Empresa> empresas;
        private Empresa empresa;
        public frmSelEmpresa(List<Empresa> empresas)
        {
            InitializeComponent();
            this.empresas = empresas;
        }

        private void frmSelEmpresa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = empresas;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
            dataGridView1.Columns["RazaoSocial"].Visible = true;
            dataGridView1.Columns["Cnpj"].Visible = true;
            dataGridView1.Columns["Endereco"].Visible = true;
            dataGridView1.Columns["Telefone"].Visible = true;            
            dataGridView1.Columns["Cidade"].Visible = true;            
            dataGridView1.Columns["Estado"].Visible = true;            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getEmpresaInList();
        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getEmpresaInList();

            }
        }
        private void getEmpresaInList()
        {
            empresa = (Empresa)dataGridView1.CurrentRow.DataBoundItem;            
            if (((frmMain)this.MdiParent).updateEmpresaSelected(empresa))
            {
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Selecione uma empresa da lista!");
            }
        }
    }
}
