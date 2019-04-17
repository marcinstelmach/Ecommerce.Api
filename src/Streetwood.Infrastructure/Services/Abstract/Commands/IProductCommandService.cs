using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCommandService
    {
        // because sometimes commands can return value :D
        Task<int> AddAsync(string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, int maxCharmsCount, string sizes, Guid productCategoryId);

        Task UpdateAsync(int id, string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, string sizes);

        Task DeleteAsync(int id);
    }
}