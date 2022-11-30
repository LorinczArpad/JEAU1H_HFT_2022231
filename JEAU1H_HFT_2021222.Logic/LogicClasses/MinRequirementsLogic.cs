using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Logic
{
    public class MinRequirementsLogic : IMinRequirementsLogic
    {
        IRepository<MinRequirements> repo;

        public MinRequirementsLogic(IRepository<MinRequirements> repo)
        {
            this.repo = repo;
        }

        public void Create(MinRequirements item)
        {
            if(item.CPU.Length < 240 && item.GPU.Length < 240) {
                this.repo.Create(item);
             }
            else
            {
                throw new ArgumentException("CPU and GPU names can't be longer than 240 character");
            }
        }

        public void Delete(int id)
        {
            if (repo.Read(id) != null)
            {
                this.repo.Delete(id);
            }
            else
            {
                throw new ArgumentException("Not found");
            }
        }

        public MinRequirements Read(int id)
        {
            if (repo.ReadAll().Last().ReqId >= id)
            {
                return this.repo.Read(id);
            }
            else
            {
                throw new ArgumentException("Item not found");
            }
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
