using System;
namespace Shared.Configs
{
    public class AuthSettingsConfig
    {
        public string Key { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
    }
}

