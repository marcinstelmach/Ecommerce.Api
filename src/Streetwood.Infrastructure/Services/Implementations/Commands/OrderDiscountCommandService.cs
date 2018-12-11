using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class OrderDiscountCommandService : IOrderDiscountCommandService
    {
        private readonly IOrderDiscountRepository orderDiscountRepository;

        public OrderDiscountCommandService(IOrderDiscountRepository orderDiscountRepository)
        {
            this.orderDiscountRepository = orderDiscountRepository;
        }

        public async Task AddAsync(string name, string nameEng, string description, string descriptionEng, int percentValue,
            DateTime availableFrom, DateTime availableTo, string code)
        {
            var discount = new OrderDiscount(name, nameEng, description, descriptionEng, percentValue, true,
                availableFrom, availableTo, code);

            await orderDiscountRepository.AddAsync(discount);
            await orderDiscountRepository.SaveChangesAsync();
        }
    }
}
