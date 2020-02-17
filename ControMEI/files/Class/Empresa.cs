using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControMEI.files.Class
{
    class Empresa
    {
        private int id;
        private string cnpj;
        private string razaoSocial;
        private string cep;
        private string endereco;
        private string numero;
        private string complemento;
        private string bairro;
        private string telefone;
        private string cidade;
        private string estado;
        private string email;
        public Empresa(int id, string cnpj, string razaoSocial, string cep, string endereco, string numero, string complemento, string bairro, string telefone, string cidade, string estado, string email)
        {
            this.Id = id;
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Telefone = telefone;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Email = email;
        }
        public Empresa(string cnpj, string razaoSocial, string cep, string endereco, string numero, string complemento, string bairro, string telefone, string cidade, string estado, string email)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.Cep = cep;
            this.Endereco = endereco;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Telefone = telefone;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Email = email;
        }
        public Empresa(int id)
        {
            this.Id = id;
        }

        public int Id { get => id; set => id = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string RazaoSocial { get => razaoSocial; set => razaoSocial = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Email { get => email; set => email = value; }
    }
}
