using System;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto.Products;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCommandService
    {
        // because sometimes commands can return value :D
        Task<int> AddAsync(AddProductDto dto);

        Task UpdateAsync(int id, string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, string sizes);

        Task DeleteAsync(int id);
    }
}