﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace ControMEI.files.DAO
{
    class BD
    {
        private static SQLiteConnection sqliteConnection;
        public static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\Cadastro.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"c:\Cadastro.sqlite");
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Empresa ( " +
                            "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                            "razaosocial VARCHAR,                  " +
                            "cnpj VARCHAR,                         " +
                            "cep VARCHAR,                          " +
                            "endereco VARCHAR,                     " +
                            "numero VARCHAR,                       " +
                            "complemento VARCHAR,                  " +
                            "bairro VARCHAR,                       " +
                            "telefone VARCHAR,                     " +
                            "cidade VARCHAR,                       " +
                            "estado VARCHAR,                       " +
                            "email VARCHAR                         " +
                            ")";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Recebimento ( " +
                            "id INTEGER PRIMARY KEY AUTOINCREMENT,          " +
                            "id_empresa INT,                                " +
                            "data VARCHAR,                                  " +
                            "tipo VARCHAR,                                  " +
                            "fiscal VARCHAR,                                " +
                            "valor VARCHAR,                                 " +
                            "FOREIGN KEY(id_empresa) REFERENCES empresa(id) " +
                            ")";
                    cmd.ExecuteNonQuery();
                    sqliteConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
