using JEAU1H_HFT_2021222.Models;
using System.Collections.Generic;

namespace JEAU1H_HFT_2021222.Logic
{
    interface IMinRequirementsLogic
    {
        void Create(MinRequirements item);
        void Delete(int id);
        MinRequirements Read(int id);
        IEnumerable<MinRequirements> ReadAll();
        void Update(MinRequirements item);
    }
}