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
            dataGridView1.DataSource = recebimentoDAO.SelectAllDataTable();
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
    }
}
