using System;
using System.Collections.Generic;
using System.Linq;
using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
namespace JEAU1H_HFT_2021222.Logic
{
    public class GameLogic
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
        public IEnumerable<IGrouping<Studio, Game>> GamesWithStudios()
        {
            var groupbystudios =
            from games in repo.ReadAll()
            group games by studrepo.Read(games.StudioId) into newGroup
            orderby newGroup.Key
            select newGroup;
            return groupbystudios;
        }
    }
}
