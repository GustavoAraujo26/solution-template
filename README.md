# Desafio Autoglass - API de produtos

> ### Introdução

API de gestão de produtos criada em .NET 5 seguindo as regras propostas no desafio prático de programação da Autoglass.

Na pasta [VideoApresentacao](https://github.com/GustavoAraujo26/api-produtos-autoglass/tree/master/VideoApresentacao) consta video com explicação da arquitetura e execução do projeto em si.

Sobre as entidades, a aplicação possui 2 principais: "Produto" e "Fornecedor", sendo que o segundo está atrelado ao primeiro. 

Sobre os recursos disponíveis:
* Recuperar um registro por código;
* Listar registros filtrando a partir de parâmetros e paginando a resposta;
* Inserir;
* Editar;
* Excluir registro de forma lógica.

Além disso, como proposto no desafio, para a entidade de produto, é necessário inserir validação para que a data de fabricação não seja maior ou igual a data de validade.

> ### Campos
Para produto, foram determinados os seguintes campos:
* Código (sequencial e não nulo);
* Descrição;
* Situação (Ativo ou inativo);
* Data de fabricação;
* Data de validade.

Já para fornecedor, foram determinados  os seguintes campos:
* Código;
* Descrição;
* CNPJ.

> ### Requisitos Obrigatórios

Foi proposto como requisito obrigatório os seguintes itens:
* Construção de WebAPI em .Net ou .NET 5;
* Construção da estrutura em camadas e em DDD;

Já como diferenciais, foram propostos os seguintes pontos:
* Utilizar ORM
* Utilizar a biblioteca AutoMapper para fazer o mapeamento entity-DTO;
* Fazer teste unitário

> ### Funcionalidades

Com os requisitos definidos, foram criados 6 endpoints para cada entidade (produto e fornecedor), seguindo os padrões RESTFUL.

* POST para criação do produto/fornecedor;
* DELETE para alteração da situação do produto/fornecedor para "inativo";
* PUT edição do produto/fornecedor;
* PATCH para alteração da situação do produto/fornecedor para "ativo";
* GET para retornar produto/fornecedor pelo seu código;
* POST passando dados de pesquisa para retorno de produtos/fornecedores de forma paginada.

Além disso, a API conta com outros 2 endpoints, os quais fazem o controle da configuração do banco de dados.

Outro ponto importate para ressaltar, é que a API conta com versionamento, sendo divida no seguinte formato:
* V1: endpoints de produto;
* V2: endpoints de fornecedor;
* V3: endpoints de configuração do banco de dados.

> ### Banco de dados e ORM

Para persistência dos dados, foi escolhido o SQL Server, sendo utilizado via Docker.

Para configuração do mesmo, basta executar os comandos abaixo no console (caso tenha o Docker instalado):

Comando para baixar a imagem do SQL Server:

``
docker pull mcr.microsoft.com/mssql/server
``

Comando para criar o volume físico para persistência do banco:

``
docker volume create sqlserver
``

Comando para criação e execução do Docker contendo o SQL server:

``
docker run --name sql_server -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=1q2w3e4r@#$' -p 1433:1433 -v sqlserver -d mcr.microsoft.com/mssql/server
``

Após criado o Docker contendo o banco basta executar a API. No caso a string de conexão utilizada no projeto encontra-se no [lauchSettings.json](https://github.com/GustavoAraujo26/api-produtos-autoglass/blob/master/API/AutoGlassProducts.Api/Properties/launchSettings.json).

Outro ponto para ressaltar é que na string de conexão, não pode constar o nome do banco de dados. A API possui um "HostedService" responsável por criar automaticamente o banco junto com as tabelas.

Por último, mas não menos importante, o ORM utilizado foi o Dapper.

> ### Principais Bibliotecas utilizadas
* **Asp.Versioning.Mvc.ApiExplorer 6.4.0**: utilizado para fazer o versionamento da API;
* **GustavoAraujo26.ArchitectureTools 1.2.2**: [biblioteca de autoria](https://github.com/GustavoAraujo26/architecture-tools) própria para reutilização de classes/extensões e afins na arquitetura;
* **Serilog 4.0.0**: utilizado para controlar os logs da aplicação;
* **Swashbuckle.AspNetCore 5.6.3**: utilizado para expor a documentação da API;
* **FluentValidation 11.9.2**: utilizado para construir as validações das requisições;
* **MediatR 12.3.0**: utilizado para implementar o design pattern "Mediator", com o intuito de diminuir o acomplamento interno da aplicação;
* **AutoMapper 10.0.0**: utilizado para realizar os mapeamentos na aplicação;
* **Scrutor 4.2.2**: utilizado para realizar as injeções de dependência de forma automática;
* **AutoBogus 2.13.1**: utilizado para gerar massa de dados utilizada nos testes;
* **Dapper 2.1.35**: ORM utilizado na aplicação;
* **Moq 4.20.70**: utilizado nos testes unitários para mockar as chamadas no repositório;
* **xunit 2.4.2**: utilizado para realizar os testes unitários.