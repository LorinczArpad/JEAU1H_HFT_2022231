using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Logic
{
    class StudioLogic
    {
        IRepository<Studio> repo;

        public StudioLogic(IRepository<Studio> repo)
        {
            this.repo = repo;
        }

        public void Create(Studio item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Studio Read(int id)
        {
            return this.repo.Read(id);
        }

        public IEnumerable<Studio> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Studio item)
        {
            this.repo.Update(item);
        }
    }
}
