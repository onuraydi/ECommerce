using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                AddressDetail1 = createAddressCommand.AddressDetail1,
                District = createAddressCommand.District,
                UserID = createAddressCommand.UserID,
                Country = createAddressCommand.Country,
                Description = createAddressCommand.Description,
                AddressDetail2 = createAddressCommand.AddressDetail2,
                Email = createAddressCommand.Email,
                Name = createAddressCommand.Name,
                Phone = createAddressCommand.Phone,
                Surname = createAddressCommand.Surname,
                ZipCode = createAddressCommand.ZipCode,
            });
        }
    }
}
