using EnglishPremierLeague.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishPremierLeague.Domain.Services.Interfaces
{
    public interface ITeamService
    {
        Task CreateTeam(Team team, byte[] teamLogo);
    }
}
