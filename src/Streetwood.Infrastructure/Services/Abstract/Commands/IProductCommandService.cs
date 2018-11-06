using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductCommandService
    {
        Task<int> AddAsync(string name, string nameEng, decimal price, string description, string descriptionEng,  bool acceptCharms, string sizes, Guid productCategoryId);
        //because sometimes commands can return value :D
    }
}
