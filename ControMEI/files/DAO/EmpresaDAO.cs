﻿using ControMEI.files.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ControMEI.files.DAO
{
    class EmpresaDAO
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

        public string Insert(Empresa empresa)
        {
            try
            {
                Open();                
                sql = "INSERT INTO Empresa (razaosocial,cnpj,cep,endereco,numero,complemento,bairro,telefone,cidade,estado,email) VALUES (@razaosocial,@cnpj,@cep,@endereco,@numero,@complemento,@bairro,@telefone,@cidade,@estado,@email);";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@razaosocial", empresa.RazaoSocial);
                cmd.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                cmd.Parameters.AddWithValue("@cep", empresa.Cep);
                cmd.Parameters.AddWithValue("@endereco", empresa.Endereco);
                cmd.Parameters.AddWithValue("@numero", empresa.Numero);
                cmd.Parameters.AddWithValue("@complemento", empresa.Complemento);
                cmd.Parameters.AddWithValue("@bairro", empresa.Bairro);
                cmd.Parameters.AddWithValue("@telefone", empresa.Telefone);
                cmd.Parameters.AddWithValue("@cidade", empresa.Cidade);
                cmd.Parameters.AddWithValue("@estado", empresa.Estado);
                cmd.Parameters.AddWithValue("@email", empresa.Email);
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
        public void Delete(Empresa empresa)
        {
            try
            {
                //conexao.Open();
                sql = "DELETE Empresa WHERE id = @id";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@id", empresa.Id);
                returnSql = cmd.ExecuteNonQuery();
                if (returnSql > 0)
                {
                    MessageBox.Show("Exclusão efetuado");
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
        public Empresa Select(Empresa empresa)
        {
            Empresa empresaTemp = null;
            try
            {
                Open();
                sql = "SELECT * FROM Empresa WHERE id = @id";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@id", empresa.Id);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    empresaTemp = new Empresa(empresa.Id,
                        dr["razaosocial"].ToString(),
                        dr["cnpj"].ToString(),
                        dr["cep"].ToString(),
                        dr["endereco"].ToString(),
                        dr["numero"].ToString(),
                        dr["complemento"].ToString(),
                        dr["bairro"].ToString(),
                        dr["telefone"].ToString(),
                        dr["cidade"].ToString(),
                        dr["estado"].ToString(),
                        dr["email"].ToString());
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }
            return empresaTemp;
        }
        public List<Empresa> SelectAll()
        {
            List<Empresa> empresaTemp = new List<Empresa>();
            try
            {
                Open();
                sql = "SELECT * FROM Empresa";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empresaTemp.Add(new Empresa(dr.GetInt32(dr.GetOrdinal("Id")),
                        dr["razaosocial"].ToString(),
                        dr["cnpj"].ToString(),
                        dr["cep"].ToString(),
                        dr["endereco"].ToString(),
                        dr["numero"].ToString(),
                        dr["complemento"].ToString(),
                        dr["bairro"].ToString(),
                        dr["telefone"].ToString(),
                        dr["cidade"].ToString(),
                        dr["estado"].ToString(),
                        dr["email"].ToString()));
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }
            return empresaTemp;
        }
        public void Update(Empresa empresa)
        {
            int retorno;
            string sql;
            try
            {
                Open();                
                sql = "UPDATE Empresa SET razaosocial = @razaosocial, cnpj = @cnpj, cep = @cep, endereco = @endereco, numero = @numero, complemento = @complemento, bairro = @bairro, telefone = @telefone, cidade = @cidade, estado = @estado, email = @email WHERE id = @id";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                cmd.Parameters.AddWithValue("@razaosocial", empresa.RazaoSocial);
                cmd.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                cmd.Parameters.AddWithValue("@cep", empresa.Cep);
                cmd.Parameters.AddWithValue("@endereco", empresa.Endereco);
                cmd.Parameters.AddWithValue("@numero", empresa.Numero);
                cmd.Parameters.AddWithValue("@complemento", empresa.Complemento);
                cmd.Parameters.AddWithValue("@bairro", empresa.Bairro);
                cmd.Parameters.AddWithValue("@telefone", empresa.Telefone);
                cmd.Parameters.AddWithValue("@cidade", empresa.Cidade);
                cmd.Parameters.AddWithValue("@estado", empresa.Estado);
                cmd.Parameters.AddWithValue("@email", empresa.Email);
                retorno = cmd.ExecuteNonQuery();
                if (retorno > 0)
                {
                    MessageBox.Show("Atualização efetuado");
                }
                else
                {
                    MessageBox.Show("Atualização não realizado");
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }
        }
        public int checkEmpresa()
        {
            int result = 0;
            try
            {
                Open();
                sql = "SELECT COUNT(*) as countEmp FROM  Empresa";
                cmd = new SQLiteCommand(sql, sqliteConnection);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    result = dr.GetInt32(dr.GetOrdinal("countEmp"));
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                //return "Erro no comando sql:\n" + ex.Message;
            }
            return result;
        }
    }
}
