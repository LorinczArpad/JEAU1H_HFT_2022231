using JEAU1H_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Repository
{
    public class MinRequirementsRepository : Repository<MinRequirements>, IRepository<MinRequirements>
    {
        public MinRequirementsRepository(VideoGamesDbContext ctx) : base(ctx)
        {

        }
        public override MinRequirements Read(int id)
        {
            return ctx.Requirements.FirstOrDefault(t => t.ReqId == id);
        }

        public override void Update(MinRequirements item)
        {
            var old = Read(item.ReqId);
            old.CPU = item.CPU;
            old.GPU = item.GPU;
            old.ReqId = item.ReqId;
          

           
            ctx.SaveChanges();
        }
    }
    
    
}
