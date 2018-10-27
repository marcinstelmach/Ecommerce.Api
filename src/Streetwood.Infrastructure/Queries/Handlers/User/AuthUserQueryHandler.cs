using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.User;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.User
{
    public class AuthUserQueryHandler : IRequestHandler<AuthUserQueryModel, TokenModel>
    {
        private readonly IUserQueryService userQueryService;

        public AuthUserQueryHandler(IUserQueryService userQueryService)
        {
            this.userQueryService = userQueryService;
        }

        public async Task<TokenModel> Handle(AuthUserQueryModel request, CancellationToken cancellationToken)
            => await userQueryService.GetTokenAsync(request.Email, request.Password);
    }
}
