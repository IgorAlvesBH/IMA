# Client App
Projeto criado com objetivo de atender aos requisitos do processo seletivo da Minutrade. Foram utilizadas as tecnologias:
- WebApi
- AngularJS
- Entity Framework
- SQL Server
- Ninject

Não optei pelo MEAN Stack em função do tempo para desenvolver o app, dessa forma, preferi desenvolver a solução em .Net.

##Instruções:
1. É preciso instalar o .Net framework 4.6.1
 > https://www.microsoft.com/pt-br/download/details.aspx?id=49981

2. Abrir a solution dentro da pasta Minutrade

3. Acessar o projeto MinutradeApp.Data localizado na pasta "04 - Data" e em seguida abrir o arquivo SqlRepository.cs e definir os dados de acesso ao SQL Server (Se executar a aplicação pelo VS não é preciso executar este passo).

![SqlConnection](/Minutrade/screens/SqlConnection.png?raw=true "SqlConnection")

4. Certificar que a string de conexão com o banco está correta.

5. Acessar on VS o caminho "View | Other windows e clicar em Package Manager Console"

6. Acessar o Package Manager Console e na opção Default Project, selecionar "MinutradeApp.Data"

7. Executar o comando update-database (Será criado o banco de dados no final da execução)

![CreateDataBase](/Minutrade/screens/CreateDataBase.png?raw=true "CreateDataBase")

8. Definir a porta que o client vai poder ter acesso, para isto, acessar o projeto "01 - Web | MinutradeApp | App_Start | WebApiConfig.cs". Na variável corsAttr, certificar que o caminho é o mesmo de onde a parte client será executada.

![Client_Url_Permission](/Minutrade/screens/Client_Url_Permission.png?raw=true "Client_Url_Permission")

9. A parte client está disponível no caminho "Minutrade | MinutradeApp | Client"

10. Executá-la em um servidor cujo caminho seja igual ao configurado no passo 8.

11. Executar a aplicação na parte server e client.

##API
Todos os dados são retornados no formato JSon, abaixo os serviços:

***GET* /clients**
Não possui parâmetros, retorna uma lista com todos os registros da base.

***GET* /clients/CPF**
Retorna o cliente de acordo com o CPF informado. 

***PUT* /clients/Client**
Atualiza a entidade cliente

***PUT* /clients/CPF**
Remove o cliente de acordo com o CPF informado.

## Teste
Abaixo a imagem do teste de integração e unidade criados:
![TestExplorer](/Minutrade/screens/TestExplorer.png?raw=true "TestExplorer")

##Aplicação em execução
- Tela inicial:
![Index](/Minutrade/screens/Index.png?raw=true "Index")

-Detalhe:
![View](/Minutrade/screens/View.png?raw=true "View")

-Edição:
![Edit](/Minutrade/screens/Edit.png?raw=true "Edit")

-Inclusão:
![New](/Minutrade/screens/New.png?raw=true "New")

- Parte server:
Url para retornar os dados:
http://localhost:58723/api/Client
