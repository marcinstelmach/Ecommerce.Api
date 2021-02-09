namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Streetwood.Infrastructure.Dto;
    using Streetwood.Infrastructure.Dto.Products;

    public interface IProductCommandService
    {
        // because sometimes commands can return value :D
        Task<int> AddAsync(AddProductDto dto);

        Task UpdateAsync(int id, string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, bool acceptGraver, string sizes, ICollection<ProductColorDto> productColorDtos);

        Task DeleteAsync(int id);
    }
}