using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Dto.User;
using Streetwood.Infrastructure.Queries.Models.User;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryModel, UserDto>
    {
        private readonly IUserQueryService userQueryService;

        public GetUserByIdQueryHandler(IUserQueryService userQueryService)
        {
            this.userQueryService = userQueryService;
        }

        public async Task<UserDto> Handle(GetUserByIdQueryModel request, CancellationToken cancellationToken)
            => await userQueryService.GetByIdAsync(request.Id);
    }
}
