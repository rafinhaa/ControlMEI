using ControMEI.files.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace ControMEI.files.DAO
{    
    class RecebimentoDAO
    {
        private readonly SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rafinhaa\source\repos\SimplesMEI\SimplesMEI\Database.mdf;Integrated Security=True");
        private SqlDataReader dr;
        private SqlCommand cmd;
        private string sql;
        private int returnSql;

        public void Open()
        {
            try
            {
                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão " + ex.Message);
            }
        }
        public void Close()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão " + ex.Message);
            }
        }

        public void Insert(Recebimento recebimento)
        {
            try
            {
                Open();
                sql = "INSERT INTO Recebimento (id_empresa,data,tipo,fiscal,valor) VALUES (@id_empresa,@descricao@data,@tipo,@notafiscal,@valor);";
                cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id_empresa", recebimento.Empresa.Id);
                cmd.Parameters.AddWithValue("@descricao", recebimento.Descricao);
                cmd.Parameters.AddWithValue("@data", recebimento.Data);
                cmd.Parameters.AddWithValue("@tipo", recebimento.Tipo);
                cmd.Parameters.AddWithValue("@notafiscal", recebimento.NotaFiscal);
                cmd.Parameters.AddWithValue("@valor", recebimento.Valor);
                returnSql = cmd.ExecuteNonQuery();
                if (returnSql > 0)
                {
                    MessageBox.Show("Cadastro efetuado");
                }
                else
                {
                    MessageBox.Show("Cadastro não realizado");
                }
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }

        }

        public void Delete(Recebimento recebimento)
        {
            try
            {
                conexao.Open();
                sql = "DELETE Recebimento WHERE id = @id";
                cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", recebimento.Id);
                returnSql = cmd.ExecuteNonQuery();
                if (returnSql > 0)
                {
                    MessageBox.Show("Cadastro efetuado");
                }
                else
                {
                    MessageBox.Show("Cadastro não realizado");
                }
                cmd.Dispose();
                //conexao.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }

        }
        public Recebimento Select(Recebimento recebimento)
        {
            Recebimento recebimentoTemp = null;
            try
            {
                Open();
                sql = "SELECT * FROM Receita WHERE id = @id";
                cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", recebimento.Id);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    recebimentoTemp = new Recebimento(
                        new Empresa(dr.GetInt32(dr.GetOrdinal("id_empresa"))),
                        dr.GetInt32(dr.GetOrdinal("id")),
                        dr["descricao"].ToString(),
                        dr.GetInt32(dr.GetOrdinal("notafiscal")),                        
                        dr["data"].ToString(),
                        dr.GetInt32(dr.GetOrdinal("tipo")),
                        dr.GetFloat(dr.GetOrdinal("valor"))
                        );
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }
            return recebimentoTemp;
        }
        public List<Recebimento> SelectAll()
        {
            List<Recebimento> recebimentoTemp = new List<Recebimento>();
            try
            {
                Open();
                sql = "SELECT * FROM Recebimento";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    recebimentoTemp.Add(new Recebimento(
                        new Empresa(dr.GetInt32(dr.GetOrdinal("id_empresa"))),
                        dr.GetInt32(dr.GetOrdinal("id")),
                        dr["descricao"].ToString(),
                        dr.GetInt32(dr.GetOrdinal("notafiscal")),
                        dr["data"].ToString(),
                        dr.GetInt32(dr.GetOrdinal("tipo")),
                        dr.GetFloat(dr.GetOrdinal("valor"))
                        ));
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }
            return recebimentoTemp;
        }
        public void Update(Recebimento recebimento)
        {
            int retorno;
            string sql;
            try
            {
                Open();
                sql = "UPDATE RECEITA SET id_empresa = @id_empresa, descricao = @descricao , data = @data, tipo = @tipo, fiscal = @fiscal, valor = @valor WHERE id = @id";
                cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id_empresa", recebimento.Empresa.Id);
                cmd.Parameters.AddWithValue("@descricao", recebimento.Data);
                cmd.Parameters.AddWithValue("@data", recebimento.Data);
                cmd.Parameters.AddWithValue("@tipo", recebimento.Tipo);
                cmd.Parameters.AddWithValue("@fiscal",recebimento.NotaFiscal);
                cmd.Parameters.AddWithValue("@valor", recebimento.Valor);
                cmd.Parameters.AddWithValue("@id", recebimento.Id);
                retorno = cmd.ExecuteNonQuery();
                if (retorno > 0)
                {
                    MessageBox.Show("Cadastro efetuado");
                }
                else
                {
                    MessageBox.Show("Cadastro não realizado");
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }
        }
    }
}
