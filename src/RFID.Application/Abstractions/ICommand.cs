using MediatR;

namespace RFID.Application.Abstractions
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
