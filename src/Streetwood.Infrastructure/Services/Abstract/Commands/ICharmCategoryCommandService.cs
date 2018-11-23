using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface ICharmCategoryCommandService
    {
        Task AddAsync(string name, string nameEng);

        Task UpdateAsync(Guid id, string name, string nameEng);

        Task DeleteAsync(Guid id);
    }
}
