using JEAU1H_HFT_2021222.Models;
using System.Collections.Generic;

namespace JEAU1H_HFT_2021222.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        List<GameLogic.GamewithMinreq> GamesWithRequirements();
        List<GameLogic.GamewithStudi> GamesWithStudios();
        List<GameLogic.GamewithStudioandMinreq> GamesWithStudiosAndRequirements();
        IEnumerable<Game> GamesWithThiStudio(string name);
        Game Read(int id);
        IEnumerable<Game> ReadAll();
        List<Game> ReleaseYearSearch(string year);
        void Update(Game item);
    }
}