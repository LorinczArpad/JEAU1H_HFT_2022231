using JEAU1H_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Repository
{
    public class StudioRepository : Repository<Studio>, IRepository<Studio>
    {
        public StudioRepository(VideoGamesDbContext ctx) : base(ctx)
        {

        }
        public override Studio Read(int id)
        {
            return ctx.Studios.FirstOrDefault(t => t.StudioID == id);
        }

        public override void Update(Studio item)
        {
            var old = Read(item.StudioID);
            old.CEOName = item.CEOName;
            old.Name = item.Name;
            old.StudioID = item.StudioID;
            
            
            ctx.SaveChanges();
        }
    }
}
