# Reservey

Sistema de reservas hoteleiras desenvolvido com arquitetura hexagonal e práticas avançadas de engenharia de software.

## Sobre o Projeto

Reservey é uma plataforma de reservas hoteleiras similar ao Airbnb, construída com foco em qualidade de código, testabilidade e manutenibilidade. O projeto implementa conceitos modernos de arquitetura de software e padrões de design para criar uma aplicação robusta e escalável.

## Tecnologias Utilizadas

- C# / .NET
- Entity Framework
- SQL Server

## Arquitetura e Padrões

O projeto implementa as seguintes práticas e padrões de engenharia de software:

**Domain Driven Design (DDD)**
- DTOs (Data Transfer Objects)
- Value Objects
- Entities e Models
- Aggregators
- Bounded Contexts bem definidos

**Hexagonal Architecture**
- Isolamento do domínio de negócio
- Portas e adaptadores
- Comparações com Clean Architecture

**Test Driven Development (TDD)**
- Código altamente testável
- Cobertura de testes unitários próxima a 100%
- Testes como documentação

**CQRS (Command Query Responsibility Segregation)**
- Separação de comandos e queries
- Possibilidade de segregação de leitura e escrita
- Preparado para evolução para microsserviços

**SOLID Principles**
- Single Responsibility Principle
- Open/Closed Principle
- Dependency Inversion com Injeção de Dependência
- Padrões mínimos de qualidade de código

**Design Patterns**
- State Machine Pattern para transições de estado de entidades
- Result Pattern para comunicação entre camadas
- Null Object Pattern para controle de fluxo de exceções

**Outras Práticas**
- Dependency Injection
- Entity Framework com Migrations
- Feature Slicing

## Estrutura do Projeto

O projeto está organizado seguindo os princípios da arquitetura hexagonal, com separação clara entre camadas e responsabilidades bem definidas.

## Pré-requisitos

- .NET SDK (versão compatível)
- SQL Server
- Experiência com C#, .NET e Entity Framework

## Como Executar
```bash
# Clone o repositório
git clone [url-do-repositorio]

# Navegue até o diretório
cd Reservey

# Restaure as dependências
dotnet restore

# Execute as migrations
dotnet ef database update

# Execute o projeto
dotnet run
```

## Contribuindo

Contribuições são bem-vindas. Por favor, abra uma issue para discutir mudanças maiores antes de submeter um pull request.

## Licença

[Especificar licença do projeto]

## Contato

[Suas informações de contato ou links relevantes]
