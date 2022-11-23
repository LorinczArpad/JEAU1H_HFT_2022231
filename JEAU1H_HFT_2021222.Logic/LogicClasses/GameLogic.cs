using System;
using System.Collections.Generic;
using System.Linq;
using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
namespace JEAU1H_HFT_2021222.Logic
{
    public class GameLogic : IGameLogic
    {
        IRepository<Game> repo;
        IRepository<MinRequirements> minrepo;
        IRepository<Studio> studrepo;


        public GameLogic(IRepository<Game> repo, IRepository<MinRequirements> minrepo)
        {
            this.repo = repo;
            this.minrepo = minrepo;
        }
        public GameLogic(IRepository<Game> repo, IRepository<Studio> studrepo)
        {
            this.repo = repo;
            this.studrepo = studrepo;
        }
        public GameLogic(IRepository<Game> repo, IRepository<Studio> studrepo, IRepository<MinRequirements> minrepo)
        {
            this.repo = repo;
            this.studrepo = studrepo;
            this.minrepo = minrepo;
        }

        public GameLogic(IRepository<Game> repo)
        {
            this.repo = repo;
        }

        public void Create(Game item)
        {
            if (int.Parse(item.Pyear) < 1980 )
            {
                throw new ArgumentException("The game is too old");
            }
            else if(!studrepo.ReadAll().Any(x => x.StudioID == item.StudioId) )
            {
                throw new ArgumentException("StudioID was not found");
            }
            else if (!minrepo.ReadAll().Any(x => x.ReqId == item.ReqId))
            {
                throw new ArgumentException("RequiremetsID was not found");
            }
            else
            {
                this.repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            if (repo.Read(id) != null)
            {
                this.repo.Delete(id);
            }
            else
            {
                throw new ArgumentException("Not found");
            }
        }

        public Game Read(int id)
        {
            if (repo.ReadAll().Last().GameID >= id)
            {
                return this.repo.Read(id);
            }
            else
            {
                throw new ArgumentException("Item not found");
            }
        }

        public IEnumerable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<Game> ReleaseYearSearch(string year)
        {
            return this.repo.ReadAll().Where(x => x.Pyear == year).ToList();
        }
        public IEnumerable<string> GamesWithStudios()
        {
            var games = repo.ReadAll();
            List<string> a = new List<string>();
          
            
            foreach (var game in games)
            {
                
                a.Add($"{game.Name} : {studrepo.Read(game.StudioId).Name}");
            }
            return a;
        }
        public IEnumerable<string> GamesWithRequirements()
        {
            var games = repo.ReadAll();
            List<string> a = new List<string>();
         
            
            foreach (var game in games)
            {
                a.Add($"{game.Name}: {minrepo.Read(game.ReqId).CPU},{minrepo.Read(game.ReqId).GPU}");
            }
            return a;
        }
        public IEnumerable<string> GamesWithStudiosAndRequirements()
        {
            var games = repo.ReadAll();

            List<string> a = new List<string>();
            foreach (var game in games)
            {
                a.Add($"{game.Name} : {studrepo.Read(game.StudioId).Name}, {minrepo.Read(game.ReqId).CPU},{minrepo.Read(game.ReqId).GPU}");
            }
            return a;
        }
        public IEnumerable<Game> GamesWithThisStudio(string name)
        {
            return repo.ReadAll().Where(x => studrepo.Read(x.StudioId).Name == name);
        }
        public IEnumerable<Game> GamesWithThisCPU(string cpu)
        {
            return repo.ReadAll().Where(x => minrepo.Read(x.ReqId).CPU == cpu);
        }



    }
}

