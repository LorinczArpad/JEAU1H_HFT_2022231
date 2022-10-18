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
    }
}
