📌 Changelog

Todas as mudanças relevantes deste projeto serão documentadas aqui.
Este arquivo segue o padrão Keep a Changelog e a convenção de versionamento semântico (SemVer).

 - 2025-07-24

🎉 Added

- Estrutura de projeto organizada por camadas (Controllers, DTOs, Services, Validators etc.)

- CRUD completo para Usuários e Contatos com relação 1:N

- Sistema de autenticação JWT com claims e roles

- Middleware para tratamento global de exceções

- Validações com FluentValidation

- Proteção de rotas com [Authorize] e [Authorize(Roles = "Admin")]

- Documentação via Swagger com suporte a autenticação Bearer JWT

- Testes unitários para:

  - AuthService

  - UserService

  - ContactService

  - Controllers

  - Middleware

  - TokenService

  - DTOs (validações)

✨ Melhorias

- Interface Swagger personalizada com instruções de uso do JWT

- Token JWT enriquecido com claims de identificação, roles e jti

- README.md completo com instruções e prints

