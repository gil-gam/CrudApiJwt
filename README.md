# 📦 CrudApiJwt

API RESTful desenvolvida com ASP.NET Core 8, Entity Framework Core e autenticação via JWT. Permite gerenciamento de usuários e seus contatos pessoais, com proteção de rotas e autenticação baseada em tokens.

🚧 Em construção

---

## 🚀 Funcionalidades

- 🔐 Cadastro e login com autenticação JWT
- 👤 CRUD completo de usuários
- 📇 CRUD completo de contatos (relação 1:N)
- 🛡️ Proteção de rotas com autorização baseada em JWT
- ✅ Validações com FluentValidation
- 📄 Documentação interativa com Swagger
- 🧪 Testes unitários para Services, Validators e Middleware
- 🗃️ Banco de dados com EF Core e Migrations

---

## 🧱 Stack Tecnológico

- ✅ ASP.NET Core 8
- ✅ Entity Framework Core 8
- ✅ SQL Server (ou SQLite)
- ✅ JWT (JSON Web Token)
- ✅ FluentValidation
- ✅ Swagger (Swashbuckle)
- ✅ xUnit + Moq (para testes)

---

## 🛠️ Como executar localmente

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/CrudApiJwt.git
```

2. Acesse o diretório:

```bash
cd CrudApiJwt
```

3. Configure a string de conexão no arquivo appsettings.json:

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Db;Trusted_Connection=True;"
}
```

4. Configure a chave JWT no appsettings.json:

```bash
"JwtSettings": {
  "SecretKey": "sua-chave-super-secreta",
  "Issuer": "CrudApiJwt",
  "Audience": "CrudApiJwtUsers",
  "ExpirationInMinutes": 60
}
```

5. Execute as migrações para criar o banco:

```bash
dotnet ef database update
```

6. Execute a aplicação:

```bash
dotnet run
```

7. Acesse a interface do Swagger:

```bash
https://localhost:7035/swagger
```

---

## 🔐 Como testar a autenticação JWT (via Swagger)

1. Faça um POST em /api/auth/register com email e senha

2. Em seguida, faça login com POST em /api/auth/login

3. Copie o token retornado

4. No Swagger UI, clique em “Authorize” e insira:

```bash
Bearer SEU_TOKEN_AQUI
```

5. Agora você poderá acessar as rotas protegidas (ex: /api/contacts)

---

## 🧪 Testes Automatizados

✅ Serviços: AuthService, UserService, ContactService

✅ Validadores: FluentValidation com cobertura completa

✅ Middleware: ExceptionHandlingMiddleware

✅ Controllers: AuthController, UsersController, ContactController

⏳ Testes de integração serão implementados após finalização de todas as rotas

### Como executar os testes

Execute o seguinte comando no terminal:

```bash
dotnet test
```

Os testes utilizam xUnit + Moq e garantem que os principais fluxos da aplicação estão funcionando corretamente.

---

## 🗂️ Estrutura do Projeto 

```bash
├── Controllers
│   └── AuthController.cs
│   └── UsersController.cs
│   └── ContactsController.cs
│
├── Data
│   └── AppDbContext.cs
│
├── DTOs
│   └── UserDTO.cs
│   └── ContactDTO.cs
│   └── LoginDTO.cs
│
├── Middlewares
│   └── ExceptionHandlingMiddleware.cs
|
├── Migrations
|
├── Models
│   └── User.cs
│   └── Contact.cs
|
├── Services
│   └── ApplicationDbContext.cs
│   └── AuthService.cs
│   └── ContactService.cs
│   └── TokenService.cs
│   └── UserService.cs
│
├── Settings
│   └── JwtSettings.cs
│
├── Validators
│   └── UserDTOValidator.cs
│   └── ContactDTOValidator.cs
│   └── LoginDTOValidator.cs
|
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 👨‍💻 Autor

Desenvolvido por Gilberto Andreatta Maia

https://www.linkedin.com/in/gilbertoandreatta/

---

## 📝 Licença
Este projeto está sob a licença MIT. Sinta-se livre para utilizar, modificar e distribuir.

---

OBS.: futuramente, incluir imagens/prints para destacar a interface do Swagger ou os testes de token.
