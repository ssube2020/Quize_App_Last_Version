using System;
using Quize_App.Models;
using Quize_App.Models.Auth;

namespace Quize_App.Contracts
{
    public interface IAuthService
    {
        Task<AuthResult> Login(AuthRequest request);
        Task<AuthResponse> Register(RegistrationRequest request);
    }
}

