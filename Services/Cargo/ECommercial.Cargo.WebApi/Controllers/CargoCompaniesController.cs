using ECommercial.Cargo.BusinessLayer.Abstract;
using ECommercial.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using ECommercial.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommercial.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;

        public CargoCompaniesController(ICargoCompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _companyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName,

            };
            _companyService.Tinsert(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCargoCompany(int id)
        {
            _companyService.Tdelete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var values = _companyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany() 
            {
                CargoCompanyID = updateCargoCompanyDto.CargoCompanyID,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName,
            };
            _companyService.Tupdate(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Güncellendi");
        }
    }
}
