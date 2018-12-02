using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCategoryDiscountCommandService
    {
        Task AddAsync(string name, string nameEng, string description, string descriptionEng, int percentValue,
            DateTime availableFrom, DateTime availableTo);

        Task UpdateAsync(IEnumerable<Guid> categoryIds, Guid discountId);
    }
}
