# BancoDigital v1
Implementação de uma API em C# .Net com Swagger, com 3 funcionalidades básicas (Ver saldo, depoistar e debitar).


# Tecnologias Utilizadas.
- dotnet core 5
- entity framework core
- Mysql
- Swagger

# Requisitos
Dotnet
MySQL 

*Modifique a connection string  que fica localizada no arquivo appsettings.json de acordo com a sua configuraçao do Mysql

Execute a o projeto através da sua IDE de preferência ou terminal
Ao executar a API uma interface criada pelo Swagger aparecerá com as acões da API


# Funcionalidades da API

GET /api/Contas/Saldo?conta={conta} -Obtém o saldo existente da conta informada.
Rquest: https://localhost:44369/api/Contas/saldo?conta=23

PUT /api/Contas/Depositar/{conta}/{valor} -Realiza um depósito do valor na conta informada e retorna o numero da conta com  o saldo atualizado
Request Body: 
{
  "conta": "string",
  "saldo": 150
}

PUT /api/Contas/Sacar -Realiza o saque  do valor na conta especificada e retorna o numero da conta com o saldo atualizado, somente se o valor do débito for menor ou igual ao disponível na conta.
{
  "conta": "string",
  "saldo": 150
}

