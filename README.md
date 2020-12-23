# ControlMEI

Programado com Visual Studio 2019


CHANGLOG:

v0.7b - 23/12/2020
- Criado Thread ThreadProc para monitorar a quantidade de empresas cadastradas

v0.6b - 04/04/2020
- Criado botão de atualizar nofrmConRecebimento
- Criado botão de excluir nofrmConRecebimento
- Criado métodos para inserir o dataset no gridview
- Criado método para bindar as informações das linhas do gridview no objeto Recebimento

v0.5b - 22/03/2020
- Criando frmConRecebimento
- Alterado o campo valor da tabela Recebimento de VARCHAR para REAL
- Incluido o método SelectAllDataSource que retorna um DataSource para um DataGridView
- Criado método genérico SelectAllDataTable que recebe uma string sql de consulta
- Criado o método validarConRecebimento que monsta a string sql de consulta

v0.4b - 15/03/2020
- Criado método genérico para a abertura de fomulários

v0.3b - 12/03/2020
- Criado na classe BD.cs a verificação se já existe um banco de dados
- Criando no frmMain.cs uma tela para escolher se estiver mais do que uma espresa cadastrada

v0.2b - 11/03/2020
- BD.cs cria o banco de dados no diretorio atual
- Criado o método diretorioAtual na classe Util.cs que retorna uma string do diretorio onde está sendo executado
- Alterado o retorno do método Insert da classe EmpresaDAO para string
- Alterado o retorno do método Insert da classe RecebimentoDAO para string
- Criado o botão sair

v0.1b - 10/03/2020
- Adicionado Classe BD.cs 