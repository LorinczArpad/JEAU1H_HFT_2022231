﻿using JEAU1H_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEAU1H_HFT_2021222.Repository
{
    class StudioRepository : Repository<Studio>, IRepository<Studio>
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
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
