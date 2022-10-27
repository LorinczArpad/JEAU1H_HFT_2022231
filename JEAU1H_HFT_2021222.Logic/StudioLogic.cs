using JEAU1H_HFT_2021222.Models;
using JEAU1H_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Logic
{
    public class StudioLogic : IStudioLogic
    {
        IRepository<Studio> repo;

        public StudioLogic(IRepository<Studio> repo)
        {
            this.repo = repo;
        }

        public void Create(Studio item)
        {
            if (item.Name != null && item.CEOName != null)
            {
                this.repo.Create(item);
            }
            else
            {
                throw new ArgumentException("Cant add studio without a name or ceo name");
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
