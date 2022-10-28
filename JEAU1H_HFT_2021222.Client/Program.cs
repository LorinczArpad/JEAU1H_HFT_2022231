﻿using ConsoleTools;
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
        static MinRequirementsLogic minlogic;
        static StudioLogic studlogic;
       
        static void Main(string[] args)
        {
            
            var ctx = new VideoGamesDbContext();
            var gamerepo = new GameRepository(ctx);
            var minrepo = new MinRequirementsRepository(ctx);
            var studrepo = new StudioRepository(ctx);
            gamelogic = new GameLogic(gamerepo, studrepo, minrepo);
            minlogic = new MinRequirementsLogic(minrepo);
            studlogic = new StudioLogic(studrepo);

        #region Menus
            //list menu in gaes
            var gameslistmenu = new ConsoleMenu(args, level: 2)
                .Add("ListGames", () => List("Games"))
                .Add("List Games with there studio", () => GamesWithStudios())
                .Add("List Games with CPU",()=> GamesWithThisCPU())
                .Add("List all information", () => GamesWithStudiosAndRequirements())
                .Add("List Games with there Requirements",() => GamesWithRequirements())
                .Add("Exit", ConsoleMenu.Close);


            //Games menu
            var gamessubmenu = new ConsoleMenu(args, level: 1)
            .Add("Delete", () => Delete("Games"))
            .Add("Create", () => Create("Games"))
            .Add("List", () => gameslistmenu.Show())
            .Add("Search", () => Seach("Games"))
            .Add("Update",() => Overwrite("Games"))
            .Add("Seach by release year", () =>ReleaseYearSearch())
            .Add("Exit", ConsoleMenu.Close);
            //studio menu
            var studiossubmenu = new ConsoleMenu(args, level: 1)
            .Add("Delete", () => Delete("Studios"))
            .Add("Create", () => Create("Studios"))
            .Add("List", () => List("Studios"))
            .Add("Search", () => Seach("Studios"))
            .Add("Update", () => Overwrite("Studios"))
            .Add("Exit", ConsoleMenu.Close);
            //req menu
            var MinRequirementssubmenu = new ConsoleMenu(args, level: 1)
             .Add("Delete", () => Delete("Requirements"))
            .Add("Create", () => Create("Requirements"))
            .Add("List", () => List("Requirements"))
            .Add("Search", () => Seach("Requirements"))
            .Add("Update", () => Overwrite("Requirements"))
            .Add("Exit", ConsoleMenu.Close);
            //Main menu
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => gamessubmenu.Show())
                .Add("Studio", () => studiossubmenu.Show())
                .Add("MinRequirements", () => MinRequirementssubmenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
            #endregion

        }
        #region Functions
        static void Delete(string name)
        {
            if (name == "Games") { 
            Console.WriteLine("ID: ");
            var id = int.Parse(Console.ReadLine());
            try
            {
               gamelogic.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                    Thread.Sleep(1500);
            }
                
            }
            if (name == "Studios")
            {
                Console.WriteLine("ID: ");
                var id = int.Parse(Console.ReadLine());
                try
                {
                    studlogic.Delete(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(1500);
                }

            }
            if (name == "Requirements")
            {
                Console.WriteLine("ID: ");
                var id = int.Parse(Console.ReadLine());
                try
                {
                    minlogic.Delete(id);
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
                try
                {
                    gamelogic.Create(g);
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(2500);
            }
            if (name == "Studios")
            {
                Console.WriteLine("Add the name of the Studio: ");
                var nameg = Console.ReadLine();
                Console.WriteLine("Add the name of the CEO: ");
                var ceo = Console.ReadLine();
                

                Studio g = new Studio(nameg, studlogic.ReadAll().Last().StudioID + 1, ceo);

                studlogic.Create(g);

            }
            if (name == "Requirements")
            {
                Console.WriteLine("GPU: ");
                var gpu = Console.ReadLine();
                Console.WriteLine("CPU:");
                var cpu = Console.ReadLine();


                MinRequirements g = new MinRequirements(minlogic.ReadAll().Last().ReqId + 1, cpu,gpu);

                minlogic.Create(g);

            }
        }
        static void List(string name)
        {
            if(name == "Games")
            {
                foreach(var item in gamelogic.ReadAll())
                {
                    Console.WriteLine($"{item.Name}| {item.Pyear}|RequirementsID: | {item.ReqId}| StudioID: |{item.StudioId} GameID: |{item.GameID}");
                }
                Thread.Sleep(2500);

            }
            if (name == "Studios")
            {
                foreach (var item in studlogic.ReadAll())
                {
                    Console.WriteLine($"Studio's name: {item.Name} StudioID: {item.StudioID} CEO's name: {item.CEOName}");
                }
                Thread.Sleep(2500);

            }
            if (name == "Requirements")
            {
                foreach (var item in minlogic.ReadAll())
                {
                    Console.WriteLine($"ID: {item.ReqId} CPU: {item.CPU} GPU: {item.GPU}");
                }
                Thread.Sleep(2500);

            }
        }
        static void Seach(string name)
        {
            if(name == "Games")
            {
                Console.WriteLine("Give the ID of the required item: ");
                var id = int.Parse(Console.ReadLine());
                try
                {
                    var item = gamelogic.Read(id);
                    Console.WriteLine($"{item.Name}| {item.Pyear}|RequirementsID: | {item.ReqId}| StudioID: |{item.StudioId} GameID: |{item.GameID}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(2500);

            }
            if (name == "Studios")
            {
                Console.WriteLine("Give the ID of the required item: ");
                var id = int.Parse(Console.ReadLine());
                try
                {
                    var item = studlogic.Read(id);
                    Console.WriteLine($"Studio's name: {item.Name} StudioID: {item.StudioID} CEO's name: {item.CEOName}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(2500);

            }
            if (name == "Requirements")
            {
                Console.WriteLine("Give the ID of the required item: ");
                var id = int.Parse(Console.ReadLine());
                try
                {
                    var item = minlogic.Read(id);
                    Console.WriteLine($"ID: {item.ReqId} CPU: {item.CPU} GPU: {item.GPU}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Thread.Sleep(2500);

            }
        }
        static void Overwrite(string name)
        {
            if(name == "Games")
            {
                Console.WriteLine("Add the name of the game: ");
                var nameg = Console.ReadLine();
                Console.WriteLine("Add the name realise year: ");
                var year = Console.ReadLine();
                Console.WriteLine("Add the StudioID: ");
                var studid = int.Parse(Console.ReadLine());
                Console.WriteLine("Add the MinRequimentId: ");
                var reqid = int.Parse(Console.ReadLine());
                Console.WriteLine("Add the Game's ID");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine("Old Item:");
                var item = gamelogic.Read(id);
                Console.WriteLine($"{item.Name}| {item.Pyear}|RequirementsID: | {item.ReqId}| StudioID: |{item.StudioId} GameID: |{item.GameID}");
                gamelogic.Update(new Game(nameg, id, year, studid, reqid));
                var item2 = gamelogic.Read(id);
                Console.WriteLine("New item: ");
                Console.WriteLine($"{item2.Name}| {item2.Pyear}|RequirementsID: | {item2.ReqId}| StudioID: |{item2.StudioId} GameID: |{item2.GameID}");
                Thread.Sleep(3500);
            }
            if (name == "Studios")
            {
                Console.WriteLine("Add the name of the studio: ");
                var nameg = Console.ReadLine();
                Console.WriteLine("Add the name of the CEO: ");
                var ceo = Console.ReadLine();
                Console.WriteLine("Add the StudioID: ");
                var studid = int.Parse(Console.ReadLine());
                var item = studlogic.Read(studid);
                Console.WriteLine("Old Item:");
                Console.WriteLine($"Studio's name: {item.Name} CEO's name: {item.CEOName} StudioID: {item.StudioID}");
                studlogic.Update(new Studio(nameg, studid, ceo));
                var item2 = studlogic.Read(studid);
                Console.WriteLine($"Studio's name: {item2.Name} CEO's name: {item2.CEOName} StudioID: {item2.StudioID}");
                Thread.Sleep(3500);
            }
            if (name == "Requirements")
            {
                Console.WriteLine("CPU: ");
                var cpu = Console.ReadLine();
                Console.WriteLine("GPU:");
                var gpu = Console.ReadLine();
                Console.WriteLine("ID: ");
                var id = int.Parse(Console.ReadLine());
                var item = minlogic.Read(id);
                Console.WriteLine("Old Item:");
                Console.WriteLine($"CPU: {item.CPU} GPU: {item.GPU} ID: {item.ReqId}");
                minlogic.Update(new MinRequirements(id,cpu,gpu));
                var item2 = minlogic.Read(id);
                Console.WriteLine($"CPU: {item.CPU} GPU: {item.GPU} ID: {item.ReqId}");
                Thread.Sleep(3500);
            }
        }
        static void ReleaseYearSearch()
        {
            Console.WriteLine("Give the year that you wanna search for: ");
            var year = Console.ReadLine();
            bool found = false;
            foreach(var item in gamelogic.ReleaseYearSearch(year))
            {
                Console.WriteLine($"{item.Name}| {item.Pyear}|RequirementsID: | {item.ReqId}| StudioID: |{item.StudioId} GameID: |{item.GameID}");
                found = true;
            }
            if(!found)
            {
                Console.WriteLine("No games were found");
            }
            Thread.Sleep(2500);
        }
        static void GamesWithStudios()
        {
            foreach(var item in gamelogic.GamesWithStudios())
            {
                Console.WriteLine($"{item.g.Name}  {item.s.Name}" );
            }
            Thread.Sleep(2500);
        }
        static void GamesWithThisCPU()
        {
            Console.WriteLine("Give the required cpu's full name: ");
            var cpu = Console.ReadLine();
            gamelogic.GamesWithThisCPU(cpu);
            bool found = false;
            foreach(var item in gamelogic.GamesWithThisCPU(cpu))
            {
                Console.WriteLine(item.Name);
                found = true;
            }
            if (!found)
            {
                Console.WriteLine("No games were found  with this cpu requirements");
            }
            Thread.Sleep(2500);
        }
        static void GamesWithStudiosAndRequirements()
        {
            foreach(var item in gamelogic.GamesWithStudiosAndRequirements())
            {
                Console.WriteLine("*************************************************************************************************");
                Console.WriteLine($"Name: {item.g.Name} Year: {item.g.Pyear} GameID: {item.g.GameID} RequirementsID: {item.g.ReqId} StudioID: {item.g.StudioId}\n  MinCPU: {item.r.CPU} MinGPU: {item.r.GPU}\n Studio's CEO's name: {item.s.CEOName} Studio's name:  {item.s.CEOName}");
                Console.WriteLine("*************************************************************************************************");
            }
            Thread.Sleep(4500);
        }
        static void GamesWithRequirements()
        {
            foreach (var item in gamelogic.GamesWithRequirements())
            {
                Console.WriteLine("*************************************************************************************************");
                Console.WriteLine($"Name: {item.g.Name}   MinCPU: {item.r.CPU} MinGPU: {item.r.GPU}");
                Console.WriteLine("*************************************************************************************************");
            }
            Thread.Sleep(3500);
        }
        #endregion
    }

}
