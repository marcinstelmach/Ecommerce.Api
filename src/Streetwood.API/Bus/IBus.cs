using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Streetwood.API.Bus
{
    public interface IBus
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
