
using JEAU1H_HFT_2021222.Logic;
using JEAU1H_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JEAU1H_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGameLogic Gamelogic;
        public StatController(IGameLogic gamelogic)
        {
            this.Gamelogic = gamelogic;
        }

        // non cruds
        [HttpGet]
        public IEnumerable<string> GamesWithRequirements()
        {
            return this.Gamelogic.GamesWithRequirements();
        }

        [HttpGet]
        public IEnumerable<string> GamesWithStudios()
        {
            return this.Gamelogic.GamesWithStudios();
        }
        [HttpGet]
        public IEnumerable<string> GamesWithStudiosAndRequirements()
        {
            return this.Gamelogic.GamesWithStudiosAndRequirements();
        }
        [HttpGet("{name}")]
        public IEnumerable<Game> GamesWithThisStudio(string name)
        {
            return this.Gamelogic.GamesWithThisStudio(name);
        }
        [HttpGet("{cpu}")]
        public IEnumerable<Game> GamesWithThisCPU(string cpu)
        {
            return this.Gamelogic.GamesWithThisCPU(cpu);
        }
        [HttpGet("{year}")]
        public IEnumerable<Game> ReleaseYearSearch(string year)
        {
            return this.Gamelogic.ReleaseYearSearch(year);
        }
    }
}
