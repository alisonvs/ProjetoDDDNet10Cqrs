# 🚀 ProjetoDDDNet10

Projeto exemplo utilizando **.NET 10**, aplicando conceitos avançados de arquitetura moderna:

- ✅ Clean Architecture  
- ✅ DDD (Domain-Driven Design)  
- ✅ CQRS  
- ✅ MediatR  
- ✅ Domain Events  
- ✅ Unit of Work  
- ✅ FakeDb (modo demonstração)  
- ✅ SQL Server  
- ✅ Swagger  
- ✅ Serilog (Logging)  
- ✅ API Versioning  

---

# 🏗️ Arquitetura

O projeto segue o padrão **Clean Architecture**, dividido em camadas independentes:

ProjetoDDDNet10
│
├── src
│ ├── ProjetoDDDNet10.Domain
│ ├── ProjetoDDDNet10.Application
│ ├── ProjetoDDDNet10.Infrastructure
│ └── ProjetoDDDNet10.API
│
└── tests
└── ProjetoDDDNet10.Tests


---

# 📂 Estrutura das Camadas

## 🔵 Domain
Contém regras de negócio puras.

- Entities  
- Domain Events  
- BaseEntity  
- Interfaces  

Não depende de nenhuma outra camada.

---

## 🟢 Application
Contém:

- Commands  
- Queries  
- Handlers  
- Interfaces de Repositório  
- Interfaces de UnitOfWork  

Implementa CQRS usando MediatR.

---

## 🟡 Infrastructure
Implementação técnica:

- Repositórios  
- DbContext (EF Core ou FakeDb)  
- Persistência  
- Integrações externas  

---

## 🔴 API
Camada de entrada (Presentation):

- Controllers  
- Configuração de DI  
- Swagger  
- Logging  
- Versionamento  

---

# 🔥 Tecnologias Utilizadas

- .NET 10  
- ASP.NET Core  
- MediatR  
- Entity Framework Core  
- SQL Server  
- Serilog  
- Swagger  

---

# ⚙️ Como Rodar o Projeto

## 1️⃣ Clonar repositório

```bash
git clone https://github.com/seuusuario/ProjetoDDDNet10.git
cd ProjetoDDDNet10
