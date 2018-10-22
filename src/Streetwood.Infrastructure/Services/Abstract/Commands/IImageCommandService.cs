using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IImageCommandService
    {
        Task AddAsync(IFormFile file, int productId, bool isMain);

        Task DeleteAsync(Guid id);
    }
}
