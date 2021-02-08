# ControlMEI

Software de gerencia para Micro Empreendedor Individual (MEI)
- Cadastro de empresas
- Cadastro de receita (Revenda de Mercadorias, Venda de produtos e Prestação de Serviços)
- Consulta a receitadas cadastradas
- Emissão de relatórios

### CHANGLOG:
##### v0.11.1b - 08/02/2021
- Fix Bug - frmConEmpresa não salva alteração de e-mail

##### v0.11b - 08/02/2021
- Criado metodo para limpar campos em frmCadEmpresa.cs
- Criado metodo para limpar campos em frmCadReceita.cs

##### v0.10b - 04/02/2021
- Criado frmSobre
- Criado metodo para limpar campos em frmConRecebimento

##### v0.9b - 01/02/2021
- Criado frmSelEmpresa
- Caso tenha mais que uma empresa abre o frmSelEmpresa para selecionar a empresa
- Atualizado o metodo Update das classes EmpresaDAO e RecebimentoDAO
- Criado frmConEmpresa
- Alterado a ordem do MenuStrip1


##### v0.8b - 28/01/2021
- Criado método para identificar se nao tem nenhuma empresa cadastrada
- Apos cadastro de empresa habilitar menu
- Removido a ThreadProc

##### v0.7.1b - 23/12/2020
- Criado método para fechar a Thread quando a aplicação for encerrada

##### v0.7b - 23/12/2020
- Criado Thread ThreadProc para monitorar a quantidade de empresas cadastradas

##### v0.6b - 04/04/2020
- Criado botão de atualizar nofrmConRecebimento
- Criado botão de excluir nofrmConRecebimento
- Criado métodos para inserir o dataset no gridview
- Criado método para bindar as informações das linhas do gridview no objeto Recebimento

##### v0.5b - 22/03/2020
- Criando frmConRecebimento
- Alterado o campo valor da tabela Recebimento de VARCHAR para REAL
- Incluido o método SelectAllDataSource que retorna um DataSource para um DataGridView
- Criado método genérico SelectAllDataTable que recebe uma string sql de consulta
- Criado o método validarConRecebimento que monsta a string sql de consulta

##### v0.4b - 15/03/2020
- Criado método genérico para a abertura de fomulários

##### v0.3b - 12/03/2020
- Criado na classe BD.cs a verificação se já existe um banco de dados
- Criando no frmMain.cs uma tela para escolher se estiver mais do que uma espresa cadastrada

##### v0.2b - 11/03/2020
- BD.cs cria o banco de dados no diretorio atual
- Criado o método diretorioAtual na classe Util.cs que retorna uma string do diretorio onde está sendo executado
- Alterado o retorno do método Insert da classe EmpresaDAO para string
- Alterado o retorno do método Insert da classe RecebimentoDAO para string
- Criado o botão sair

##### v0.1b - 10/03/2020
- Adicionado Classe BD.cs 