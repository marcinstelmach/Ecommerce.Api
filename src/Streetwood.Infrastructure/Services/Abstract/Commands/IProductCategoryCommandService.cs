using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCategoryCommandService
    {
        Task AddAsync(string name, string nameEng, Guid? productCategoryId);

        Task UpdateAsync(Guid id, string name, string nameEng);

        Task DeleteAsync(Guid id);
    }
}
