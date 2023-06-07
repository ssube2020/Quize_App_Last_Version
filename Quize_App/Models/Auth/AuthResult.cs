using System;
namespace Quize_App.Models.Auth
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string AccessToken { get; set; }
        public string SuccessMessage { get; set; }
    }
}

