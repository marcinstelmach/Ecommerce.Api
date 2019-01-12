using System;
using System.Linq;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
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
            var existingDiscount = await orderDiscountRepository.GetByCodeAsync(code);
            if (existingDiscount != null)
            {
                throw new StreetwoodException(ErrorCode.DiscountWithThisCodeExistAlready);
            }

            var discount = new OrderDiscount(name, nameEng, description, descriptionEng, percentValue,
                availableFrom, availableTo, code);

            await orderDiscountRepository.AddAsync(discount);
            await orderDiscountRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string name, string nameEng, string description, string descriptionEng, int percentValue,
            DateTime availableFrom, DateTime availableTo)
        {
            var discount = await orderDiscountRepository.GetAndEnsureExistAsync(id);

            if (discount.Orders.Any())
            {
                throw new StreetwoodException(ErrorCode.OrderDiscountInUse);
            }

            discount.SetName(name);
            discount.SetNameEng(nameEng);
            discount.SetDescription(description);
            discount.SetDescriptionEng(descriptionEng);
            discount.SetAvailableFrom(availableFrom);
            discount.SetAvailableTo(availableTo);
            discount.SetPercentValue(percentValue);

            await orderDiscountRepository.SaveChangesAsync();
        }
    }
}
