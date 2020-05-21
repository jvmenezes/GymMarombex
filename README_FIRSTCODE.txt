README

/****
Usando técnica de FISRTCODE com EntityFramework e SQLServer
****/

1. - Criar um arquivo de extensão UDF na área de trabalho
 1.1 - Depois execute esse arquivo
 1.2 - Na guia CONEXÃO
   1.2.1 - No campo nome do servidor, coloque o IP do servidor ou o nome da sua máquina caso queira utilizar um banco local
   1.2.2 - Inserir usuário e senha de acordo com a autenticação necessária
   1.2.3 - Selecione o banco de dados no servidor, caso não exista o banco, crie um para utilização
 1.3 - Clique no botão "Testar Conexão"
   1.3.1 - Se houver êxito, significa que tudo deu certo, sendo assim, salve e feche a janela
 1.4 - Edite esse arquivo de extensão UDF no bloco de notas, e pegue a CONNECTIONSTRING que ele gerou, desconsidere apenas a primeira chave PROVIDER

2.0 - Utlize a "connectionString" pega no 1.4, e adicione no Web.Config o trecho abaixo dando um nome para a sua "connectionString"
  <connectionStrings>
    <add name="MarombexConnectionString" connectionString="Password=123456;Persist Security Info=True;User ID=autoMEGenerator;Initial Catalog=Marombex;Data Source=ME003153" providerName="System.Data.SqlClient"/>
  </connectionStrings>

3. Ir em Package Manager e adicionar o pacote do EntityFramework
Install-Package EntityFramework

4. Para criar as tabelas no seu banco de dados, basta dar os comandos abaixo
Enable-Migrations  //Habilita o migrations na aplicação
Add-Migration Initial  //Criará uma classe que será usada para persistir a estrutura de código na base de dados 
update-database    //Atualiza a estrutura da base de dados a partir da classe criada no comando acima

5. Se precisar Criar/Alterar novas estruturas na base, usar os dois comandos abaixo:
Add-Migration Add_Coluna_Alunos_Idade  //Criará uma classe que será usada para persistir a estrutura de código na base de dados 
update-database    //Atualiza a estrutura da base de dados a partir da classe criada no comando acima


https://www.youtube.com/watch?v=KQ3CAUnDaSM
Desc: Code First com ASP.NET MVC + Entity Framework