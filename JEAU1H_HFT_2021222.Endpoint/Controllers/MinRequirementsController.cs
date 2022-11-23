using JEAU1H_HFT_2021222.Logic;
using JEAU1H_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JEAU1H_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MinRequirementsController : ControllerBase
    {
        IMinRequirementsLogic minlogic;

        public MinRequirementsController(IMinRequirementsLogic minlogic)
        {
            this.minlogic = minlogic;
        }

        [HttpGet]
        public IEnumerable<MinRequirements> ReadAll()
        {
            return this.minlogic.ReadAll();
        }


        [HttpGet("{id}")]
        public MinRequirements Read(int id)
        {
            return this.minlogic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] MinRequirements minreq)
        {
            this.minlogic.Create(minreq);
        }


        [HttpPut]
        public void Put([FromBody] MinRequirements minreq)
        {
            this.minlogic.Update(minreq);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.minlogic.Delete(id);
        }
    }
}
