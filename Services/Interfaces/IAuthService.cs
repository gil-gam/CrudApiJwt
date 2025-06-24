using CrudApiJwt.DTOs;
using CrudApiJwt.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace CrudApiJwt.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequest request);
        Task<User> RegisterAsync(RegisterRequest request);
    }
}
