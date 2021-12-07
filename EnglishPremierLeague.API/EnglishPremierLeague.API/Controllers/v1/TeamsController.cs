using AutoMapper;
using EnglishPremierLeague.API.Extensions;
using EnglishPremierLeague.API.Models.v1.Request;
using EnglishPremierLeague.API.Models.v1.Response;
using EnglishPremierLeague.Domain.Entities;
using EnglishPremierLeague.Domain.Ports.Repositories.Uow;
using EnglishPremierLeague.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EnglishPremierLeague.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/teams")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public class TeamsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;
        private readonly IUnitOfWork _unitOfWork;
        public TeamsController(IMapper mapper, ITeamService teamService,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _teamService = teamService;
            _unitOfWork = unitOfWork;
        }        

        [HttpGet]
        [ProducesResponseType(typeof(List<TeamsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetTeams()
        {
            var teams = _unitOfWork.Teams.GetAll();
            if(!teams.Any())
                return NoContent();

            return Ok(_mapper.Map<List<TeamsResponse>>(teams));
          
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult SaveTeam([FromBody] TeamRequest teamRequest)
        {
            var team = _mapper.Map<Team>(teamRequest);
            _teamService.CreateTeam(team);
            return NoContent();
        }

        [HttpGet("{teamId:int}")]
        [ProducesResponseType(typeof(TeamResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetTeamByTeamId(int teamId)
        {
            var team = _unitOfWork.Teams.GetTeamWithPlayers(teamId);
            if(team == null)
                return NoContent();

            return Ok(_mapper.Map<TeamResponse>(team));
        }

        [HttpDelete("{teamId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteTeam(int teamId)
        {
            _teamService.DeleteTeam(teamId);
            return NoContent();
        }

    }
}
