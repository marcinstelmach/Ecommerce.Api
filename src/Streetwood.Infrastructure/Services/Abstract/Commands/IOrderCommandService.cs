using System;
using System.Collections.Generic;
using System.Text;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IOrderCommandService
    {
        IList<ProductOrder> CreateProductOrders();
    }
}
