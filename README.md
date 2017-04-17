# README #


Seja bem vindo a aplicação financeira. Nela você poderá cadastrar contas e lançar transações.
Os métodos estão sem autenticação de usuário.
Estamos em contrução da aplicação, e só é possível utilizar a aplicação através de métodos Web.Api. Abaixo você encontrará os métodos disponíveis.


### Cadastro de Conta ###
  
Métodos para CRUD da conta  
  
URL  
* GET /api/BankAccount : Obter todas as contas  
* GET /api/BankAccount/1 : Obter conta com o Id 1  
* POST /api/BankAccount : Cadastrar conta  
* PUT /api/BankAccount : Alterar conta  
  
Para os métodos POST e PUT, segue formato do Json:  
>{  
>"AccountId": 2,  
>"BankName": "Itaú",  
>"AccountAgency": "9345",  
>"AccountNumber": "243487-8",  
>"AccountDescription": "Conta Secundária"  
>}  
  
### Transações ###
  
Métodos para lançar transações  
  
URL  
* GET /api/Transaction : Obter todas as transações limitadas aos 2 últimos meses  
* GET /api/Transaction/1 : Obter transações da conta com o Id 1. Transações limitadas aos 2 últimos meses  
* GET /api/Transaction/GetSummary : Obter resumo agrupado por Conta, Ano e Mês  
* POST /api/Transaction : Cadastrar transação  
* PUT /api/Transaction : Alterar Transação  
* DELETE /api/Transaction/1 : Remover Transação com o Id 1  
  
Para os métodos POST e PUT, segue formato do Json:  
>{  
>"TransactionId": 3,  
>"AccountId": 1,   
>"TransactionValue": 50.00,  
>"InclusionDate": "2017-03-15T18:25:43.511Z",  
>"TransactionDescription": "Transação 001",  
>"Capitalization": false,  
>"AccountTransfer": false  
>}  
  
