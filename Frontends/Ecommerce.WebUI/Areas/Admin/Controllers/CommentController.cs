using ECommerce.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.baslik = "Yorum İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //[Route("CreateComment")]
        //[HttpGet]
        //public IActionResult CreateComment()
        //{
        //    ViewBag.baslik = "Yorum İşlemleri";
        //    ViewBag.v1 = "Ana Sayfa";
        //    ViewBag.v2 = "Yorumlar";
        //    ViewBag.v3 = "Yorum Yapma";
        //    return View();
        //}

        //[Route("CreateComment")]
        //[HttpPost]
        //public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var JsonData = JsonConvert.SerializeObject(createCommentDto);
        //    StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("https://localhost:7075/api/Comments/", stringContent);
        //    if(responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index", "Comment", new { area = "Admin" });
        //    }
        //    return View();
        //}

        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            ViewBag.baslik = "Yorum İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7075/api/Comments/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7075/api/Comments/", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteComment/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7075/api/Comments/" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
