using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands.Address
{
    public interface IAddressCommandService
    {
        Task AddAsync(string city, string street, string postCode, int phoneNumber, string country, Guid userId);
    }
}
