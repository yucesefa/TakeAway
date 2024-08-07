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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {

                Amount = createOrderDetailCommand.Amount,
                OrderingId = createOrderDetailCommand.OrderingId,
                Price = createOrderDetailCommand.Price,
                ProductName = createOrderDetailCommand.ProductName,
                ProductId = createOrderDetailCommand.ProductId,
                TotalPrice = createOrderDetailCommand.TotalPrice
            });
        }
    }
}
