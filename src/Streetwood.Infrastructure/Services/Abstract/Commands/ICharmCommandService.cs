using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface ICharmCommandService
    {
        Task<Guid> AddAsync(string name, string nameEng, decimal price, Guid charmCategoryId);

        Task AddPhotoAsync(Guid id, IFormFile file);
    }
}
