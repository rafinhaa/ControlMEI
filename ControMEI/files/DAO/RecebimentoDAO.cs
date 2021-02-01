using ControMEI.files.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;


namespace ControMEI.files.DAO
{
    class RecebimentoDAO
    {
        private static SQLiteConnection sqliteConnection = BD.DbConnection();
        private SQLiteDataReader dr;
        private SQLiteCommand cmd;
        private string sql;
        private int returnSql;

        private void Open()
        {
            try
            {
                if (sqliteConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqliteConnection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão " + ex.Message);
            }
        }
        private void Close()
        {
            try
            {
                sqliteConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão " + ex.Message);
            }
        }

        public string Insert(Recebimento recebimento)
        {
            try
            {
                Open();
                sql = "INSERT INTO Recebimento (id_empresa,descricao,data,tipo,fiscal,valor) VALUES (@id_empresa,@descricao,@data,@tipo,@notafiscal,@valor);";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@id_empresa", recebimento.Empresa.Id);
                cmd.Parameters.AddWithValue("@descricao", recebimento.Descricao);
                cmd.Parameters.AddWithValue("@data", recebimento.Data);
                cmd.Parameters.AddWithValue("@tipo", recebimento.Tipo);
                cmd.Parameters.AddWithValue("@notafiscal", recebimento.NotaFiscal);
                cmd.Parameters.AddWithValue("@valor", recebimento.Valor);
                returnSql = cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
                if (returnSql > 0)
                {
                    return "Cadastro efetuado com sucesso!";
                }
                else
                {
                    return "Não foi possível efetuar o cadastro.";
                }

            }
            catch (SqlException ex)
            {
                return "Erro no comando sql:\n" + ex.Message;
            }

        }
        public void Delete(Recebimento recebimento)
        {
            try
            {
                Open();
                sql = "DELETE FROM Recebimento WHERE id = @id";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@id", recebimento.Id);
                returnSql = cmd.ExecuteNonQuery();
                if (returnSql > 0)
                {
                    MessageBox.Show("Remoção concluída");
                }
                else
                {
                    MessageBox.Show("Não foi possível efetuar a remoção");
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
                sql = "SELECT * FROM Recebimento WHERE id = @id";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@id", recebimento.Id);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    recebimentoTemp = new Recebimento(
                        new Empresa(dr.GetInt32(dr.GetOrdinal("id_empresa"))),
                        dr.GetInt32(dr.GetOrdinal("id")),
                        dr["descricao"].ToString(),
                        dr.GetInt32(dr.GetOrdinal("fiscal")),
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
        public List<Recebimento> SelectAllList(Empresa empresa)
        {
            List<Recebimento> recebimentoTemp = new List<Recebimento>();
            try
            {
                Open();
                sql = "SELECT * FROM Recebimento WHERE id_empresa = @id_empresa";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@id_empresa", empresa.Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    recebimentoTemp.Add(new Recebimento(
                        new Empresa(dr.GetInt32(dr.GetOrdinal("id_empresa"))),
                        dr.GetInt32(dr.GetOrdinal("id")),
                        dr["descricao"].ToString(),
                        dr.GetInt32(dr.GetOrdinal("fiscal")),
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
        public DataTable SelectAllDataTable(Empresa empresa)
        {
            var dataTable = new DataTable();
            try
            {
                Open();                
                sql = "SELECT id, id_empresa, descricao, data, tipo, fiscal, round(valor,2) AS valor from recebimento WHERE id_empresa = @id_empresa ORDER BY data ASC";                
                cmd.Parameters.AddWithValue("@id_empresa", empresa.Id);
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sql, sqliteConnection);
                sqlda.SelectCommand.Parameters.AddWithValue("@id_empresa", empresa.Id);
                using (dataTable)
                {
                    sqlda.Fill(dataTable);
                }
                sqlda.Dispose();
                Close();
            }
            catch (Exception ex)
            {
                Close();
                MessageBox.Show("ERRO " + ex.Message);
            }
            return dataTable;
        }
        public DataTable SelectAllDataTable(string values)
        {
            var dataTable = new DataTable();
            try
            {
                Open();
                sql = "SELECT * FROM Recebimento WHERE " + values;
                SQLiteDataAdapter sqlda = new SQLiteDataAdapter(sql, sqliteConnection);
                using (dataTable)
                {
                    sqlda.Fill(dataTable);
                }
                Close();
            }
            catch (Exception ex)
            {
                Close();
                MessageBox.Show("ERRO " + ex.Message);
            }
            return dataTable;
        }        
        public bool Update(Recebimento recebimento)
        {
            int retorno;
            string sql;
            try
            {
                Open();
                sql = "UPDATE Recebimento SET id_empresa = @id_empresa, descricao = @descricao , data = @data, tipo = @tipo, fiscal = @fiscal, valor = @valor WHERE id = @id";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@id_empresa", recebimento.Empresa.Id);
                cmd.Parameters.AddWithValue("@descricao", recebimento.Descricao);
                cmd.Parameters.AddWithValue("@data", recebimento.Data);
                cmd.Parameters.AddWithValue("@tipo", recebimento.Tipo);
                cmd.Parameters.AddWithValue("@fiscal", recebimento.NotaFiscal);
                cmd.Parameters.AddWithValue("@valor", recebimento.Valor);
                cmd.Parameters.AddWithValue("@id", recebimento.Id);
                retorno = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (retorno > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
