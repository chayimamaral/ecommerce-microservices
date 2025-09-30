# Ecommerce Microservices

Este repositório contém uma aplicação de microserviços em .NET 9 com PostgreSQL e RabbitMQ para gerenciamento de estoque e vendas.

## Estrutura

- StockService: Microserviço de estoque
- SalesService: Microserviço de vendas
- ApiGateway: API Gateway para redirecionamento de rotas
- Common: Código compartilhado (DTOs, JWT, RabbitMQ)
- images: Capturas de tela/documentação

## Como Rodar

1. Configure o PostgreSQL e RabbitMQ (ex: via Docker)
2. Configure connection strings nos appsettings.json
3. Execute os microserviços:
```
dotnet run --project StockService
dotnet run --project SalesService
dotnet run --project ApiGateway
```


Estrutura do Projeto

ecommerce-microservices/
│
├── ApiGateway/                # API Gateway (redireciona para microserviços)
│   ├── Program.cs
│   ├── appsettings.json
│   └── Startup.cs (se necessário)
│
├── EstoqueService/          # Microserviço de Estoque
│   ├── Controllers/
│   │   └── ProductsController.cs
│   ├── Models/
│   │   └── Produto.cs
│   ├── Data/
│   │   └── EstoqueDbContext.cs
│   ├── Services/
│   │   └── EstoqueService.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── VendaService/          # Microserviço de Vendas
│   ├── Controllers/
│   │   └── VendaController.cs
│   ├── Models/
│   │   └── Venda.cs
│   ├── Data/
│   │   └── VendaDbContext.cs
│   ├── Services/
│   │   └── VendaService.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── common/                     # Código compartilhado entre microserviços
│   ├── DTOs/
│   │   ├── ProdutoDto.cs
│   │   └── VendaDto.cs
│   ├── Messaging/
│   │   └── RabbitMQPublisher.cs
│   └── Security/
│       └── JwtHandler.cs
│
├── docker-compose.yml           # Para rodar PostgreSQL + RabbitMQ + serviços
├── README.md
└── .gitignore
