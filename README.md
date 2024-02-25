# My Games App

Esta é uma aplicação CRUD de gerenciamento de jogos.


## Pré-requisitos

Antes de iniciar, verifique se você tem os seguintes requisitos:

<b>1 - Para rodar na máquina local</b>
- [SDK .NET 7.0](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)

- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## Instalação

Siga as etapas abaixo para configurar o projeto localmente:

<b>1 - Clonando Repositório</b>

1. Clone o repositório:

   ```shell
   git clone https://github.com/maatheux/convert-img-to-pdf-gui.git
   ```

2. Execute este [script sql](scripts-sql/create-database-tables-sql.sql) de criação do banco de dados

3. Crie as variáveis de ambiente para o nome de usuário e senha do banco, e ajuste a a url e porta para acesso do banco

## Uso
Para executar o projeto localmente, siga as etapas abaixo:

<b>1 - Se clonou o repositório</b>

1. Dentro da pasta do projeto abra o terminal e digite o seguinte comando para realizar o build:

    ```shell
    dotnet build
    ```

2. Digite o seguinte comando para executar o projeto:

    ```shell
    dotnet run
    ```
