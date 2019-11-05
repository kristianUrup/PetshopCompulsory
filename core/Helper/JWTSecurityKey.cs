using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PetshopCompulsory.Core.Helper
{
    public static class JWTSecurityKey
    {
        private static byte[] secretBytes = Encoding.UTF8.GetBytes("A Secret for HmacSha256");

        public static SymmetricSecurityKey Key
        {
            get { return new SymmetricSecurityKey(secretBytes);}
        }

        public static void SetSecret(string secret)
        {
            secretBytes = Encoding.UTF8.GetBytes(secret);
        }

    }
}
