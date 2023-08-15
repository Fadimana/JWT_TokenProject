using JWT_TokenOluşturma.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_TokenOluşturma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public IActionResult Get()
        {
            Token token=TokenHandler.CreateToken(_configuration);
            return Ok(token);
        }
    }
}
