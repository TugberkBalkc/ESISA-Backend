using AutoMapper;
using ESISA.Core.Application.Dtos.Advert;
using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;
using System.Transactions;
using ESISA.Core.Domain.Exceptions.BusinessLogic;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IAdvertCommandRepository _advertCommandRepository;
        private readonly IIndividualAdvertCommandRepository _individualAdvertCommandRepository;

        private readonly IMapper _mapper;

        public TestController(ITokenHandler tokenHandler, IAdvertCommandRepository advertCommandRepository,
            IIndividualAdvertCommandRepository individualAdvertCommandRepository, IMapper mapper)
        {
            _tokenHandler = tokenHandler;
            _advertCommandRepository = advertCommandRepository;
            _individualAdvertCommandRepository = individualAdvertCommandRepository;
            _mapper= mapper;
        }

        [HttpPost("GetToken")]
        public void RequestToGetTokenWithBusinessException()
        {
            _tokenHandler.CreateToken(Guid.Empty, null, null, null, null);
        }

        [HttpPost("CreateIndividualAdvert")]
        public async Task<IActionResult> CreateIndividualAdvert(CreateIndividualAdvertDto createIndividualAdvertDto)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    Advert advert = _mapper.Map<Advert>(createIndividualAdvertDto);

                    _advertCommandRepository.AddAsync(advert);

                    await _advertCommandRepository.SaveChangesAsync();


                    IndividualAdvert individualAdvert = _mapper.Map<IndividualAdvert>(createIndividualAdvertDto);
                    
                    if(createIndividualAdvertDto.IndividualAdvertPrice <0 )
                    {
                        throw new BusinessLogicException();
                    }

                    await _individualAdvertCommandRepository.AddAsync(individualAdvert);

                    _individualAdvertCommandRepository.SaveChangesAsync();

                    transactionScope.Complete();

                    return Ok();
                }
                catch (Exception)
                {
                    transactionScope.Dispose();

                    return BadRequest();
                   
                }
            }
         
        }
    }
}
