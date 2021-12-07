using AutoMapper;
using EnglishPremierLeague.API.Models.v1.Response;
using EnglishPremierLeague.Domain.Ports.Repositories.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public class CountriesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CountriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(CountriesResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCountries()
        {
            var countries = _unitOfWork.Countries.GetAll();
            if(!countries.Any())
                return NoContent();

            return Ok(_mapper.Map<List<CountriesResponse>>(countries));
        }
    }
}
