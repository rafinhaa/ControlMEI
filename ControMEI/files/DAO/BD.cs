using System;
using System.Data.SQLite;

namespace ControMEI.files.DAO
{
    class BD
    {
        private static string diretorioBD = Util.Util.diretorioAtual() + "\\database.sqlite";
        private static SQLiteConnection sqliteConnection;
        public static SQLiteConnection DbConnection()
        {   
            sqliteConnection = new SQLiteConnection("Data Source=" + diretorioBD + "; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQLite()
        {
            if (!System.IO.File.Exists(diretorioBD))
            {
                try
                {
                    SQLiteConnection.CreateFile(@"" + diretorioBD);
                    CriarTabelaSQlite();
                }
                catch
                {
                    throw;
                }
            }                
        }
        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Empresa ( "     +
                            "id INTEGER PRIMARY KEY AUTOINCREMENT,"               +
                            "razaosocial VARCHAR,"                                +
                            "cnpj VARCHAR,"                                       +
                            "cep VARCHAR,"                                        +
                            "endereco VARCHAR,"                                   +
                            "numero VARCHAR,"                                     +
                            "complemento VARCHAR,"                                +
                            "bairro VARCHAR,"                                     +
                            "telefone VARCHAR,"                                   +
                            "cidade VARCHAR,"                                     +
                            "estado VARCHAR,"                                     +
                            "email VARCHAR"                                       +
                            ")";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Recebimento ( " +
                            "id INTEGER PRIMARY KEY AUTOINCREMENT,"               +
                            "id_empresa INT,"                                     +
                            "descricao VARCHAR,"                                  +
                            "data VARCHAR,"                                       +
                            "tipo INT,"                                           +
                            "fiscal INT,"                                         +
                            "valor REAl,"                                         +
                            "FOREIGN KEY(id_empresa) REFERENCES empresa(id)"      +
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
