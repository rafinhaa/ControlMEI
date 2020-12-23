using ControMEI.files.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControMEI.files.Util
{
    class Util
    {
        public static float converterStringEmFloat(string valor)
        {
			if (valor.Length == 0)
				valor += "0";
            return float.Parse(valor);
        }
        public static bool validarEmail(string email)
        {
			if (!validarGenerico(email))
				return false;
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
		public static bool validarCNPJ(string cnpj)
        {
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}
		public static bool validarGenerico(string texto)
		{			
			if (texto.Trim().Length == 0)
				return false;
			else
				return true;
		}
		public static bool validarCEP(string cep)
		{
			if (cep.Trim().Replace("-", "").Length != 8)
				return false;
			else
				return true;
		}
		public static bool validarTelefone(string telefone)
		{		
			if (telefone.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Length == 12 ||
				telefone.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Length == 11)
				return true;
			else
				return false;
		}
		public static bool validarEmpresa(Empresa empresa)
		{			
			string erros = "Por favor corrigir os seguintes erros:\n";
			if (!validarCNPJ(empresa.Cnpj)){
				erros += "CNPJ inválido\n";
			}
			if (!validarGenerico(empresa.RazaoSocial))
			{
				erros += "Razão social está em branco\n";
			}
			if (!validarCEP(empresa.Cep))
			{
				erros += "CEP inválido!\n";
			}
			if (!validarGenerico(empresa.Endereco))
			{
				erros += "Endereço está em branco\n";
			}
			if (!validarGenerico(empresa.Numero))
			{
				erros += "Número está em branco\n";
			}
			if (!validarGenerico(empresa.Bairro))
			{
				erros += "Bairro está em branco\n";
			}
			if (!validarTelefone(empresa.Telefone))
			{
				erros += "Telefone está em branco\n";
			}
			if (!validarGenerico(empresa.Cidade))
			{
				erros += "Cidade está em branco\n";
			}
			if (!validarGenerico(empresa.Estado))
			{
				erros += "Estado está em branco\n";
			}
			if (!validarEmail(empresa.Email))
			{
				erros += "Email inválido!\n";
			}
			if(erros.Length > 40)
			{
				MessageBox.Show(erros);
				return false;
			}else
				return true;
		}
		public static bool validarComboBox(int valor)
		{
			if (valor == -1)
				return false;
			else
				return true;
		}
		public static bool validarData(string data)
		{
			if (data.Trim().Replace("/", "").Length != 8)
				return false;
			else
				return true;
		}
		public static bool validarValor(float valor)
		{
			if (valor < 0)
				return false;
			else
				return true;
		}
		public static bool validarRecebimento(Recebimento recebimento)
		{
			string erros = "Por favor corrigir os seguintes erros:\n";
			if (!validarGenerico(recebimento.Descricao))
			{
				erros += "Descrição está em branco\n";
			}
			if (!validarComboBox(recebimento.NotaFiscal))
			{
				erros += "Selecione o tipo fiscal!\n";
			}
			if (!validarData(recebimento.Data))
			{
				erros += "Data inválida!\n";
			}
			if (!validarComboBox(recebimento.Tipo))
			{
				erros += "Selecione o tipo prestado!\n";
			}
			if (!validarValor(recebimento.Valor))
			{
				erros += "Valor inválido!\n";
			}
			if (erros.Length > 40)
			{
				MessageBox.Show(erros);
				return false;
			}
			else
				return true;
		}
		public static string diretorioAtual()
		{
			return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
		}

		public static string validarConRecebimento(Recebimento recebimento)
		{
			string sql = "";
			if (validarGenerico(recebimento.Descricao))
			{
				sql += " descricao = '" + recebimento.Descricao + "' AND";
			}
			if (validarComboBox(recebimento.NotaFiscal))
			{
				sql += " fiscal = " + recebimento.NotaFiscal + " AND";
			}
			if (validarData(recebimento.Data))
			{
				sql += " data = '" + recebimento.Data + "' AND";
			}
			if (validarComboBox(recebimento.Tipo))
			{
				sql += " tipo = " + recebimento.Tipo + " AND";
			}
			if (validarValor(recebimento.Valor))
			{
				sql += " valor = " + recebimento.Valor + " AND";
			}
			return sql.Remove(sql.Length -3 );
		}
	}
}
