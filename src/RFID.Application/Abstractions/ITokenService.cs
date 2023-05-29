using System.Security.Claims;

namespace RFID.Application.Abstractions
{
    public interface ITokenService
    {
        string GetAccessToken(Claim[] claims);
    }
}
