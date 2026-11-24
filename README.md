# Mini ERP — Pedidos e Estoque

Sistema de gestão de **produtos, clientes, pedidos e estoque**, construído com **.NET 10 (C#)** no back-end e **Angular** no front-end.

O projeto evolui em fases, cada uma adicionando uma camada comum em sistemas corporativos: API REST, persistência, testes, containers, autenticação, CI/CD, integração com sistema legado, NoSQL e cloud.

## Stack

| Camada | Tecnologia |
|---|---|
| API | ASP.NET Core Web API (.NET 10, C#) |
| ORM | Entity Framework Core |
| Banco relacional | PostgreSQL 17 |
| Documentação da API | OpenAPI + Swagger UI |
| Front-end | Angular *(em breve)* |
| Infra local | Docker / Docker Compose |

## Como rodar

**Pré-requisitos:** [.NET 10 SDK](https://dotnet.microsoft.com/download) e [Docker](https://www.docker.com/).

```bash
# 1. Subir o banco de dados
docker compose up -d

# 2. Rodar a API
dotnet run --project src/MiniErp.Api
```

## Estrutura

```
mini-erp/
├── src/
│   └── MiniErp.Api/        # API REST (ASP.NET Core)
├── docker-compose.yml      # PostgreSQL para desenvolvimento
└── MiniErp.slnx            # Solution .NET
```

## Roadmap

- [x] Estrutura da solução e banco de dados via Docker
- [ ] **Fase 1** — CRUD de Produtos, Clientes e Pedidos (EF Core + PostgreSQL + Swagger)
- [ ] **Fase 2** — Testes unitários e de integração (xUnit)
- [ ] **Fase 3** — Front-end em Angular
- [ ] **Fase 4** — Aplicação completa em containers (Docker Compose)
- [ ] **Fase 5** — Autenticação e autorização com JWT
- [ ] **Fase 6** — Pipeline de CI com GitHub Actions
- [ ] **Fase 7** — Integração com módulo legado de faturamento em PHP
- [ ] **Fase 8** — Auditoria de pedidos com MongoDB
- [ ] **Fase 9** — Deploy no Azure (App Service + Functions)
- [ ] **Fase 10** — Mensageria (RabbitMQ) e infraestrutura como código (Terraform)

## Autor

**Brenno Vilela** — Desenvolvedor Full Stack
