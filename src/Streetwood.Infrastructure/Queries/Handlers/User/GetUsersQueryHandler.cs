using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Streetwood.Infrastructure.Dto.User;
using Streetwood.Infrastructure.Queries.Models.User;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Queries.Handlers.User
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryModel, IList<UserDto>>
    {
        private readonly IUserQueryService userQueryService;

        public GetUsersQueryHandler(IUserQueryService userQueryService)
        {
            this.userQueryService = userQueryService;
        }

        public async Task<IList<UserDto>> Handle(GetUsersQueryModel request, CancellationToken cancellationToken)
            => await userQueryService.GetAsync();
    }
}
