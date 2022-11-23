
using JEAU1H_HFT_2021222.Models;
using System.Collections.Generic;
using static JEAU1H_HFT_2021222.Logic.GameLogic;

namespace JEAU1H_HFT_2021222.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        IEnumerable<string> GamesWithRequirements();
        IEnumerable<string> GamesWithStudios();
        IEnumerable<string> GamesWithStudiosAndRequirements();
        IEnumerable<Game> GamesWithThisCPU(string cpu);
        IEnumerable<Game> GamesWithThisStudio(string name);
        Game Read(int id);
        IEnumerable<Game> ReadAll();
        IEnumerable<Game> ReleaseYearSearch(string year);
        void Update(Game item);
    }
}