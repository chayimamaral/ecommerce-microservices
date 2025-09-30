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
