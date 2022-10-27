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
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Game Read(int id)
        {
            return this.repo.Read(id);
        }

        public IEnumerable<Game> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Game item)
        {
            this.repo.Update(item);
        }
        public List<Game> ReleaseYearSearch(string year)
        {
            return this.repo.ReadAll().Where(x => x.Pyear == year).ToList();
        }
        public List<GamewithStudi> GamesWithStudios()
        {
            var games = repo.ReadAll();
            
            List<GamewithStudi> a = new List<GamewithStudi>();
            foreach(var game in games)
            {
                a.Add(new GamewithStudi(game, studrepo.Read(game.StudioId)));
            }
            return a;
        }
        public List<GamewithMinreq> GamesWithRequirements()
        {
            var games = repo.ReadAll();

            List<GamewithMinreq> a = new List<GamewithMinreq>();
            foreach (var game in games)
            {
                a.Add(new GamewithMinreq(game, minrepo.Read(game.StudioId)));
            }
            return a;
        }
        public List<GamewithStudioandMinreq> GamesWithStudiosAndRequirements()
        {
            var games = repo.ReadAll();

            List<GamewithStudioandMinreq> a = new List<GamewithStudioandMinreq>();
            foreach (var game in games)
            {
                a.Add(new GamewithStudioandMinreq(game, studrepo.Read(game.StudioId), minrepo.Read(game.StudioId)));
            }
            return a;
        }
        public class GamewithStudioandMinreq
        {
            public Game g;
            public Studio s;
            public MinRequirements r;
            public GamewithStudioandMinreq(Game g, Studio s,  MinRequirements r)
            {
                this.g = g;
                this.s = s;
                this.r = r;
            }
        }

        public class GamewithStudi
        {
            public Game g;
            public Studio s;
            public GamewithStudi(Game g, Studio s)
            {
                this.g = g;
                this.s = s;
            }
        }
        public class GamewithMinreq
        {
            public Game g;
            public MinRequirements r;
            public GamewithMinreq(Game g, MinRequirements r)
            {
                this.g = g;
                this.r = r;
            }
        }
    }
}

