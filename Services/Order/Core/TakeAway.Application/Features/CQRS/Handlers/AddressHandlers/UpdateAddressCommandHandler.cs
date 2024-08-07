using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Application.Features.CQRS.Commands.AddressCommands;
using TakeAway.Application.Interfaces;
using TakeAway.Domain.Entities;

namespace TakeAway.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var values = await _repository.GetByIdAsync(updateAddressCommand.AddressId);
            values.Surname = updateAddressCommand.Surname;
            values.UserId = updateAddressCommand.UserId;
            values.Email = updateAddressCommand.Email;
            values.City = updateAddressCommand.City;
            values.Detail = updateAddressCommand.Detail;
            values.District = updateAddressCommand.District;
            values.Name = updateAddressCommand.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
