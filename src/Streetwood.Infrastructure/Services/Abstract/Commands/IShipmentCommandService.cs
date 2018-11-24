using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IShipmentCommandService
    {
        Task AddAsync(string name, string nameEng, string description, string descriptionEng, decimal price, ShipmentType type);

        Task UpdateAsync(Guid id, string name, string nameEng, string description, string descriptionEng, bool isActive, ShipmentType type);

        Task DeleteAsync(Guid id);
    }
}
