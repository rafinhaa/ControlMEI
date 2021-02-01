using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControMEI.files.Class
{
    class Recebimento
    {
        private int id;
        private string descricao;
        private int notaFiscal;
        private string data;
        private int tipo;
        private float valor;        
        private Empresa empresa;

        public Recebimento(Empresa empresa)
        {
            this.empresa = empresa;
        }
        public Recebimento(Empresa empresa, string descricao, int notaFiscal, string data, int tipo, float valor)
        {
            this.Descricao = descricao;
            this.NotaFiscal = notaFiscal;
            this.Data = data;
            this.Tipo = tipo;
            this.Valor = valor;
            this.Empresa = empresa;
        }
        public Recebimento(Empresa empresa, int id, string descricao, int notaFiscal, string data, int tipo, float valor )
        {
            this.Id = id;
            this.Descricao = descricao;
            this.NotaFiscal = notaFiscal;
            this.Data = data;
            this.Tipo = tipo;
            this.Valor = valor;
            this.Empresa = empresa;
        }

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int NotaFiscal { get => notaFiscal; set => notaFiscal = value; }
        public string Data { get => data; set => data = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public float Valor { get => valor; set => valor = value; }
        internal Empresa Empresa { get => empresa; set => empresa = value; }

        public override string ToString()
        {
            return "Id: " + Id +
                    "\nDescricao: " + Descricao +
                    "\nNotaFiscal: " + NotaFiscal +
                    "\nData: " + Data +
                    "\nTipo: " + Tipo +
                    "\nTipoalor: " + Valor +
                    "\nEmpresa: " + Empresa;
        }
    }
}
