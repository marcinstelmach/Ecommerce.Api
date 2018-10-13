using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface ICharmCommandService
    {
        Task AddAsync(string name, string nameEng, decimal price, Guid charmCategoryId);
    }
}
