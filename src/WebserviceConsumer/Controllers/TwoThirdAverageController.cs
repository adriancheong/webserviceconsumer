using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebserviceConsumer.Model;

namespace Game1.Controllers
{
    [Route("[controller]")]
    public class TwoThirdAverageController : Controller
    {
        [HttpGet("Count")]
        public int Count()
        {
            return TwoThirdAverageGame.GetNumberOfSubmissions();
        }

        [HttpGet("Result")]
        public double Result()
        {
            return Math.Round(TwoThirdAverageGame.GetTwoThirdOfAverage(), 8);
        }

        [HttpGet("Winner")]
        public string Winner()
        {
            return TwoThirdAverageGame.GetWinner();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Submission value)
        {
            if (value != null)
                TwoThirdAverageGame.Submit(value.Name, value.Number);
        }

        [HttpPost("Reset")]
        public void Reset()
        {
            TwoThirdAverageGame.Reset();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
