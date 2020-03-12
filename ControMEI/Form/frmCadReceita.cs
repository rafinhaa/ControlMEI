﻿using ControMEI.files.Class;
using ControMEI.files.DAO;
using ControMEI.files.Util;
using System;
using System.Windows.Forms;

namespace ControMEI
{
    public partial class frmCadReceita : Form
    {       

        public frmCadReceita()
        {
            InitializeComponent();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '.')
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Recebimento recebimento = new Recebimento(
                new Empresa(1),
                txtDescrição.Text,
                cmbEmissaoNF.SelectedIndex,
                mskData.Text,
                cmbTipo.SelectedIndex,
                Util.converterStringEmFloat(txtValor.Text)                
                );            
            if (Util.validarRecebimento(recebimento))
            {
                RecebimentoDAO recebimentoDAO = new RecebimentoDAO();
                MessageBox.Show(recebimentoDAO.Insert(recebimento));
            }
        }
    }
}
