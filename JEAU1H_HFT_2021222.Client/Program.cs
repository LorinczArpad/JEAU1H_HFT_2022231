using JEAU1H_HFT_2021222.Logic;
using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JEAU1H_HFT_2021222.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new VideoGamesDbContext();
            var gamerepo = new GameRepository(ctx);
            var minrepo = new MinRequirementsRepository(ctx);
            var studrepo = new StudioRepository(ctx);
            var logic = new GameLogic(gamerepo,studrepo,minrepo);
            
           
           
        }
    }
}
