using AutoMapper;
using EnglishPremierLeague.API.Models.v1.Request;
using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Repositories.Uow;
using EnglishPremierLeague.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EnglishPremierLeague.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/players")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public class PlayersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IPlayerService _playerService;
        public PlayersController(IMapper mapper, IPlayerService playerService)
        {
            _mapper = mapper;
            _playerService = playerService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult PostPlayer([FromBody] PlayerRequest playerRequest)
        {
            var player = _mapper.Map<Player>(playerRequest);
            _playerService.AddPlayer(player);
            return NoContent();
        }

    }
}
