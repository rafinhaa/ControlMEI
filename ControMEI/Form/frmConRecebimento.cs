using ControMEI.files.Class;
using ControMEI.files.DAO;
using ControMEI.files.Util;
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
    public partial class Form1 : Form
    {
        RecebimentoDAO recebimentoDAO = new RecebimentoDAO();
        Recebimento recebimento;
        private Empresa empresa;
        bool atualizar = false;

        public Form1(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtInicio.Value = new DateTime(now.Year, now.Month, 1);
            dtFim.Value = dtInicio.Value.AddMonths(1).AddDays(-1);
            btnCancelar.Visible = false;
            recebimento = new Recebimento(empresa);
            disableItens();
            updateTable();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Id"].Visible = false;
            
        }        
        private void bindListToFields(Recebimento recebimento)
        {
            txtDescrição.Text = recebimento.Descricao;
            cmbEmissaoNF.SelectedIndex = recebimento.NotaFiscal;
            dateTimePicker1.Value = Convert.ToDateTime(Util.formatDateToBr(recebimento.Data));
            cmbTipo.SelectedIndex = recebimento.Tipo;
            txtValor.Text = recebimento.Valor.ToString();
        }

        private void updateTable()
        {
            dataGridView1.DataSource = recebimentoDAO.SelectListByPeriod(empresa,
                    dtInicio.Value.ToString("yyyy-MM-dd"),
                    dtFim.Value.ToString("yyyy-MM-dd")
            );
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            recebimentoDAO.Delete(recebimento);
            updateTable();
            limpaCampos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            recebimento = (Recebimento)dataGridView1.CurrentRow.DataBoundItem;
            bindListToFields(recebimento);
        }
        private void limpaCampos()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = String.Empty;
            }
        }

        private void dtFim_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = recebimentoDAO.SelectDataTableByPeriod(empresa,
                dtInicio.Value.ToString("yyyy-MM-dd"),
                dtFim.Value.ToString("yyyy-MM-dd")
            );
        }

        private void dtInicio_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = recebimentoDAO.SelectDataTableByPeriod(empresa,
                dtInicio.Value.ToString("yyyy-MM-dd"),
                dtFim.Value.ToString("yyyy-MM-dd")
            );
        }
        public void disableItens()
        {
            txtDescrição.Enabled = false;
            cmbEmissaoNF.Enabled = false;
            cmbTipo.Enabled = false;
            txtValor.Enabled = false;
            btnCancelar.Visible = false;
            btnCancelar.Enabled = false;
            btnExcluir.Enabled = true;
            dataGridView1.Enabled = true;
        }
        public void enableItens()
        {
            txtDescrição.Enabled = true;
            cmbEmissaoNF.Enabled = true;
            cmbTipo.Enabled = true;
            txtValor.Enabled = true;
            btnCancelar.Visible = true;
            btnCancelar.Enabled = true;
            btnExcluir.Enabled = false;
            dataGridView1.Enabled = false;
        }

        private void btnEditarOuAtualizar_Click(object sender, EventArgs e)
        {            
            if (atualizar)
            {
                atualizar = false;
                recebimento.Descricao = txtDescrição.Text;
                recebimento.NotaFiscal = cmbEmissaoNF.SelectedIndex;
                recebimento.Data = Util.formatDateToUs(dateTimePicker1.Value.ToShortDateString());
                recebimento.Tipo = cmbTipo.SelectedIndex;
                recebimento.Valor = Util.converterStringEmFloat(txtValor.Text);
                if (Util.validarRecebimento(recebimento))
                {
                    if (recebimentoDAO.Update(recebimento))
                    {
                        MessageBox.Show("Atualização efetuada com sucesso!");
                        updateTable();
                        btnEditarOuAtualizar.Text = "Editar";
                        disableItens();
                        limpaCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel efetuar a atualização");
                    }
                }                                
            }
            else{
                enableItens();
                atualizar = true;
                btnEditarOuAtualizar.Text = "Atualizar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            atualizar = false;
            limpaCampos();
            disableItens();
        }
    }
}
