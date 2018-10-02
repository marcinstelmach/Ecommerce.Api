using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto.User;

namespace Streetwood.Infrastructure.Queries.Models.User
{
    public class GetUsersQueryModel : IRequest<IList<UserDto>>
    {
    }
}
