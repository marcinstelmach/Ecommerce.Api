using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface ICharmCategoryCommandService
    {
        Task AddAsync(string name);

        Task Delete(Guid id);
    }
}
