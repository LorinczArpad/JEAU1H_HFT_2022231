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
    public class StudioController : ControllerBase
    {
        IStudioLogic Studiologic;

        public StudioController(IStudioLogic studiologic)
        {
            Studiologic = studiologic;
        }

        [HttpGet]
        public IEnumerable<Studio> ReadAll()
        {
            return this.Studiologic.ReadAll();
        }


        [HttpGet("{id}")]
        public Studio Read(int id)
        {
            return this.Studiologic.Read(id);
        }


        [HttpPost]
        public void Create([FromBody] Studio studio)
        {
            this.Studiologic.Create(studio);
        }


        [HttpPut]
        public void Put([FromBody] Studio studio)
        {
            this.Studiologic.Update(studio);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Studiologic.Delete(id);
        }
    }
}
