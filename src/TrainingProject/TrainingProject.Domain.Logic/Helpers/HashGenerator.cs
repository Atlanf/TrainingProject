using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TrainingProject.Domain.Logic.Helpers
{
    public static class HashGenerator
    {
        public static string Generate(string src)
        {
            return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(src)));
        }
    }
}
