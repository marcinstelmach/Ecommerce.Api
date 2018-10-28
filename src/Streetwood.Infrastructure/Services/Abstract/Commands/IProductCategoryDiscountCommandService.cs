using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCategoryDiscountCommandService
    {
        Task AddAsync(string name, string nameEng, string description, string descriptionEng, int percentValue,
            DateTime availableFrom, DateTime availableTo);

        Task Update(Guid categoryId, Guid discountId);
    }
}
