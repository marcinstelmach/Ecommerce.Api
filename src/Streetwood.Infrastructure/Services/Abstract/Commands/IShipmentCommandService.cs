using System.Threading.Tasks;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IShipmentCommandService
    {
        Task AddAsync(string name, string nameEng, string description, string descriptionEng, decimal price, bool isActive, ShipmentType type);
    }
}
