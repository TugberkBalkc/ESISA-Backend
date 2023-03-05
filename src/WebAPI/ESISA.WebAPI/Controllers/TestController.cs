using ESISA.Core.Application.Interfaces.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITokenHandler _tokenHandler;

        public TestController(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        [HttpPost("GetToken")]
        public void RequestToGetTokenWithBusinessException()
        {
            _tokenHandler.CreateToken(Guid.Empty, null, null, null, null);
        }
    }
}
