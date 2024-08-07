﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.CQRS.Queries.OrderDetailQueries;
using TakeAway.Application.Features.CQRS.Results.OrderDetailResults;
using TakeAway.Application.Interfaces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
            return new GetOrderDetailByIdQueryResult
            {
                Amount = values.Amount,
                OrderDetailId = values.OrderDetailId,
                OrderingId = values.OrderingId,
                Price = values.Price,
                ProductName = values.ProductName,
                ProductId = values.ProductId,
                TotalPrice = values.TotalPrice
            };
        }
    }
}
