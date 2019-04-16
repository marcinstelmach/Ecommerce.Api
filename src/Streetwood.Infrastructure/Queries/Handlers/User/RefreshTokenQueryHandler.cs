using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.User;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.User
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQueryModel, TokenModel>
    {
        private readonly IUserQueryService userQueryService;

        public RefreshTokenQueryHandler(IUserQueryService userQueryService)
        {
            this.userQueryService = userQueryService;
        }

        public async Task<TokenModel> Handle(RefreshTokenQueryModel request, CancellationToken cancellationToken)
            => await userQueryService.RefreshTokenAsync(request.JwtToken, request.RefreshToken);
    }
}
