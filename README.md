# provadotnet

Instale o dotnet 3.1

Pra baixar o projeto use: git clone https://github.com/rodrigoarka/provadotnet.git

Basta digitar no cmd na pasta do projeto: 

dotnet run

GET http://localhost:5000/v1/diff - obtem a Comparação 

POST http://localhost:5000/v1/diff/left - Carrega o Json Left enviado no Body da Requisição

POST http://localhost:5000/v1/diff/right - Carrega o Json Right enviado no Body da Requisição

Dotnet não é minha linguagem nativa, então eu tive alguns problemas pra achar sobre manipulação de arquivos e tratar isso de forma mais profissional. 

