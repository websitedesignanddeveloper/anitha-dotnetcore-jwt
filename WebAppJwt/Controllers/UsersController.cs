using Microsoft.AspNetCore.Mvc;
using WebAppJwt.Models;
using WebAppJwt.Services_file;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace WebAppJwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration _config;
        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _config = configuration;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

      
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPut("getSingleUser")]
        public Task<IActionResult> GetSingleUser(Object obj)
        {
            var singleUser =  obj;
            return  null;
        }
      
        [HttpGet("getNasaImageList")]
        public async Task<IActionResult> GetNasaImageList()
        {
            List<Images> ImgList = new List<Images>();
            
                try
                {
                    DateTime dt = DateTime.Now;
                    var searchDate = dt.ToString("yyyy-MM-dd");
                    HttpClient http = new HttpClient();
                    var NasaApi = http.GetAsync(_config["Url"] + searchDate + "&api_key=DNBMtukhKD83Xec4BhdOmn8YFly5W2VNK7y8mJwV").Result;
                    var result = await NasaApi.Content.ReadAsStringAsync();
                    Images jsonObj = JsonConvert.DeserializeObject<Images>(result);
                    var imgdata = new Images();
                    imgdata.date = searchDate;
                    imgdata.photos = jsonObj.photos;

                    ImgList.Add(imgdata);

                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ImgList });
                }
            return Ok(ImgList);
        }

    }
}
