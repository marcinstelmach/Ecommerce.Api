using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCommandService
    {
        Task AddAsync(string name, string nameEng, decimal price, string description, string descriptionEng,  bool acceptCharms, string sizes, Guid productCategoryId);
    }
}
