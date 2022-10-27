using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Logic
{
    class MinRequirementsLogic
    {
        IRepository<MinRequirements> repo;

        public MinRequirementsLogic(IRepository<MinRequirements> repo)
        {
            this.repo = repo;
        }

        public void Create(MinRequirements item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public MinRequirements Read(int id)
        {
            return this.repo.Read(id);
        }

        public IEnumerable<MinRequirements> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(MinRequirements item)
        {
            this.repo.Update(item);
        }
    }
}
