using JEAU1H_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace JEAU1H_HFT_2021222.Logic
{
    public interface IGameLogic
    {
        void Create(Game item);
        void Delete(int id);
        IEnumerable<IGrouping<MinRequirements, Game>> GamesWithRequirements();
        IEnumerable<IGrouping<string, Game>> GamesWithStudios();
        Game Read(int id);
        IEnumerable<Game> ReadAll();
        List<Game> ReleaseYearSearch(string year);
        void Update(Game item);
    }
}