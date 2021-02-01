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

        public Form1(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            recebimento = new Recebimento(empresa);
            updateTable();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Recebimento recebimento = new Recebimento(
                empresa,
                txtDescrição.Text,
                cmbEmissaoNF.SelectedIndex,
                dateTimePicker1.Value.ToShortDateString(),
                cmbTipo.SelectedIndex,
                Util.converterStringEmFloat(txtValor.Text)
                );            
            dataGridView1.DataSource = recebimentoDAO.SelectAllDataTable(Util.validarConRecebimento(recebimento));
        }
        
        private void bindListToFields(Recebimento recebimento)
        {
            txtDescrição.Text = recebimento.Descricao;
            cmbEmissaoNF.SelectedIndex = recebimento.NotaFiscal;
            dateTimePicker1.Value = Convert.ToDateTime(recebimento.Data);
            cmbTipo.SelectedIndex = recebimento.Tipo;
            txtValor.Text = recebimento.Valor.ToString();
        }

        private void updateTable()
        {
            dataGridView1.DataSource = recebimentoDAO.SelectAllList(empresa);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            recebimentoDAO.Delete(recebimento);
            updateTable();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            recebimento.Descricao = txtDescrição.Text;
            recebimento.NotaFiscal = cmbEmissaoNF.SelectedIndex;
            recebimento.Data = dateTimePicker1.Value.ToShortDateString();
            recebimento.Tipo = cmbTipo.SelectedIndex;
            recebimento.Valor = Util.converterStringEmFloat(txtValor.Text);             
            if (Util.validarRecebimento(recebimento))
            {
                if (recebimentoDAO.Update(recebimento)) {
                    MessageBox.Show("Atualização efetuada com sucesso!");                    
                    updateTable();
                }
                else
                {
                    MessageBox.Show("Não foi possivel efetuar a atualização");
                }
            }
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
    }
}
