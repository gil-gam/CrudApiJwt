# 📦 CrudApiJwt

API RESTful desenvolvida com ASP.NET Core 8, Entity Framework Core e autenticação via JWT. Permite gerenciamento de usuários e seus contatos pessoais, com proteção de rotas e autenticação baseada em tokens.

---

## 🚀 Funcionalidades

- 🔐 Cadastro e login de usuários com autenticação JWT
- 👤 CRUD completo de usuários
- 📇 CRUD completo de contatos (1 usuário → N contatos)
- 🔑 Proteção de rotas com autorização JWT
- 📄 Documentação automática com Swagger
- 🧪 Pronto para testes via Swagger UI ou Postman
- 🗃️ Banco de dados com Entity Framework Core + Migrations

---

## 🧱 Tecnologias e Stack

- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server (ou SQLite, configurável)
- JWT (JSON Web Token) para autenticação
- Swagger (Swashbuckle) para documentação
- AutoMapper (opcional para mapeamento DTOs)
- FluentValidation (opcional para validações)

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

5. Execute as migrações (via terminal ou Package Manager Console):

```bash
dotnet ef database update
```

6. Rode o projeto:

```bash
dotnet run
```

7. Acesse a API via Swagger:

```bash
https://localhost:5001/swagger
```
---

## 🧪 Autenticação JWT (como testar)

1. Faça um POST em /api/auth/register para cadastrar um novo usuário

2. Faça login com POST em /api/auth/login

3. Copie o token retornado

4. No Swagger UI, clique em “Authorize” e insira:

```bash
Bearer SEU_TOKEN_AQUI
```

5. Agora você poderá acessar as rotas protegidas (ex: /api/contacts)

---

## 🗂️ Estrutura do Projeto 

```bash
├── Controllers
│   ├── AuthController.cs
│   ├── UsersController.cs
│   └── ContactsController.cs
│
├── Models
│   ├── User.cs
│   └── Contact.cs
│
├── DTOs
│   ├── UserDTO.cs
│   ├── ContactDTO.cs
│   └── LoginDTO.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Services
│   └── TokenService.cs
│
├── Settings
│   └── JwtSettings.cs
│
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

OBS.: incluir imagens/prints para destacar a interface do Swagger ou os testes de token.







