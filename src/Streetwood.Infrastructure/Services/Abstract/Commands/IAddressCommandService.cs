using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IAddressCommandService
    {
        Task AddAsync(string city, string street, string postCode, int phoneNumber, string country, Guid userId);

        Task EraseDataAsync(IEnumerable<Address> addresses);
    }
}
