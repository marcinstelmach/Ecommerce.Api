using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCommandService
    {
        // because sometimes commands can return value :D
        Task<int> AddAsync(string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, bool acceptGraver, int maxCharmsCount, string sizes, Guid productCategoryId,
            ICollection<ProductColorDto> productColorViewModels);

        Task UpdateAsync(int id, string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, bool acceptGraver, string sizes, ICollection<ProductColorDto> productColorDtos);

        Task DeleteAsync(int id);
    }
}