using MediatR;
using Microsoft.EntityFrameworkCore;
using RFID.Application.Abstractions;
using RFID.Application.DTOs;
using RFID.Application.Exceptions;
using RFID.Domain.Entities;

namespace RFID.Application.UseCases.Admin.Commands
{
    public class CreateRFIDUserCommand : ICommand<long>
    {
        public int ToolId { get; set; }
        public string ToolName { get; set; } = string.Empty;
        public string TagId { get; set; } = string.Empty;       // CardId 
        public DateOnly DateOnly { get; set; }
        public int UserId { get; set; }
    }
    public class CreateRFIDUserCommandHandler : ICommandHandler<CreateRFIDUserCommand, long>
    {
        private readonly IApplicationDbContext _context;
        public CreateRFIDUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateRFIDUserCommand request, CancellationToken cancellationToken)
        {
            if(await _context.RFIDModels.AnyAsync(x=>x.TagId == request.TagId, cancellationToken))
            {
                throw new RFIDModelExistsException();
            }
            var RFIDUser = new RFIDUserViewModel
            {
                ToolId = request.ToolId,
                ToolName = request.ToolName,
                TagId = request.TagId,
                UserId = request.UserId,
                DateOnly = request.DateOnly
            };
            return RFIDUser.UserId;
        }
    }
}
