using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAway.Application.Interfaces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            values.OrderingId = updateOrderDetailCommand.OrderingId;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.Amount = updateOrderDetailCommand.Amount;
            values.Price = updateOrderDetailCommand.Price;
            values.TotalPrice = updateOrderDetailCommand.TotalPrice;
            values.ProductId = updateOrderDetailCommand.ProductId;
            await _repository.UpdateAsync(values);
        }
    }
}
