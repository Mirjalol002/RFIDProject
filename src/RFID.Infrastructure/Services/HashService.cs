using RFID.Application.Abstractions;
using System.Text;
using XSystem.Security.Cryptography;


namespace RFID.Infrastructure.Services
{
    public class HashService : IHashService
    {
        public string GetHash(string key)
        {
#pragma warning disable
            var sha256 = new SHA256Managed();
# pragma warning restore
            var bytes = Encoding.UTF8.GetBytes(key);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
