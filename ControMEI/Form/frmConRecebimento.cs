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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //RecebimentoDAO recebimentoDAO = new RecebimentoDAO();
            //dataGridView1 = recebimentoDAO.D();
            //dataGridView1.DataSource = recebimentoDAO.SelectAll();
            //dataGridView1.DataSource = recebimentoDAO.SelectAllDataSet().Tables[0];
            updateTable();
            //dataGridView1.Columns["id"].Visible = false;
            //dataGridView1.Columns["id_empresa"].Visible = false;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Recebimento recebimento = new Recebimento(
                new Empresa(1),
                txtDescrição.Text,
                cmbEmissaoNF.SelectedIndex,
                dateTimePicker1.Value.ToShortDateString(),
                cmbTipo.SelectedIndex,
                Util.converterStringEmFloat(txtValor.Text)
                );            
            dataGridView1.DataSource = recebimentoDAO.SelectAllDataTable(Util.validarConRecebimento(recebimento));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            recebimento = new Recebimento(new Empresa(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value)),
                Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                dataGridView1.CurrentRow.Cells[2].Value.ToString(),
                Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value),
                dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value),
                float.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString())
                );
            bindListToFields(recebimento);
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
            dataGridView1.DataSource = recebimentoDAO.SelectAllDataTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                RecebimentoDAO recebimentoDAO = new RecebimentoDAO();
                MessageBox.Show(recebimentoDAO.Update(recebimento));
                updateTable();
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
    }
}
