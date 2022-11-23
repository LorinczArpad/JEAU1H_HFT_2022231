using JEAU1H_HFT_2021222.Logic;
using JEAU1H_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static JEAU1H_HFT_2021222.Logic.GameLogic;

namespace JEAU1H_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic Gamelogic;

        public GameController(IGameLogic gamelogic)
        {
            Gamelogic = gamelogic;
        }

        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.Gamelogic.ReadAll();
        }


        [HttpGet("{id}")]
        public Game Read(int id)
        {
            return this.Gamelogic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Game game)
        {
            this.Gamelogic.Create(game);
        }


        [HttpPut]
        public void Put([FromBody] Game game)
        {
            this.Gamelogic.Update(game);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Gamelogic.Delete(id);
        }
        /*
        // non cruds
        [HttpGet]
        public IEnumerable<GamewithMinreq> GamesWithRequirements()
        {
            return this.Gamelogic.GamesWithRequirements();
        }
        
        [HttpGet]
        public IEnumerable<GamewithStudi> GamesWithStudios()
        {
            return this.Gamelogic.GamesWithStudios();
        }
        [HttpGet]
        public IEnumerable<GamewithStudioandMinreq> GamesWithStudiosAndRequirements()
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
        */
    }
}
