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

8. Definir a porta que o client vai poder ter acesso, para isto, acessar o projeto "01 - Web | MinutradeApp | App_Start | WebApiConfig.cs". Na variável corsAttr, certificar que o caminho é o mesmo de onde a parte client será executada.

9. A parte client está disponível no caminho "Minutrade | MinutradeApp | Client"

10. Executá-la em um servidor cujo caminho seja igual ao configurado no passo 8.

11. Executar a aplicação na parte server e client.



