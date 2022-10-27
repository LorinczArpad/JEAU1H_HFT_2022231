using ConsoleTools;
using JEAU1H_HFT_2021222.Logic;
using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JEAU1H_HFT_2021222.Client
{
    class Program
    {
        static GameLogic gamelogic;
        static MinRequirementsLogic minreqlogic;
        static StudioLogic studreqlogic;
        static void Main(string[] args)
        {
            var ctx = new VideoGamesDbContext();
            var gamerepo = new GameRepository(ctx);
            var minrepo = new MinRequirementsRepository(ctx);
            var studrepo = new StudioRepository(ctx);
            gamelogic = new GameLogic(gamerepo, studrepo, minrepo);
            minreqlogic = new MinRequirementsLogic(minrepo);
            studreqlogic = new StudioLogic(studrepo);

            /*  void Create(Game item);
        void Delete(int id);
        IEnumerable<GameLogic.GamewithMinreq> GamesWithRequirements();
        IEnumerable<GameLogic.GamewithStudi> GamesWithStudios();
        IEnumerable<GameLogic.GamewithStudioandMinreq> GamesWithStudiosAndRequirements();
        IEnumerable<Game> GamesWithThisCPU(string cpu);
        IEnumerable<Game> GamesWithThisStudio(string name);
        Game Read(int id);
        IEnumerable<Game> ReadAll();
        IEnumerable<Game> ReleaseYearSearch(string year);
        void Update(Game item);*/
            //gamessubemenu
            var gamessubmenu = new ConsoleMenu(args, level: 1)
            .Add("Delete", () => Delete("Games"))
            .Add("Create", () => Create("Games"))
            .Add("Exit", () => ConsoleMenu.Close());

            //menu
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => gamessubmenu.Show())
                //.Add("Studio", () => studiosubmenu.Show())
               // .Add("MinRequirements", () => MinRequirementssubmenu.Show())
                .Add("Exit", () => ConsoleMenu.Close());
            menu.Show();


        }
        static void Delete(string name)
        {
            if (name == "Games") { 
            Console.WriteLine("ID: ");
            var id = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(gamelogic.Read(id).Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                    Thread.Sleep(1500);
            }
            }
        }
        static void Create(string name)
        {
            if (name == "Games")
            {
                Console.WriteLine("Add the name of the game: ");
                var nameg = Console.ReadLine();
                Console.WriteLine("Add the name realise year: ");
                var year = Console.ReadLine();
                Console.WriteLine("Add the StudioID: ");
                var studid = int.Parse(Console.ReadLine());
                Console.WriteLine("Add the MinRequimentId: ");
                var reqid = int.Parse(Console.ReadLine());
                
                Game g = new Game(nameg, gamelogic.ReadAll().Last().GameID + 1, year, studid, reqid);
                
                gamelogic.Create(g);
              
            }
        }
       
    }
}
