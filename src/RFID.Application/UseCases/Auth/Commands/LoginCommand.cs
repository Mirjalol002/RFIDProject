using MediatR;
using Microsoft.EntityFrameworkCore;
using RFID.Application.Abstractions;
using RFID.Application.Exceptions;
using RFID.Domain.Entities;
using RFID.Domain.Exceptions;
using System.Security.Claims;

namespace RFID.Application.UseCases.Auth.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;
        public LoginCommandHandler(IApplicationDbContext context, ITokenService tokenService, IHashService hashService)
        {
            _context = context;
            _tokenService = tokenService;
            _hashService = hashService;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var admin = await _context.RFIDAdmins.FirstOrDefaultAsync(x => x.UserName == request.UserName, cancellationToken);
            if (admin == null)
            {
                throw new LoginException(new EntityNotFoundException(nameof(RFIDAdmin)));
            }
            if (admin.PasswordHash != _hashService.GetHash(request.Password))
            {
                throw new LoginException();
            }
            var claims = new List<Claim>()
            {
                new (ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new (ClaimTypes.Name, admin.UserName),
                //new (ClaimTypes.Email, admin.)
            };

            if (await _context.RFIDAdmins.AnyAsync(x => x.Id == admin.Id, cancellationToken))
            {
                claims.Add(new Claim(ClaimTypes.Role, nameof(RFIDAdmin)));
            }
            return _tokenService.GetAccessToken(claims.ToArray());
        }
    }
}
