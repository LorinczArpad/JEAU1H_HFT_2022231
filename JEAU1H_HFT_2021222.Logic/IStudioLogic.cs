using JEAU1H_HFT_2021222.Models;
using System.Collections.Generic;

namespace JEAU1H_HFT_2021222.Logic
{
    interface IStudioLogic
    {
        void Create(Studio item);
        void Delete(int id);
        Studio Read(int id);
        IEnumerable<Studio> ReadAll();
        void Update(Studio item);
    }
}