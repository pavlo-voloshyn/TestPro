﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Services.Constants
{
    public class AuthOptions
    {
        public const string ISSUER = "TestProBackend";
        public const string AUDIENCE = "TestProFrontend";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 14;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
