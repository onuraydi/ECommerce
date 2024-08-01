using ECommercial.Cargo.BusinessLayer.Abstract;
using ECommercial.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using ECommercial.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommercial.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailsById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.Tdelete(id);
            return Ok("Kargo Detayı Başarıyla Silindi");
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailsDto createCargoDetailsDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailsDto.Barcode,
                CargoCompanyID = createCargoDetailsDto.CargoCompanyID,
                SenderCustomer = createCargoDetailsDto.SenderCustomer,
                RecieverCustomer = createCargoDetailsDto.RecieverCustomer
            };
            _cargoDetailService.Tinsert(cargoDetail);
            return Ok("Kargo Detayı Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyID = updateCargoDetailDto.CargoCompanyID,
                RecieverCustomer = updateCargoDetailDto.RecieverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                CargoDetailID = updateCargoDetailDto.CargoDetailID
            };
            _cargoDetailService.Tupdate(cargoDetail);
            return Ok("Kargo Detayı Başarıyla Güncellendi");
        }
    }
}
