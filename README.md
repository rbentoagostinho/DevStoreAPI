# DevStore API

API RESTful desenvolvida em .NET 8 seguindo padrões de Clean Architecture e DDD.


## 🚀 Configuração do Ambiente



No arquivo appsettings.json, atualize uma string de conexão:
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=devstore;Username=seu_usuario;Password=sua_senha"
}



Executar como migrações
cd src/Ambev.DeveloperEvaluation.WebApi
dotnet ef database update

Executando o Projeto

Por meio do Visual Studio 2022


Abra a soluçãoDevStoreAPI.sln
Defina o projeto Ambev.DeveloperEvaluation.WebApicomo projeto de inicialização
Pressione F5 para iniciar

A API estará disponível em:

https://localhost:7181/swagger (HTTPS)
http://localhost:5119/swagger (HTTP)

Executando todos os testes

 Estrutura do Projeto
 DevStoreAPI/
├── src/
│   ├── Ambev.DeveloperEvaluation.Application/  # Camada de aplicação
│   ├── Ambev.DeveloperEvaluation.Common/       # Código compartilhado
│   ├── Ambev.DeveloperEvaluation.Domain/       # Camada de domínio
│   ├── Ambev.DeveloperEvaluation.IoC/          # Injeção de dependência
│   ├── Ambev.DeveloperEvaluation.ORM/          # Acesso a dados
│   └── Ambev.DeveloperEvaluation.WebApi/       # API REST
└── tests/
    ├── Ambev.DeveloperEvaluation.Functional/   # Testes funcionais
    ├── Ambev.DeveloperEvaluation.Integration/  # Testes de integração
    └── Ambev.DeveloperEvaluation.Unit/         # Testes unitários

     Regras de Negócio
Vendas

Compras acima de 4 itens idênticos têm 10% de desconto
Compras entre 10 e 20 itens idênticos têm 20% de desconto
Não é possível vender acima de 20 itens idênticos
Compras abaixo de 4 itens não podem ter desconto

Endpoints Disponíveis
Produtos

GET /api/products- Lista de todos os produtos
GET /api/products/{id}- Obtenha um produto específico
POST /api/products- Cria um novo produto
PUT /api/products/{id}- Atualiza um produto
DELETE /api/products/{id}- Remover um produto

Vendas

GET /api/sales- Lista todas as vendas
GET /api/sales/{id}- Obter uma venda específica
POST /api/sales- Cria uma nova venda
PUT /api/sales/{id}/cancel- Cancela uma venda