using CrudApiJwt.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace CrudApiJwt.Services.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Realiza o login do usuário e retorna um token JWT válido.
        /// </summary>
        /// <param name="request">Credenciais de login</param>
        /// <returns>Token JWT</returns>
        Task<string> LoginAsync(LoginRequest request);

        /// <summary>
        /// Registra um novo usuário e retorna os dados do usuário criado.
        /// </summary>
        /// <param name="request">Dados de registro</param>
        /// <returns>Usuário recém-criado</returns>
        Task<User> RegisterAsync(RegisterRequest request);
    }
}
