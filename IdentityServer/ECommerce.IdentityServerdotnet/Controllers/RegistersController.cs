using ECommerce.IdentityServerdotnet.Dtos;
using ECommerce.IdentityServerdotnet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace ECommerce.IdentityServerdotnet.Controllers
{

    /*[Authorize(LocalApi.PolicyName)] */ // ilgili kullanıcı access token'a sahip değilse işlem gerçekleşemeyecek
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.Username,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(values,userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı Başarıyla Eklendi");
            }
            return Ok("Bir Hata Oluştu Tekrar Deneyiniz!");
        }
    }
}
