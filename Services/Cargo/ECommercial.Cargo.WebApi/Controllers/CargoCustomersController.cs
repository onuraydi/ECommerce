using ECommercial.Cargo.BusinessLayer.Abstract;
using ECommercial.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using ECommercial.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommercial.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _customerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomersById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                Name= createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname
            };
            _customerService.Tinsert(cargoCustomer);
            return Ok("Kargo Müşteri Başarıyla Eklendi");
        }


        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _customerService.Tdelete(id);
            return Ok("Kargo Müşteri Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomers = new CargoCustomer()
            {
                CargoCustomerID = updateCargoCustomerDto.CargoCustomerID,
                Address= updateCargoCustomerDto.Address,
                City= updateCargoCustomerDto.City,
                District= updateCargoCustomerDto.District,
                Email= updateCargoCustomerDto.Email,
                Phone= updateCargoCustomerDto.Phone,
                Name= updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname
            };
            _customerService.Tupdate(cargoCustomers);
            return Ok("Kargo Müşteri Başarıyla Güncellendi");
        }
    }
}
