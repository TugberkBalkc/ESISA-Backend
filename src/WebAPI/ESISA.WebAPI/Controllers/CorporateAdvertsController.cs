
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateAdvertsController : CustomControllerBase
    {
        public CorporateAdvertsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

      
     
    }
}
